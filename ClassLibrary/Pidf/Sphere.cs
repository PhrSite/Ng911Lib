/////////////////////////////////////////////////////////////////////////////////////
//	File:	Sphere.cs												25 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the Sphere XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
    /// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
    [XmlRoot("Sphere", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
    public class Sphere
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sphere() { }

        /// <summary>
        /// Gets or sets the srsName attribute for the Sphere element.
        /// </summary>
        [XmlAttribute("srsName")]
        public string srsName = "urn:ogc:def:crs:EPSG::4979";

        /// <summary>
        /// Gets or sets the "pos" element that contains the latitude,
        /// longitude and altitude (optional).
        /// </summary>
        [XmlElement("pos", Namespace = "http://www.opengis.net/gml")]
        public Position pos = null;

        /// <summary>
        /// Gets or sets the radius of the sphere. The uom attribute specifies the units of measure. The 
        /// default uom is meters.
        /// </summary>
        [XmlElement("radius")]
        public Axis radius = null;
    }
}
