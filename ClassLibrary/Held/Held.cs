/////////////////////////////////////////////////////////////////////////////////////
//  File: Held.cs                                                   10 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

using Pidf;

namespace Held
{
    /// <summary>
    /// Class for the locationRequest HELD request. See RFC 5985 HTTP-Enabled Location Delivery (HELD)
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:geopriv:held")]
    [XmlRoot("locationRequest", Namespace = "urn:ietf:params:xml:ns:geopriv:held", IsNullable = false)]
    public class LocationRequest
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationRequest() { }

        /// <summary>
        /// Specifies the response time being requested. Allowable values are "emergencyRouting", 
        /// "emergencyDispatch" or a number of milliseconds greater that 0.
        /// </summary>
        [XmlAttribute("responseTime")]
        public string responseTime = "emergencyRouting";

        /// <summary>
        /// Specifies the location type for the request.
        /// </summary>
        [XmlElement("locationType")]
        public LocationType locationType = new LocationType();

        /// <summary>
        /// Specifies a device that the location request applies to. See RFC 6155.
        /// </summary>
        [XmlElement("device", Namespace = "urn:ietf:params:xml:ns:geopriv:held:id")]
        public HeldDevice device = null;
    }

    /// <summary>
    /// Class for specifying the location type being requested in a HELD location request.
    /// </summary>
    public class LocationType
    {
        /// <summary>
        /// If true then the HELD server must return either the requested location
        /// type or an error response.
        /// </summary>
        [XmlAttribute("exact")]
        public bool exact = false;

        /// <summary>
        /// Specifies a string list of the type of location being requested. 
        /// The allowable values are: "any", "geodetic", "civic" or "locationURI", or a list of a 
        /// combination of these values.
        /// </summary>
        [XmlText]
        public List<string> Value = new List<string>();
    }

    /// <summary>
    /// Class for specifying a device to request the location for. See RFC 6155.
    /// </summary>
    /// <remarks>Note: Sections 3.3, 3.4, 3.6, 3.7 and 3.8 of RFC 6155 have not been
    /// implemented because these sections specify functionality that is not
    /// yet required.</remarks>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:geopriv:held:id")]
    [XmlRoot("device", Namespace = "urn:ietf:params:xml:ns:geopriv:held:id", IsNullable = false)]
    public class HeldDevice
    {
        /// <summary>
        /// Specifies the IP address of the device. See Section 3.1 of RFC 6155.
        /// </summary>
        [XmlElement("ip")]
        public HeldIp ip = null;

        /// <summary>
        /// Specifies the MAC address of the device. See Section 3.2 of RFC 6155.
        /// </summary>
        [XmlElement("mac")]
        public string mac = null;

        /// <summary>
        /// Specifies the URI of the device. May be a sip, sips or a tel
        /// style URI. See Section 3.5 of RFC 6155.
        /// </summary>
        [XmlElement("uri")]
        public string uri = null;
    }

    /// <summary>
    /// Class for specifying the IP address of a device in a HELD locationRequest
    /// query.
    /// </summary>
    public class HeldIp
    {
        /// <summary>
        /// Specifies the IP version. Must be either "4" or "6".
        /// </summary>
        [XmlAttribute("v")]
        public string v = "4";
        /// <summary>
        /// Contains the IP address. Must be a valid IPv4 or a valid IPv6 address.
        /// </summary>
        [XmlText]
        public string IpAddr = null;
    }

    /// <summary>
    /// Class for the locationResponse response from a HELD server.
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:geopriv:held")]
    [XmlRoot("locationResponse", Namespace = "urn:ietf:params:xml:ns:geopriv:held", IsNullable = false)]
    public class LocationResponse
    {
        /// <summary>
        /// May contain a list of locationURI elements that specify URIs that can be used to de-reference 
        /// the location.
        /// </summary>
        [XmlElement("locationUriSet")]
        public LocationUriSet locationUriSet = null;

        /// <summary>
        /// May contain the location by-value.
        /// </summary>
        [XmlElement("presence", Namespace = "urn:ietf:params:xml:ns:pidf")]
        public Presence presence = null;
    }

    /// <summary>
    /// Class for the locationUriSet element of a HELD locationRequest.
    /// </summary>
    public class LocationUriSet
    {
        /// <summary>
        /// Specifies the expiration time/date of the response. The format is UTC time in ISO 8601 format.
        /// </summary>
        [XmlAttribute("expires")]
        public string expires = null;

        /// <summary>
        /// Contains a list of URIs that can be dereferenced to get a location
        /// value.
        /// </summary>
        [XmlElement("locationURI")]
        public List<string> locationURI = new List<string>();
    }

    /// <summary>
    /// Class for a HELD error response.
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:geopriv:held")]
    [XmlRoot("error", Namespace = "urn:ietf:params:xml:ns:geopriv:held", IsNullable = false)]
    public class HeldError
    {
        /// <summary>
        /// Attribute that explains the reason for the error. 
        /// The allowable values are: "requestError", "xmlError", "generalLisError", "locationUnknown", 
        /// "unsupportedMessage", "timeout", "cannotProvideLiType" and "notLocatable".
        /// See Section 6.3 of RFC 5985 for a description of each value.
        /// </summary>
        [XmlAttribute("code")]
        public string code = null;
        /// <summary>
        /// Message that explains the error.
        /// </summary>
        [XmlElement("message")]
        public HeldErrorMessage message = null;
    }

    /// <summary>
    /// Class for a HELD error message element. 
    /// </summary>
    public class HeldErrorMessage
    {
        /// <summary>
        /// Language attribute.
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string lang = "en";
        /// <summary>
        /// Text for the message element.
        /// </summary>
        [XmlText]
        public string Value = null;
    }
}
