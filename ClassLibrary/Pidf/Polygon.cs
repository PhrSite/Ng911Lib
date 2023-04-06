/////////////////////////////////////////////////////////////////////////////////////
//	File:	Polygon.cs												21 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the Polygon XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
    /// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/gml")]
	[XmlRoot(Namespace = "http://www.opengis.net/gml", IsNullable = false)]
	public class Polygon
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Polygon() { }

		/// <summary>
		/// Gets or sets the srsName attribute for the Polygon element. The default value specifies the 
		/// 2D profile.
		/// </summary>
		[XmlAttribute("srsName")]
		public string srsName = "urn:ogc:def:crs:EPSG::4326";

		/// <summary>
		/// Gets or sets the exterior element.
		/// </summary>
		[XmlElement("exterior")]
		public Exterior exterior = null;
	}
}
