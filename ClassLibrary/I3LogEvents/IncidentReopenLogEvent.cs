/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentReopenLogEvent.cs                               14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the IncidentReopenLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when an agency needs to log events for an incident for which it has logged the
    /// IncidentClearLogEvent.
    /// </summary>
    public class IncidentReopenLogEvent : LogEvent
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public IncidentReopenLogEvent()
        {
            logEventType = "IncidentReopenLogEvent";
        }
    }
}
