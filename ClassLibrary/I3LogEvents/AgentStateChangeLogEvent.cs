/////////////////////////////////////////////////////////////////////////////////////
//  File:   AgentStateChangeLogEvent.cs                             14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using AdditionalData;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the AgentStateChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when an element detects a change in agent state.
    /// </summary>
    public class AgentStateChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Must be set to either "Available" or "NotAvailable".
        /// Required.
        /// </summary>
        public string primaryAgentState { get; set; }

        /// <summary>
        /// Must be set to one of the values defined in the Agent States Registry defined in Section 10.36 of 
        /// NENA-STA-010.3.
        /// </summary>
        public string secondaryAgentState { get; set; }

        /// <summary>
        /// If the device whose state has changed is not the element identified in the header field, the 
        /// identifier of the device MUST be included in a “deviceID” member.
        /// </summary>
        public string deviceId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AgentStateChangeLogEvent()
        {
            logEventType = "AgentStateChangeLogEvent";
        }
    }
}
