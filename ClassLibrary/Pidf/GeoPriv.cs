/////////////////////////////////////////////////////////////////////////////////////
//	File:	GeoPriv.cs											    19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//				1 Dec 22 PHR -- changed the namespace of the UsageRules to
//				  urn:ietf:params:xml:ns:pidf:geopriv10. Note: The subelements
//                are in urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy
//				18 Dec 22 PHR -- Added the Any element extension point.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;
using AdditionalData;

namespace Pidf
{
	/// <summary>
	/// Class that implements the XML schema for the PIDF geopriv type. Section 2.2.5 of RFC 4119.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
	[XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10", IsNullable = false)]
	public class GeoPriv
	{
		/// <summary>
		/// Default constructor. Sets all element fields to their default value.
		/// </summary>
		public GeoPriv() { }

		/// <summary>
		/// Sets or gets the location-info element. This element contains the location as a
		/// civic address or point, circle, etc.
		/// This element is required.
		/// </summary>
		[XmlElement("location-info")]
		public locInfoType LocationInfo = new locInfoType();

        /// <summary>
        /// Sets or gets the usage-rules element. This element is required. This field is initially set 
        /// to a default locPolicyType object. This element is required.
        /// </summary>
        //[XmlElement("usage-rules", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy")]
        // 1 Dec 22 PHR -- This element is in urn:ietf:params:xml:ns:pidf:geopriv10, the subelements
        // are in urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy
        [XmlElement("usage-rules", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
        public locPolicyType UsageRules = new locPolicyType();

		/// <summary>
		/// Sets or gets the method element. This element is optional. If used, then this string element 
		/// should be one of the registered values specified in Section 6.1 of RFC 4119.
		/// </summary>
		[XmlElement("method")]
		public string locMethod = null;

		/// <summary>
		/// XML extension point for unknown elements.
		/// </summary>
		[XmlAnyElement]
		public XmlElement[] Any = null;

        /// <summary>
        /// See Section 8.6 of RFC 7852.
        /// </summary>
		[XmlElement("provided-by", Namespace = "urn:ietf:params:xml:ns:EmergencyCallData")]
		public ProvidedByType ProvidedBy = null;
    }
}
