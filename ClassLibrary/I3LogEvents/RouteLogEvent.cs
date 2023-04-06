/////////////////////////////////////////////////////////////////////////////////////
//  File:   RouteLogEvent.cs                                        13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the RouteLogEvent log event. See Sections 4.12.3.7 and 
    /// E.8.1 of NENA-STA-010.3. 
    /// </summary>
    public class RouteLogEvent : LogEvent
    {
        /// <summary>
        /// URI of the destination that the call was routed to. Required.
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// ID of the PRR that was selected. Required.
        /// </summary>
        public string ruleId { get; set; }

        /// <summary>
        /// Type of the policy that the PRR is part of. Required.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// Name of the policy that the PRR is part of. Required.
        /// </summary>
        public string policyName { get; set; }

        /// <summary>
        /// Cause of the routing decision. Optional.
        /// </summary>
        public string cause { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RouteLogEvent()
        {
        }
    }
}
