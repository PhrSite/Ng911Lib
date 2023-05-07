/////////////////////////////////////////////////////////////////////////////////////
//  File:   KeepAliveFailureLogEvent.cs                             14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the KeepAliveFailureLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when an element sent a SIP OPTIONS request and did not receive a SIP OK response or
    /// received a malformed or invalid response.
    /// </summary>
    public class KeepAliveFailureLogEvent : LogEvent
    {
        /// <summary>
        /// Must be set to one of the values in the Status Codes Registry specified in Section 10.29 of
        /// NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string responseStatus { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeepAliveFailureLogEvent()
        {
            logEventType = "KeepAliveFailureLogEvent";
        }
    }
}
