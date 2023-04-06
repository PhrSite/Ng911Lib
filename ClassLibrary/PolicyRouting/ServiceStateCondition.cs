/////////////////////////////////////////////////////////////////////////////////////
//  File:   ServiceStateCondition.cs                                23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests the Service State of a service. See Sections 3.3.3.10 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class ServiceStateCondition : ConditionBase
    {
        /// <summary>
        /// Contains one of Service Name, Service Identifier or Agency Identifier. Required.
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// Condtion to use. Must be either "EQ" or "NE". Required.
        /// </summary>
        public string condition { get; set; } = "EQ";

        /// <summary>
        /// Must be set to one of the values in the Service State Registry. See Section 10.12 of 
        /// NENA-010.3. Required.
        /// </summary>
        public string value { get; set; } = "Normal";

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ServiceStateCondition()
        {
            conditionType = nameof(ServiceStateCondition);
        }
    }
}
