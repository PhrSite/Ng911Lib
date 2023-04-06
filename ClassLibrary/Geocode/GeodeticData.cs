/////////////////////////////////////////////////////////////////////////////////////
//  File:   GeodeticData.cs                                         19 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Geocode
{
    /// <summary>
    /// Data class used by the Geocode Conversion Service to return geodetic data in response to a
    /// Geocode Request. See Section 4.5.1 and Section E.5.1 of NENA-STA-010.3.
    /// </summary>
    public class GeodeticData
    {
        /// <summary>
        /// Contains the PIDF-LO XML document that contains a geodetic location if available.
        /// </summary>
        public string pidfLoGeo { get; set; }

        /// <summary>
        /// URI of another Geocode Conversion Service to query if the pidfLoGeo property is not provided.
        /// </summary>
        public string gcsReferralUri { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeodeticData()
        {
        }
    }
}
