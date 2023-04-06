/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocatorRecordUriArray.cs                                17 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AgencyLocator
{
    /// <summary>
    /// Used by a Agency Locator Service to return an array of agency locator URIs.
    /// See Section 4.15.3 and E.10.1 of NENA-STA-010.3.
    /// </summary>
    public class LocatorRecordUriArray
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
        /// Array of Locator URI objects. Required.
        /// </summary>
        public List<LocatorRecordUri> locatorUris = new List<LocatorRecordUri>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocatorRecordUriArray() 
        {
        }
    }
}
