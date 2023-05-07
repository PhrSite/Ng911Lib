/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocationQueryLogEvent.cs                                13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Class for the LocationQueryLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a HTTP Enabled Location Data (HELD, RFC 5985) request is sent or received.
    /// </summary>
    public class LocationQueryLogEvent : LogEvent
    {
        /// <summary>
        /// The URI that the request was sent to. Required.
        /// </summary>
        public string uri { get; set; }

        /// <summary>
        /// Contains the body of the HELD request. Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Contains a unique ID that links the request to a response. Required.
        /// </summary>
        public string queryId { get; set; }

        /// <summary>
        /// Set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocationQueryLogEvent()
        {
            logEventType = "LocationQueryLogEvent";
        }
    }
}
