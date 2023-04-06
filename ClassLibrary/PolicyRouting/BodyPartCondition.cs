/////////////////////////////////////////////////////////////////////////////////////
// File:    BodyPartCondition.cs                                    23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Body Part Condition for a Policy Routing Rule. See Sections 3.3.3.1.12 and E.1.1 of NENA STA-010.3.
    /// </summary>
    
    public class BodyPartCondition : ConditionBase
    {
        /// <summary>
        /// Set to a MIME media (content) type and subtype (e.g., “text/plain”).
        /// Required.
        /// </summary>
        public string contentType { get; set; }

        /// <summary>
        /// This is the name of an element or member in the specified body part. Required.
        /// </summary>
        public string element { get; set; }

        /// <summary>
        /// Operator for the condition. Must be one of: exists, missing, EQ, SS, NE, GT, LT, GE, LE.
        /// Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// This is the value to be compared with the value of the specified element or member of the 
        /// first body part of the specified type, using the specified comparison operator; this 
        /// member is omitted when “operator” is “exists” or “missing” and MANDATORY otherwise.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BodyPartCondition()
        {
            conditionType = nameof(BodyPartCondition);
            Operator = OpCode.SS;
        }
    }
}
