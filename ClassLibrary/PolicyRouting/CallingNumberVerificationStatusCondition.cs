/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallingNumberVerificationStatusCondition.cs             23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// This condition allows testing the outcome of any validation of the calling number that may have 
    /// been done by the Secure Telephone Identity Verification Service (STI-VS) FE.
    /// See Sections 3.3.3.1.18 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class CallingNumberVerificationStatusCondition : ConditionBase
    {
        /// <summary>
        /// Operator to use for comparison. Must be either "EQ" or "NE".
        /// Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; } = OpCode.EQ;

        /// <summary>
        /// Must be set to "TN-Validation-Passed", TN-Validation-Failed" or "No-TN-Validation".
        /// Required.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallingNumberVerificationStatusCondition()
        {
            conditionType = nameof(CallingNumberVerificationStatusCondition);
        }
    }
}
