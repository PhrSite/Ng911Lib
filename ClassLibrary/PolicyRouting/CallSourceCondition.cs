/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallSourceCondition.cs                                  23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// Tests the call’s source network. CallSource (as defined in the Via header fields of the INVITE) 
    /// is interpreted by the ESRP to ignore intra-ESInet Vias and other intermediaries.
    /// See Sections 3.3.3.1.11 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class CallSourceCondition : ConditionBase
    {
        /// <summary>
        /// Operator to use for comparison. Must be "EQ", "SS" or "NE". Required.
        /// </summary>
        [JsonPropertyName("operator")]
        public string Operator { get; set; } = OpCode.EQ;

        /// <summary>
        /// This is the value to be compared with the ESRP’s determined Call Source value using the 
        /// test indicated by “operator”. Required.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallSourceCondition()
        {
            conditionType = nameof(CallSourceCondition);
        }
    }
}
