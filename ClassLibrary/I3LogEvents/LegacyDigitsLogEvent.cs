/////////////////////////////////////////////////////////////////////////////////////
//  File:   LegacyDigitsLogEvent.cs                                 14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the LegacyDigitsLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by an LPG when DTMF or MF digits are sent or received.
    /// </summary>
    public class LegacyDigitsLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the digits that were sent or received.
        /// For DTMF digits this must contain only: "0" - "9", "#" and "*".
        /// For MF digits this must contain only: "0" - "9", "#", "*", "KP", "ST" or "STP".
        /// Required.
        /// </summary>
        public string digits { get; set; }

        /// <summary>
        /// Must be set to either "sent" or "received".
        /// Required.
        /// </summary>
        public string sentReceived { get; set; }

        /// <summary>
        /// Must be set to either "DTMF" or "MF". Required.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LegacyDigitsLogEvent()
        {
            logEventType = "LegacyDigitsLogEvent";
        }
    }
}
