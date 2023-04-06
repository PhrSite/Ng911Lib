/////////////////////////////////////////////////////////////////////////////////////
//  File:   RecCallStartLogEvent.cs                                 15 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the RecCallStartLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a SIPREC media recorder detects the start of a SIPREC call.
    /// </summary>
    public class RecCallStartLogEvent : LogEvent
    {
        /// <summary>
        /// Must be set to either "incoming" or "outgoing". "incoming" means that the call was received
        /// by the ESInet. "outgoing" means that the call was made by a PSAP.
        /// Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Type of the call. Must be one of the values specified in the LogEvent
        /// Call Types Registry. See Section 10.23 of NENA-STA-010.3.
        /// </summary>
        public string standardPrimaryCallType { get; set; }

        /// <summary>
        /// Not required. Must be one of the values defined in Section 10.23 of NENA-STA-010.3 if
        /// specified.
        /// </summary>
        public string standardSecondaryCallType { get; set; }

        /// <summary>
        /// Contains an application specific local call type.
        /// Optional.
        /// </summary>
        public string localCallType { get; set; }

        /// <summary>
        /// Contains application specific local use information.
        /// Optional.
        /// </summary>
        public string localUse { get; set; }

        /// <summary>
        /// Used for with non-SIP interfaces, identifies the destination of the call.
        /// Not requred for SIP interfaces.
        /// </summary>
        public string to { get; set; }

        /// <summary>
        /// Used for with non-SIP interfaces, identifies the source of the call.
        /// Not requred for SIP interfaces.
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecCallStartLogEvent()
        {
            logEventType = "RecCallStartLogEvent";
        }
    }
}
