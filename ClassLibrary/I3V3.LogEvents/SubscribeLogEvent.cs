/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubscribeLogEvent.cs                                    15 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.IO;

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the SubscribeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a SIP SUBSCRIBE request is processed for one of the event packages specified
    /// in Section 10.35. The server must log this event. The client may log this event.
    /// </summary>
    public class SubscribeLogEvent : LogEvent
    {
        /// <summary>
        /// Must be one of the values from the Event Package Registry in Section 10.34. The allowed
        /// values are: ElementState, ServiceState, QueueState, ESRPNotify, AbandonedCall and GapOverlap.
        /// Required.
        /// </summary>
        public string package { get; set; }

        /// <summary>
        /// Contains the URI or FQDN of the other party. Required
        /// </summary>
        public string peer { get; set; }

        /// <summary>
        /// Contains an array of any parameters from the SUBSCRIBE request. Required.
        /// </summary>
        public List<SubParamsType> parameter = new List<SubParamsType>();

        /// <summary>
        /// Set to the final expiration time negotiated. Required
        /// </summary>
        public int expiration { get; set; }

        /// <summary>
        /// Contains the response code sent to the SUBSCRIBE request. Required.
        /// </summary>
        public string response { get; set; }

        /// <summary>
        /// Set to "purpose" flag is set to "initial" for a new subscription, "refresh" for a refresh of an 
        /// existing subscription, and "terminate" for a terminated subscription.
        /// Required.
        /// </summary>
        public string purpose { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Used to correlate the transactions for the subscription. Generated locally and MUST be globally 
        /// unique, and it is suggested that it be of the form: “urn:emergency:uid:subid:’globally unique id’”.
        /// Required.
        /// </summary>
        public string subscriptionId { get; set; }

        /// <summary>
        /// Default subscription
        /// </summary>
        public SubscribeLogEvent()
        {
            logEventType = "SubscribeLogEvent";
        }
    }

    /// <summary>
    /// Class for sending the subscription parameters for the SubscribeLogEvent.
    /// </summary>
    public class SubParamsType
    {
        /// <summary>
        /// Set to the parameter type
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Set to the parameter value
        /// </summary>
        public string value { get; set; }

    }
}
