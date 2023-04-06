/////////////////////////////////////////////////////////////////////////////////////
//  File:   TestCallDiscrepancyReport.cs                            22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Test Call Generator Discrepancy Report. See Sections 3.7.21 and E.2.1 of
    /// NENA-010.3.
    /// </summary>
    public class TestCallDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be set to the string equivalent of one of the values in the
        /// TestCallProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// Emergency Call Identifier assigned to the call. Required.
        /// </summary>
        public string callIdUrn { get; set; }

        /// <summary>
        /// The SIP request string.
        /// Required.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// Number of test calls placed since the last time SendCallRequests was received from this PSAP
        /// Required.
        /// </summary>
        public int nbrOfCalls { get; set; }

        /// <summary>
        /// Number of calls counted in NbrOfCalls that were completed successfully.
        /// </summary>
        public int successCount { get; set; }

        /// <summary>
        /// Number of calls counted in NbrOfCalls that were attempted, but failed to complete.
        /// Required.
        /// </summary>
        public int failCount { get; set; }

        /// <summary>
        /// TBD
        /// Required.
        /// </summary>
        public string time { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// The status code returned from the SIP request. Required.
        /// </summary>
        public int result { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string contact { get; set; }

        /// <summary>
        /// TBD
        /// </summary>
        public string sdp { get; set; }

        /// <summary>
        /// TBD
        /// Required.
        /// </summary>
        public bool mediaOk { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TestCallDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems used for a Test Call Generator Discrepancy Report.
    /// </summary>
    public enum TestCallProblemEnum
    {
        TestInvite,
        TestMessage,
        TestOptions,
        TestMidDialog,
        TestMedia,
        TestLoopbackMedia,
        TestSignaling,
        OtherTestCall
    }
}
