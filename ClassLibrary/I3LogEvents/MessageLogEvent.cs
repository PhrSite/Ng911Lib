/////////////////////////////////////////////////////////////////////////////////////
//  File:   MessageLogEvent.cs                                      13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the MessageLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a SIP MESSAGE request is sent or received.
    /// </summary>
    public class MessageLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the text of the SIP MESSAGE method. Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Must be either incoming or outgoing.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        MessageLogEvent()
        {
            logEventType = "MessageLogEvent";
        }
    }
}
