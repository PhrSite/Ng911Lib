﻿/////////////////////////////////////////////////////////////////////////////////////
//  File:   Rfc8147.cs                                              6 Feb 23 PHR
//
//  This file was generated from the file called Rfc8147.xsd using the xsd.exe
//  utility as follows: xsd.exe Rfc8147.xsd /classes -f -n:Ecall. Then the following
//  changes were made.
//      1.) Simplified the System.Xml.Serialization namespaces
//      2.) Added documentation comments.
/////////////////////////////////////////////////////////////////////////////////////

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 

using System.Xml;
using System.Xml.Serialization;

namespace ECall {
    
    /// <summary>
    /// This is the class for the root element of an ECALL XML document. The root element has three
    /// sub-elements: capabilities, request and ack. Only one of these sub-elements will be non-null.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    [XmlRoot("EmergencyCallData.Control", Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control", 
        IsNullable=false)]
    public partial class controlType {

        /// <summary>
        /// The capabilities element is transmitted by the In-Vehicle System (IVS) to indicate its 
        /// capabilities to the PSAP. See Section 9.1.2 of RFC 8147.
        /// </summary>
        public capabilitiesType capabilities;

        /// <summary>
        /// Used in a control block sent by the PSAP to the IVS to request the vehicle to perform an action.
        /// </summary>
        [XmlElement("request")]
        public requestType[] request;

        /// <summary>
        /// The ack element acknowledges receipt of an eCall data object or request.
        /// </summary>
        public ackType ack;
        
        /// <summary>
        /// Element extension point
        /// </summary>
        [XmlAnyElement()]
        public XmlElement[] Any;
        
        /// <summary>
        /// Attribute extension point
        /// </summary>
        [XmlAnyAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
    }

    /// <summary>
    /// Class for data transmitted by the IVS to indicate its capabilities to the PSAP. See Section 9.1.2 of
    /// RFC 8147.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    public partial class capabilitiesType {
        
        /// <summary>
        /// Contains an array of actions (requests) supported by the IVS. Optional.
        /// </summary>
        [XmlElement("request")]
        public requestType[] request;
        
        /// <summary>
        /// Element extension point.
        /// </summary>
        [XmlAnyElement()]
        public XmlElement[] Any;
        
        /// <summary>
        /// Attribute extension point.
        /// </summary>
        [XmlAnyAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
    }
    
    /// <summary>
    /// Used by the IVS to describe the types of requests (actions) it supports. Also used by the PSAP
    /// to request data from the IVS.
    /// See Section 9.1.3 of RFC 8147.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    public partial class requestType {

        /// <summary>
        /// Defined for extension. Sent from the PSAP to the IVS.
        /// </summary>
        [XmlElement("text")]
        public requestTypeText[] text;

        /// <summary>
        /// Identifies the action that the vehicle is requested to perform when in a root element. In a request 
        /// element within a capabilities element, indicates an action that the vehicle is capable of performing.
        /// The Section 14.8.1 of RFC 8147 defines the "send-data" value. Section 9.1 of RFC 8148 defines the
        /// following additional attribute values: msg-static, msg-dynamic, honk, lamp, enable-camera and
        /// door-lock
        /// </summary>
        [XmlAttribute(DataType="token")]
        public string action;

        /// <summary>
        /// RFC 8148 defines values of 0 and 1 in Section 14.4.
        /// </summary>
        [XmlAttribute("int-id")]
        public uint intid;
        
        /// <summary>
        /// Set to true if the intid element is specified or false if it is not.
        /// </summary>
        [XmlIgnore()]
        public bool intidSpecified;

        /// <summary>
        /// Specifies how long to carry on the specified action. If absent, the default is for the duration 
        /// of the call. See Section 9.1 of RFC 8148.
        /// Sent in either direction. Optional.
        /// </summary>
        [XmlAttribute(DataType="duration")]
        public string persistence;

        /// <summary>
        /// Mandatory with a "send-data" action within a request element that is not within a capabilities
        /// element. Specifies the data block that the IVS is requested to transmit. Sent in either direction.
        /// RFC 8147 the "eCall.MSD" value is mandatory to support. RFC 8148 (USA) defines "VEDS".
        /// </summary>
        [XmlAttribute(DataType="token")]
        public string datatype;

        /// <summary>
        /// Defined for extensibility. Used in a request element that is a child of a capability
        /// element, this attribute lists all supported values of the action type.Permitted values depend 
        /// on the action value.Multiple values are separated with a semicolon. White space is ignored.
        /// Documents that make use of it are expected to explain when it is required, the permitted 
        /// values, and how it is used. Optional.
        /// </summary>
        [XmlAttribute("supported-values")]
        public string supportedvalues;

        /// <summary>
        /// Identifies the element to be acted on. Permitted values depend on the request type. See 
        /// Sections 9.1, 14.5 and 14.6 of RFC 8148.
        /// Sent from the PSAP to the IVS. Optional.
        /// </summary>
        [XmlAttribute("element-id", DataType="token")]
        public string elementid;

        /// <summary>
        /// Indicates the requested state of an element associated with the request 
        /// type. Permitted values depend on the request type. See Section 9.1 of RFC 8148. 
        /// Sent from the PSAP to the IVS. Optional.
        /// </summary>
        [XmlAttribute("requested-state", DataType="token")]
        public string requestedstate;

        /// <summary>
        /// Extension point for elements
        /// </summary>
        [XmlAnyElement()]
        public XmlElement[] Any;

        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr;
    }

    /// <summary>
    /// Defined for extension. Sent from the PSAP to the IVS. Optional.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    public partial class requestTypeText {
        
        /// <summary>
        /// Contains the free text.
        /// </summary>
        [XmlText()]
        public string Value;

        /// <summary>
        /// Extension point for attributes
        /// </summary>
        [XmlAnyAttribute()]
        public XmlAttribute[] AnyAttr;

    }

    /// <summary>
    /// Data class that acknowledges receipt of an eCall data object or request.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    public partial class ackType
    {
        /// <summary>
        /// Element for each request element that is not a successfully executed "send-data" action.
        /// Optional.
        /// </summary>
        [XmlElement("actionResult")]
        public ackTypeActionResult[] actionResult;

        /// <summary>
        /// Contains the Content-ID of the body part being acknowledged. Sent in either direction.
        /// Required
        /// </summary>
        [XmlAttribute("ref", DataType="anyURI")]
        public string @ref;

        /// <summary>
        /// Indicates if the referenced object was considered successfully received or not.
        /// Required in an ack element sent by a PSAP.
        /// </summary>
        [XmlAttribute()]
        public bool received;
        
        /// <summary>
        /// Set to true if the received element is specified, else set to false.
        /// </summary>
        [XmlIgnore()]
        public bool receivedSpecified;
    }

    /// <summary>
    /// Indicates the result of an action (other than a successfully executed "send-data" action). 
    /// The ack  element contains an actionResult element for each request element that is not a 
    /// successfully executed "send-data" action.
    /// </summary>
    [Serializable()]
    [XmlType(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:EmergencyCallData:control")]
    public partial class ackTypeActionResult
    {
        /// <summary>
        /// Contains the value of the "action" attribute of the request element. Required.
        /// </summary>
        [XmlAttribute(DataType="token")]
        public string action;

        /// <summary>
        /// Indicates if the action was successfully accomplished. Required.
        /// </summary>
        [XmlAttribute()]
        public bool success;

        /// <summary>
        /// Used when "success" is "false", this attribute contains a reason code for a failure.
        /// Section 14.8.2 of RFC 8147 specifies the following allowed values:
        /// damaged, data-unsupported, security-failure, unable and unsupported.
        /// </summary>
        [XmlAttribute(DataType="token")]
        public string reason;

        /// <summary>
        /// Contains further explanation of the circumstances of a success or failure. Optional.
        /// </summary>
        [XmlAttribute()]
        public string details;
    }
}
