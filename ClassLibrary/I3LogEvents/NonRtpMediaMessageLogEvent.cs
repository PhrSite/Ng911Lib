/////////////////////////////////////////////////////////////////////////////////////
//  File:   NonRtpMediaMessageLogEvent.cs                           14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the NonRtpMediaMessageLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when media that is not transported over RTP (MSRP for example) is sent or received.
    /// </summary>
    public class NonRtpMediaMessageLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the entire text message.
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing".
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Must be either "SIP" or "MSRP". See Section 10.22 of NENA-STA-010.3.
        /// </summary>
        public string protocol { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NonRtpMediaMessageLogEvent()
        {
            logEventType = "NonRtpMediaMessageLogEvent";
        }
    }
}
