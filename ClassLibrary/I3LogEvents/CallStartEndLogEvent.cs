/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallStartEndLogEvent.cs                                 13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Class for the CallStartLogEvent, RecCallStartLogEvent, CallEndLogEvent and the RecCallEndLogEvent 
    /// events.
    /// </summary>
    public class CallStartEndLogEvent : LogEvent
    {
        /// <summary>
        /// Specifies the direction of the call. Must be "incoming" or "outgoing".
        /// Required.
        /// </summary>
        public string direction { get; set; } = "incoming";

        /// <summary>
        /// Type of the call. Must be one of the values specified in the LogEvent
        /// Call Types Registry. See Section 10.23 of NENA-STA-010.3.
        /// Optional.
        /// </summary>
        public string standardPrimaryCallType { get; set; } = "emergency";

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
        /// Used for non-SIP interfaces, identifies the destination of the call.
        /// Not requred for SIP interfaces.
        /// </summary>
        public string to { get; set;  }

        /// <summary>
        /// Used for non-SIP interfaces, identifies the source of the call.
        /// Not requred for SIP interfaces.
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="eventType">Specifies the logEventType. Must be one of: CallStartLogEvent, 
        /// RecCallStartLogEvent, CallEndLogEvent or RecCallEndLogEvent</param>
        public CallStartEndLogEvent(string eventType)
        { 
            logEventType = eventType;
        }

        /// <summary>
        /// Default constructor for deserialization.
        /// </summary>
        public CallStartEndLogEvent()
        {
        }
    }
}
