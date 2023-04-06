/////////////////////////////////////////////////////////////////////////////////////
//  File:   ConditionBase.cs                                        23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Base class for all conditions used in Policy Routing Rules. See Sections 3.3.3.1 and
    /// E.1.1 of NENA STA-010.3.
    /// </summary>
    public class ConditionBase
    {
        /// <summary>
        /// Set to the specific condition type. Must be set to the string equivalent of one of the
        /// values in the ConditionTypeEnum. Required.
        /// </summary>
        public string conditionType { get; set; }
        /// <summary>
        /// If true, then reverse (negate) the evaluation of the condition.
        /// </summary>
        public bool negation { get; set; } = false;
        /// <summary>
        /// Text describing the condition.
        /// Optional.
        /// </summary>
        public string description { get; set; }
    }
}
