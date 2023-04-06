/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallIdArray.cs                                          16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3LogEvents
{
    /// <summary>
    /// Class for returning an array of Call IDs when querying a logging service.
    /// </summary>
    public class CallIdArray
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
        /// Array of Call IDs. Required.
        /// </summary>
        public List<string> callIds = new List<string>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallIdArray()
        {
        }
    }
}
