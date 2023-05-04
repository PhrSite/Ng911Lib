/////////////////////////////////////////////////////////////////////////////////////
//  File:   DiscrepancyResolution.cs                                20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class used by a discrepancy reporting service for sending the resolution to a
    /// discrepancy report. See Sections 3.7.2 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class DiscrepancyResolution
    {
        /// <summary>
        /// FQDN of entity responding to the report. Required.
        /// </summary>
        public string respondingAgencyName { get; set; }

        /// <summary>
        /// jCard of the agency providing the resolution. Required.
        /// </summary>
        public string respondingContactJcard { get; set; }

        /// <summary>
        /// UserId of agent responding to the report.
        /// </summary>
        public string respondingAgentId { get; set; }

        /// <summary>
        /// Unique (to reporting agency) ID of report. Required.
        /// </summary>
        public string discrepancyReportId { get; set; }

        /// <summary>
        /// FQDN of agency that created the discrepancy report. Required.
        /// </summary>
        public string reportingAgencyName { get; set; }

        /// <summary>
        /// Name of the service or instance where the discrepancy existed.
        /// Required.
        /// </summary>
        public string problemService { get; set; }

        /// <summary>
        /// Timestamp of the resolution. Must be in the NENA Timestamp format specified in Section 2.3 of 
        /// NENA-STA-010.3. Required.
        /// </summary>
        public string responseTime { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// Agent ID of the agent that reported the discrepancy.
        /// </summary>
        public string reportingAgentId { get; set; }

        /// <summary>
        /// Text comment.
        /// </summary>
        public string responseComments { get; set; }

        /// <summary>
        /// Specifies how the discrepancy was resolved. Must be set to the string equivalent of one of the 
        /// values in DrResolutionEnum. Required.
        /// </summary>
        public string resolution { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DiscrepancyResolution()
        {
        }
    }

    /// <summary>
    /// Enumeration of the possible resolutions to a discrepancy report.
    /// </summary>
    public enum DrResolutionEnum
    {
        /// <summary>
        /// The discrepancy was corrected
        /// </summary>
        DiscrepancyCorrected, 
        /// <summary>
        /// No discrepancy was found
        /// </summary>
        NoDiscrepancy, 
        /// <summary>
        /// Other response or action taken
        /// </summary>
        OtherResponse,
        /// <summary>
        /// A policy was added to corrected the discrepancy
        /// </summary>
        PolicyAdded, 
        /// <summary>
        /// A policy was added to correct the discrepancy
        /// </summary>
        PolicyUpdated,
        /// <summary>
        /// No such policy
        /// </summary>
        NoSuchPolicy,
        /// <summary>
        /// Insufficient credentials (to correct the policy)
        /// </summary>
        InsufficientCredentials,
        /// <summary>
        /// An entry was added to correct the policy
        /// </summary>
        EntryAdded,
        /// <summary>
        /// Permissions policy was corrected
        /// </summary>
        PerPolicy,
        /// <summary>
        /// Call taker was advised
        /// </summary>
        CallTakerAdvised,
        /// <summary>
        /// Transfer was correct
        /// </summary>
        TransferCorrect,
        /// <summary>
        /// Bad certificate chain was corrected
        /// </summary>
        BadCertificateChain,
        /// <summary>
        /// Data was corrected
        /// </summary>
        DataCorrected,
        /// <summary>
        /// Record was corrected
        /// </summary>
        RecordsCorrected,
        /// <summary>
        /// Permissions were corrected
        /// </summary>
        PermissionsCorrected,
        /// <summary>
        /// Device configuration error was corrected
        /// </summary>
        DeviceConfigError,
        /// <summary>
        /// Policy was corrected
        /// </summary>
        PolicyCorrected,
        /// <summary>
        /// No error was detected
        /// </summary>
        NoError,
        /// <summary>
        /// Problem was corrected
        /// </summary>
        ProblemCorrected,
        /// <summary>
        /// Invalie record was corrected
        /// </summary>
        InvalidRecord,
        /// <summary>
        /// GIS data was corrected
        /// </summary>
        Gis,
        /// <summary>
        /// Discrepancy acknowledged
        /// </summary>
        Acknowledged,
    }
}
