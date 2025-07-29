/////////////////////////////////////////////////////////////////////////////////////
//  File:   QueueStateCondition.cs                                  23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests the current state of a queue. See Sections 3.3.3.1.8 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class QueueStateCondition : ConditionBase
    {
        /// <summary>
        /// Must be set to the queue URI. Required.
        /// </summary>
        public string queue { get; set; }

        /// <summary>
        /// Must be either "EQ" or "NE". Required.
        /// </summary>
        public string condition { get; set; }

        /// <summary>
        /// Must be set to one of the values in the Queue state Registry. See Section 10.17 of 
        /// NENA-STA-010.3. Required.
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public QueueStateCondition()
        {
            conditionType = nameof(QueueStateCondition);
        }
    }

    
}
