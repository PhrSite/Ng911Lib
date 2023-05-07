/////////////////////////////////////////////////////////////////////////////////////
//  File:   WebSocketTerminatedLogEvent.cs                          6 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Must be logged by the server (notifier) when a Web Socket connection is terminated. May be logged by
/// the client (subscriber). See Section 2.9.11 of NENA-STA-24.1a-2023.
/// </summary>
public class WebSocketTerminatedLogEvent : LogEvent
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
    /// Contains a WebSocket Close frame status code per RFC 6455. Required.
    /// </summary>
    public int closeCode { get; set; }

    /// <summary>
    /// Text that describes the closeCode. 
    /// </summary>
    public string closeText { get; set; }

    /// <summary>
    /// Must match the webSocketId property in the corresponding WebSocketEstablishedLogEvent log event.
    /// Required.
    /// </summary>
    public string webSocketId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public WebSocketTerminatedLogEvent()
    {
        logEventType = "WebSocketTerminatedLogEvent";
    }
}
