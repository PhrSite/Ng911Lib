/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogEventContainerArray.cs                               16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class used by a logging service to return the results of a query for log events.
    /// See Section 4.12.3.1.1 and Section E.8.1 of NENA-STA-010.3.
    /// </summary>
    public class LogEventContainerArray
    {
        /// <summary>
        /// Number of items in the array. Required.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Total number of items found. Required.
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// Array of LogEvent Container objects. Required.
        /// </summary>
        public List<LogEventContainer> logEventContainers = new List<LogEventContainer>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogEventContainerArray()
        {
        }
    }
}
