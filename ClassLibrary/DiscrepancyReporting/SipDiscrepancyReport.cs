/////////////////////////////////////////////////////////////////////////////////////
//  File:   SipDiscrepancyReport.cs                                 21 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using AdditionalData;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for a SIP Discrepancy Report. See Sections 3.7.9 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class SipDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be set to the string equivalent of one of the values in the 
        /// SipProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// Set to the Emergency Call Identifier.
        /// Conditional: REQUIRED if problem is related to a specific call.
        /// </summary>
        public string callIdUrn { get; set; }

        /// <summary>
        /// Set to the Emergency Incident Identifier.
        /// Conditional: REQUIRED if problem is related to a specific incident.
        /// </summary>
        public string incidentIdUrn { get; set; }

        /// <summary>
        /// Set to the block of parameters specified in Section 4.6.17 of NENA-STA-010.3. This is the
        /// string verion of the SendCallRequests data class.
        /// Conditional: REQUIRED if discrepancy report is related to a test call.
        /// </summary>
        public string testCallGenerator { get; set; }

        /// <summary>
        /// Set to the string version of the SIP request.
        /// Conditional: REQUIRED if the problem occurred on a SIP request or response.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// The status code returned from the SIP request.
        /// Conditional: REQUIRED if the problem occurred on a SIP request or response.
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// The name of the call queue.
        /// Conditional: REQUIRED if the call was sent to a queue.
        /// </summary>
        public string queueName { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SipDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of the possible SIP related problems for a SIP Discrepancy Report.
    /// </summary>
    public enum SipProblemEnum
    {
        InitialINVITE, 
        MESSAGE, 
        OPTIONS,
        MidDialog,
        RequiredMedia,
        MediaProblem,
        EngorgedQ,
        Signaling,
        OtherSip
    }
}
