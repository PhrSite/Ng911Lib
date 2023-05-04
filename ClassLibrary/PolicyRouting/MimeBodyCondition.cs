/////////////////////////////////////////////////////////////////////////////////////
//  File:   MimeBodyCondition.cs                                    23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests if an incoming call’s SIP INVITE or MESSAGE has a body part with a specified MIME type.
    /// See Sections 3.3.3.1.4 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class MimeBodyCondition : ConditionBase
    {
        /// <summary>
        /// Contains an array of strings. Each element specifies a MIME type.
        /// </summary>
        public List<string> mimeList { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MimeBodyCondition()
        {
            conditionType = nameof(MimeBodyCondition);
        }
    }
}
