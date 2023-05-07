/////////////////////////////////////////////////////////////////////////////////////
//  File:   DiscrepancyReportLogEvent.cs                            14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the DiscrepancyReportLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a discrepancy report is sent or received.
    /// </summary>
    public class DiscrepancyReportLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the body of the report as a JSON string.
        /// Required.
        /// </summary>
        public string contents { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing".
        /// Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Identifies the name of the Discrepancy Reporting web service function that was called to make 
        /// the report or response (DiscrepancyReportRequest, StatusUpdateResponse, etc.).
        /// Required.
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DiscrepancyReportLogEvent()
        {
            logEventType = "DiscrepancyReportLogEvent";
        }
    }
}
