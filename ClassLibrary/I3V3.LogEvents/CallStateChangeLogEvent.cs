/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallStateChangeLogEvent.cs                              14 Jan 14 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the CallStateChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when an element detects a change in call state.
    /// </summary>
    public class CallStateChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the new state. Must be set to one of the call states defined in the Call States
        /// Registry in Section 10.24 of NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing".
        /// Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Set to the Call-ID of another leg of the call in cases where a call is added to or removed
        /// from a conference, etc.
        /// Conditional.
        /// </summary>
        public string legCallId { get; set; }

        /// <summary>
        /// If the target involved in the state change is not the call identified in the header field, 
        /// the identifier of the target whose state changed must be included in a “targetId” member.
        /// If the target is a SIP device, this must be the SIP URI of the target.
        /// </summary>
        public string targetId { get; set; }

        /// <summary>
        /// Optional text description of the reason for the state change.
        /// </summary>
        public string changeReason { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CallStateChangeLogEvent()
        {
            logEventType = "CallStateChangeLogEvent";
        }
    }
}
