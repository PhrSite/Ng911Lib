/////////////////////////////////////////////////////////////////////////////////////
//  File:   QueueStateChangeLogEvent.cs                             14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the QueueStateChangeLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when by a queue manager when the state of a call queue changes.
    /// </summary>
    public class QueueStateChangeLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the body of the SIP NOTIFY contents for the queue state change SIP event
        /// package.
        /// Required.
        /// </summary>
        public string notificationContents { get; set; }

        /// <summary>
        /// Must be set to the queue ID of the queue that changed state.
        /// Required.
        /// </summary>
        public string queueId { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing".
        /// Required.
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public QueueStateChangeLogEvent()
        {
            logEventType = "QueueStateChangeLogEvent";
        }
    }
}
