/////////////////////////////////////////////////////////////////////////////////////
//  File:   PolicyEnum.cs                                           23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyStore
{
    /// <summary>
    /// Data class that contains basic information about a policy for enumeration purposes.
    /// See Sections 3.3.1.3.1 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class PolicyEnum
    {
        /// <summary>
        /// Type of the policy. Restricted to the values in the Policy Types registry. See Section 
        /// 10.33 of NENA-STA-010.3. Required.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// ID of the agency or service whose policy is requested. MUST be a FQDN or URI that contains a
        /// FQDN. Required.
        /// </summary>
        public string policyOwner { get; set; }

        /// <summary>
        /// For “OriginationRoutePolicy” or “NormalNextHopRoutePolicy”, this is the policyQueueName.
        /// CONDITIONAL, MUST NOT be specified unless policyType is “OriginationRoutePolicy” or 
        /// “NormalNextHopRoutePolicy”.
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// For “OtherRoutePolicy”, this is an arbitrary identifier for the policy. Conditional, must 
        /// not be specified unless policyType is OtherRoutePolicy.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Policy is not valid after this time. Optional. If not specified then this policy never expires.
        /// Must be in NENA Timestamp format specified in Section 2.3 NENA-STA-010.3.
        /// Optional.
        /// </summary>
        public string policyExpirationTime { get; set; }

        /// <summary>
        /// Date/Time policy was last modified. Must be in NENA Timestamp format specified in Section 2.3
        /// NENA-STA-010.3. CONDITIONAL, MUST be provided on retrieval, ignored on store.
        /// </summary>
        public string policyLastModificationTime { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PolicyEnum()
        {
        }
    }
}
