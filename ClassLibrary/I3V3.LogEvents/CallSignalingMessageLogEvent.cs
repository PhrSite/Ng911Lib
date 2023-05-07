/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallSignalingMessageLogEvent.cs                         13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Class for the CallSignalingMessage. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged whenever a SIP message is sent or received.
    /// </summary>
    public class CallSignalingMessageLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the entire SIP request or response message. Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Specifies the direction of the call. Must be "incoming" or "outgoing".
        /// Required.
        /// </summary>
        public string direction { get; set; } = "incoming";

        /// <summary>
        /// Specifies the protocol. Always use "sip".
        /// </summary>
        public string protocol { get; set; } = "sip";

        /// <summary>
        /// Default constructor for de-serialization
        /// </summary>
        public CallSignalingMessageLogEvent()
        {
            logEventType = "CallSignalingMessageLogEvent";
        }
    }
}
