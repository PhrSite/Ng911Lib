/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogEventContainer.cs                                    16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Contains a log event as a JWS string.
    /// </summary>
    public class LogEventContainer
    {
        /// <summary>
        /// LogEvent Identifier assigned by the logging service as described in Section 2.1.8.
        /// Required.
        /// </summary>
        public string logEventId { get; set; }

        /// <summary>
        /// RTSP parameters returned from RecMediaStartEvent. MUST be returned if media was recorded.
        /// </summary>
        public List<string> rtsp = new List<string>();

        /// <summary>
        /// A LogEvent in JWS format. Required.
        /// </summary>
        public string logEvent { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogEventContainer()
        {
        }
    }
}
