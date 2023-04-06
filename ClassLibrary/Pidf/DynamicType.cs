/////////////////////////////////////////////////////////////////////////////////////
//  File: DynamicType.cs                                            8 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// This class contains information about the orientation, heading and speed of an object
    /// whose location is described in a PIDF-LO XML document.
    /// See RFC 5962.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:dynamic")]
    [XmlRoot("Dynamic", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:dynamic", IsNullable = false)]
    public class DynamicType
    {
        /// <summary>
        /// Describes the physical orientation of the object.
        /// </summary>
        [XmlElement("orientation")]
        public DirectionType orientation = null;

        /// <summary>
        /// Describes the speed of the object in meters/second
        /// </summary>
        [XmlElement("speed")]
        public double speed;

        /// <summary>
        /// Set this to true if the speed element has been set. A value of false indicates either that 
        /// the speed element is not present or that the speed element should not be serialized.
        /// </summary>
        [XmlIgnore()]
        public bool speedSpecified;

        /// <summary>
        /// Specifies the direction in which the object is moving
        /// </summary>
        [XmlElement("heading")]
        public DirectionType heading = null;

        /// <summary>
        /// Extension point for unknown elements. Will be null if there are no unknown elements.
        /// </summary>
        [XmlAnyElement()]
        public System.Xml.XmlElement[] Any = null;

        /// <summary>
        /// Extension point fo unknown attributes. Will be null if there are no unknown attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr = null;
    }
}
