/////////////////////////////////////////////////////////////////////////////////////
//  File:   EidoLogEvent.cs                                         13 Jan 23 PHR
//  Revised: 5 May 23 PHR
//              -- Added peerId and subscriptionId per NENA-STA-024.1a-2023
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
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
        /// Must be set to either incoming or outgoing. Required
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Value is the identity of the peer. For a client or subscriber, it is the identity of the server or 
        /// notifier. For the server or notifier, it is the identity of the requesting client or subscriber.
        /// See Section 2.9 and Section 2.9.1 of NENA-STA-024.1a-2023.
        /// </summary>
        public string peerId { get; set; }

        /// <summary>
        /// Unique ID of the subscription if the event is the result of a EIDO conveyance subscription.
        /// </summary>
        public string subscriptionId { get; set; }

        /// <summary>
        /// Default constructor for de-serialization
        /// </summary>
        public EidoLogEvent()
        {
            logEventType = "EidoLogEvent";
        }
    }
}
