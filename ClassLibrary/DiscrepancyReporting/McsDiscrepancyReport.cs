/////////////////////////////////////////////////////////////////////////////////////
//  File:   McsDiscrepancyReport.cs                                 22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the MSAG Conversion Service (MCS) Discrepancy Report. See Sections 3.7.16 and
    /// E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class McsDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the service requested. Must be either PIDFLOtoMSAG or MSAGtoPIDFLO.
        /// Required.
        /// </summary>
        public string serviceCall { get; set; }

        /// <summary>
        /// The PIDF-LO supplied to PIDFLOtoMSAG, or received from MSAGtoPIDFLO.
        /// Required.
        /// </summary>
        public string pidfLo { get; set; }

        /// <summary>
        /// The MSAG supplied to MSAGtoPIDFLO, or received from PIDFLOtoMSAG.
        /// Required.
        /// </summary>
        public string msag { get; set; }

        /// <summary>
        /// The status code received from the conversion attempt. Required.
        /// </summary>
        public string statusCode { get; set; }

        /// <summary>
        /// Referral value received from the MCS.
        /// Conditional: REQUIRED when a Referral to another MCS was returned.
        /// </summary>
        public string referral { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public McsDiscrepancyReport()
        {
        }
    }
}
