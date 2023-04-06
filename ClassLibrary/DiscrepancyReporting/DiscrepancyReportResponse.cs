/////////////////////////////////////////////////////////////////////////////////////
//  File:   DiscrepancyReportResponse.cs                            20 Jan 20 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the response to a discrepancy report request. See Sections 3.7.1 and E.2.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class DiscrepancyReportResponse
    {
        /// <summary>
        /// FQDN of the agency responding to the report. Required.
        /// </summary>
        public string respondingAgencyName { get; set; }

        /// <summary>
        /// jCard of the agency responding to the report. Required.
        /// </summary>
        public string respondingContactJcard { get; set; }

        /// <summary>
        /// UserId of agent creating the response report.
        /// </summary>
        public string respondingAgentId { get; set; }

        /// <summary>
        /// Estimated response time stamp. Must be in the NENA Timestamp format specified in Section 2.3 
        /// of NENA-STA-010.3.
        /// </summary>
        public string responseEstimatedReturnTime { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// Text comment.
        /// </summary>
        public string responseComments { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DiscrepancyReportResponse()
        {
        }
    }
}
