/////////////////////////////////////////////////////////////////////////////////////
//  File:   SipRecMetadataLogEvent.cs                               14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the SipRecMetadataLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged by a SIPREC Recording Server (SRS) when it receives the SIPREC metadata (RFC 7865).
    /// </summary>
    public class SipRecMetadataLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the SIPREC metadata XML document (see RFC 7865).
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SipRecMetadataLogEvent()
        {
            logEventType = "SipRecMetadataLogEvent";
        }
    }
}
