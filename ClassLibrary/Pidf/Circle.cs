/////////////////////////////////////////////////////////////////////////////////////
//	File:	Circle.cs												20 Jul 17 PHR
//	Revised:	30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//				  comments.			
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the Circle XML schema. See RFC 5491 and GML 3.1.1 PIDF-LO Shape Application 
	/// Schema for use by the Internet Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
	[XmlRoot("Circle", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
	public class Circle
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Circle() { }

		/// <summary>
		/// Constructs a new Circle object given the latitude, longitude and
		/// radius.
		/// </summary>
		/// <param name="Lat">Latitude</param>
		/// <param name="Lon">Longitude</param>
		/// <param name="RadiusMeters">Radius in meters</param>
		public Circle(double Lat, double Lon, int RadiusMeters)
        {
			pos = new Position(Lat, Lon);
			radius = new Radius();
			// Uses the default units of measure (uom) of meters
			radius.Value = RadiusMeters.ToString();
        }

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
		/// Gets or sets the radius element. The Value property of this object contains the radius and 
		/// the "uom" property specifies the units of measure.
		/// </summary>
		[XmlElement("radius")]
		public Radius radius = null;
	}
}
