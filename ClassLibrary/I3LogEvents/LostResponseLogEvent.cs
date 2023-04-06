/////////////////////////////////////////////////////////////////////////////////////
//  File:   LostResponseLogEvent.cs                                 14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the LostResponseLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a LoST (RFC 5222) response is sent or received.
    /// </summary>
    public class LostResponseLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the entire LoST response XML document
        /// </summary>
        public string responseAdapter { get; set; }

        /// <summary>
        /// Must be set to "incoming" or "outgoing"
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Links this response to a LosT query.
        /// </summary>
        public string responseId { get; set; }

        /// <summary>
        /// Set to the malformed XML LoST response if the element is logging a malformed response it has 
        /// received.
        /// </summary>
        public string malformedResponse { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LostResponseLogEvent()
        {
            logEventType = "LostResponseLogEvent";
        }
    }
}
