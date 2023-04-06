/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogEventIdArray.cs                                      16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Class for returning an array of log event IDs in response to a query from the logging service.
    /// </summary>
    public class LogEventIdArray
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
        /// Array of LogEvent IDs. Required.
        /// </summary>
        public List<string> logEventIds = new List<string>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogEventIdArray()
        {
        }
    }
}
