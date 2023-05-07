/////////////////////////////////////////////////////////////////////////////////////
//  File:   AliLocationResponseLogEvent.cs                          14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the AliLocationResponseLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a LSRG receives a response to an ALI request
    /// </summary>
    public class AliLocationResponseLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the full ALI response message. The STX and ETX characters must not be included.
        /// Required.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Must be set to "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Used to link the response to an ALI query request. Required.
        /// </summary>
        public string responseId { get; set; }

        /// <summary>
        /// Malformed, invalid, or responses not received from the server are logged in the “responseStatus” 
        /// member that contains a status code from the Status Codes Registry defined in Section 10.29
        /// of NENA-STA-010.3.
        /// </summary>
        public string responseStatus { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AliLocationResponseLogEvent()
        {
            logEventType = "AliLocationResponseLogEvent";
        }
    }
}
