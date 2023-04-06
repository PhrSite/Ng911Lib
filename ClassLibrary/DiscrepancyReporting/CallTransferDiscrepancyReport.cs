/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallTransferDiscrepancyReport.cs                        22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Call Transfer Discrepancy Report. See Sections 3.7.15 and E.2.1 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class CallTransferDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// The Emergency Call Identifier assigned to the call. Required.
        /// </summary>
        public string callId { get; set; }

        /// <summary>
        /// The Emergency Incident Identifier assigned to the call. Required.
        /// </summary>
        public string incidentId { get; set; }

        /// <summary>
        /// The Agency Identifier of the originator of the transfer.
        /// Required.
        /// </summary>
        public string origin { get; set; }

        /// <summary>
        /// The status code received during the transfer attempt. Required.
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// The Agency Identifier of the recipient of the transfer. Required.
        /// </summary>
        public string destination { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallTransferDiscrepancyReport()
        {
        }
    }
}
