/////////////////////////////////////////////////////////////////////////////////////
//	File:	Point.cs												20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the Point XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
	/// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/gml")]
	[XmlRoot("point", Namespace = "http://www.opengis.net/gml", IsNullable = false)]
	public class Point
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Point()
		{
		}

		/// <summary>
		/// Creates a new Point object given a latitude and a longitude
		/// </summary>
		/// <param name="Lat">Latitude</param>
		/// <param name="Long">Longitude</param>
		public Point(double Lat, double Long)
        {
			pos = new Position(Lat, Long);
        }

		/// <summary>
		/// Gets or sets the "id" attribute of the Point element.
		/// </summary>
		[XmlAttribute("id")]
		public string id = null;

		/// <summary>
		/// Gets or sets the "srsName" attribute of the Point element.
        /// The default value specifies the 2D profile using WGS84 degrees.
		/// </summary>
		[XmlAttribute("srsName")]
		public string srsName = "urn:ogc:def:crs:EPSG::4326";

		/// <summary>
		/// Gets or sets the "pos" element that contains the coordinates for this Point object.
		/// </summary>
		[XmlElement("pos")]
		public Position pos = null;
	}
}
