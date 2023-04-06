/////////////////////////////////////////////////////////////////////////////////////
//  File:   LostServiceUrnCondition.cs                              23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Causes a route query to be performed for a specified service URN using the location for routing
    /// of the call, and as a side effect sets the "Normal-NextHop" variable.
    /// See Sections 3.3.3.1.9 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class LostServiceUrnCondition : ConditionBase
    {
        /// <summary>
        /// Specifies the service URN to use in the LoST query to the ECRF.
        /// For example: urn:service:sos. Required.
        /// </summary>
        public string urn { get; set; } = "urn:service:sos";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LostServiceUrnCondition()
        {
            conditionType = nameof(LostServiceUrnCondition);
        }
    }
}
