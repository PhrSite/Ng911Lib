/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogSignatureCertificateDiscrepancyReport.cs             22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Log Signature/Certificate Discrepancy Report. See Sections 3.7.22 and E.2.1
    /// of NENA-STA-010.3.
    /// </summary>
    public class LogSignatureCertificateDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem encountered. Must be set to the string equivalent of one of the values
        /// in the LogSignatureProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The logEventId of the LogEvent. Required.
        /// </summary>
        public string logIdentifier { get; set; }

        /// <summary>
        /// The response received when resolving the “x5u” field.
        /// Conditional: REQUIRED if Problem is BadURL.
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// The thumbprint calculated from the certificate.
        /// Conditional: REQUIRED if problem is BadThumb.
        /// </summary>
        public string thumbCalc { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogSignatureCertificateDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of problems for the Log Signature/Certificate Discrepancy Report.
    /// </summary>
    public enum LogSignatureProblemEnum
    {
        /// <summary>
        /// (“alg” header was not set to “ES256”.
        /// </summary>
        BadAlgorithm,

        /// <summary>
        /// Neither the “x5u” nor “x5c” fields present
        /// </summary>
        NoCert,

        /// <summary>
        /// Unable to resolve the “x5u”.
        /// </summary>
        BadURL,

        /// <summary>
        /// An “x5u” field was present, but the “x5t#S256” field is either missing or doesn’t match the 
        /// certificate obtained by resolving the “x5u” field 
        /// </summary>
        BadThumb,

        /// <summary>
        /// Invalid certificate in the “x5c” field.
        /// </summary>
        BadCertX5c,

        /// <summary>
        /// Invalid certificate obtained via the “x5u” field.
        /// </summary>
        BadCertX5u,

        /// <summary>
        /// Unable to verify the signature.
        /// </summary>
        BadSignature,

        /// <summary>
        /// Some other problem.
        /// </summary>
        OtherLogSignature
    }

}
