//////////////////////////////////////////////////////////////////////////////////////
//  File:   SipRecMetadata.cs                                       26 Jan 23 PHR
//
//  Description:    Classes for the SIPREC metadata XML defined in RFC 7865.
//                  The xsd.exe command line tool from the file called Rfc7865.xsd
//                  file, which was downloaded from the IETF XML Registry:
//                      https://www.iana.org/assignments/xml-registry/schema/recording/1.xsd
//
//                  The command line used to generate this file was:
//                      xsd.exe SipRecMetadata.xsd /c /f /n:SipRecMetaData /o:SipRecMetaData.cs
//
//                  Do not regenerate this file using xsd because this file has been
//                  modified as follows.
//                      1.) Added documentation comments from the RFC
//                      2.) base64Binary byte arrays replaced with string
//                      3.) arrays replaced by List<>
//                      4.) Fields were replaced with automatic properties
//                      5.) Namespace names were simplified.
//////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace SipRecMetaData
{
    /// <summary>
    /// Data class for the root element (recording) of the SIPREC metadata XML document.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace = "urn:ietf:params:xml:ns:recording:1")]
    [XmlRoot(Namespace = "urn:ietf:params:xml:ns:recording:1", IsNullable = false)]
    public partial class recording
    {
        /// <summary>
        /// MIME type for the Content-Type SIP header
        /// </summary>
        [XmlIgnore]
        public const string ContentType = "application/rs-metadata+xml";

        /// <summary>
        /// Value of the dataMode element. The default value is "complete".
        /// </summary>
        public dataMode datamode { get; set; } = dataMode.complete;

        /// <summary>
        /// Specifies that the datamode enumeration value has been set.
        /// </summary>
        [XmlIgnore]
        public bool datamodeSpecified { get; set; } = true;

        /// <summary>
        /// Contains a list of Communication Session Group objects. See Section 6.2 of RFC 7865.
        /// </summary>
        [XmlElement("group")]
        public List<group> groups { get; set; } = new List<group>();

        /// <summary>
        /// Contains a list of Recording Session objects. See Section 6.1 of RFC 7865.
        /// </summary>
        [XmlElement("session")]
        public List<session> sessions { get; set; } = new List<session>();

        /// <summary>
        /// Contains a list of participant objects. See Section 6.5 of RFC 7865.
        /// </summary>
        [XmlElement("participant")]
        public List<participant> participants { get; set; } = new List<participant>();

        /// <summary>
        /// Contains a list of stream objects. See Section 6.7 of RFC 7865.
        /// </summary>
        [XmlElement("stream")]
        public List<stream> streams { get; set; } = new List<stream>();

        /// <summary>
        /// Contains a list of sessionrecordingassoc objects. See Section 6.4 of RFC 7865. 
        /// Each sessionrecordingassoc object describes the association of a communication 
        /// session with a recording session.
        /// </summary>
        [XmlElement("sessionrecordingassoc")]
        public List<sessionrecordingassoc> sessionrecordingassocs { get; set; } = new 
            List<sessionrecordingassoc>();

        /// <summary>
        /// Contains a list of participantsessionassoc objects. See Section 6.6 of RFC 7865. Each 
        /// participantsessionassoc object describes the association of a participant to a communication
        /// session.
        /// </summary>
        [XmlElement("participantsessionassoc")]
        public List<participantsessionassoc> participantsessionassocs { get; set; } = new 
            List<participantsessionassoc>();

        /// <summary>
        /// Contains a list of participantstreamassoc objects.See Section 6.8 of RFC 7865. Each 
        /// participantstreamassoc oject describes the association of a participant to a (media) stream.
        /// </summary>
        [XmlElement("participantstreamassoc")]
        public List<participantstreamassoc> participantstreamassocs { get; set; } = new 
            List<participantstreamassoc>();

        /// <summary>
        /// Extension point for custom elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// Creates a new Globally Unique Identifier (GUID) as a base64 string. Base64 encoded GUIDs 
        /// are used for the values of ID attributess in the SIPREC metadata schema.
        /// </summary>
        /// <returns>Returns the byte array of a Guid as a base64 encoded string.
        /// </returns>
        public static string NewGuidBase64Value()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }

    /// <summary>
    /// Enumeration used for specifying the data mode of a recording metadata XML document.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public enum dataMode
    {
        /// <summary>
        /// Indicates that full metadata is being provided.
        /// </summary>
        complete,

        /// <summary>
        /// Indicates that only partial metadata is being provided.
        /// </summary>
        partial,
    }

    /// <summary>
    /// Class containing data about a Communication Session Group. See Section 6.2 of RFC 7865.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class group {
        
        /// <summary>
        /// Specifies the time that the Communication Session Group is associated with the recording. 
        /// If this value field is set, then the associatetimeSpecified field must be set to true.
        /// </summary>
        [XmlElement("associate-time")]
        public DateTime associatetime { get; set; }
        
        /// <summary>
        /// Set this field to true if the associatetime field has been set.
        /// </summary>
        [XmlIgnore()]
        public bool associatetimeSpecified { get; set; }

        /// <summary>
        /// Specifies the time that the grouping ends. If this field is set then set the 
        /// disassociatetimeSpecified field to true.
        /// </summary>
        [XmlElement("disassociate-time")]
        public DateTime disassociatetime { get; set; }

        /// <summary>
        /// If true, then the disassociatetime has been set.
        /// </summary>
        [XmlIgnore]
        public bool disassociatetimeSpecified { get; set; }

        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// This attribute groups different CSs that are related. Must be set to a base64 encoded 
        /// GUID byte array.
        /// </summary>
        [XmlAttribute()]
        public string group_id { get; set; }

        /// <summary>
        /// Constructor for creating a new group object. This constructor sets group_id, 
        /// associatetime and associatetimeSpecified fields.
        /// </summary>
        public group()
        {
            group_id = recording.NewGuidBase64Value();
            associatetime = DateTime.Now;
            associatetimeSpecified = true;
        }
    }
    
    /// <summary>
    /// Class for associating a participant with send and receive media streams. See Section 6.8 of 
    /// RFC 7865.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class participantstreamassoc
    {
        /// <summary>
        /// This attribute indicates whether a participant is contributing to a stream or not.
        /// This attribute has a value that points to a stream represented by its stream_id. The 
        /// presence of this attribute indicates that a participant is contributing to a stream.
        /// </summary>
        [XmlElement("send")]
        public List<string> send { get; set; } = new List<string>();

        /// <summary>
        /// This attribute indicates whether a participant is receiving a media stream or not. 
        /// This attribute has a value that points to a stream represented by its stream_id. The presence 
        /// of this attribute indicates that a participant is receiving a stream.
        /// </summary>
        [XmlElement("recv")]
        public List<string> recv { get; set; } = new List<string>();

        /// <summary>
        /// This attribute indicates the time a participant started contributing to a media stream.
        /// </summary>
        [XmlElement("associate-time")]
        public DateTime associatetime { get; set; }
        
        /// <summary>
        /// Set this field if the associatetime field has be set.
        /// </summary>
        [XmlIgnore]
        public bool associatetimeSpecified { get; set; } = true;

        /// <summary>
        /// This attribute indicates the time a participant stopped contributing to a media stream.
        /// </summary>
        [XmlElement("disassociate-time")]
        public DateTime disassociatetime { get; set; }

        /// <summary>
        /// Set this field to true if the disassociatetime field has be set.
        /// </summary>
        [XmlIgnore]
        public bool disassociatetimeSpecified { get; set; }
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// Must be set to the participant_id of a participant object.
        /// </summary>
        [XmlAttribute()]
        public string participant_id { get; set; }
    }
    
    /// <summary>
    /// Class that describes the association between a participant and a communications session.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class participantsessionassoc
    {
        /// <summary>
        /// Contains the time that the participant was associated with the communication session.
        /// </summary>
        [XmlElement("associate-time")]
        public DateTime associatetime { get; set; }
        
        /// <summary>
        /// Set this field to true if the associatetime field has been set.
        /// </summary>
        [XmlIgnore]
        public bool associatetimeSpecified { get; set; } = true;
        
        /// <summary>
        /// Contains the time that a participant was disassociated from the communication session.
        /// </summary>
        [XmlElement("disassociate-time")]
        public DateTime disassociatetime { get; set; }
        
        /// <summary>
        /// Set this field to true if the disassociatetime field has been set.
        /// </summary>
        [XmlIgnore()]
        public bool disassociatetimeSpecified { get; set; }
        
        /// <summary>
        /// Contains an array of Participant Session Association Parameters.
        /// Note: this is not typically used.
        /// </summary>
        [XmlElement("param")]
        public List<participantsessionassocParam> param { get; set; }
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// This attribute identifies the participant to which this association belongs. This is a 
        /// GUID byte array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string participant_id { get; set; }

        /// <summary>
        /// This attribute identifies the session to which this association belongs. This is a GUID byte 
        /// array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string session_id { get; set; }
    }
    
    /// <summary>
    /// Data class that contains a parameter name/parameter value pair for describing capabilities in 
    /// the Contact header as defined in Section 9 of RFC 3840. See Section 6.6.1 of RFC 7865.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class participantsessionassocParam
    {
        /// <summary>
        /// Contains the parameter name.
        /// </summary>
        [XmlAttribute()]
        public string pname { get; set; }
        
        /// <summary>
        /// Contains the parameter value.
        /// </summary>
        [XmlAttribute()]
        public string pval { get; set; }
    }
    
    /// <summary>
    /// This class describes the association between a communication session and a recording session.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlTypeAttribute(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class sessionrecordingassoc
    {
        /// <summary>
        /// Time that the communication session was associated with the recording session.
        /// </summary>
        [XmlElement("associate-time")]
        public DateTime associatetime { get; set; }
        
        /// <summary>
        /// Set to true if the associatetime has been set.
        /// </summary>
        [XmlIgnore()]
        public bool associatetimeSpecified { get; set; } = true;
        
        /// <summary>
        /// Time that communication session was disassociated from the recording session.
        /// </summary>
        [XmlElement("disassociate-time")]
        public DateTime disassociatetime { get; set; }
        
        /// <summary>
        /// Set to true if the disassociatetime fiel has been set.
        /// </summary>
        [XmlIgnore()]
        public bool disassociatetimeSpecified { get; set; }
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;
        
        /// <summary>
        /// Identifies the communication session. This is a GUID byte array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string session_id { get; set; }
    }
    
    /// <summary>
    /// This class contains the properties of a media stream as seen by the SRC.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class stream
    {
        /// <summary>
        /// References an SDP "a=label" attribute that identifies an m-line within the RS SDP. 
        /// The m-line carries the media stream from the SRC to the SRS.
        /// </summary>
        public string label { get; set; }
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// Unique identifier for the stream. This is a GUID byte array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string stream_id { get; set; } = recording.NewGuidBase64Value();

        /// <summary>
        /// Unique identifier for the session. This is a GUID byte array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string session_id { get; set; }
    }
    
    /// <summary>
    /// Data class for representing a participants name and his/her language.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class name
    {
        /// <summary>
        /// Specifies the language.
        /// </summary>
        [XmlAttribute(Form=System.Xml.Schema.
            XmlSchemaForm.Qualified, Namespace="http://www.w3.org/XML/1998/namespace")]
        public string lang { get; set; }
        
        /// <summary>
        /// Contains the name.
        /// </summary>
        [XmlText()]
        public string Value { get; set; }
    }
    
    /// <summary>
    /// Data class for storing the name and Address of Record (AOR) for a participant.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class nameID
    {
        /// <summary>
        /// Contains the name and language.
        /// </summary>
        public name name { get; set; }
        
        /// <summary>
        /// Contains the AOR URI.
        /// </summary>
        [XmlAttribute(DataType="anyURI")]
        public string aor;
    }
    
    /// <summary>
    /// Data class for information about a participant. See Section 6.5 of RFC 7865.
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlTypeAttribute(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class participant
    {
        /// <summary>
        /// Contains the name and AOR for the participant.
        /// </summary>
        [XmlElement("nameID")]
        public List<nameID> nameIDs { get; set; } = new List<nameID>();
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<XmlElement> Any;

        /// <summary>
        /// ID for the participant. This is a GUID byte array encoded as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string participant_id { get; set; } = recording.NewGuidBase64Value();
    }
    
    /// <summary>
    /// Data class for the reason element of a communication session (session object).
    /// Specifies the reason that the the communication session was terminated.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class reason
    {
        /// <summary>
        /// Note: Value not specified in RFC 7865.
        /// </summary>
        [XmlAttribute()]
        public short cause;
        
        /// <summary>
        /// Always set to SIP.
        /// </summary>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValue("SIP")]
        public string protocol { get; set; }
        
        /// <summary>
        /// Text description of the reason.
        /// </summary>
        [XmlText]
        public string Value { get; set; }
        
        /// <summary>
        /// Constructs a new reason object.
        /// </summary>
        public reason()
        {
            protocol = "SIP";
        }
    }

    /// <summary>
    /// Data class for a communication session (session). See Section 6.3 of RFC 7865.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    public partial class session
    {
        /// <summary>
        /// Set to a list of SIP Session-ID header values for each participant of the call it 
        /// the Session-ID headers (see RFC 7989) are available.
        /// </summary>
        [XmlElement("sipSessionID")]
        public List<string> sipSessionID { get; set; } = new List<string>();
        
        /// <summary>
        /// Contains the reason that the call was terminated.
        /// </summary>
        [XmlElement("reason")]
        public List<reason> reason { get; set; }
        
        /// <summary>
        /// Optional. Contains the group_id of the Communication Session Group (see Section 6.2 of 
        /// RFC 7865) to which the enclosing session belongs.
        /// </summary>
        [XmlElement("group-ref")]
        public string groupref { get; set; }
        
        /// <summary>
        /// Start time of the session.
        /// </summary>
        [XmlElement("start-time")]
        public DateTime starttime { get; set; }
        
        /// <summary>
        /// Set to true if the starttime field has been set.
        /// </summary>
        [XmlIgnore]
        public bool starttimeSpecified { get; set; }
        
        /// <summary>
        /// Stop time of the session. This field is optional.
        /// </summary>
        [XmlElement("stop-time")]
        public DateTime stoptime { get; set; }
        
        /// <summary>
        /// Set to true if the stoptime field has been set.
        /// </summary>
        [XmlIgnore()]
        public bool stoptimeSpecified { get; set; } 
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any;

        /// <summary>
        /// Unique identifier for the communication session. This is a GUID byte array encoded 
        /// as a base64 string.
        /// </summary>
        [XmlAttribute()]
        public string session_id { get; set; } = recording.NewGuidBase64Value();
    }
    
    /// <summary>
    /// Data class for a request for a metadata snapshot sent by the SRS to the SRC. See Section 7 of 
    /// RFC 7865.
    /// </summary>
    [Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:recording:1")]
    [XmlRoot(Namespace="urn:ietf:params:xml:ns:recording:1", IsNullable=false)]
    public partial class requestsnapshot
    {
        /// <summary>
        /// Contains the reason for the request.
        /// </summary>
        public name requestreason { get; set; }
        
        /// <summary>
        /// Extension point.
        /// </summary>
        [XmlAnyElement()]
        public List<XmlElement> Any;
    }
}
