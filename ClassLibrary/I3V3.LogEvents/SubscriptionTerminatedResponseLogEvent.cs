/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubscriptionTerminatedResponseLogEvent.cs               6 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a response is sent or received to a terminate subscription message. Must be logged
/// by the server (notifier), may be logged by the client (subscriber). See Section 2.9.9 of 
/// NENA-STA-024.`a-2023.
/// </summary>
public class SubscriptionTerminatedResponseLogEvent : LogEvent
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
    /// Unique ID used for matching a response to the query. See Section 2.9 of NENA-STA-024.1a-2023.
    /// Required.
    /// </summary>
    public string queryId { get; set; }

    /// <summary>
    /// Subscription ID of the subscription that was terminate. Required.
    /// </summary>
    public string subscriptionId { get; set; }

    /// <summary>
    /// Status code that indicates the reason the subscription was terminated.
    /// Required.
    /// </summary>
    public string statusCode { get; set; }

    /// <summary>
    /// Text that describes the status code that was sent with the subscription termination message.
    /// Required.
    /// </summary>
    public string statusText { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public SubscriptionTerminatedResponseLogEvent()
    {
        logEventType = "SubscriptionTerminatedResponseLogEvent";
    }
}
