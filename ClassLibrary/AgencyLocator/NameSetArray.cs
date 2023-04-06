/////////////////////////////////////////////////////////////////////////////////////
//  File:   NameSetArray.cs                                         17 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AgencyLocator
{
    /// <summary>
    /// Data class for returning an array of agency name sets from an Agency Locator service.
    /// See Section 4.15.5 and Section E.10.1 or NENA-010.3.
    /// </summary>
    public class NameSetArray
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
        /// Array of Name Sets objects. Required
        /// </summary>
        public List<NameSet> nameSets = new List<NameSet>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public NameSetArray()
        {
        }
    }
}
