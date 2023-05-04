/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventClient.cs                                     1 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using Ng911Lib.Utilities;

using HttpUtils;
using System.Net;

namespace I3LogEvents;

/// <summary>
/// Implements an I3 V3 Log Event Client. This class allows an application to send log events to a log event
/// server.
/// </summary>
public class I3LogEventClient
{

    /// <summary>
    /// Constructs a new I3LogEventClient object. After creating a new object, hook the events and then
    /// call the Start() method before sending log events.
    /// </summary>
    /// <param name="strServerUrl">HTTP or HTTPS URL of the log event server.</param>
    /// <param name="strLoggerName">Name of the logging server. For example: Logger1</param>
    /// <param name="clientCertificate">X.509 certificate to use if mutual authentication is used. May be null
    /// if mutual authentication is not required.</param>
    public I3LogEventClient(string strServerUrl, string strLoggerName, X509Certificate2 clientCertificate)
    {
        m_serverUrl = strServerUrl;
        m_clientCertificate = clientCertificate;
        m_strLoggerName = strLoggerName;
        m_VersionsPath = m_serverUrl + "/Versions";
    }

    /// <summary>
    /// Starts the log event client. The client is ready to send log events after this method is called.
    /// </summary>
    public void Start()
    {
        if (m_Started == true)
            return;

        m_Started = true;
        m_Ahr = new AsyncHttpRequestor(m_clientCertificate, 1000, "application/json");
        m_LastPollTime = DateTime.Now - TimeSpan.FromMilliseconds(PollIntervalMs);
        m_Started = true;
        m_Thread = new Thread(Threadloop);
        m_Thread.IsBackground = true;
        m_Thread.Name = m_strLoggerName;
        m_Thread.Start();
    }

    /// <summary>
    /// Call this method to shut down the client thread. This method should be called so that all resources
    /// are cleanly released.
    /// </summary>
    public void Shutdown()
    {
        if (m_Started == false)
            return;

        m_IsEnding = true;
        m_MySemaphore.Release();    // Signal the thread
        m_Thread.Join(500);
        m_Ahr.Dispose();
        m_Thread = null;
        m_Started = false;
    }

    /// <summary>
    /// Sends a log event to the logging server if currently connected.
    /// </summary>
    /// <param name="logEvent">I3V3 log event to send.</param>
    public void SendLogEvent(LogEvent logEvent)
    {
        if (m_Started == false || m_Responding == false)
            return;

        m_Events.Enqueue(logEvent);
        m_MySemaphore.Release();    // Signal the thread to wake up
    }

    private void Threadloop()
    {
        LogEvent logEvent = null;
        while (m_IsEnding == false)
        {
            m_MySemaphore.WaitOne(WaitTimeMs);
            PollLogger();

            // Empty the queue
            while (m_IsEnding == false && m_Events.TryDequeue(out logEvent) == true)
            {   // Send the POST request synchronously
                I3LogEventContent Lec = new I3LogEventContent(logEvent);
                string strBody = JsonHelper.SerializeToString(Lec);
                HttpResults Hr = m_Ahr.DoRequestAsync(HttpMethodEnum.POST, m_serverUrl, "application/json",
                    strBody, false).Result;

                if (Hr.Excpt != null || (Hr.StatusCode != HttpStatusCode.OK && Hr.StatusCode != 
                    HttpStatusCode.Created))
                {   // An error occurred. Fire an event if anyone is listening
                    LoggingServerError?.Invoke(Hr, m_strLoggerName, logEvent);
                }
            }
        }
    }

    private void PollLogger()
    {
        DateTime Now = DateTime.Now;
        TimeSpan ElapsedTs = Now - m_LastPollTime;
        if (ElapsedTs.TotalMilliseconds < PollIntervalMs)
            return;

        m_LastPollTime = Now;

        HttpResults Hr = m_Ahr.DoRequestAsync(HttpMethodEnum.GET, m_VersionsPath, null, null, true).Result;
        if (Hr.Excpt != null)
            m_Responding = false;
        else if (Hr.StatusCode == HttpStatusCode.OK && string.IsNullOrEmpty(Hr.Body) == false)
            m_Responding = true;
        else
            m_Responding = false;
    }

    /// <summary>
    /// Returns true if the log event server is currently responding to requests or false if it is not.
    /// </summary>
    public bool Responding
    {
        get { return m_Responding; }
    }

    /// <summary>
    /// This event is fired if an exception occurred when sending a log event to the logging server or if
    /// the the logging server responded with a a status code other than 200 or 201.
    /// </summary>
    public event I3LoggingErrorDelegate LoggingServerError;

    #region Private Member Variables
    private X509Certificate2 m_clientCertificate = null;
    private string m_serverUrl = null;
    private string m_strLoggerName;
    private Semaphore m_MySemaphore = new Semaphore(0, int.MaxValue);
    private AsyncHttpRequestor m_Ahr;
    private string m_VersionsPath;
    private ConcurrentQueue<LogEvent> m_Events = new ConcurrentQueue<LogEvent>();
    private Thread m_Thread;
    private bool m_IsEnding = false;
    private bool m_Started = false;
    private bool m_Responding = true;
    private const int WaitTimeMs = 100;
    private const int PollIntervalMs = 5000;
    private DateTime m_LastPollTime = DateTime.MinValue;
    #endregion
}

/// <summary>
/// Delegate for the LoggingServerError event of the I3LogEventClient class.
/// </summary>
/// <param name="Hr">Contains the results of a request to send a log event to the log event server.</param>
/// <param name="strLoggerName">Name of the log event server. This will match the strLoggerName parameter
/// that was passed to the constructor of the I3LogEventClent class.</param>
/// <param name="logEvent">LogEvent object that was sent to the logging server.</param>
public delegate void I3LoggingErrorDelegate(HttpResults Hr, string strLoggerName, LogEvent logEvent);