/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentLinkLogEvent.cs                                 14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the IncidentLinkLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when two different incidents are not the same real world event but are related in some way
    /// are linked together.
    /// </summary>
    public class IncidentLinkLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the Incident Tracking Identifier of the original Incident.
        /// </summary>
        public string linkedIncidentId { get; set; }

        /// <summary>
        /// Must be set to one of "parent", "child", "peer" or "unspecified"
        /// </summary>
        public string relationship { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public IncidentLinkLogEvent()
        {
            logEventType = "IncidentLinkLogEvent";
        }
    }
}
