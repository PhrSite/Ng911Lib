/////////////////////////////////////////////////////////////////////////////////////
//  File:   CertUtils.cs                                            16 Feb 23 PHR
//
//  Revised:    24 Jul 25 PHR
//              - Changed from using new X509Certificate2() to X509CertificateLoader.
//                LoadPkcs12() because loading a certificate in the constructor is
//                now obsolete.
//              28 Sep 25 PHR
//              - Added support for the Code Signing Enhanced Key Usage Extension for
//                an X.509 certificate.
/////////////////////////////////////////////////////////////////////////////////////

using System.Security.Cryptography.X509Certificates;
using System.Formats.Asn1;
using System.Text;
using System.Security.Cryptography;

namespace Ng911CertUtils;

/// <summary>
/// Static class containing miscellaneous fuctions for using X.509 certificates in an NG9-1-1 system.
/// </summary>
public static class CertUtils
{
    /// <summary>
    /// ASN.1 Object ID (OID) for the Subject Alternate Name X.509 certificate extension.
    /// </summary>
    private const string SAN_OID = "2.5.29.17";

    private const string ClientAuthenticationOid = "1.3.6.1.5.5.7.3.2";
    private const string ServerAuthenticationOid = "1.3.6.1.5.5.7.3.1";

    // 28 Sep 25 PHR
    private const string CodeSigningOid = "1.3.6.1.5.5.7.3.3";

    /// <summary>
    /// Quad for valid OtherName values for SubjectAlternativeName extension required in all NG9-1-1 
    /// PKI certificates.
    /// Defined in Section 1.2.2 of the PCA Certificate Policy document.
    /// </summary>
    private const string OtherNameOid = "1.3.6.1.4.1.55670.1.1";

    /// <summary>
    /// In NG9-1-1, the otherName sequence within the Subject Alternate Name (SAN) certificate
    /// extension is used to pass the identity and roles roles of an entity. This function
    /// reads an X.509 certificate and extracts this information from it.
    /// See Section 7.1.2.11 of "Public Safety Answering Point (PSAP) Credentialing Agency (PCA) 
    /// Certificate Policy, v1.01" and Section 4.2.1.6 of RFC 5280.
    /// </summary>
    /// <param name="Cert">Input certificate.</param>
    /// <returns>Returns a Ng911SanParameters object containing the identity and roles in
    /// the X.509 certificate.</returns>
    /// <exception cref="AsnContentException"></exception>
    public static Ng911SanParams GetOtherNameParams(X509Certificate2 Cert)
    {
        Ng911SanParams NgSan = null;
        X509Extension SanExt = Cert.Extensions[SAN_OID];
        if (SanExt == null)
            throw new ArgumentException("No Subject Alternate Name extension in this certificate");

        AsnReader SanRdr = new AsnReader(SanExt.RawData, AsnEncodingRules.BER);
        if (SanRdr.HasData == false)
            throw new ArgumentException("Unable to read the Subject Alternate Name extension");

        ReadOnlyMemory<byte> EncodedSanRdr = SanRdr.PeekEncodedValue();

        try
        {
            Asn1Tag SanTag = SanRdr.PeekTag();
            AsnReader asnReader = new AsnReader(SanExt.RawData, AsnEncodingRules.BER);
            // Move down to the GeneralNames sequence. See page 38 of RFC 5280.
            Asn1Tag GnTag = asnReader.PeekTag();
            AsnReader GenNamesReader = asnReader.ReadSequence();

            while (GenNamesReader.HasData == true)
            {
                Asn1Tag Tag = GenNamesReader.PeekTag();
                if (Tag.TagValue != 0)
                {   // A tag value of 0 is for an otherName object sequence
                    GenNamesReader.ReadEncodedValue();
                    continue;
                }

                AsnReader OtherNameRdr = GenNamesReader.ReadSequence(Tag);
                Tag = OtherNameRdr.PeekTag();
                if (Tag.TagClass == TagClass.Universal && Tag.TagValue == 6)
                {   // The next object is expected to be an Object Identirier (OID)
                    NgSan = new Ng911SanParams();
                    NgSan.strOid = OtherNameRdr.ReadObjectIdentifier();

                    // The next object is expected to be a UTF8String
                    // This throws an exception even though the content bytes is a UTF8String (0x0c).
                    //str = OtherNameRdr.ReadCharacterString(UniversalTagNumber.UTF8String);
                    // So its necessary to do it this way.
                    ReadOnlyMemory<byte> Rom = OtherNameRdr.PeekContentBytes();

                    int BytesConsumed;
                    string str = AsnDecoder.ReadCharacterString(Rom.Span, AsnEncodingRules.BER,
                        UniversalTagNumber.UTF8String, out BytesConsumed);
                    string[] Fields = str.Split(new char[] { '/' }, StringSplitOptions.
                        RemoveEmptyEntries);
                    if (Fields == null || Fields.Length < 3)
                        throw new ArgumentException("The otherName string is not valid");

                    NgSan.idType = Fields[0];
                    NgSan.iD = Fields[1];

                    string[] Roles = Fields[2].Split(new char[] { ',' }, StringSplitOptions.
                        RemoveEmptyEntries);
                    if (Roles != null && Roles.Length > 0)
                    {
                        foreach (string strRole in Roles)
                            NgSan.roles.Add(strRole);
                    }

                    if (Fields.Length >= 4)
                        NgSan.owner = Fields[3];
                }
            }
        }
        catch (AsnContentException) { throw; }

        return NgSan;
    }

