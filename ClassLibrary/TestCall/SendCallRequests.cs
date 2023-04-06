/////////////////////////////////////////////////////////////////////////////////////
//  File:   SendCallRequests.cs                                     22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace TestCall
{
    /// <summary>
    /// Data class for the SendCallRequests API call to a Test Call Generator. See Sections 4.6.17.1 and
    /// E.6.1 of NENA-STA-010.3.
    /// </summary>
    public class SendCallRequests
    {
        /// <summary>
        /// Agency Identifier of the PSAP that wishes to have test calls sent to it. Required.
        /// </summary>
        public string psapId { get; set; }

        /// <summary>
        /// PIDF-LO used for location of test calls. Required.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// Minutes between test call send. Required.
        /// </summary>
        public int frequency { get; set; }

        /// <summary>
        /// Max number of Discrepancy Reports per hour. Required.
        /// </summary>
        public int discrepancyRateLimit { get; set; }

        /// <summary>
        /// When to start sending test calls. Must be in the NENA Timestamp format specified in 
        /// Section 2.3 of NENA-STA-010.3. Required.
        /// </summary>
        public string startDate { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// When to stop sending test calls.  Must be in the NENA Timestamp format specified in 
        /// Section 2.3 of NENA-STA-010.3. Required.
        /// </summary>
        public string endDate { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// PrrTest conditions for the test.
        /// </summary>
        public PrrTest testConditions { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SendCallRequests()
        {
        }
    }
}
