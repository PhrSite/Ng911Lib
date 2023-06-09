﻿/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentUnLinkLogEvent.cs                               14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the IncidentUnLinkLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when a IncidentLinkLogEvent is found to have been done in error.
    /// </summary>
    public class IncidentUnLinkLogEvent : LogEvent
    {
        /// <summary>
        /// Incident tracking identifier of the incident that is being un-linked from the incident 
        /// identified by the incidentId in the base class.
        /// Special Note: Section 4.12.3.7 and E.8.1 specify that this property name is incidentId. This
        /// will not work because incidentId in this class collides with LogEvent.incidentId.
        /// </summary>
        public string unlinkedFromIncidentId { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IncidentUnLinkLogEvent()
        {
            logEventType = "IncidentUnLinkLogEvent";
        }
    }
}
