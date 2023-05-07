/////////////////////////////////////////////////////////////////////////////////////
//  File:   IncidentIdArray.cs                                      16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Class for returning an Incident Tracking Identifiers. See Section 4.12.3.5 and E.8.1 of 
    /// NENA-STD-010.3.
    /// </summary>
    public class IncidentIdArray
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
        /// Array of Incident Tracking Identifiers. Required.
        /// </summary>
        public List<string> incidentIds = new List<string>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IncidentIdArray()
        {
        }
    }
}
