/////////////////////////////////////////////////////////////////////////////////////
//	File:	Point.cs												20 Jul 17 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pidf
{
	/// <summary>
	/// Class that implements the Position XML schema for 2 dimentional and 3 dimensional positions.
	/// </summary>
	public class Position : IXmlSerializable
	{
		private double m_Latitude = 0.0;
		private double m_Longitude = 0.0;
		private double m_Altitude = double.NaN;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Position()
		{
			m_Latitude = 0.0;
			m_Longitude = 0.0;
			m_Altitude = double.NaN;
		}

		/// <summary>
		/// Constructs a 2-dimensional Position object.
		/// </summary>
		/// <param name="Lat">Latitude in WGS84 degrees.</param>
		/// <param name="Long">Longitude in WGS84 degrees.</param>
		public Position(double Lat, double Long)
		{
			m_Latitude = Lat;
			m_Longitude = Long;
			m_Altitude = double.NaN;
		}

		/// <summary>
		/// Constructs a 3-dimensional Position objec.
		/// </summary>
		/// <param name="Lat">Latitude in WGS84 degrees.</param>
		/// <param name="Long">Longitude in WGS84 degrees.</param>
		/// <param name="Alt">Altitude in meters</param>
		public Position(double Lat, double Long, double Alt)
		{
			m_Latitude = Lat;
			m_Longitude = Long;
			m_Altitude = Alt;
		}

		/// <summary>
		/// IXmlSerializable.GetSchema(). Not used. Always returns null.
		/// </summary>
		/// <returns></returns>
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Implementation of the IXmlSerializable.ReadXml method that is called when de-serializing. 
		/// Applications should not call this method.
		/// </summary>
		/// <param name="reader">Source of the inner XML to use.</param>
		public void ReadXml(XmlReader reader)
		{
			string str = reader.ReadInnerXml();
			ParsePosString(str);
		}

		/// <summary>
		/// Implementation of the IXmlSerializable.WriteXml method that is called when serializing.
		/// Applications should not call this method.
		/// </summary>
		/// <param name="writer">Destination for the inner XML.</param>
		public void WriteXml(XmlWriter writer)
		{
			string str;

            if (double.IsNaN(m_Altitude) == true)
                str = string.Format("{0} {1}", m_Latitude, m_Longitude);
            else
                str = string.Format("{0} {1} {2}", m_Latitude, m_Longitude,
                    m_Altitude);

            writer.WriteRaw(str);
		}

		private void ParsePosString(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				m_Latitude = 0.0;
				m_Longitude = 0.0;
				return;
			}

			string[] strFields = str.Split(new char[] { ' ', '\r', '\n' },
				StringSplitOptions.RemoveEmptyEntries);

			if (strFields.Length < 2)
			{
				m_Latitude = 0.0;
				m_Longitude = 0.0;
				m_Altitude = double.NaN;
				return;
			}

			double.TryParse(strFields[0], out m_Latitude);
			double.TryParse(strFields[1], out m_Longitude);

			if (strFields.Length == 3)
				double.TryParse(strFields[2], out m_Altitude);
			else
				m_Altitude = double.NaN;
		}

		/// <summary>
		/// Gets or sets the Latitude in WGS84 degrees.
		/// </summary>
		[XmlIgnore()]
		public double Latitude
		{
			get { return m_Latitude; }
			set { m_Latitude = value; }
		}

		/// <summary>
		/// Gets or sets the Longitude in WGS84 degrees.
		/// </summary>
		[XmlIgnore()]
		public double Longitude
		{
			get { return m_Longitude; }
			set { m_Longitude = value; }
		}

		/// <summary>
		/// Gets or sets the Altitude in meters above sea level. A value of double.NaN indicates that
		/// the Altitude is not set.
		/// </summary>
		[XmlIgnore()]
		public double Altitude
		{
			get { return m_Altitude; }
			set { m_Altitude = value; }
		}
	}
}
