/////////////////////////////////////////////////////////////////////////////////////
//	File:	ArcBand.cs												20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the ArcBand XML schema. See RFC 5491 and Section 7.2.6 of GML 3.1.1 
    /// PIDF-LO Shape Application Schema for use by the Internet Engineering Task Force (IETF)", 
    /// 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
    [XmlRoot("ArcBand", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
    public class ArcBand
    {
        /// <summary>
        /// Gets or sets the srsName attribute for the Circle element.
        /// </summary>
        [XmlAttribute("srsName")]
        public string srsName = "urn:ogc:def:crs:EPSG::4326";

        /// <summary>
        /// Gets or sets the "pos" element that contains the latitude, longitude and altitude (optional).
        /// </summary>
        [XmlElement("pos", Namespace = "http://www.opengis.net/gml")]
        public Position pos = null;

        /// <summary>
        /// The inner radius defines the minimum distance from the center point.
        /// </summary>
        [XmlElement("innerRadius")]
        public Axis innerRadius = null;

        /// <summary>
        /// The outer radius defines the maximum distance from the center point.
        /// </summary>
        [XmlElement("outerRadius")]
        public Axis outerRadius = null;

        /// <summary>
        /// The start angle defines where the arc begins.
        /// </summary>
        [XmlElement("startAngle")]
        public Orientation startAngle = null;

        /// <summary>
        /// The opening angle defines where the arc ends.
        /// </summary>
        [XmlElement("openingAngle")]
        public Orientation openingAngle = null;
    }
}
