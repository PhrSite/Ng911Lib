/////////////////////////////////////////////////////////////////////////////////////
//  File:   LoggingDiscrepancyReport.cs                             20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using I3LogEvents;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for sent a Logging Discrepancy Report. See Sections 3.7.7 and E.2.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class LoggingDiscrepancyReport : DiscrepancyReport
    {

        /// <summary>
        /// Set to the The SIP INVITE or other request, or the LogEvent request, or the RetrieveLogEvent 
        /// request Required.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// Identifies the problem with the SRS or event logging server. Must be set to the string 
        /// equivalent of one of the values in the LoggingProblemEnum.
        /// Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// Set to the status code returned from the SIP request, the LogEvent request, or the 
        /// RetrieveLogEvent request.
        /// Required.
        /// </summary>
        public string result  { get; set; }

        /// <summary>
        /// Set to the  Emergency Call Identifier. 
        /// Conditional: REQUIRED if problem relates to a specific call.
        /// </summary>
        public string callIdUrn { get; set; }

        /// <summary>
        /// Set to the Emergency Incident Tracking Identifier.
        /// Conditional: REQUIRED if problem relates to a specific incident.
        /// </summary>
        public string incidentIdUrn { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LoggingDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Identifies a type of problem with a SRS or a event logging server.
    /// </summary>
    public enum LoggingProblemEnum
    {
        InviteSrsError,
        LogEventError,
        RetrieveLogEventError,
        OtherLogging
    }
}
