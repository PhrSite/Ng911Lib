/////////////////////////////////////////////////////////////////////////////////////
//  File:   DistinguishedNameParams.cs                              20 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911CertUtils
{
    /// <summary>
    /// Data (model) class for the parameters for building the distinguished name of the Subject
    /// extension of an X.509 certificate.
    /// </summary>
    public class DistinguishedNameParams
    {
        /// <summary>
        /// Specified the common name (CN) component of the distinguished name of the certificate.
        /// Required.
        /// </summary>
        public string commonName { get; set; }

        /// <summary>
        /// Specifies the country component (C) of the holder of the certificate.
        /// If specified (non-null) then this field must contain a 2-digit country code.
        /// Optional.
        /// </summary>
        public string countryOrRegion { get; set; } = "US";

        /// <summary>
        /// Specifies the domain component (DC) of the holder of the certificate. If specified (non-null)
        /// then this field must contain a valid Fully Qualified Domain Name (FQDN).
        /// Optional.
        /// </summary>
        public string domainComponent { get; set; }

        /// <summary>
        /// Specifies the email address component (E) of the holder of the certificate. If specified,
        /// (non-null) then this field must be a valid email address.
        /// Optional.
        /// </summary>
        public string emailAddress { get; set; }

        /// <summary>
        /// Specifies the state or province name (S) of the holder of the certificate.
        /// Optional.
        /// </summary>
        public string stateOrProvinceName { get; set; }

        /// <summary>
        /// Specifies the locality or city name component (L) of the holder of the certificate.
        /// Optional.
        /// </summary>
        public string localityOrCityName { get; set; }

        /// <summary>
        /// Specifies the organization name component (O) of the holder of the certificate.
        /// Optional.
        /// </summary>
        public string organizationName { get; set; }

        /// <summary>
        /// Specifies the organization unit component (OU) of the holder of the certificate.
        /// Optional.
        /// </summary>
        public string organizationalUnitName { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DistinguishedNameParams()
        {
        }
    }
}
