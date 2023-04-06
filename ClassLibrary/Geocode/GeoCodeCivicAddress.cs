/////////////////////////////////////////////////////////////////////////////////////
//  File:   GeoCodeCivicAddress.cs                                  19 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Geocode
{
    /// <summary>
    /// Data class used by a Geocode Conversion Service (GCS) for returning a Civic Address for
    /// a reverse geocode request.
    /// See Section 4.5.2 and Section E.5.1 of NENA-STA-010.3.
    /// </summary>
    public class GeoCodeCivicAddress
    {
        /// <summary>
        /// Contains the PIDF-LO XML document as a string. Contains the CivicAddress.
        /// Conditional.
        /// </summary>
        public string pidfLoAddress { get; set; }

        /// <summary>
        /// URI of another Geocode Conversion Service to query if the pidfLoAddress property is not 
        /// provided. Conditional.
        /// </summary>
        public string gcsReferralUri { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeoCodeCivicAddress()
        {
        }
    }
}
