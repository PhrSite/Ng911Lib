/////////////////////////////////////////////////////////////////////////////////////
//  File:   RecMediaEndLogEvent.cs                                  13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the RecMediaEndLogEvent log event. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by a media recorder when a media session ends.
    /// </summary>
    public class RecMediaEndLogEvent : LogEvent
    {
        /// <summary>
        /// Set to the SIPREC SDP label attribute (a=label:xx) for the media stream.
        /// Required. Only an array of length 1 will be used.
        /// </summary>
        public string[] mediaLabel { get; set; }

        /// <summary>
        /// This field is optional.
        /// </summary>
        public string mediaQualityStats { get; set; }

        /// <summary>
        /// Future. Not Used.
        /// </summary>
        public string mediaTranscodeFrom { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecMediaEndLogEvent()
        {
            logEventType = "RecMediaEndLogEvent";
        }
    }
}
