/////////////////////////////////////////////////////////////////////////////////////
//  File:   ServiceStateChangeLogEvent.cs                           14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the ServiceStateChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a SIP NOTIFY request is sent or received that indicates a change in service state.
    /// </summary>
    public class ServiceStateChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the new service state. Required.
        /// </summary>
        public string newState { get; set; }

        /// <summary>
        /// Set to the new security posture if security posture changed.
        /// </summary>
        public string newSecurityPosture { get; set; }

        /// <summary>
        /// Set to the service ID (FQDN) of the service whose state changed. Required.
        /// </summary>
        public string affectedServiceIdentifier { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceStateChangeLogEvent()
        {
            logEventType = "ServiceStateChangeLogEvent";
        }
    }
}
