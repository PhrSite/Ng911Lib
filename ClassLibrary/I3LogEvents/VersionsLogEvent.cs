/////////////////////////////////////////////////////////////////////////////////////
//  File:   VersionsLogEvent.cs                                     14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the VersionsLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logs the response to a web service Versions request.
    /// Note: Some logging clients use the Versions request to poll the logging service to see if
    /// it is available. Logging these requests will generate an excessive number of log events.
    /// </summary>
    public class VersionsLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the URL of the logging service.
        /// Required.
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// Contains the response from the logging service.
        /// Required.
        /// </summary>
        public string response { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public VersionsLogEvent()
        {
            logEventType = "VersionsLogEvent";
        }
    }
}
