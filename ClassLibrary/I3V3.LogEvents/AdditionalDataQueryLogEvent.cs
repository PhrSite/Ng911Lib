/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdditionalDataQueryLogEvent.cs                          13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the AdditionalDataQueryLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when a request for Additional Data is sent or received.
    /// </summary>
    public class AdditionalDataQueryLogEvent : LogEvent
    {
        /// <summary>
        /// The URI of the request. Required
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// Contains the body of the request. Required.
        /// Note: RFC 7852 specifies the protocol for requesting Additional Data.
        /// The requestor sends an HTTP GET, there is no body for a GET request.
        /// </summary>
        public string text { get; set; } = "";

        /// <summary>
        /// Set to “outgoing” or “incoming”. Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Locally generated tag that is used to relate the request to the response.
        /// Required.
        /// </summary>
        public string queryId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdditionalDataQueryLogEvent()
        {
            logEventType = "AdditionalDataQueryLogEvent";
        }
    }
}
