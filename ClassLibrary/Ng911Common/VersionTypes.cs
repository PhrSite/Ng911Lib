/////////////////////////////////////////////////////////////////////////////////////
//  File:   VersionTypes.cs                                         13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911Common
{
    /// <summary>
    /// Class for the VersionsArray type described in Appendix E.11.4.1 of NENA-STA-010.3. Also see 
    /// Section 2.8.3 of NENA-STA-010.3.
    /// </summary>
    public class VersionsArrayType
    {
        /// <summary>
        /// The “fingerprint” string is intended to contain a unique string for a particular code set 
        /// (e.g., a build identifier). 
        /// Optional.
        /// </summary>
        public string fingerprint { get; set; }

        /// <summary>
        /// Contains an array of information for each version supported by the server.
        /// Required.
        /// </summary>
        public List<VersionItemType> versions { get; set; } = new List<VersionItemType>();
    }

    /// <summary>
    /// Class containing the information about an I3V3 version of a service.
    /// </summary>
    public class VersionItemType
    {
        /// <summary>
        /// Major version number.
        /// Required.
        /// </summary>
        public int major { get; set; } = 1;

        /// <summary>
        /// Minor version number.
        /// Required.
        /// </summary>
        public int minor { get; set; } = 0;

        /// <summary>
        /// Not defined in NENA-STA-010.3.
        /// Optional.
        /// </summary>
        public string vendor { get; set; }

        /// <summary>
        /// Contains service-specific information.
        /// Optional.
        /// </summary>
        public VersionServiceInfoType serviceInfo { get; set; } = new VersionServiceInfoType();
    }

    /// <summary>
    /// Class for the service-specific information.
    /// </summary>
    public class VersionServiceInfoType
    {
        /// <summary>
        /// Algorithms requied by the service. alg Header Parameter Values for JWS.
        /// Each item must be either "EdDSA" or "none".
        /// Optional.
        /// </summary>
        public List<string> requiredAlgorithms { get; set; } = new List<string>();

        public VersionServiceInfoType()
        {
            requiredAlgorithms.Add("none");
        }
    }
}
