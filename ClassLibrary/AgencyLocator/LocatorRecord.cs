/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocatorRecord.cs                                        17 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AgencyLocator
{
    /// <summary>
    /// Data class that contains information about an agency. See Section 4.15.4 and Section E.10.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class LocatorRecord
    {
        /// <summary>
        /// ID of this record at this Service/Agency Locator. Required.
        /// </summary>
        public string recordId { get; set; }

        /// <summary>
        /// Service ID or Agency ID of the Service or Agency. Required.
        /// </summary>
        public string serviceAgencyId { get; set; }

        /// <summary>
        /// Official name of Service or Agency. Required
        /// </summary>
        public string serviceAgencyName { get; set; }

        /// <summary>
        /// Service operator or Agency Contact information. The name of the service or agency is found in 
        /// the first ‘org’ field of the jCard. Required.
        /// </summary>
        public string serviceAgencyJcard { get; set; }

        /// <summary>
        /// Array of Service or Agency Type (psap, police, fire, …). Required.
        /// </summary>
        public List<string> serviceAgencyTypes = new List<string>();

        /// <summary>
        /// Interface where 9-1-1 SIP calls are accepted. Required.
        /// </summary>
        public string emergencySipInterfaceUri { get; set; }

        /// <summary>
        /// URI (sip or tel) containing 10 digit admin line #, see Section 4.2.1.1 of NENA-STA-010.3.
        /// </summary>
        public string adminLineUri { get; set; }

        /// <summary>
        /// Service or Agency Logging Service interface, see Section 4.12.1 of NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string loggerUri { get; set; }

        /// <summary>
        /// EIDO Interface URI, See Section 4.12.1 of NENA-010.3.
        /// </summary>
        public string eidoInterfaceUri { get; set; }

        /// <summary>
        /// MappingDataService Web Feature Service interface
        /// </summary>
        public string mdsFeatureInterfaceUri { get; set; }

        /// <summary>
        /// MappingDataService Web Map Service interface.
        /// </summary>
        public string mdsImageInterfaceUri { get; set; }

        /// <summary>
        /// Service state Subscription URI for a service, such as the PSAP service.
        /// </summary>
        public string svcStateUri { get; set; }

        /// <summary>
        /// Discrepancy Report Service URI, see Section 3.7 of NENA-STA-010.3.
        /// </summary>
        public string dscRptUri { get; set; }

        /// <summary>
        /// jCard of top agency or service operator official.
        /// </summary>
        public string headJcard { get; set; }

        /// <summary>
        /// jCard of supervisor on duty now.
        /// </summary>
        public string onDutySuperJcard { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LocatorRecord()
        {
        }
    }
}
