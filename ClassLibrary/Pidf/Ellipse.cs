/////////////////////////////////////////////////////////////////////////////////////
//	File:	Ellipse.cs												20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the Ellipse XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
    /// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
    [XmlRoot("Ellipse", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
    public class Ellipse
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Ellipse() { }

        /// <summary>
        /// Gets or sets the srsName attribute for the Ellipse element.
        /// </summary>
        [XmlAttribute("srsName")]
        public string srsName = "urn:ogc:def:crs:EPSG::4326";

        /// <summary>
        /// Gets or sets the "pos" element that contains the latitude,
        /// longitude and altitude (optional).
        /// </summary>
        [XmlElement("pos", Namespace = "http://www.opengis.net/gml")]
        public Position pos = null;

        /// <summary>
        /// Semi Major Axis of the ellipse. See Section 5.2.4 of RFC 5491.
        /// </summary>
        [XmlElement("semiMajorAxis")]
        public Axis semiMajorAxis = null;

        /// <summary>
        /// Semi Minor Axis of the ellipse. See Section 5.2.4 of RFC 5491.
        /// </summary>
        [XmlElement("semiMinorAxis")]
        public Axis semiMinorAxis = null;

        /// <summary>
        /// Orientation angle of the semi-major axis. See Section 5.2.4 of RFC 5491.
        /// </summary>
        [XmlElement("orientation")]
        public Orientation orientation = null;
    }
}
