/////////////////////////////////////////////////////////////////////////////////////
//  File:   RequestUriCondition.cs                                  23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Tests the Request-URI in the call’s SIP INVITE or MESSAGE. See Sections 3.3.3.1.13 and
    /// E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class RequestUriCondition : ConditionBase
    {
        /// <summary>
        /// Operator to use for comparison. Must be "EQ", "SS" or "NE". Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// This is the value to be compared with the call’s Request-URI value using the test 
        /// specified in “operator”. Required.
        /// </summary>
        public string content { get; set; } = "urn:service:sos";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RequestUriCondition()
        {
            conditionType = nameof(RequestUriCondition);
            Operator = OpCode.EQ;
        }
    }
}
