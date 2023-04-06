/////////////////////////////////////////////////////////////////////////////////////
//	File:	Status.cs												19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//				28 Mar 23 PHR
//				  -- Added the basic element
//                -- Simplified the namespaces and attributes
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Container for a geopriv XML object. See RFC 3863 and RFC 4119.
    /// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf")]
	[XmlRoot("status", Namespace = "urn:ietf:params:xml:ns:pidf", IsNullable = false)]
	public class Status
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
		public Status() { }

        /// <summary>
        /// Contains the location information.
        /// </summary>
		[XmlElement("geopriv", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
		public GeoPriv geopriv = null;

        /// <summary>
        /// Indicates availability to receive instant messages if the tuple is for an instant messaging 
        /// address. Allowed values are "open" or "closed". A value of "open" means that the instant 
        /// message inbox is ready to receive message. A value of closed indicates that it is not.
        /// Not used for NG9-1-1 applications. Optional.
        /// </summary>
        [XmlElement("basic")]
		public string basic = null;
	}
}
