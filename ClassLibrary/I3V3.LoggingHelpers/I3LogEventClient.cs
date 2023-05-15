/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventClient.cs                                     1 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

using HttpUtils;
using System.Net;
using I3V3.LogEvents;
using Ng911Common;
using Ng911Lib.Utilities;

namespace I3V3.LoggingHelpers;

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
    /// <param name="strServerUrl">HTTP or HTTPS URL of the log event server. For example: 
    /// https://ESInetLogger.com. The client will post log events to https://ESInetLogger.com/LogEvents
    /// and get version information from https://ESInetLogger.com/Versions</param>
    /// <param name="strLoggerName">Name of the logging server. For example: Logger1</param>
    /// <param name="clientCertificate">X.509 certificate to use if mutual authentication is used. May 
    /// be null if mutual authentication is not required.</param>
    public I3LogEventClient(string strServerUrl, string strLoggerName, X509Certificate2 clientCertificate)
    {
        m_LoggingPath = strServerUrl + "/LogEvents";
        m_clientCertificate = clientCertificate;
        m_strLoggerName = strLoggerName;
        m_VersionsPath = strServerUrl + "/Versions";
    }

    /// <summary>
    /// Starts the log event client. The client is ready to send log events after this method is called.
    /// </summary>
    public void Start()
    {
        if (m_Ahr != null)
            return;

        m_Ahr = new AsyncHttpRequestor(m_clientCertificate, 3000, "application/json");
        m_LastPollTime = DateTime.Now - TimeSpan.FromMilliseconds(PollIntervalMs);
        m_Responding = true;
        m_Thread = new Thread(Threadloop);
        m_Thread.IsBackground = true;
        m_Thread.Name = m_strLoggerName + "_Thread";
        m_Thread.Start();
    }

    /// <summary>
    /// Gets the logging schema versions that the log event server supports. This method must be
    /// called before Start() is called and the caller must wait for the response.
    /// </summary>
    /// <returns>Returns a VersionsArrayType object if successful. Returns null if the request to
    /// the server times out or if some other error occurred.
    /// </returns>
    public async Task<VersionsArrayType> GetVersionsArrayAsync()
    {
        if (m_Ahr != null)
            throw new InvalidOperationException("GetVersionsArray() cannot be called after Start() " +
                "has been called.");

        VersionsArrayType Vat = null;
        AsyncHttpRequestor Ahr = new AsyncHttpRequestor(m_clientCertificate, 3000, "application/json");
        HttpResults Hr = await Ahr.DoRequestAsync(HttpMethodEnum.GET, m_VersionsPath, null, null, true);
        if (Hr.Excpt == null && Hr.StatusCode == HttpStatusCode.OK && string.IsNullOrEmpty(Hr.Body) == 
            false)
        {   // A valid response code with a response body was received.
            Vat = JsonHelper.DeserializeFromString<VersionsArrayType>(Hr.Body);
        }

        Ahr.Dispose();
        return Vat;
    }

    /// <summary>
    /// Call this method to shut down the client thread. This method should be called so that all resources
    /// are cleanly released.
    /// </summary>
    public void Shutdown()
    {
        if (m_Ahr == null)
            return;

        m_IsEnding = true;
        m_MySemaphore.Release();    // Signal the thread
        m_Thread.Join(500);
        m_Ahr.Dispose();
        m_Ahr = null;
        m_Thread = null;
    }

    /// <summary>
    /// Sends a log event to the logging server if currently connected.
    /// </summary>
    /// <param name="logEvent">I3V3 log event to send.</param>
    public void SendLogEvent(LogEvent logEvent)
    {
        if (m_Ahr == null || m_Responding == false)
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

                HttpResults Hr = m_Ahr.DoRequestAsync(HttpMethodEnum.POST, m_LoggingPath, "application/json",
                    strBody, false).Result;

                if (Hr.Excpt != null || Hr.StatusCode != HttpStatusCode.OK && Hr.StatusCode !=
                    HttpStatusCode.Created)
                {   // An error occurred. Fire an event if anyone is listening
                    LoggingServerError?.Invoke(Hr, m_strLoggerName, strBody);
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
        bool NewStatus = m_Responding;
        if (Hr.Excpt != null)
            NewStatus = false;
        else if (Hr.StatusCode == HttpStatusCode.OK && string.IsNullOrEmpty(Hr.Body) == false)
        {   // A valid response code with a response body was received. Validate the response body
            VersionsArrayType Vat = JsonHelper.DeserializeFromString<VersionsArrayType>(Hr.Body);
            if (Vat == null)
                NewStatus = false;
            else
                NewStatus = true;
        }
        else
            NewStatus = false;

        if (NewStatus != m_Responding)
        {   // A status change occurred
            FireServerStatusChanged(NewStatus);
        }

        m_Responding = NewStatus;
    }

    private void FireServerStatusChanged(bool NewStatus)
    {
        try
        {
            LoggingServerStatusChanged?.Invoke(m_strLoggerName, NewStatus);
        }
        catch { }   // In case the receiver of this event misbehaves in its event handler
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

    /// <summary>
    /// This event is fired when the status of the logging server changed.
    /// </summary>
    public event LoggingServerStatusChangedDeletate LoggingServerStatusChanged;

    #region Private Member Variables
    private X509Certificate2 m_clientCertificate = null;
    private string m_LoggingPath = null;
    private string m_strLoggerName;
    private Semaphore m_MySemaphore = new Semaphore(0, int.MaxValue);
    private AsyncHttpRequestor m_Ahr;
    private string m_VersionsPath;
    private ConcurrentQueue<LogEvent> m_Events = new ConcurrentQueue<LogEvent>();
    private Thread m_Thread;
    private bool m_IsEnding = false;
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
/// <param name="strLogEvent">JSON string of the log event that was sent to the logging server.</param>
public delegate void I3LoggingErrorDelegate(HttpResults Hr, string strLoggerName, string strLogEvent);

/// <summary>
/// Delegate for the LoggingServerStatusChanged event of the I3LogEventClient class.
/// </summary>
/// <param name="strLoggerName">Name of the log event server. This will match the strLoggerName parameter
/// that was passed to the constructor of the I3LogEventClent class.</param>
/// <param name="Responding">True if the logging server started responding again after it stopped
/// responding. False if the logging server stopped responding after it was responding.</param>
public delegate void LoggingServerStatusChangedDeletate(string strLoggerName, bool Responding);
