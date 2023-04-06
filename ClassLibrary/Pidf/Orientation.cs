/////////////////////////////////////////////////////////////////////////////////////
//	File:	Orientation.cs                                          20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class for representing an orientation of a shape.
    /// </summary>
    public class Orientation
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Orientation()
        {
        }

        /// <summary>
        /// Specifies the units of measure. The default value specifies degrees.
        /// </summary>
        [XmlAttribute("uom")]
        public string uom = "urn:ogc:def:uom:EPSG::9102";

        /// <summary>
        /// Value of the orientation.
        /// </summary>
        [XmlText]
        public double Value = 0.0;
    }
}
