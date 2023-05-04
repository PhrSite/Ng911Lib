/////////////////////////////////////////////////////////////////////////////////////
//  File:   ImrDiscrepancyReport.cs                                 22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the IMR Discrepancy Report. See Sections 3.7.20 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class ImrDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem encountered. Must be the string equivalent of one of the values
        /// in the ImrProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// Emergency Call Identifier assigned to the call. Required.
        /// </summary>
        public string callId { get; set; }

        /// <summary>
        /// Emergency Incident Identifier assigned to the call.
        /// Conditional: REQUIRED if used for an emergency call.
        /// </summary>
        public string incidentId { get; set; }

        /// <summary>
        /// The SIP header field of the INVITE or MESSAGE request. Required.
        /// </summary>
        public string callHeader { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ImrDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems for an IMR Discrepancy Report.
    /// </summary>
    public enum ImrProblemEnum
    {
        /// <summary>
        /// The queue was full
        /// </summary>
        EngorgedQ,
        /// <summary>
        /// Response was incorrect
        /// </summary>
        ResponseIncorrect,
        /// <summary>
        /// Response was confusint
        /// </summary>
        ResponseConfusing,
        /// <summary>
        /// Call transfer was incorrect
        /// </summary>
        CallTransferIncorrect,
        /// <summary>
        /// Excessive silence detected
        /// </summary>
        ExcessiveSilence,
        /// <summary>
        /// Unknow script encountered
        /// </summary>
        UnknownScript,
        /// <summary>
        /// Input failed
        /// </summary>
        InputFailed,
        /// <summary>
        /// Script logic failure
        /// </summary>
        ScriptLogicFailure,
        /// <summary>
        /// Other IMR problem
        /// </summary>
        OtherImr
    }
}
