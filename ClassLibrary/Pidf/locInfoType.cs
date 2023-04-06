/////////////////////////////////////////////////////////////////////////////////////
//	File:	locInfoType.cs											24 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//              8 Dec 22 PHR -- Added the Dynamic element from RFC 5962.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the locInfoType XML schema specified in Section 2.2.5 of RFC 4119.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
	[XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10", IsNullable = false)]
	public class locInfoType
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public locInfoType() { }

        /// <summary>
        /// ID for the location.
        /// </summary>
        [XmlAttribute("id")]
        public string id = Guid.NewGuid().ToString().Replace("-", "");

        /// <summary>
        /// Profile such as geodetic-2d or civic
        /// </summary>
        [XmlAttribute("profile")]
        public string profile = "geodetic-2d";

        /// <summary>
        /// Contains a civic address location
        /// </summary>
		[XmlElement("civicAddress", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr")]
		public CivicAddress civicAddress = null;

        /// <summary>
        /// Contains a point location.
        /// </summary>
		[XmlElement("Point", Namespace = "http://www.opengis.net/gml")]
		public Point Point = null;

        /// <summary>
        /// Contains a 2D circle location.
        /// </summary>
		[XmlElement("Circle", Namespace = "http://www.opengis.net/pidflo/1.0")]
		public Circle Circle = null;

        /// <summary>
        /// Contains a 2D ellipse location.
        /// </summary>
        [XmlElement("Ellipse", Namespace = "http://www.opengis.net/pidflo/1.0")]
        public Ellipse Ellipse = null;

        /// <summary>
        /// Contains a 2D arc-band shape for the location.
        /// </summary>
        [XmlElement("ArcBand", Namespace = "http://www.opengis.net/pidflo/1.0")]
        public ArcBand ArcBand = null;

        /// <summary>
        /// Contains a polygon.
        /// </summary>
		[XmlElement("Polygon", Namespace = "http://www.opengis.net/gml")]
		public Polygon Polygon = null;

        /// <summary>
        /// Contains a 3D sphere location.
        /// </summary>
        [XmlElement("Sphere", Namespace = "http://www.opengis.net/pidflo/1.0")]
        public Sphere Sphere = null;

        /// <summary>
        /// Contains a 3D ellipsoid location.
        /// </summary>
        [XmlElement("Ellipsoid", Namespace = "http://www.opengis.net/pidflo/1.0")]
        public Ellipsoid Ellipsoid = null;

        /// <summary>
        /// Contains a 3D prism shape for the location.
        /// </summary>
        [XmlElement("Prism", Namespace = "http://www.opengis.net/pidflo/1.0")]
        public Prism Prism = null;

        /// <summary>
        /// Contains the confidence information for the location. Should not be
        /// present if the location type is a Point. See RFC 7459
        /// </summary>
        [XmlElement("confidence", Namespace = "urn:ietf:params:xml:ns:geopriv:conf")]
        public Confidence confidence = null;

        /// <summary>
        /// Contains the Dynamic orientation, heading and speed information. See RFC 5962
        /// </summary>
        [XmlElement("Dynamic", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:dynamic")]
        public DynamicType Dynamic = null;
    }
}
