/////////////////////////////////////////////////////////////////////////////////////
//  File:   PolicyDiscrepancyReport.cs                              22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Policy Discrepancy Report. See Sections 3.7.13 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class PolicyDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// The policy ID.
        /// Required.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Specifies the type of problem. Must be set to the string equivalent of one of the values in
        /// the PolicyProblemEnum.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The location.
        /// Conditional: REQUIRED if the discrepancy is against a PRR policy.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Call Tracking Identifier.
        /// Conditional: REQUIRED if the discrepancy is specific to a call.
        /// </summary>
        public string callId { get; set; }

        /// <summary>
        /// The route URN.
        /// Conditional: REQUIRED if the discrepancy is against a PRR policy.
        /// </summary>
        public string routeUrn { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PolicyDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems for a Policy Discrepancy Report.
    /// </summary>
    public enum PolicyProblemEnum
    {
        InvalidUrn,
        UnknownPSAP,
        ConflictingRoute,
        OtherConflict,
        IncorrectUrn,
        Malformed,
        Loop,
        VerificationFailure,
        OtherPolicy
    }
}