    /// <summary>
    /// Adds the Subject Alternate Name (SAN) extension to a CertificateRequest that contains the
    /// otherName sequence that contains the ID type, ID, roles and owner information for building
    /// a new X.509 certificate for use in NG9-1-1 systems.
    /// See Section 7.1.2.11 of "Public Safety Answering Point (PSAP) Credentialing Agency (PCA) 
    /// Certificate Policy, v1.01" and Section 4.2.1.6 of RFC 5280.
    /// </summary>
    /// <param name="Params">Input parameters to use to build the otherName sequence to add to the
    /// SAN extension.</param>
    /// <param name="req">Input CertificateRequest to add the SAN extension to.</param>
    public static void AddNg911San(Ng911SanParams Params, CertificateRequest req)
    {
        if (Params == null)
            return;

        string strOtherNameString = BuildNg911OtherNameString(Params);

        AsnWriter Aw = new AsnWriter(AsnEncodingRules.BER);

        Asn1Tag SanTag = new Asn1Tag(UniversalTagNumber.SequenceOf, true);
        Aw.PushSequence(SanTag);
        Asn1Tag GenNameTag = new Asn1Tag(TagClass.ContextSpecific, 0, true);
        Aw.PushSequence(GenNameTag);
        Aw.WriteObjectIdentifier(OtherNameOid);
        Asn1Tag OtherNameTag = new Asn1Tag(TagClass.ContextSpecific, 0, true);
        Aw.PushSequence(OtherNameTag);
        Aw.WriteCharacterString(UniversalTagNumber.UTF8String, strOtherNameString);
        Aw.PopSequence(OtherNameTag);
        Aw.PopSequence(GenNameTag);
        Aw.PopSequence(SanTag);

        byte[] RawBytes = Aw.Encode();

        X509Extension San = new X509Extension(SAN_OID, RawBytes, false);
        req.CertificateExtensions.Add(San);
    }

    private static string BuildNg911OtherNameString(Ng911SanParams Params)
    {
        StringBuilder Sb = new StringBuilder();
        Sb.AppendFormat("{0}/{1}/", Params.idType, Params.iD);
        for (int i = 0; i < Params.roles.Count; i++)
        {
            Sb.Append(Params.roles[i]);
            if (i < Params.roles.Count-1)
                Sb.Append(",");
        }

        // The owner field is optional
        if (string.IsNullOrEmpty(Params.owner) == false)
            Sb.AppendFormat("/{0}", Params.owner);

        return Sb.ToString();
    }

