/////////////////////////////////////////////////////////////////////////////////////
//  File:   Ng911SanParams.cs                                       16 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911CertUtils
{
    /// <summary>
    /// Data class (model) for the parameters stored in the otherName field of the Subject Alternative Name 
    /// extension of a NG9-1-1 X.509 certificate. See Section 7.1.2.11 of "Public Safety Answering Point
    /// (PSAP) Credentialing Agency CPCA) Certificate Policy, v1.01".
    /// </summary>
    public class Ng911SanParams
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Ng911SanParams()
        {
        }

        /// <summary>
        /// Specifies the type of object that is being identified, such as AgentId, AgencyId, ServiceId
        /// or ElementId. See Section 2.1 of NENA-STA-010.3.
        /// Set to "CAId" if the certificate is for a Certificate Authority.
        /// </summary>
        public string idType { get; set; }

        /// <summary>
        /// Contains a URI of the entity being identified. For example: foo.allegheny.pa.us.
        /// </summary>
        public string iD { get; set; }

        /// <summary>
        /// Contains a list of roles. See Section 5.3 of NENA-STA-010.3.
        /// Note: The contents and the format of the items in this list depend upon the idType field.
        /// </summary>
        public List<string> roles { get; set; } = new List<string>();

        /// <summary>
        /// Contains the ID of the issuing agency of the certificate. For an Intermediage CA (ICA),
        /// this field shall contain the iD of the issuing CA. May be null of the certificate is for
        /// a root CA or an end entity.
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// Contains the OID (Object ID) contained in the otherName sequence.
        /// </summary>
        public string strOid { get; set; } = "1.3.6.1.4.1.55670.1.1";
    }
}
