/////////////////////////////////////////////////////////////////////////////////////
//  File:   QueueState.cs                                           12 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3V3 Queue State NOTIFY body. See Section 4.2.1.3 and Section E.11.3.3 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class QueueState
    {
        /// <summary>
        /// Contains the queue state information. Required.
        /// </summary>
        public QueueStateType queueState { get; set; } = new QueueStateType();
    }

    public class QueueStateType
    {
        /// <summary>
        /// SIP URI of queue. Required
        /// </summary>
        public string queueUri { get; set; }

        /// <summary>
        /// Integer indicating current number of calls in the queue. Required
        /// </summary>
        public int queueLength { get; set; } = 0;

        /// <summary>
        /// Integer indicating maximum length of the queue. Required
        /// </summary>
        public int queueMaxLength { get; set; } = 0;

        /// <summary>
        /// Current queue state. Required.
        /// Must be one of the values in the queueState registry. See Section 10.17 of NENA-STA-010.3.
        /// Allowed values: Active, Inactive, Disabled, Full, Standby,  ResourceExhausted, Unreachable.
        /// </summary>
        public string state { get; set; }
    }
}
