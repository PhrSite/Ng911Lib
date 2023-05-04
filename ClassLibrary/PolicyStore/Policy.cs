/////////////////////////////////////////////////////////////////////////////////////
//  File:   RuleSet.cs                                              23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using PolicyRouting;

namespace PolicyStore
{
    /// <summary>
    /// Class for the settings of a Policy Rule Set. See Section 3.3.1 of NENA-STA-010.3.
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// ID of the agency or service whose policy is requested. MUST be a FQDN or URI that contains a
        /// FQDN. Required.
        /// </summary>
        public string policyOwner { get; set; }

        /// <summary>
        /// Type of the policy. Restricted to the values in the Policy Types registry. See Section 
        /// 10.33 of NENA-STA-010.3. Required.
        /// </summary>
        public string policyType { get; set; } = PolicyTypeEnum.NormalNextHopRoutePolicy.ToString();

        /// <summary>
        /// For “OtherRoutePolicy”, this is an arbitrary identifier for the policy. Conditional, must 
        /// not be specified unless policyType is OtherRoutePolicy.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// For “OriginationRoutePolicy” or “NormalNextHopRoutePolicy”, this is the policyQueueName.
        /// CONDITIONAL, MUST NOT be specified unless policyType is “OriginationRoutePolicy” or 
        /// “NormalNextHopRoutePolicy”.
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// Policy is not valid after this time. Optional. If not specified then this policy never expires.
        /// Must be in NENA Timestamp format specified in Section 2.3 NENA-STA-010.3.
        /// Optional.
        /// </summary>
        public string policyExpirationTime { get; set; }

        /// <summary>
        /// Array of rules. Required.
        /// </summary>
        public List<Rule> policyRules { get; set; } = new List<Rule>();

        /// <summary>
        /// Date/Time policy was last modified. Must be in NENA Timestamp format specified in Section 2.3
        /// NENA-STA-010.3. CONDITIONAL, MUST be provided on retrieval, ignored on store.
        /// </summary>
        public string policyLastModifiedTime { get; set; } = TimeUtils.GetCurrentNenaTimestamp();
    }

    /// <summary>
    /// Enumeration of policy types that pertain to routing.
    /// </summary>
    public enum PolicyTypeEnum
    {
        /// <summary>
        /// Originating Route Policy
        /// </summary>
        OriginationRoutePolicy,
        /// <summary>
        /// Normal Next Hop Policy
        /// </summary>
        NormalNextHopRoutePolicy,
        /// <summary>
        /// Other Route Policy
        /// </summary>
        OtherRoutePolicy
    }
}
