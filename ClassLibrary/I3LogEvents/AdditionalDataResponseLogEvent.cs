/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdditionalDataResponseLogEvent.cs                       13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the AdditionalDataResponseLogEvent. See Sections 4.12.3.7 and E.8.1 of 
    /// NENA-STA-010.3.
    /// Logged when a response to an Additional Data Request is received or sent.
    /// </summary>
    public class AdditionalDataResponseLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the body of the response. Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Set to “outgoing” or “incoming”. Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Set to one of the status codes specified in 10.29 of NENA-STA-010.3. Required.
        /// </summary>
        public string responseStatus { get; set; }

        /// <summary>
        /// Used to match the response to the queryId of the query. Required.
        /// </summary>
        public string responseId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdditionalDataResponseLogEvent()
        {
            logEventType = "AdditionalDataResponseLogEvent";
        }
    }
}
