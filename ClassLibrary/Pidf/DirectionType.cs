/////////////////////////////////////////////////////////////////////////////////////
//  File: DirectionType.cs                                          8 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Contains the horizontal and vertical components of an orientation or a heading.
    /// See RFC 5962
    /// </summary>
    public class DirectionType : IXmlSerializable
    {
        private double m_Horizontal = double.NaN;
        private double m_Vertical = double.NaN;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectionType()
        {
        }

        /// <summary>
        /// Constructs a DirectionType with a horizontal and a vertical component
        /// </summary>
        /// <param name="horizontal">Horizontal component in decimal degrees</param>
        /// <param name="vertical">Vertical elevation angle in decimal degrees</param>
        public DirectionType(double horizontal, double vertical)
        {
            m_Horizontal = horizontal;
            m_Vertical = vertical;
        }

        /// <summary>
        /// Constructs a DirectionType with only a horizontal component.
        /// </summary>
        /// <param name="horizontal">Horizontal component in decimal degrees</param>
        public DirectionType(double horizontal)
        {
            m_Horizontal = horizontal;
        }

        /// <summary>
        /// Gets or sets the horizontal component. Units are in decimal degrees.
        /// Horizontal angles are measured from Northing to Easting. Horizontal
        /// angles start from zero when pointing to or travelling towards the
        /// North and increase towards the East.
        /// </summary>
        [XmlIgnore]
        public double Horizontal
        {
            get { return m_Horizontal; }
            set { m_Horizontal = value; }
        }

        /// <summary>
        /// Gets or sets the vertical elevation from the local horizontal plane.
        /// Units are in decimal degrees.
        /// </summary>
        [XmlIgnore]
        public double Vertical
        {
            get { return m_Vertical; }
            set { m_Vertical = value; }
        }

        /// <summary>
        /// IXmlSerializable.GetSchema(). Not used. Always returns null.
        /// </summary>
        /// <returns>Returns null</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Implementation of the IXmlSerializable.ReadXml method that is called when de-serializing.
        /// </summary>
        /// <param name="reader">Source of the inner XML to use.</param>
        public void ReadXml(XmlReader reader)
        {
            ParseDirectionString(reader.ReadInnerXml());
        }

        /// <summary>
        /// Implementation of the IXmlSerializable.WriteXml method that is called when serializing.
        /// </summary>
        /// <param name="writer">Destination for the inner XML.</param>
        public void WriteXml(XmlWriter writer)
        {
            // The horizontal component is required. If not set, then don't write the element contents
            if (double.IsNaN(m_Horizontal) == true)
                return;

            string str;
            if (double.IsNaN(m_Vertical) == true)
                str = m_Horizontal.ToString();
            else
                str = $"{m_Horizontal} {m_Vertical}";

            writer.WriteRaw(str);
        }

        private void ParseDirectionString(string str)
        {
            if (string.IsNullOrEmpty(str) == true)
                return;

            string[] strFields = str.Split(new char[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (strFields.Length >= 1)
                double.TryParse(strFields[0], out m_Horizontal);

            if (strFields.Length >= 2)
                double.TryParse(strFields[1], out m_Vertical);
        }
    }
}
