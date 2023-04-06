/////////////////////////////////////////////////////////////////////////////////////
//	File:	Radius.cs												21 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the radius XML schema.
	/// </summary>
	[SerializableAttribute()]
	[XmlType(AnonymousType = true, Namespace = "http://www.opengis.net/pidflo/1.0")]
	[XmlRoot("radius", Namespace = "http://www.opengis.net/pidflo/1.0", IsNullable = false)]
	public class Radius
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Radius()
		{
		}

		private string m_Value = null;

		/// <summary>
		/// Gets or sets the uom attribute value for the radius element. The default value specifies the 
		/// units of measure is meters.
		/// </summary>
		[XmlAttribute("uom")]
		public string uom = "urn:ogc:def:uom:EPSG::9001";

		/// <summary>
		/// Gets or sets the value of the radius element.
		/// </summary>
		[XmlText()]
		public string Value
		{
			get { return m_Value; }
			set
			{
				m_Value = value;
				if (string.IsNullOrEmpty(m_Value) == false)
					m_Value = m_Value.Trim();
			}
		}
	}
}
