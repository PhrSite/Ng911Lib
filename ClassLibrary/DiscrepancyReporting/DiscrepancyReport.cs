/////////////////////////////////////////////////////////////////////////////////////
//  File:   DiscrepancyReport.cs                                    20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Base class (header) for all discrepancy reports. See Sections 3.7.1 and E.2.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class DiscrepancyReport
    {
        /// <summary>
        /// URI for responding entity to use for responses. Required.
        /// </summary>
        public string resolutionUri { get; set; }

        /// <summary>
        /// Type of discrepancy report. Must be the string equivalent of one of the values in
        /// DRTypeEnum.
        /// Required.
        /// </summary>
        public string reportType { get; set; }

        /// <summary>
        /// Timestamp of the discrepancy report submittal. Must be in the NENA Timestamp format
        /// specified in Section 2.3 of NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string discrepancyReportSubmitTimeStamp { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// Unique (to reporting agency) ID of report. Required.
        /// </summary>
        public string discrepancyReportId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// FQDN of the entity creating the report. Required.
        /// </summary>
        public string reportingAgencyName { get; set; }

        /// <summary>
        /// UserId of agent creating the report.
        /// </summary>
        public string reportingAgentId { get; set; }

        /// <summary>
        /// jCard of the contact of the agency submitting this report. Required.
        /// </summary>
        public string reportingContactJcard { get; set; }

        /// <summary>
        /// Name of service or instance where discrepancy exists
        /// </summary>
        public string problemService { get; set; }

        /// <summary>
        /// Specifies the serverity of the problem. Must be the string equivalent of one of the values in
        /// DrServerityEnum. Required.
        /// </summary>
        public string problemSeverity { get; set; }

        /// <summary>
        /// Text comment.
        /// </summary>
        public string problemComments { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Specifies the type of the discrepancy report.
    /// </summary>
    public enum DRTypeEnum
    {
        /// <summary>
        /// Policy Store Discrepancy Report
        /// </summary>
        PolicyStoreDiscrepancyReport, 
        /// <summary>
        /// LoST Discrepancy Report
        /// </summary>
        LostDiscrepancyReport,
        /// <summary>
        /// BCF Discrepancy Report
        /// </summary>
        BcfDiscrepancyReport, 
        /// <summary>
        /// Logging Discrepancy Report
        /// </summary>
        LoggingDiscrepancyReport,
        /// <summary>
        /// Call Taker Discrepancy Report
        /// </summary>
        CallTakerDiscrepancyReport,
        /// <summary>
        /// SIP Discrepancy Report
        /// </summary>
        SipDiscrepancyReport, 
        /// <summary>
        /// Permissions Discrepancy Report
        /// </summary>
        PermissionsDiscrepancyReport,
        /// <summary>
        /// GIS Discrepancy Report
        /// </summary>
        GisDiscrepancyReport, 
        /// <summary>
        /// LIS Discrepancy Report
        /// </summary>
        LisDiscrepancyReport, 
        /// <summary>
        /// Policy Discrepancy Report
        /// </summary>
        PolicyDiscrepancyReport,
        /// <summary>
        /// Origination Service Discrepancy Report
        /// </summary>
        OriginatingServiceDiscrepancyReport,
        /// <summary>
        /// Call Transfer Discrepancy Report
        /// </summary>
        CallTransferDiscrepancyReport, 
        /// <summary>
        /// MCS (MSAG Conversion Service) Discrepancy Report
        /// </summary>
        McsDiscrepancyReport,
        /// <summary>
        /// ESRP Discrepancy Report
        /// </summary>
        EsrpDiscrepancyReport, 
        /// <summary>
        /// ADR (Additional Data Repository) Discrepancy Report
        /// </summary>
        AdrDiscrepancyReport,
        /// <summary>
        /// Network Discrepancy Report
        /// </summary>
        NetworkDiscrepancyReport, 
        /// <summary>
        /// IMR (Interactive Media Response) system Discrepancy Reprort
        /// </summary>
        ImrDiscrepancyReport,
        /// <summary>
        /// Test Call Discrepancy Report
        /// </summary>
        TestCallDiscrepancyReport, 
        /// <summary>
        /// Log Signature Certificate Discrepancy Report
        /// </summary>
        LogSignatureCertificateDiscrepancyReport,
    }

    /// <summary>
    /// Specifies the severity of the discrepancy report.
    /// </summary>
    public enum DrServerityEnum
    {
        /// <summary>
        /// Minor severity
        /// </summary>
        Minor,
        /// <summary>
        /// Moderate severity
        /// </summary>
        Moderate,
        /// <summary>
        /// Operation is degraded
        /// </summary>
        Degraded,
        /// <summary>
        /// Operation is impared
        /// </summary>
        Impaired,
        /// <summary>
        /// Severe
        /// </summary>
        Severe,
        /// <summary>
        /// Critical
        /// </summary>
        Critical,
    }
}
