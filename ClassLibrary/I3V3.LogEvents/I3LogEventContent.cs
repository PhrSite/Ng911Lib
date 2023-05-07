/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventContent.cs                                    13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Common;

namespace I3V3.LogEvents
{
    /// <summary>
    /// JSON content data class for passing I3V3 log events as a JSON Web Signature (JWS) to an I3V3 
    /// log event server.
    /// </summary>
    public class I3LogEventContent
    {
        /// <summary>
        /// This field must be a JWS object as defined in Section E.10.4.1 of NENA-STA-010.3.
        /// </summary>
        public I3Jws content { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public I3LogEventContent()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Let"> </param>
        public I3LogEventContent(LogEvent Let)
        {
            content = new I3Jws(Let);
        }
    }
}
