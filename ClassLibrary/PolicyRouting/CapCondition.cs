/////////////////////////////////////////////////////////////////////////////////////
//  File: CapCondition.cs                                           23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Condition class for testing Common Alerting Protocol message bodies. See Sections 3.3.3.1.17 
    /// and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class CapCondition : ConditionBase
    {
        /// <summary>
        /// Must be one of "Identifier", "Sender", "Address", "InfoEventCode" or "InfoValueName".
        /// Required.
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// Operator to used for comparison. Must be "EQ", "SS" or "NE". Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; } = OpCode.EQ;

        /// <summary>
        /// This is the string that is compared with the corresponding element of the CAP component 
        /// using the test indicated by “operator”.
        /// Required.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Value to use to compare the "NonInteractive" field of the CAP massage with.
        /// </summary>
        public bool nonInteractive { get; set; } = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CapCondition()
        {
            conditionType = nameof(CapCondition);
        }
    }
}
