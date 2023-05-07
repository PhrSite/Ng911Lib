/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubscriptionTerminatedLogEvent.cs                       5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a subscription is terminated because the incident has closed or the subscription expires or 
/// the subscriber asks for the subscription to be terminated via unsubscribe. Must be logged by the server
/// (notifier), may be logged by the client (subscriber). See Section 2.9.8 of NENA-STA-024.1a-2023.
/// </summary>
public class SubscriptionTerminatedLogEvent : LogEvent
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
    /// Should be set to one of: “incident closed”, “expired”, “unsubscribed”, and “internal error”. 
    /// Other reasons MAY use non-standard values. Required.
    /// </summary>
    public string reason { get; set; }

    /// <summary>
    /// Set to the subscription ID of the subscription that was terminated. Required.
    /// </summary>
    public string subscriptionId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public SubscriptionTerminatedLogEvent()
    {
        logEventType = "SubscriptionTerminatedLogEvent";
    }
}
