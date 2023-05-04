/////////////////////////////////////////////////////////////////////////////////////
//  File:   SipHeaderCondition.cs                                   23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Tests a SIP header field in the INVITE or MESSAGE of a call (such as “From”, “To”, “Contact”, 
    /// etc.). See Sections 3.3.3.1.2 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class SipHeaderCondition : ConditionBase
    {
        /// <summary>
        /// MUST exist and be set to the name of a SIP header field, without
        /// the colon.
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// Operator for the condition. Must be one of EQ, SS, IS. Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; } = OpCode.EQ;

        /// <summary>
        /// Content to match the SIP header value to. If “operator” is set to “EQ” or “SS”, this member 
        /// contains a string against which the specified header field value is compared, either for 
        /// equality or as a substring. If operator is "IS" then this field must contain a REGEX expression
        /// to match the header's value to.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SipHeaderCondition()
        {
            conditionType = nameof(SipHeaderCondition);
        }
    }
}
