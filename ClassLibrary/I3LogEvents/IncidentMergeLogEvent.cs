/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentMergeLogEvent.cs                                13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the IncidentMergeLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when an incident is merged with another incident.
    /// </summary>
    public class IncidentMergeLogEvent : LogEvent
    {
        /// <summary>
        /// Emergy Incident ID of the incident that was merged with the incident identified in the
        /// incidentId property of the LogEvent base class.
        /// </summary>
        public string mergeIncidentId { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        IncidentMergeLogEvent()
        {
            logEventType = "IncidentMergeLogEvent";
        }
    }
}
