/////////////////////////////////////////////////////////////////////////////////////
//	File:	Person.cs												19 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class for the person element of a presence element. See RFC 4479.
    /// </summary>
	[SerializableAttribute()]
    [XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
    [XmlRoot("person", Namespace = "urn:ietf:params:xml:ns:pidf:data-model", IsNullable = false)]
    public class Person
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Person() { }

        /// <summary>
        /// Contains the location information.
        /// </summary>
        [XmlElement("geopriv", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
        public GeoPriv geopriv = null;

        /// <summary>
        /// Identifies the person.
        /// </summary>
        [XmlAttribute("id")]
        public string id = null;

        /// <summary>
        /// Timestamp for the location of the person.
        /// </summary>
		[XmlElement("timestamp")]
        public DateTime timestamp = DateTime.MinValue;
    }
}
