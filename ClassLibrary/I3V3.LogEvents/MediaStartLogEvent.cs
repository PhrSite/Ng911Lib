/////////////////////////////////////////////////////////////////////////////////////
//  File:   MediaStartLogEvent.cs                                   13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the MediaStartLogEvent log event. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// </summary>
    public class MediaStartLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the text of the media block of the SDP. Required.
        /// </summary>
        public string sdp { get; set; }

        /// <summary>
        /// Set to the SIPREC SDP label attribute (a=label:xx) for the media stream.
        /// Required. Only an array of length 1 will be used.
        /// </summary>
        public string[] mediaLabel { get; set; }

        /// <summary>
        /// Set to “incoming” for media streams that the are received or “outgoing” 
        /// for media streams that are sent. Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MediaStartLogEvent()
        {
            logEventType = "MediaStartLogEvent";
        }
    }
}
