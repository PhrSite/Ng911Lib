/////////////////////////////////////////////////////////////////////////////////////
//	File:	Prism.cs												20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the Prism XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
    /// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
    [XmlRoot("Ellipsoid", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
    public class Prism
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Prism() { }

        /// <summary>
        /// Gets or sets the srsName attribute for the Ellipsoid element.
        /// </summary>
        [XmlAttribute("srsName")]
        public string srsName = "urn:ogc:def:crs:EPSG::4979";

        /// <summary>
        /// Describes the base of the polygon shape for the prism.
        /// </summary>
        [XmlElement("base")]
        public PrismBase PrismBase = null;

        /// <summary>
        /// Height of the prism.
        /// </summary>
        [XmlElement("height")]
        public Axis height = null;

    }

    /// <summary>
    /// Class for storing a polygon shape of the base of a prism.
    /// </summary>
    public class PrismBase
    {
        /// <summary>
        /// Default constructure.
        /// </summary>
        public PrismBase() { }

        /// <summary>
        /// Polygon for the base of a prism shape.
        /// </summary>
        [XmlElement("Polygon", Namespace = "http://www.opengis.net/gml")]
        public Polygon Polygon = null;
    }
}
