/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentClearLogEvent.cs                                14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the IncidentClearLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when an finishes its handling of an incident.
    /// </summary>
    public class IncidentClearLogEvent : LogEvent
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public IncidentClearLogEvent()
        {
            logEventType = "IncidentClearLogEvent";
        }
    }
}
