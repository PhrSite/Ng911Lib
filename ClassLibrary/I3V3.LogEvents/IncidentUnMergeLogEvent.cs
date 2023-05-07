/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentUnMergeLogEvent.cs                              14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the IncidentUnMergeLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when a an IncidentMergeLogEvent is found to be in error.
    /// </summary>
    public class IncidentUnMergeLogEvent : LogEvent
    {
        /// <summary>
        /// incidentId of the merged incident that was in error.
        /// </summary>
        public string unmergedFromIncidentId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public IncidentUnMergeLogEvent()
        {
            logEventType = "IncidentUnMergeLogEvent";
        }
    }
}
