/////////////////////////////////////////////////////////////////////////////////////
//  File: WebSocketEstablishedLogEvent.cs                           6 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a WebSocket connection is established. Must be logged by the server (notifier). May
/// be logged by the client (subscriber). See Section 2.9.10 of NENA-STA-024.1a-2023.
/// </summary>
public class WebSocketEstablishedLogEvent : LogEvent
{
    /// <summary>
    /// If logged by the server then set to the ID of the client. If logged by the client then set to the
    /// ID of the server. Required.
    /// </summary>
    public string peerId { get; set; }

    /// <summary>
    /// Set to either "outgoing" or "incoming". Required.
    /// </summary>
    public string direction { get; set; }

    /// <summary>
    /// Status code returned for the Web Socket connection request. Requred.
    /// </summary>
    public string status { get; set; }

    /// <summary>
    /// Text description of the status code. Required.
    /// </summary>
    public string statusDescription { get; set; }

    /// <summary>
    /// Locally generated unique ID that will be used to relate the connection establishment with the
    /// connection termination.
    /// It is suggested to be of the form “urn:nena:uid:logEvent:”, followed by a locally unique ID, followed
    /// by a colon, followed by the domain of the entity performing the logging, for example:
    /// “urn:nena:uid:logEvent:a99dasdas37:psap.example.com”.
    /// Required.
    /// </summary>
    public string webSocketId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public WebSocketEstablishedLogEvent()
    {
        logEventType = "WebSocketEstablishedLogEvent";
    }
}
