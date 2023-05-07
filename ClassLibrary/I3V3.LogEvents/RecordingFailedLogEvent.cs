/////////////////////////////////////////////////////////////////////////////////////
//  File:   RecordingFailedLogEvent.cs                              13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the RecordingFailedLogEvent log event. See Sections 4.12.3.7 E.8.1 of NENA-STA-010.3.
    /// Logged when a media recording session to a SIPREC recorder fails.
    /// </summary>
    public class RecordingFailedLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the text of the SDP. Required.
        /// </summary>
        public string sdp { get; set; }

        /// <summary>
        /// One of the values from the ReasonCodes NENA registry. Available values are "lostConnection" 
        /// and "dropOuts". Required.
        /// </summary>
        public string reasonCode { get; set; } = "lostConnection";

        /// <summary>
        /// Free text field that describes the reason for the failure. Required.
        /// </summary>
        public string reasonText { get; set; } = "SIPREC session failed";

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecordingFailedLogEvent()
        {
            logEventType = "RecordingFailedLogEvent";
        }
    }
}
