/////////////////////////////////////////////////////////////////////////////////////
//  File:   ElementStateChangeLogEvent.cs                           14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the ElementStateChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged a SIP NOTIFY request is sent or received that indicates a change in an element's state.
    /// </summary>
    public class ElementStateChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the body of the notification message (SIP NOTIFY). Required.
        /// </summary>
        public string notificationContents { get; set; }

        /// <summary>
        /// Contains the new element state.
        /// </summary>
        public string StateChangeNotificationContents { get; set; }

        /// <summary>
        /// Contains the element ID (FQDN) of the element whose state changed
        /// </summary>
        public string affectedElementId { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing". Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ElementStateChangeLogEvent()
        {
            logEventType = "ElementStateChangeLogEvent";
        }
    }
}
