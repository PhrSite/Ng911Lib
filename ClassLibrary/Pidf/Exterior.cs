/////////////////////////////////////////////////////////////////////////////////////
//	File:	Exterior.cs												24 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the exterior node XML schema for a Polygon. See RFC 5491 and 
	/// Section 7.4 of GML 3.1.1 PIDF-LO Shape Application Schema for use by the Internet 
	/// Engineering Task Force (IETF)", 2007-04-10, OGC 06-142r1.
    /// </summary>
    [Serializable()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/gml")]
	[XmlRoot(Namespace = "http://www.opengis.net/gml", IsNullable = false)]
	public class Exterior
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Exterior()
		{
		}

		/// <summary>
		/// Gets or sets the LinearRing element. This will be either a LinearPosRing
		/// or a LinearCompact ring object.
		/// </summary>
		[XmlElement("LinearRing")]
		public LinearRing LinearRing = null;
	}
}
