/////////////////////////////////////////////////////////////////////////////////////
//  File:   EsrpDiscrepancyReport.cs                                22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the ESRP Discrepancy Report. See Sections 3.7.17 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class EsrpDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be set to the string equivalent of one of the values in the
        /// EsrpProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The Emergency Call Identifier assigned to the call.
        /// Conditional: REQUIRED when the discrepancy relates to a specific call.
        /// </summary>
        public string callId { get; set; }

        /// <summary>
        /// The Emergency Incident Identifier assigned to the call.
        /// Conditional: REQUIRED when the discrepancy report relates to a specific incident.
        /// </summary>
        public string incidentId { get; set; }

        /// <summary>
        /// The PIDF-LO XML document received with or via the call.
        /// Conditional: REQUIRED when the discrepancy report relates to a specific call.
        /// </summary>
        public string pidfLo { get; set; }

        /// <summary>
        /// The name of the call queue in question.
        /// Conditional: REQUIRED when the discrepancy report is due to one or more queues whose 
        /// fullness is a problem; OPTIONAL when the discrepancy is due to the PSAP receiving fewer 
        /// calls than would normally be expected.
        /// </summary>
        public string queueName { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EsrpDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeratiof of possible problems for an ESRP Discrepancy Report.
    /// </summary>
    public enum EsrpProblemEnum
    {
        /// <summary>
        /// Call received
        /// </summary>
        CallReceived,
        /// <summary>
        /// Queue was full
        /// </summary>
        EngorgedQ,
        /// <summary>
        /// Call drought -- no calls received
        /// </summary>
        CallDrought
    }
}
