/////////////////////////////////////////////////////////////////////////////////////
//	File:	Device.cs												20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class for the device element of a presence element. See RFC 4479.
    /// </summary>
	[Serializable()]
	[XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
	[XmlRoot("device", Namespace = "urn:ietf:params:xml:ns:pidf:data-model", IsNullable = false)]
	public class Device
	{
        /// <summary>
        /// Default constructor
        /// </summary>
		public Device()
        {
        }

        /// <summary>
        /// Contains the location information.
        /// </summary>
		[XmlElement("geopriv", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10")]
		public GeoPriv geopriv = null;

        /// <summary>
        /// Instance identifier of the device.
        /// </summary>
		[XmlAttribute("id")]
		public string id = null;

        /// <summary>
        /// Device ID. URI that is globally and temporally unique identifier
        /// for the device.
        /// </summary>
		[XmlElement("deviceID")]
		public string devicdID = null;

        /// <summary>
        /// Timestamp for the location of the device.
        /// </summary>
		[XmlElement("timestamp")]
		public DateTime timestamp = DateTime.MinValue;
	}
}
