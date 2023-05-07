/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallTransferLogEvent.cs                                 13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the CallTransferLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3. 
    /// Logged by the call transferor when a call is transferred.
    /// </summary>
    public class CallTransferLogEvent : LogEvent
    {
        /// <summary>
        /// SIP URI of the transfer target. Required.
        /// </summary>
        public string target { get; set; }

        /// <summary>
        /// SIP Call-ID header value of the call that was transferred. Required.
        /// </summary>
        public string targetCallIdSip { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CallTransferLogEvent()
        {
            logEventType = "CallTransferLogEvent";
        }
    }
}
