/////////////////////////////////////////////////////////////////////////////////////
//	File:	Tuple.cs												19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//              28 Mar 23 PHR
//                -- Added the note element.
//                -- Simplified the namespaces and attributes
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class for the tuple element. See RFC 3863 and RFC 4119.
    /// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf")]
	[XmlRoot("tuple", Namespace = "urn:ietf:params:xml:ns:pidf", IsNullable = false)]
	public class Tuple
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
		public Tuple()
        {
        }

        /// <summary>
        /// ID for the tuple object. Required.
        /// </summary>
		[XmlAttribute("id")]
		public string id = null;

        /// <summary>
        /// Wrapper element for a geopriv element that contains the location information. Required.
        /// </summary>
		[XmlElement("status")]
		public Status status = null;

        /// <summary>
        /// Time of the location. Optional.
        /// </summary>
		[XmlElement("timestamp")]
		public DateTime timestamp = DateTime.Now;

        /// <summary>
        /// May contain a URI to contact the entity that the location pertains to. Optional.
        /// </summary>
		[XmlElement("contact")]
		public string contact = null;

        /// <summary>
        /// Contains human readable comments text. Optional.
        /// </summary>
		[XmlElement("note")]
        public string note = null;
    }
}
