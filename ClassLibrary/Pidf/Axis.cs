/////////////////////////////////////////////////////////////////////////////////////
//	File:	Axis.cs                                                 20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class for representing an axis or a length.
    /// </summary>
    public class Axis
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Axis() { }

        /// <summary>
        /// Specifies the units of measure. The default value specifies meters.
        /// </summary>
        [XmlAttribute("uom")]
        public string uom = "urn:ogc:def:uom:EPSG::9001";

        /// <summary>
        /// Length value.
        /// </summary>
        [XmlText]
        public double Value = 0.0;
    }

}
