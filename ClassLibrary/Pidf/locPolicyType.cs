/////////////////////////////////////////////////////////////////////////////////////
//	File:	locPolicyType.cs										19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//				18 Dec 22 PHR -- Added the Any element extension point.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the Location Policy (locPolicy type) schema specified in Section 2.2.5 
	/// of RFC 4119.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy")]
	[XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy", IsNullable = false)]
	public class locPolicyType
	{
		/// <summary>
		/// Default constructor. Sets all element fields to their default value.
		/// </summary>
		public locPolicyType()
		{
		}

		/// <summary>
		/// Sets or gets the retransmission-allowed element. If true, then the receiver of the location 
		/// information may re-transmit it. The default value is true.
		/// </summary>
		[XmlElement("retransmission-allowed")]
		public string RetransmissionAllowed = "true";

		/// <summary>
		/// Sets or gets the retention-expiry element. This is a DateTime element that specifies how 
		/// long the location may be retained by the receiver. The default value is 365 days.
		/// </summary>
		[XmlElement("retention-expiry")]
		public DateTime RetentionExpiry = DateTime.Now + new TimeSpan(365, 0, 0, 0);

		/// <summary>
		/// Sets or gets the external-ruleset element. This element must contain an xs:anyURI (any URI) 
		/// type as a string. Use of this field is optional. The default setting is null.
		/// </summary>
		[XmlElement("external-ruleset")]
		public string ExternalRuleset = null;

		/// <summary>
		/// Sets or gets the note-well element element. This element may contain notes about the location 
		/// policy. Use of this field is optional. The default setting is null.
		/// </summary>
		[XmlElement("note-well")]
		public string NoteWell = null;

        /// <summary>
        /// XML extension point for unknown elements.
        /// </summary>
        [XmlAnyElement]
        public XmlElement[] Any = null;
    }
}