    /// <summary>
    /// Builds an X500DistinguishedName object. This is a helper method for build new X.509
    /// certificates.
    /// </summary>
    /// <param name="Dnp">Input parameters</param>
    /// <returns>Returns a new X500DistinguishedName object.</returns>
    /// <exception cref="ArgumentException">Thrown if the commonName field is null or empty
    /// or if the countryOrRegion field is specified but the length is not 2 characters.</exception>
    private static X500DistinguishedName BuildDistinguishedName(DistinguishedNameParams Dnp)
    {
        if (string.IsNullOrEmpty(Dnp.commonName) == true)
            throw new ArgumentException("The commonName field must be specified");

        if (string.IsNullOrEmpty(Dnp.countryOrRegion) == false && Dnp.countryOrRegion.Length != 2)
            throw new ArgumentException("The countryOrRegion length must be 2 characters only");

        X500DistinguishedNameBuilder Dnb = new X500DistinguishedNameBuilder();
        Dnb.AddCommonName(Dnp.commonName);

        if (string.IsNullOrEmpty(Dnp.countryOrRegion) == false)
            Dnb.AddCountryOrRegion(Dnp.countryOrRegion);

        if (string.IsNullOrEmpty(Dnp.domainComponent) == false)
            Dnb.AddDomainComponent(Dnp.domainComponent);

        if (string.IsNullOrEmpty(Dnp.emailAddress) == false)
            Dnb.AddEmailAddress(Dnp.emailAddress);

        if (string.IsNullOrEmpty(Dnp.stateOrProvinceName) == false)
            Dnb.AddStateOrProvinceName(Dnp.stateOrProvinceName);

        if (string.IsNullOrEmpty(Dnp.localityOrCityName) == false)
            Dnb.AddLocalityName(Dnp.localityOrCityName);

        if (string.IsNullOrEmpty(Dnp.organizationName) == false)
            Dnb.AddOrganizationName(Dnp.organizationName);

        if (string.IsNullOrEmpty(Dnp.organizationalUnitName) == false)
            Dnb.AddOrganizationalUnitName(Dnp.organizationalUnitName);

        return Dnb.Build();
    }

    private static void AddKeyUsageExtensions(CertificateRequest req, KeyUsageParams Kup)
    {
        X509KeyUsageFlags flags = X509KeyUsageFlags.None;
        if (Kup.crlSign == true)
            flags |= X509KeyUsageFlags.CrlSign;

        if (Kup.dataEncipherment == true)
            flags |= X509KeyUsageFlags.DataEncipherment;

        if (Kup.decipherOnly == true)
            flags |= X509KeyUsageFlags.DecipherOnly;

        // 28 Sep 25 PHR
        // If codeSigning is true, then digitalSignature must also be true.
        if (Kup.digitalSignature == true || Kup.codeSigning == true)
        //if (Kup.digitalSignature == true)
            flags |= X509KeyUsageFlags.DigitalSignature;

        if (Kup.encipherOnly == true)
            flags |= X509KeyUsageFlags.EncipherOnly;

        if (Kup.keyAgreement == true)
            flags |= X509KeyUsageFlags.KeyAgreement;

        if (Kup.keyCertSign == true)
            flags |= X509KeyUsageFlags.KeyCertSign;

        if (Kup.keyEncipherment == true)
            flags |= X509KeyUsageFlags.KeyEncipherment;

        if (Kup.nonRepudiation == true)
            flags |= X509KeyUsageFlags.NonRepudiation;

        req.CertificateExtensions.Add(new X509KeyUsageExtension(flags, false));

        if (Kup.clientAuthentication == true || Kup.serverAuthentication == true || Kup.codeSigning == true)
        {
            OidCollection Oc = new OidCollection();
            if (Kup.clientAuthentication == true)
                Oc.Add(new Oid(ClientAuthenticationOid, "Client Authentication"));
            if (Kup.serverAuthentication == true)
                Oc.Add(new Oid(ServerAuthenticationOid, "Server Authentication"));

            // 28 Sep 25 PHR
            if (Kup.codeSigning == true)
                Oc.Add(new Oid(CodeSigningOid, "Code Signing"));

            X509EnhancedKeyUsageExtension ext1 = new X509EnhancedKeyUsageExtension(Oc, false);
            req.CertificateExtensions.Add(ext1);
        }
    }

