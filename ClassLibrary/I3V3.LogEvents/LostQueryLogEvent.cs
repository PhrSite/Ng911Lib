/////////////////////////////////////////////////////////////////////////////////////
//  File:   LostQueryLogEvent.cs                                    14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the LostQueryLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a LoST query (See RFC 5222) is sent or received.
    /// </summary>
    public class LostQueryLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the entire LoST query XML document. Required.
        /// </summary>
        public string queryAdapter { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Identifier that links the request to a LoST response. MUST be globally unique, and it is 
        /// suggested that it be of the form: “urn:emergency:uid:queryid". Required.
        /// </summary>
        public string queryId { get; set; }

        /// <summary>
        /// Set to the malformed XML LoST query if the element is logging a malformed query it has received.
        /// </summary>
        public string malformedQuery { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LostQueryLogEvent()
        {
            logEventType = "LostQueryLogEvent";
        }
    }
}
