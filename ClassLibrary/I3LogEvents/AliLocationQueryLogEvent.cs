/////////////////////////////////////////////////////////////////////////////////////
//  File:   AliLocationQueryLogEvent.cs                             14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using AdditionalData;

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the AliLocationQueryLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by a LSRG when a legacy ALI location request is sent.
    /// </summary>
    public class AliLocationQueryLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the text of the ALI location request.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing"
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// The “queryId” member is used to relate the request to the response.The queryId is generated 
        /// locally, MUST be globally unique, and it is suggested that it be of the form: 
        /// “urn:emergency:uid:queryid:’globally unique id’”.
        /// </summary>
        public string queryId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AliLocationQueryLogEvent()
        {
            logEventType = "AliLocationQueryLogEvent";
        }
    }
}
