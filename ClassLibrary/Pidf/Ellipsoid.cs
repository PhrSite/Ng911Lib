/////////////////////////////////////////////////////////////////////////////////////
//	File:	Ellipsoid.cs											20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the Ellipsoid XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape 
    /// Application Schema for use by the Internet Engineering Task Force (IETF)", 
    /// 2007-04-10, OGC 06-142r1.
    /// </summary>
    [SerializableAttribute()]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
    [XmlRoot("Ellipsoid", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
    public class Ellipsoid
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ellipsoid() { }

        /// <summary>
        /// Gets or sets the srsName attribute for the Ellipsoid element.
        /// The default value specifies the geogrphic 3d profile.
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
        /// Semi-Major Axis
        /// </summary>
        [XmlElement("semiMajorAxis")]
        public Axis semiMajorAxis = null;

        /// <summary>
        /// Semi-Minor Axis
        /// </summary>
        [XmlElement("semiMinorAxis")]
        public Axis semiMinorAxis = null;

        /// <summary>
        /// Vertical Axis.
        /// </summary>
        [XmlElement("verticalAxis")]
        public Axis verticalAxis = null;

        /// <summary>
        /// Orientation.
        /// </summary>
        [XmlElement("orientation")]
        public Orientation orientation = null;
    }
}