    /// <summary>
    /// Creates a RSA self-signed X.509 certificates containing a private key. This function
    /// writes the certificate containing a private key to a *.pfx file and the certificate
    /// without the private key to a *.cer file.
    /// This function creates an RSA key that is 2048 bits in length and uses the SHA 512 bit
    /// hash algorithm.
    /// </summary>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="ExpiresYears">Specifies the number of years that the certificate will
    /// be valid for.</param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="strDir">Directory in which to save the certificate files. Must already
    /// exist.</param>
    /// <param name="strFileNameNoExtension">File name for the files with no extension.</param>
    /// <param name="IsCa">If true then the self-signed certificate can be used to sign other
    /// certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    public static void CreateRsaSelfSignedCertificate(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw, string strDir,
        string strFileNameNoExtension, bool IsCa, out Exception Ex)
    {
        Ex = null;
        try
        {
            byte[] CertBytes = CreateRsaSelfSignedByteArray(Dnp, Kup, Nsp, ExpiresYears, strPw, IsCa,
                out Ex);
            if (CertBytes != null)
            {
                // Save it as a PFX file
                File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".pfx"), CertBytes);
                // Save it as a CER file
                //X509Certificate2 Cert1 = new X509Certificate2(CertBytes, strPw);
                // 24 Jul 25 PHR
                X509Certificate2 Cert1 = X509CertificateLoader.LoadPkcs12(CertBytes, strPw);
                CertBytes = Cert1.GetRawCertData();
                File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".cer"), CertBytes);
            }
        }
        catch (ArgumentException Ae) { Ex = Ae; }
        catch (Exception E) { Ex = E; }
    }

    /// <summary>
    /// Creates a RSA self-signed X.509 certificate with a private key.
    /// This function creates an RSA key that is 2048 bits in length and uses the SHA 512 bit
    /// hash algorithm.
    /// </summary>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="ExpiresYears">Specifies the number of years that the certificate will
    /// be valid for.</param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="IsCa">If true then the self-signed certificate can be used to sign other
    /// certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught. If this output is non-null, the return value will be null.</param>
    /// <returns>Returns a new X.509 certificate with a private key. Set to null if the Ex
    /// output parameter is non-null.</returns>
    public static X509Certificate2 CreateRsaSelfSignedCertificate(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw, bool IsCa,
        out Exception Ex)
    {
        Ex = null;
        byte[] CertBytes = CreateRsaSelfSignedByteArray(Dnp, Kup, Nsp, ExpiresYears, strPw, IsCa,
            out Ex);
        //X509Certificate2 Cert = new X509Certificate2(CertBytes, strPw, X509KeyStorageFlags.Exportable);
        // 24 Jul 25 PHR
        X509Certificate2 Cert = X509CertificateLoader.LoadPkcs12(CertBytes, strPw, X509KeyStorageFlags.Exportable,
            null);
        return Cert;
    }

    private static byte[] CreateRsaSelfSignedByteArray(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw, bool IsCa,
        out Exception Ex)
    {
        Ex = null;
        RSA rsa = RSA.Create(2048);
        X500DistinguishedName Dn = BuildDistinguishedName(Dnp);
        CertificateRequest req = new CertificateRequest(Dn, rsa, HashAlgorithmName.SHA512,
            RSASignaturePadding.Pkcs1);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(IsCa, false, 2, false));
        AddKeyUsageExtensions(req, Kup);

        if (Nsp != null)
            AddNg911San(Nsp, req);

        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

        DateTime Start = DateTime.UtcNow - TimeSpan.FromDays(1);
        DateTime End = Start + TimeSpan.FromDays(ExpiresYears * 365);
        // CreateSelfSigned adds a private key
        X509Certificate2 Cert1;
        byte[] CertBytes;
        try
        {
            Cert1 = req.CreateSelfSigned(Start, End);
            CertBytes = Cert1.Export(X509ContentType.Pkcs12, strPw);
        }
        catch (ArgumentException Ae)
        {
            Ex = Ae;
            return null;
        }
        catch (Exception E)
        {
            Ex = E;
            return null;
        }

        return CertBytes;
    }

    /// <summary>
    /// Creates an ECDSA (Elliptic Curve Digital Signature Algorithm) self-signed X.509 certificate 
    /// with a private key.
    /// </summary>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="ExpiresYears">Specifies the number of years that the certificate will
    /// be valid for.</param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="IsCa">If true then the self-signed certificate can be used to sign other
    /// certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    /// <returns>Returns a new X.509 certificate with a private key. Set to null if the Ex
    /// output parameter is non-null.</returns>
    public static X509Certificate2 CreateEcdsaSelfSignedCertificate(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw, bool IsCa, 
        out Exception Ex)
    {
        Ex = null;
        byte[] CertBytes = CreateEcdsaSelfSignedByteArray(Dnp, Kup, Nsp, ExpiresYears, strPw, IsCa,
            out Ex);
        if (CertBytes != null)
        {
            //X509Certificate2 Cert = new X509Certificate2(CertBytes, strPw, X509KeyStorageFlags.
            //    Exportable);
            // 24 Jul 25 PHR
            X509Certificate2 Cert = X509CertificateLoader.LoadPkcs12(CertBytes, strPw, X509KeyStorageFlags.Exportable,
                null);
            return Cert;
        }
        else
            return null;
    }

    /// <summary>
    /// Creates an ECDSA self-signed X.509 certificate with a private key. This function
    /// writes the certificate containing a private key to a *.pfx file and the certificate
    /// without the private key to a *.cer file.
    /// </summary>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="ExpiresYears">Specifies the number of years that the certificate will
    /// be valid for.</param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="strDir">Directory in which to save the certificate files. Must already
    /// exist.</param>
    /// <param name="strFileNameNoExtension">File name for the files with no extension.</param>
    /// <param name="IsCa">If true then the self-signed certificate can be used to sign other
    /// certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    public static void CreateEcdsaSelfSignedCertificate(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw,
        string strDir, string strFileNameNoExtension, bool IsCa, out Exception Ex)
    {
        Ex = null;
        byte[] CertBytes = CreateEcdsaSelfSignedByteArray(Dnp, Kup, Nsp, ExpiresYears, strPw, IsCa,
            out Ex);
        if (CertBytes != null)
        {
            // Save it as a PFX file
            File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".pfx"), CertBytes);
            // Save it as a CER file
            //X509Certificate2 Cert1 = new X509Certificate2(CertBytes, strPw);
            // 24 Jul 24 PHR
            X509Certificate2 Cert1 = X509CertificateLoader.LoadPkcs12(CertBytes, strPw);
            CertBytes = Cert1.GetRawCertData();
            File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".cer"), CertBytes);
        }
    }

    /// <summary>
    /// Creates an ECDSA (Elliptic Curve Digital Signature Algorithm) signed X.509 certificate 
    /// with a private key.
    /// </summary>
    /// <param name="Root">X.509 certificate to use for signing the new certificate.</param>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="IsCa">If true then the certificate can be used to sign other certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    /// <returns>A signed X.509 certificate with a private key. Returns null if an exception
    /// occured.</returns>
    public static X509Certificate2 CreateEcdsaSignedCertificate(X509Certificate2 Root, 
        DistinguishedNameParams Dnp, KeyUsageParams Kup, Ng911SanParams Nsp, bool IsCa,
        out Exception Ex)
    {
        Ex = null;
        ECDsa ecdsa = ECDsa.Create();
        X500DistinguishedName Dn = BuildDistinguishedName(Dnp);
        CertificateRequest req = new CertificateRequest(Dn, ecdsa, HashAlgorithmName.SHA512);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(IsCa, false, 2, false));
        AddKeyUsageExtensions(req, Kup);
        if (Nsp != null)
            AddNg911San(Nsp, req);

        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));
        X509AuthorityKeyIdentifierExtension Aki = X509AuthorityKeyIdentifierExtension.
            CreateFromCertificate(Root, true, true);
        req.CertificateExtensions.Add(Aki);

        DateTime Start = Root.NotBefore + TimeSpan.FromHours(1);
        DateTime End = Root.NotAfter - TimeSpan.FromHours(1);
        byte[] SerialNumber = Guid.NewGuid().ToByteArray();
        X509Certificate2 Cert1;
        X509Certificate2 Cert2;
        try
        {
            Cert1 = req.Create(Root, Start, End, SerialNumber);
            // Creates a private key from the public key
            Cert2 = Cert1.CopyWithPrivateKey(ecdsa);
        }
        catch (ArgumentException Ae)
        {
            Ex = Ae;
            return null;
        }
        catch (Exception E)
        {
            Ex = E;
            return null;
        }

        return Cert2;
    }

    /// <summary>
    /// Creates an ECDSA (Elliptic Curve Digital Signature Algorithm) signed X.509 certificate.
    /// This function writes the certificate containing a private key to a *.pfx file and the 
    /// certificate without the private key to a *.cer file.
    /// </summary>
    /// <param name="Root">X.509 certificate to use for signing the new certificate.</param>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that will be
    /// used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="strPw">Password for the private key of the certificate.</param>
    /// <param name="strDir">Directory in which to store the certificate files.</param>
    /// <param name="fileNameNoExtension">Filename with no extension for the certificate files.</param>
    /// <param name="IsCa">If true then the certificate can be used to sign other certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    public static void CreateEcdsaSignedCertificate(X509Certificate2 Root,
        DistinguishedNameParams Dnp, KeyUsageParams Kup, Ng911SanParams Nsp, string strPw,
        string strDir, string fileNameNoExtension, bool IsCa, out Exception Ex)
    {
        Ex = null;
        X509Certificate2 Cert1 = CreateEcdsaSignedCertificate(Root, Dnp, Kup, Nsp, IsCa, out Ex);
        if (Cert1 == null)
            return;

        try
        {
            byte[] Cert1Bytes = Cert1.Export(X509ContentType.Pkcs12, strPw);
            File.WriteAllBytes(Path.Combine(strDir, fileNameNoExtension + ".pfx"), Cert1Bytes);
            byte[] RawBytes = Cert1.GetRawCertData();
            File.WriteAllBytes(Path.Combine(strDir, fileNameNoExtension + ".cer"), RawBytes);
        }
        catch (ArgumentException Ae) { Ex = Ae;}
        catch (Exception E) { Ex = E; }
    }

    private static byte[] CreateEcdsaSelfSignedByteArray(DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, int ExpiresYears, string strPw, bool IsCa,
        out Exception Ex)
    {
        Ex = null;
        ECDsa ecdsa = ECDsa.Create();

        X500DistinguishedName Dn = BuildDistinguishedName(Dnp);
        CertificateRequest req = new CertificateRequest(Dn, ecdsa, HashAlgorithmName.SHA512);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(IsCa, false, 2, false));
        AddKeyUsageExtensions(req, Kup);

        if (Nsp != null)
            AddNg911San(Nsp, req);

        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));

        DateTime Start = DateTime.UtcNow - TimeSpan.FromDays(1);
        DateTime End = Start + TimeSpan.FromDays(ExpiresYears * 365);
        // CreateSelfSigned adds a private key
        X509Certificate2 Cert1;
        byte[] CertBytes;
        try
        {
            Cert1 = req.CreateSelfSigned(Start, End);
            CertBytes = Cert1.Export(X509ContentType.Pkcs12, strPw);
        }
        catch (ArgumentException Ae)
        {
            Ex = Ae;
            return null;
        }
        catch (Exception E)
        {
            Ex = E;
            return null;
        }

        return CertBytes;
    }

    /// <summary>
    /// Creates an RSA signed X.509 certificate. This function writes the certificate containing a 
    /// private key to a *.pfx file and the certificate without the private key to a *.cer file.
    /// This function creates an RSA key that is 2048 bits in length and uses the SHA 512 bit
    /// hash algorithm.
    /// </summary>
    /// <param name="Root">X.509 certificate to use for signing the new certificate.</param>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="strDir">Directory in which to save the certificate files.</param>
    /// <param name="strFileNameNoExtension">File name for the files with no extension.</param>
    /// <param name="IsCa">If true then the certificate can be used to sign other certificates.</param>
    /// <param name="Ex">If an exception occurred then the Ex output parameter is set to the
    /// exception that was caught.</param>
    public static void CreateRsaSignedCertificate(X509Certificate2 Root, DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, string strPw, string strDir, 
        string strFileNameNoExtension, bool IsCa, out Exception Ex)
    {
        Ex = null;
        byte[] CertBytes = CreateRsaSignedByteArray(Root, Dnp, Kup, Nsp, strPw, IsCa, out Ex);

        if (CertBytes == null)
        {
            try
            {
                File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".pfx"), CertBytes);
                //X509Certificate2 Cert = new X509Certificate2(CertBytes, strPw, X509KeyStorageFlags.
                //    Exportable);
                // 24 Jul 25 PHR
                X509Certificate2 Cert = X509CertificateLoader.LoadPkcs12(CertBytes, strPw, X509KeyStorageFlags.Exportable,
                    null);
                CertBytes = Cert.GetRawCertData();
                File.WriteAllBytes(Path.Combine(strDir, strFileNameNoExtension + ".cer"), CertBytes);
            }
            catch (ArgumentException Ae) { Ex = Ae; }
            catch (Exception E) { Ex = E; }
        }
    }

    private static byte[] CreateRsaSignedByteArray(X509Certificate2 Root, DistinguishedNameParams Dnp,
        KeyUsageParams Kup, Ng911SanParams Nsp, string strPw, bool IsCa, out Exception Ex)
    {
        Ex = null;
        RSA rsa = RSA.Create(2048);
        X500DistinguishedName Dn = BuildDistinguishedName(Dnp);
        CertificateRequest req = new CertificateRequest(Dn, rsa, HashAlgorithmName.SHA512,
            RSASignaturePadding.Pkcs1);

        req.CertificateExtensions.Add(new X509BasicConstraintsExtension(IsCa, false, 2, false));
        AddKeyUsageExtensions(req, Kup);
        if (Nsp != null)
            AddNg911San(Nsp, req);

        req.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(req.PublicKey, false));
        X509AuthorityKeyIdentifierExtension Aki = X509AuthorityKeyIdentifierExtension.
            CreateFromCertificate(Root, true, true);
        req.CertificateExtensions.Add(Aki);

        DateTime Start = Root.NotBefore + TimeSpan.FromHours(1);
        DateTime End = Root.NotAfter - TimeSpan.FromHours(1);
        byte[] SerialNumber = Guid.NewGuid().ToByteArray();
        X509Certificate2 Cert1;
        X509Certificate2 Cert2;
        try
        {
            Cert1 = req.Create(Root, Start, End, SerialNumber);
            // Creates a private key from the public key
            Cert2 = Cert1.CopyWithPrivateKey(rsa);
        }
        catch (ArgumentException Ae) 
        {
            Ex = Ae;
            return null;
        }
        catch (Exception E)
        {
            Ex = E;
            return null;
        }

        return Cert2.Export(X509ContentType.Pkcs12, strPw);
    }

    /// <summary>
    /// Creates an RSA signed X.509 certificate with a private key. 
    /// This function creates an RSA key that is 2048 bits in length and uses the SHA 512 bit
    /// hash algorithm.
    /// </summary>
    /// <param name="Root">X.509 certificate to use for signing the new certificate.</param>
    /// <param name="Dnp">Contains the parameters for building the distinguished name that
    /// will be used in the Subject certificate extension.</param>
    /// <param name="Kup">Contains the parameters for the key usage extension.</param>
    /// <param name="Nsp">Contains the parameters for building the identity and roles to
    /// be contained in the otherName field of the Subject Alternate Name (SAN) certificate
    /// extension. This parameter may be null if a SAN extension is not needed.</param>
    /// <param name="IsCa">If true, then the new certificate can be used to sign other certificates
    /// </param>
    /// <param name="strPw">Password for the private key of the certificate</param>
    /// <param name="Ex">Output. Set to an exception object if an exception occurred. Null if an
    /// exception did not occur.</param>
    /// <returns>Returns a new X.509 certificate with a private key. Returns null if an
    /// exception occured.</returns>
    public static X509Certificate2 CreateRsaSignedCertificate(X509Certificate2 Root, 
        DistinguishedNameParams Dnp, KeyUsageParams Kup, Ng911SanParams Nsp, string strPw, bool IsCa,
        out Exception Ex)
    {
        Ex = null;
        byte[] CertBytes = CreateRsaSignedByteArray(Root, Dnp, Kup, Nsp, strPw, IsCa, out Ex);
        if (CertBytes == null)
            return null;
        else
            //return new X509Certificate2(CertBytes, strPw, X509KeyStorageFlags.Exportable);
            // 24 Jul 25 PHR
            return X509CertificateLoader.LoadPkcs12(CertBytes, strPw, X509KeyStorageFlags.Exportable);
    }
}
