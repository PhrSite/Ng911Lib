/////////////////////////////////////////////////////////////////////////////////////
//  File:   NormalNextHopCondition.cs                               23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Tests the current value of the “Normal-NextHop” variable. The LoST Service URN Condition 
    /// (Section 3.3.3.1.9) sets “Normal-NextHop” to the URI returned by the LoST query or marks 
    /// it as undefined. See Sections 3.3.3.1.14. and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class NormalHextHopCondition : ConditionBase
    {
        /// <summary>
        /// Operator to use for comparison. Must be "EQ", "SS" or "NE". Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// This value is compared against the current value of the NormalNextHop variable using the test
        /// specified by the “operator”. Required.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NormalHextHopCondition()
        {
            conditionType = nameof(NormalHextHopCondition);
        }
    }
}
