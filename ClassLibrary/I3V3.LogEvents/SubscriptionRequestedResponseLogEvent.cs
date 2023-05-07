/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubscriptionRequestedResponseLogEvent.cs                5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// The subscriber MAY and the notifier MUST log a subscription requested response log event. See Section
/// 2.9.7 of NENA-STA-024.1a-2023.
/// </summary>
public class SubscriptionRequestedResponseLogEvent : LogEvent
{
    /// <summary>
    /// Unique ID used for matching a response to the query. See Section 2.9 of NENA-STA-024.1a-2023.
    /// Required.
    /// </summary>
    public string queryId { get; set; }

    /// <summary>
    /// Must be set to either "incoming" or "outgoing". Required.
    /// </summary>
    public string direction { get; set; }

    /// <summary>
    /// Subscription ID from the subscription response and request.
    /// </summary>
    public string subscriptionId { get; set; }

    /// <summary>
    /// expires field from the subscription request response.
    /// </summary>
    public int expires { get; set; }

    /// <summary>
    /// Set to the error code if the subscription request was denied.
    /// </summary>
    public string errorCode { get; set; }

    /// <summary>
    /// Set to text that describes the error if the subscription request was denied.
    /// </summary>
    public string errorText { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public SubscriptionRequestedResponseLogEvent()
    {
        logEventType = "SubscriptionRequestedResponseLogEvent";
    }
}
