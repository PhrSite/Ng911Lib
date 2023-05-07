/////////////////////////////////////////////////////////////////////////////////////
//  File:   RouteRuleMsgLogEvent.cs                                 14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the RouteRuleMsgLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by a LogMessageAction (see Section 3.3.3.2.4 of NENA-STA-010.3) of a policy routing rule.
    /// </summary>
    public class RouteRuleMsgLogEvent : LogEvent
    {
        /// <summary>
        /// Specifies the routing rule ID. Required.
        /// </summary>
        public string ruleId { get; set; }

        /// <summary>
        /// Specifies the priority of the routing rule. Required.
        /// </summary>
        public string priority { get; set; }

        /// <summary>
        /// Contains the action's message field. Required.
        /// </summary>
        public string  message { get; set; }

        /// <summary>
        /// Identifies the owner of the policy. Required.
        /// </summary>
        public string policyOwner { get; set; }

        /// <summary>
        /// Identifies the policy type. Required.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// Identifies the queue that the policy pertains to.
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// Contains the policy ID.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RouteRuleMsgLogEvent()
        {
            logEventType = "RouteRuleMsgLogEvent";
        }
    }
}
