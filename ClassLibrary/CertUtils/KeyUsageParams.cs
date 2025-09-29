/////////////////////////////////////////////////////////////////////////////////////
//  File:   KeyUsageParams.cs                                       20 Feb 23 PHR
//  Revised:    29 Sep 25 PHR
//              - Added the codeSigning property
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911CertUtils;

/// <summary>
///  Parameters for specifying the allowed uses for an X.509 certificate.
/// </summary>
public class KeyUsageParams
{
    /// <summary>
    /// The key can be used to sign a certificate revocation list (CRL).
    /// </summary>
    public bool crlSign { get; set; } = false;

    /// <summary>
    /// The key can be used for data encryption.
    /// </summary>
    public bool dataEncipherment { get; set; } = true;

    /// <summary>
    /// The key can be used for decryption only.
    /// </summary>
    public bool decipherOnly { get; set; } = false;

    /// <summary>
    /// The key can be used as a digital signature.
    /// </summary>
    public bool digitalSignature { get; set; } = true;

    /// <summary>
    /// The key can be used for encryption only.
    /// </summary>
    public bool encipherOnly { get; set; } = false;

    /// <summary>
    /// The key can be used to determine key agreement, such as a key created using 
    /// the Diffie-Hellman key agreement algorithm.
    /// </summary>
    public bool keyAgreement { get; set; } = false;

    /// <summary>
    /// The key can be used to sign certificates.
    /// </summary>
    public bool keyCertSign { get; set; } = false;

    /// <summary>
    /// The key can be used for key encryption.
    /// </summary>
    public bool keyEncipherment { get; set; } = false;

    /// <summary>
    /// The public key can be used to verify digital signatures other than signatures on certificates.
    /// </summary>
    public bool nonRepudiation { get; set; } = true;

    /// <summary>
    /// The certificate can be used for authenticating as a client.
    /// </summary>
    public bool clientAuthentication { get; set; } = true;

    /// <summary>
    /// The certificate can be used for authenticating as a server
    /// </summary>
    public bool serverAuthentication { get; set; } = true;

    /// <summary>
    /// The certificate can be used for code signing. The digitalSignature usage parameter must also be true.
    /// </summary>
    public bool codeSigning { get; set; } = false;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public KeyUsageParams()
    {
    }
}
