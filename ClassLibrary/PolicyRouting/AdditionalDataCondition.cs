/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdditionalDataCondition.cs                              23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Additional Data Condition for a Policy Routing Rule. Tests the SIP INVITE or MESSAGE of the 
    /// call to check if it contains an Additional Data block that meets a specified condition.
    /// See Sections 3.3.3.1.3 and E.1.1 of NENA STA-010.3.
    /// </summary>
    public class AdditionalDataCondition : ConditionBase
    {
        /// <summary>
        /// Must be set to a value consisting of “EmergencyCallData”, a dot, and a block type. 
        /// For example: EmergencyCallData.SubscriberInfo. Required.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Specifies the name of an XML element within the additional data XML document.
        /// This member MUST be omitted when “operator” is set to “exists” or “missing” and is MANDATORY 
        /// otherwise.
        /// </summary>
        public string element { get; set; }

        /// <summary>
        /// Operator for the condition. Must be one of: exists, missing, EQ, SS, NE, GT, LT, GE, LE.
        /// Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// This specifies the value of which is compared with the value of the specified element of 
        /// the specified Additional Data block, using the test specified by “operator”; this member
        /// MUST be omitted when “operator” is “exists” or “missing” and is MANDATORY otherwise.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AdditionalDataCondition()
        {
            conditionType = nameof(AdditionalDataCondition);
        }
    }
}
