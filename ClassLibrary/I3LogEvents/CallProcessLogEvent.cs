
namespace I3LogEvents
{
    /// <summary>
    /// Data class for the CallProcessLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by non-call stateful functional elements that handle a call when they see a SIP
    /// INVITE or MESSAGE request. This log event indicates that they saw the call.
    /// </summary>
    public class CallProcessLogEvent : LogEvent
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CallProcessLogEvent()
        {
            logEventType = "CallProcessLogEvent";
        }
    }
}
