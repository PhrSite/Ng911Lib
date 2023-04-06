/////////////////////////////////////////////////////////////////////////////////////
//  File:   MalformedMessageLogEvent.cs                             13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the MalformedMessageLogEvent log event. See Sections 4.12.3.7 and E.8.1 of 
    /// NENA-STA-010.3.
    /// Logged when a malformed SIP message is received. 
    /// </summary>
    public class MalformedMessageLogEvent : LogEvent
    {
        /// <summary>
        /// String contents of the malformed SIP message that it received.
        /// Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// IP address from which the the malformed message was received from.
        /// Required.
        /// </summary>
        public string ipAddress { get; set; }

        /// <summary>
        /// Explains the reason that the message is malformed. Optional.
        /// </summary>
        public string explanationText { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MalformedMessageLogEvent()
        {
            logEventType = "MalformedMessageLogEvent";
        }
    }
}
