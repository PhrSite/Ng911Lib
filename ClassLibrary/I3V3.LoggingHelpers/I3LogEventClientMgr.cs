/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventClientMgr.cs                                  9 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using I3V3.LogEvents;

namespace I3V3.LoggingHelpers;

/// <summary>
/// Class for managing multiple I3 logging clients. To use this class, create an instance of it, create
/// I3LogEventClient objects and add them to the list of managed clients by calling the AddLoggingClient()
/// method, hook the events of this class if desired and then call the Start() method of this class. 
/// Note: Do not call the Start() method of the I3LogEventClient class. Call the Shutdown() method of
/// this class to gracefully shutdown a logging clients.
/// </summary>
public class I3LogEventClientMgr
{
    private bool m_Started = false;
    private List<I3LogEventClient> m_Clients = new List<I3LogEventClient>();

    /// <summary>
    /// Adds a new I3LogEventClient object to the list of manage logging clients.
    /// </summary>
    /// <param name="client">New client to add.</param>
    public void AddLoggingClient(I3LogEventClient client)
    {
        if (m_Started == true)
            throw new InvalidOperationException("Cannot call AddLoggingClient() after calling Start()");

        m_Clients.Add(client);
        client.LoggingServerError += Client_LoggingServerError;
        client.LoggingServerStatusChanged += Client_LoggingServerStatusChanged;
    }

    private object m_EventLock = new object();

    /// <summary>
    /// Event handler for the LoggingServerStatusChanged event of all of the logging clients.
    /// </summary>
    /// <param name="strLoggerName"></param>
    /// <param name="Responding"></param>
    private void Client_LoggingServerStatusChanged(string strLoggerName, bool Responding)
    {
        lock (m_EventLock)
        {
            try
            {
                LoggingServerStatusChanged?.Invoke(strLoggerName, Responding);
            }
            catch { }
        }
    }

    /// <summary>
    /// Event handler for the LoggingServerError event for all of the managed clients.
    /// </summary>
    /// <param name="Hr"></param>
    /// <param name="strLoggerName"></param>
    /// <param name="strLogEvent"></param>
    private void Client_LoggingServerError(HttpUtils.HttpResults Hr, string strLoggerName, string 
        strLogEvent)
    {
        lock (m_EventLock) 
        {
            try
            {
                LoggingServerError?.Invoke(Hr, strLoggerName, strLogEvent);
            }
            catch { }
        }
    }

    /// <summary>
    /// Starts all managed log event clients.
    /// </summary>
    public void Start()
    {
        if (m_Started == true) return;
        m_Started = true;

        foreach (I3LogEventClient client in m_Clients)
            client.Start();
    }

    /// <summary>
    /// Shuts down all of the managed log event client objects. Do not call any other methods of this
    /// class after calling ShutDown().
    /// </summary>
    public void Shutdown()
    {
        if (m_Started == false)
            return;

        m_Started = false;
        foreach (I3LogEventClient client in m_Clients)
            client.Shutdown();
    }

    private object m_LockObj = new object();

    /// <summary>
    /// Sends a log event to each of the managed clients. This method is thread-safe.
    /// </summary>
    /// <param name="logEvent">Log event to send to all log event servers.</param>
    public void SendLogEvent(LogEvent logEvent)
    {
        lock (m_LockObj)
        {
            foreach (I3LogEventClient client in m_Clients)
                client.SendLogEvent(logEvent);
        }
    }

    /// <summary>
    /// This event is fired if an exception occurred when sending a log event to the logging server or if
    /// the logging server responded with a a status code other than 200 or 201.
    /// </summary>
    public event I3LoggingErrorDelegate LoggingServerError;

    /// <summary>
    /// This event is fired when the status of the logging server changed.
    /// </summary>
    public event LoggingServerStatusChangedDeletate LoggingServerStatusChanged;

}
