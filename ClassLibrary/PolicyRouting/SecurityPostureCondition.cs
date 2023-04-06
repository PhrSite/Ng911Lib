/////////////////////////////////////////////////////////////////////////////////////
//  File:   SecurityPostureCondition.cs                             23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests the current security posture of a service or agency. See Sections 3.3.3.1.7 and
    /// E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class SecurityPostureCondition : ConditionBase
    {
        /// <summary>
        /// Contains one of Service Name, Service Identifier, or Agency Identifier.
        /// Required.
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// Must be either "EQ" or "NE". Required.
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// Must be set to one of the entries in the Security Posture Registry (see Section 10.18 of 
        /// NENA-STA-010.3). Required.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SecurityPostureCondition()
        {
            conditionType = nameof(SecurityPostureCondition);
        }
    }
}
