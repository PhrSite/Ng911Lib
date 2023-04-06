/////////////////////////////////////////////////////////////////////////////////////
//  File:   EidoLogEvent.cs                                         13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Class for the EidoLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a Emergency Incident Data Object (EIDO) is sent or received.
    /// </summary>
    public class EidoLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the EIDO JSON string if the EIDO is sent by-value, null otherwise.
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// Contains the URI of the reference to the EIDO if the EIDO is sent by-reference.
        /// </summary>
        public string reference { get; set; }

        /// <summary>
        /// Must be set to either incoming or outgoing
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor for de-serialization
        /// </summary>
        public EidoLogEvent()
        {
            logEventType = "EidoLogEvent";
        }
    }
}
