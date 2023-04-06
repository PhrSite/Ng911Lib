/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallTakerDiscrepancyReport.cs                           20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Call Taker Discrepancy Report. See Section s3.7.8 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class CallTakerDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Set to the Emergency Call ID assigned to the call. Required.
        /// </summary>
        public string callIdUrn { get; set; }

        /// <summary>
        /// Set to the Emergency Incident ID assigned to the call. Required.
        /// </summary>
        public string incidentIdUrn { get; set; }

        /// <summary>
        /// Set to the the PIDF-LO XML document received with the call. Required.
        /// </summary>
        public string pidfLo { get; set; }

        /// <summary>
        /// Set to the header field of the INVITE or MESSAGE. Required.
        /// </summary>
        public string callHeader { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CallTakerDiscrepancyReport()
        {
        }
    }
}
