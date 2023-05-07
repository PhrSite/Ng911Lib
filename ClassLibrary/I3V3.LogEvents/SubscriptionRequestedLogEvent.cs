/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubscriptionRequestedLogEvent.cs                        5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged by the notifier (server) when a EIDO subscription is requested. May be logged by the subscriber
/// (client). See Section 2.9.6 of NENA-STA-024.1a-2023.
/// </summary>
public class SubscriptionRequestedLogEvent : LogEvent
{
    /// <summary>
    /// If logged by the server then set to the ID of the client. If logged by the client then set to the
    /// ID of the server. Required.
    /// </summary>
    public string peerId { get; set; }

    /// <summary>
    /// Must be set to either "incoming" or "outgoing". Required.
    /// </summary>
    public string direction { get; set; }

    /// <summary>
    /// Unique ID used for matching a response to the query. See Section 2.9 of NENA-STA-024.1a-2023.
    /// Required.
    /// </summary>
    public string queryId { get; set; }

    /// <summary>
    /// Set to the expires property in the subscription request.
    /// </summary>
    public int expires { get; set; }

    /// <summary>
    /// Set to the subscriptionId in the subscription request.
    /// </summary>
    public string subscriptionId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public SubscriptionRequestedLogEvent()
    {
        logEventType = "SubscriptionRequestedLogEvent";
    }
}
