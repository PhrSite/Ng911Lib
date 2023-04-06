
namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for reporting a problem with a Policy Store Service. See Sections 3.7.4 and E.2.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class PolicyStoreDiscrepancyReport : DiscrepancyReport
    {

        /// <summary>
        /// Type of the policy. Values are limited to names in the Policy Types registry. See Section
        /// 10.33 of NENA-STA-010.3.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// For “OriginationRoutePolicy” or “NormalNextHopRoutePolicy”, this is the policyQueueName.
        /// CONDITIONAL, MUST NOT be specified unless policyType is “OriginationRoutePolicy” or 
        /// “NormalNextHopRoutePolicy”
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// For “OtherRoutePolicy”, this is an arbitrary identifier for the policy.
        /// CONDITIONAL, MUST NOT be specified unless policyType is “OtherRoutePolicy”.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Specifies the agency whose policy is requested.Must be a FQDN or URI that contains a FQDN
        /// Required.
        /// </summary>
        public string policyAgencyName { get; set; }

        /// <summary>
        /// Specifies the type of problem. Must be the string equivalent of one of the values in the 
        /// PolicyStoreProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The Response received from the  Policy Retrieve Request as shown in Section 3.3.1 of 
        /// NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string retrievePolicyResponse { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PolicyStoreDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Types of policy store problems.
    /// </summary>
    public enum PolicyStoreProblemEnum
    {
        PolicyInvalid,
        PolicyAltered,
        SignatureVerificationFailure,
        PolicyMissing,
        OtherPolicyStore
    }
}
