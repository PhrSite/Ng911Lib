/////////////////////////////////////////////////////////////////////////////////////
//  File:   AbandonedCall.cs                                        16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3 Abandoned Call NOTIFY body. See Section 4.2.2.9 and E.11.2.1 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class AbandonedCall
    {
        /// <summary>
        /// Contains the SIP INVITE message.
        /// Required.
        /// </summary>
        public string invite { get; set; }

        /// <summary>
        /// Timestamp for the time that the INVITE request was received.
        /// Required.
        /// </summary>
        public string inviteTimestamp { get; set; }

        /// <summary>
        /// Timestamp for the time that the CANCEL request was received.
        /// Required.
        /// </summary>
        public string cancelTimestamp { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AbandonedCall()
        {
        }
    }
}
