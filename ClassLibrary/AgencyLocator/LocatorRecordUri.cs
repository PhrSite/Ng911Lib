/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocatorRecordUri.cs                                     17 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AgencyLocator
{
    /// <summary>
    /// Data class that contains information about an agency or service.
    /// See Sections 4.15.3 and E.10.1 of NENA-STA-010.3.
    /// </summary>
    public class LocatorRecordUri
    {
        /// <summary>
        /// URI of a Locator Record or another Service/Agency Locator. Required.
        /// </summary>        
        public string uri { get; set; }

        /// <summary>
        /// Name of Service or Agency whose URI is returned.
        /// Required.
        /// </summary>
        public string serviceAgencyName { get; set; }

        /// <summary>
        /// Must be set to one of: RecordUri, ReferralUri.
        /// Required.
        /// </summary>
        public string uriType { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocatorRecordUri()
        {
        }
    }
}
