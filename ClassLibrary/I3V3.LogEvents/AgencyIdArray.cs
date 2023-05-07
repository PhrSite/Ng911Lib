/////////////////////////////////////////////////////////////////////////////////////
//  File:   AgencyIdArray.cs                                        16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Class for returning an array of Agency Identifiers from a logging service.
    /// </summary>
    public class AgencyIdArray
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
        /// Array of Agency IDs. Required.
        /// </summary>
        public List<string> agencyIds = new List<string>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AgencyIdArray()
        {
        }
    }
}
