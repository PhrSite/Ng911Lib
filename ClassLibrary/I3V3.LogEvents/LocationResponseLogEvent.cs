/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocationResponseLogEvent.cs                             13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the LocationResponseLogEvent. See Sections 4.12.3.7 and E.8.1 of 
    /// NENA-STA-010.3.
    /// Logged when a HELD response is sent or received.
    /// </summary>
    public class LocationResponseLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the body of the HELD response. Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Set to 200 if there are no errors in the response or one of the error codes defined in Section 
        /// 10.30 of NENA-STA-010.3.
        /// </summary>
        public string responseStatus { get; set; }

        /// <summary>
        /// Contains a unique ID that links the response to the original request. Required.
        /// </summary>
        public string responseId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocationResponseLogEvent()
        {
            logEventType = "LocationResponseLogEvent";
        }
    }
}
