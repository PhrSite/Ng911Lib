/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncomingQueueCondition.cs                               23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Tests the URI of the queue the call was received on. See Sections 3.3.3.1.15 and E.1.1 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class IncomingQueueCondition : ConditionBase
    {
        /// <summary>
        /// Operator to use to evaluate this condition. Must be "EQ", "SS" or "NE". Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; } = OpCode.EQ;

        /// <summary>
        /// This is the value to be compared with the queue URI using the test indicated by “operator”.
        /// Required.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IncomingQueueCondition()
        {
            conditionType = nameof(IncomingQueueCondition);
        }
    }
}
