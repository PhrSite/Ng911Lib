/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentSplitLogEvent.cs                                14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the IncidentSplitLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when an agency creates a new Incident by cloning the data from an existing incident.
    /// </summary>
    public class IncidentSplitLogEvent : LogEvent
    {
        /// <summary>
        /// Set to the new or old incidentId.
        /// Special Note: NENA-STA-010.3b-2021 and the loggingservice.yaml file specified that this field
        /// is incidentId. This is incorrect because it conflicts with the incidentId property defined
        /// in the LogEvent base class.
        /// </summary>
        public string newOrOldIncidentId { get; set; }

        /// <summary>
        /// Must be set to either "new" or "old.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public IncidentSplitLogEvent()
        {
            logEventType = "IncidentSplitLogEvent";
        }
    }
}
