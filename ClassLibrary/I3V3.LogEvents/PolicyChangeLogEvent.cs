/////////////////////////////////////////////////////////////////////////////////////
//  File:   PolicyChangeLogEvent.cs                                 14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the PolicyChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a routing policy is changed.
    /// </summary>
    public class PolicyChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Specifies the type of the policy. Required.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// Identifies the owner of the policy. Required.
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// Specifies the type of the change. Must be one of "CREATE", "UPDATE" or "DELETE".
        /// Required.
        /// </summary>
        public string changeType { get; set; }

        /// <summary>
        /// Contains the policy content as a JSON string. Required.
        /// </summary>
        public string policyContent { get; set; }

        /// <summary>
        /// Identifies the policy store the the policy is stored in. Required.
        /// </summary>
        public string policyStoreId { get; set; }

        /// <summary>
        /// Identifies the application that made the change. Required.
        /// </summary>
        public string policyEditor { get; set; }

        /// <summary>
        /// Identifies the queue that the policy applies to.
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// ID of the policy.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PolicyChangeLogEvent()
        {
            logEventType = "PolicyChangeLogEvent";
        }
    }
}
