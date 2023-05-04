/////////////////////////////////////////////////////////////////////////////////////
//  File:   ConferenceEvent.cs                                      12 Jan 23 PHR
//
//  Description:    This file contains the classes for the SIP Event Package for 
//                  Conference State XML schema defined in RFC 4575. The classes
//                  were originally generated with the xsd.exe command line tool
//                  from the file called ConferenceEvent.xsd. This XSD file was
//                  downloaded from the IETF XML Registry:
//  https://www.iana.org/assignments/xml-registry/schema/conference-info.xsd
//
//      The command line used to generate this file was:
//          xsd.exe ConferenceEvent.xsd /c /f/ n:I3SubNot
//
//      Do not regenerate this file using xsd.exe because this file has been 
//      modified:
//          1.) arrays ([]) were replaced with List<> because List<> is much
//              easier to work with in applications.
//          2.) Added documentation comments.
//          3.) Changed the state attributes from a statetype
//              enumeration to a string because the XML serialization libraries
//              do not serialize enumerated attribute values.
//          4.) Simplified the namespaces in the attributes
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml.Serialization;

namespace I3SubNot
{
    
    /// <summary>
    /// This is the root element tag (conference-info) of the conference event XML document.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="conference-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    [XmlRoot("conference-info", Namespace="urn:ietf:params:xml:ns:conference-info", IsNullable=false)]
    public partial class conferencetype {

        /// <summary>
        /// Defines the MIME type to used in for a SIP Content-Type header
        /// </summary>
        [XmlIgnore]
        public const string ConfMimeType = "application/conference-info+xml";

        /// <summary>
        /// Provides an overall description of the conference. This field is optional. See Section 5.3 of 
        /// RFC 4575.
        /// </summary>
        [XmlElement("conference-description")]
        public conferencedescriptiontype conferencedescription;

        /// <summary>
        /// Contains information about the entity hosting the conference. Optional. See Section 5.4 of RFC 4575.
        /// </summary>
        [XmlElement("host-info")]
        public hosttype hostinfo;
        
        /// <summary>
        /// Contains overall conference state information. Optional. See Section 5.5
        /// of RFC 4575.
        /// </summary>
        [XmlElement("conference-state")]
        public conferencestatetype conferencestate;
        
        /// <summary>
        /// Contains the participants of the conference. See Section 5.6 of RFC 4575.
        /// </summary>
        public userstype users;

        /// <summary>
        /// This element contains a set of entry child elements, each containing a sidebar conference URI. 
        /// See Section 5.9.1 of RFC 4575. Optional.
        /// </summary>
        [XmlElement("sidebars-by-ref")]
        public uristype sidebarsbyref;

        /// <summary>
        /// This element contains a set of entry child elements, each containing information about a single 
        /// sidebar. See Section 5.9.2 of RFC 4575.
        /// Optional.
        /// </summary>
        [XmlElement("sidebars-by-val")]
        public sidebarsbyvaltype sidebarsbyval;
        
        /// <summary>
        /// Extension point for new elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;

        /// <summary>
        /// This attribute contains the conference URI that identifies the conference being described in 
        /// the document. Required. See Section 5.2 of RFC 4575.
        /// </summary>
        [XmlAttribute(DataType="anyURI")]
        public string entity;

        /// <summary>
        /// This attribute indicates whether the document contains the whole conference information("full") or 
        /// only the information that has changed since the previous document("partial"), or whether the 
        /// conference ceased to exist ("deleted").
        /// </summary>
        [XmlAttribute()]
        public string state;

        /// <summary>
        /// This attribute allows the recipient of conference information documents to properly order the 
        /// received notifications. Optional. Not valid if the versionSpecified field is false. See Section 
        /// 5.2 of RFC 4575.
        /// </summary>
        [XmlAttribute()]
        public uint version;

        /// <summary>
        /// If true then the version field has been specified and is valid. If false then the version has not 
        /// been specified.
        /// </summary>
        [XmlIgnore()]
        public bool versionSpecified;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public conferencetype() 
        {
            state = "full";
        }
    }

    /// <summary>
    /// Class for the conference-description element that describes the conference as a whole. See Section 
    /// 5.3 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="conference-description-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class conferencedescriptiontype {

        /// <summary>
        /// Contains descriptive text suitable for human consumption. Optional.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// Contains the subject of the conference. Optional.
        /// </summary>
        public string subject;

        /// <summary>
        /// Contains an additional longer description of the conference. Optional.
        /// </summary>
        [XmlElement("free-text")]
        public string freetext;

        /// <summary>
        /// Contains a list of space-separated string tokens that can be used by search engines to better 
        /// classify the conference. Optional.
        /// </summary>
        public string keywords;

        /// <summary>
        /// This element contains a sequence of entry child elements - each containing the URI to be used 
        /// in order to access the conference by different signaling means. See Section 5.3.1 of 
        /// RFC 4575. Optional.
        /// </summary>
        [XmlElement("conf-uris")]
        public uristype confuris;

        /// <summary>
        /// This element describes auxiliary services available for the conference.
        /// See Section 5.3.2 of RFC 4575. Optional.
        /// </summary>
        [XmlElement("service-uris")]
        public uristype serviceuris;

        /// <summary>
        /// The value of this element provides a hint to the recipient of the conference document about the 
        /// number of users that can be invited to the conference. Not valid if maximumusercountSpecified 
        /// is false.
        /// </summary>
        [XmlElement("maximum-user-count")]
        public uint maximumusercount;
        
        /// <summary>
        /// If true then the maximumusercount element is valid.
        /// </summary>
        [XmlIgnore()]
        public bool maximumusercountSpecified;

        /// <summary>
        /// This element contains a sequence of entry child elements of conference-medium-type, each being 
        /// indexed by the attribute ’label’. See Section 5.3.4 of RFC 4575. Optional.
        /// </summary>
        [XmlElement("available-media")]
        public conferencemediatype availablemedia;
        
        /// <summary>
        /// Extension point for new elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Extension point for new elements.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class that contains a list of URIs.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="uris-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class uristype {
        
        /// <summary>
        /// List of URIs
        /// </summary>
        [XmlElement("entry")]
        public List<uritype> entry = new List<uritype>();

        /// <summary>
        /// Specifies that state of the information in this class.
        /// </summary>
        [XmlAttribute()]
        public string state;
        
        /// <summary>
        /// Attribute extension point.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public uristype() 
        {
            state = "full";
        }
    }
    
    /// <summary>
    /// Class that contains information about a single URI.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="uri-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class uritype {
        
        /// <summary>
        /// Specifies the URI.
        /// </summary>
        [XmlElement(DataType="anyURI")]
        public string uri;
        
        /// <summary>
        /// Displayable text. Optional.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// The value of the purpose element indicates the intended usage of the URI in the context of 
        /// the conference. Optional.
        /// </summary>
        public string purpose;
        
        /// <summary>
        /// Contains information about the modification of the URI.
        /// </summary>
        public executiontype modified;
        
        /// <summary>
        /// Extention point fo elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class for specifying the date/time, reason and who modified or changed an element.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="execution-type",  Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class executiontype {
        
        /// <summary>
        /// Date/time the change was made. Not valid if whenSpecified is false.
        /// </summary>
        public System.DateTime when;
        
        /// <summary>
        /// If true, then the when field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool whenSpecified;
        
        /// <summary>
        /// Text describing the reason for the change. Optional.
        /// </summary>
        public string reason;
        
        /// <summary>
        /// URI of the person or entity making the change. Optional.
        /// </summary>
        [XmlElement(DataType="anyURI")]
        public string by;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class for containing information about the side-bars of the conference by value. See Section 
    /// 5.9.3 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="sidebars-by-val-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class sidebarsbyvaltype {
        
        /// <summary>
        /// Contains the information about the sidebar sub-conferences.
        /// </summary>
        [XmlElement("entry")]
        public List<conferencetype> entry = new List<conferencetype>();

        /// <summary>
        /// State of the sub-conference information.
        /// </summary>
        [XmlAttribute()]
        public string state;
        
        /// <summary>
        /// Attributes extension point.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public sidebarsbyvaltype()
        {
            state = "full";
        }
    }
    
    /// <summary>
    /// Enumeration for specifying the state of the conference information.
    /// </summary>
    [Serializable()]
    [XmlType(TypeName="state-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public enum statetype {
        
        /// <summary>
        /// Full update.
        /// </summary>
        full,
        
        /// <summary>
        /// Partial update.
        /// </summary>
        partial,
        
        /// <summary>
        /// Element has been deleted.
        /// </summary>
        deleted,
    }
    
    /// <summary>
    /// Class that contains information about the SIP dialog between a participant and the conference focus.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="sip-dialog-id-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class sipdialogidtype {
        
        /// <summary>
        /// Displayable text. Optional.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;
        
        /// <summary>
        /// SIP Call-ID header value for the call. This should be required.
        /// </summary>
        [XmlElement("call-id")]
        public string callid;
        
        /// <summary>
        /// Contains the From header tag of the SIP dialog.
        /// </summary>
        [XmlElement("from-tag")]
        public string fromtag;
        
        /// <summary>
        /// Contains the To header tag of the SIP dialog.
        /// </summary>
        [XmlElement("to-tag")]
        public string totag;
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class that contains information about a call.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="call-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class calltype {

        /// <summary>
        /// Contains information about the SIP dialog.
        /// </summary>
        /// <remarks>The XSD in the file called ConferenceEvent.xsd is incorrect in the
        /// definition of the call-type at line 246 because it has the sip element
        /// wrapped in a xs:choice element with an xs:any element. I believe that
        /// this was not the intent. The code that was generated as a result of
        /// this error is as follows:
        /// <code>
        ///     [System.Xml.Serialization.XmlAnyElementAttribute()]
        ///     [System.Xml.Serialization.XmlElementAttribute("sip", 
        ///         typeof(sipdialogidtype))]
        ///     public object Item;
        /// </code>
        /// The code for the sip element and the Any element of this class has
        /// been modified by hand to correct the error in the XSD code.
        /// </remarks>
        [XmlElement()]
        public sipdialogidtype sip = null;

        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Attribute extension point.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class for containing information about a single media stream. See Section 5.8 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="media-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class mediatype {

        /// <summary>
        /// This element contains the display text for the media stream. The value of this element 
        /// corresponds to the SDP description media attribute("i") defined in SDP (RFC 4566).
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// This element contains the media type for the media stream. The value of this element MUST be 
        /// one of the values registered for "media" of SDP.
        /// For example (audio, video from the m= SDP line)l
        /// </summary>
        public string type;

        /// <summary>
        /// The label element carries a unique identifier for this stream among all streams in the 
        /// conference and is assigned by the focus. This is typically from the a=label:n attribute in 
        /// the SDP and the value of the label field would be "n".
        /// </summary>
        public string label;
        
        /// <summary>
        /// Contains the synchronization source (SSRC) of the RTP stream. See Section 5.8.4 of RFC 4575.
        /// </summary>
        [XmlElement("src-id")]
        public string srcid;
        
        /// <summary>
        /// Contains the status of the media stream: sndrecv, sendonly, etc. Not valid if the 
        /// statusSpecified field is false.
        /// </summary>
        public mediastatustype status;
        
        /// <summary>
        /// If true, then the status field is valie, else it is not.
        /// </summary>
        [XmlIgnore()]
        public bool statusSpecified;
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;

        /// <summary>
        /// This is the media stream identifier being generated by the server such that its value is 
        /// unique in the endpoint context. This attribute is the key to refer to a particular media 
        /// stream in the conference document.
        /// </summary>
        [XmlAttribute()]
        public string id;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Enumeration for specifying the status of a media stream. Taken from the SDP attribute, 
    /// a=sendrecv, a=sendonly, etc.
    /// </summary>
    [Serializable()]
    [XmlType(TypeName="media-status-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public enum mediastatustype {
        
        /// <remarks/>
        recvonly,
        
        /// <remarks/>
        sendonly,
        
        /// <remarks/>
        sendrecv,
        
        /// <remarks/>
        inactive,
    }
    
    /// <summary>
    /// Class that provides information for an endpoint of a conference. See Section 5.7 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="endpoint-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class endpointtype {

        /// <summary>
        /// This element contains the display text for the endpoint. Optional.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// This element contains information about the user whose action resulted in this endpoint 
        /// being brought into the conference. See Section 5.7.2 of RFC 4575. Optional.
        /// </summary>
        public executiontype referred;

        /// <summary>
        /// This element contains the status of the endpoint. Optional. Not valid if the statusSpecified 
        /// field is false.
        /// </summary>
        public endpointstatustype status;
        
        /// <summary>
        /// If true, then the status field is valie, else it is not.
        /// </summary>
        [XmlIgnore()]
        public bool statusSpecified;

        /// <summary>
        /// This element contains the method by which the endpoint joined the conference. Not valid if the 
        /// joiningmethodSpecified field is false.
        /// </summary>
        [XmlElement("joining-method")]
        public joiningtype joiningmethod;
        
        /// <summary>
        /// If true, then the joiningmethod field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool joiningmethodSpecified;

        /// <summary>
        /// This element contains information about how the endpoint joined. See
        /// Section 5.7.5 of RFC 4575. Optional.
        /// </summary>
        [XmlElement("joining-info")]
        public executiontype joininginfo;

        /// <summary>
        /// This element contains the method by which the endpoint departed the conference. See Section 
        /// 5.7.6 of RFC 4575. Not valid if the disconnectionmethodSpecified is false. Optional.
        /// </summary>
        [XmlElement("disconnection-method")]
        public disconnectiontype disconnectionmethod;
        
        /// <summary>
        /// If true, then the disconnnectionmethod field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool disconnectionmethodSpecified;

        /// <summary>
        /// This element contains information about the endpoint’s departure from the conference. See 
        /// Section 5.7.7 of RFC 4575. Optional.
        /// </summary>
        [XmlElement("disconnection-info")]
        public executiontype disconnectioninfo;
        
        /// <summary>
        /// Contains information about the media of the endpoint.
        /// </summary>
        [XmlElement("media")]
        public List<mediatype> media = new List<mediatype>();
        
        /// <summary>
        /// Contains information about the call relating to the endoint of the
        /// conference.
        /// </summary>
        [XmlElement("call-info")]
        public calltype callinfo;
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Value of the required entity attribute of the endpoint element. See Section 5.7 of RFC 4575.
        /// </summary>
        [XmlAttribute()]
        public string entity;

        /// <summary>
        /// This attribute indicates whether the element contains the whole endpoint information 
        /// ("full") or only the information that has changed since the previous document ("partial"), 
        /// or whether the endpoint has been removed from the conference ("deleted").
        /// </summary>
        [XmlAttribute()]
        public string state;
        
        /// <summary>
        /// Attribute extension point.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public endpointtype() {
            //this.state = statetype.full;
            state = "full";
        }
    }
    
    /// <summary>
    /// Enumeration used for the status of an endpoint.
    /// </summary>
    [Serializable()]
    [XmlType(TypeName="endpoint-status-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public enum endpointstatustype {

        /// <summary>
        /// The endpoint is not yet in the session, but it is anticipated that he/she will join in the 
        /// near future.
        /// </summary>
        pending,

        /// <summary>
        /// The focus has dialed out to connect the endpoint to the conference, but the endpoint is not 
        /// yet in the roster (probably being authenticated).
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute("dialing-out")]
        dialingout,

        /// <summary>
        /// The endpoint is dialing into the conference, not yet in the roster (probably being 
        /// authenticated).
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute("dialing-in")]
        dialingin,
        
        /// <summary>
        /// A Public Switched Telephone Network (PSTN) ALERTING or SIP 180 Ringing was returned for 
        /// the outbound call; endpoint is being alerted.
        /// </summary>
        alerting,

        /// <summary>
        /// Active signaling dialog exists between an endpoint and a focus, but endpoint is "on-hold" for 
        /// this conference.
        /// </summary>
        [XmlEnum("on-hold")]
        onhold,

        /// <summary>
        /// The endpoint is a participant in the conference.
        /// </summary>
        connected,

        /// <summary>
        /// Active signaling dialog exists between an endpoint and a focus and the endpoint can "listen" 
        /// to the conference, but the endpoint’s media is not being mixed into the conference.
        /// </summary>
        [XmlEnum("muted-via-focus")]
        mutedviafocus,

        /// <summary>
        /// Focus is in the process of disconnecting the endpoint.
        /// </summary>
        disconnecting,

        /// <summary>
        /// The endpoint is not a participant in the conference, and no active dialog exists between 
        /// the endpoint and the focus.
        /// </summary>
        disconnected,
    }
    
    /// <summary>
    /// Enumeration that specified the method by which an endpoint joined the conference. See Section 
    /// 5.7.4 of RFC 4575.
    /// </summary>
    [System.SerializableAttribute()]
    [XmlType(TypeName="joining-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public enum joiningtype {
        
        /// <remarks/>
        [XmlEnum("dialed-in")]
        dialedin,
        
        /// <remarks/>
        [XmlEnum("dialed-out")]
        dialedout,
        
        /// <remarks/>
        [XmlEnum("focus-owner")]
        focusowner,
    }
    
    /// <summary>
    /// Enumeration that specifies the method by which an endpoint departed the conference. See Section 
    /// 5.7.6 of RFC 4575.
    /// </summary>
    [SerializableAttribute()]
    [XmlType(TypeName="disconnection-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public enum disconnectiontype {
        
        /// <remarks/>
        departed,
        
        /// <remarks/>
        booted,
        
        /// <remarks/>
        failed,
        
        /// <remarks/>
        busy,
    }
    
    /// <summary>
    /// Class that contains human-readable strings describing the roles of a user in the conference. See 
    /// Section 5.6.3 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="user-roles-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class userrolestype {
        
        /// <remarks/>
        [XmlElement("entry")]
        public List<string> entry = new List<string>();
        
        /// <remarks/>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class that contains information about the user of a conference. See Section 5.6 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="user-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class usertype {

        /// <summary>
        /// This element is used to display the user-friendly name in the conference.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// This element contains additional (to the ’entity’) URIs being associated with the user. 
        /// See Section 5.6.2 of RFC 4575.
        /// </summary>
        [XmlElement("associated-aors")]
        public uristype associatedaors;

        /// <summary>
        /// This element MAY contain a set of human-readable strings describing the roles of the user in 
        /// the conference.
        /// </summary>
        public userrolestype roles;

        /// <summary>
        /// This element contains a list of tokens, separated by spaces, each containing a language 
        /// understood by the user.
        /// </summary>
        public string languages;

        /// <summary>
        /// This element contains a conference URI (different from the main conference URI) for users 
        /// that are connected to the main conference as a result of focus cascading. See Section 
        /// 5.6.5 of RFC 4575.
        /// </summary>
        [XmlElement("cascaded-focus", DataType="anyURI")]
        public string cascadedfocus;
        
        /// <summary>
        /// Contains information about one or more endpoints for the user. Optional.
        /// See Section 5.6.6 of RFC 4575.
        /// </summary>
        [XmlElement("endpoint")]
        public List<endpointtype> endpoint = new List<endpointtype>();
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;

        /// <summary>
        /// This attribute contains the URI for the user in the conference. 
        /// Required. See Section 5.6 of RFC 4575.
        /// </summary>
        [XmlAttribute(DataType="anyURI")]
        public string entity;

        /// <summary>
        /// This attribute indicates whether the document contains the whole user information("full") or 
        /// only the information that has changed since the previous document("partial"), or whether 
        /// the user was removed from the conference("deleted").
        /// </summary>
        [XmlAttribute()]
        public string state;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public usertype() 
        {
            state = "full";
        }
    }

    /// <summary>
    /// Class that contains the participants of the conference. See Section 5.6 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="users-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class userstype {

        /// <summary>
        /// Contains a list of users.
        /// </summary>
        [XmlElement("user")]
        public List<usertype> user = new List<usertype>();
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;

        /// <summary>
        /// Specifies the state of the information included in this object.
        /// </summary>
        [XmlAttribute()]
        public string state = "full";
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public userstype()
        {
            state = "full";
        }
    }
    
    /// <summary>
    /// This class contains information about the conference state. See Section 5.5 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="conference-state-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class conferencestatetype {

        /// <summary>
        /// Specified the overall number of participants in the conference. Not valid if usercountSpecified 
        /// field is false.
        /// </summary>
        [XmlElement("user-count")]
        public uint usercount;
        
        /// <summary>
        /// If true, then the usercount field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool usercountSpecified;

        /// <summary>
        /// Specifies whether or not the conference is active. Not valid if the activeSpecified field is 
        /// false.
        /// </summary>
        public bool active;
        
        /// <summary>
        /// If true then the active field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool activeSpecified;

        /// <summary>
        /// Specifies whether or not the conference is locked. See Section 5.5.3 of RFC 4575. Not 
        /// valid if the lockedSpecified field is false.
        /// </summary>
        public bool locked;
        
        /// <summary>
        /// If true then the locked field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool lockedSpecified;
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class that contains information about the entity hosting the conference. See Section 5.4 of 
    /// RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="host-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class hosttype {

        /// <summary>
        /// This element contains information about the entity hosting the conference. Optional.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// This element contains HTTP: or HTTPS: URI of a web page describing either the conference 
        /// service or the user hosting the conference.
        /// Optional.
        /// </summary>
        [XmlElement("web-page", DataType="anyURI")]
        public string webpage;

        /// <summary>
        /// This element contains a set of entry child elements, each containing the URI value and 
        /// optionally its description. Optional.
        /// </summary>
        public uristype uris;
        
        /// <summary>
        /// Extension point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class for information about a single media type. See Section 5.3.4 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="conference-medium-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class conferencemediumtype {

        /// <summary>
        /// This element contains the display text for the media stream.
        /// </summary>
        [XmlElement("display-text")]
        public string displaytext;

        /// <summary>
        /// This element contains the media type of the media stream. The value of this element MUST be 
        /// one of the values registered for media" of SDP and its later revision(s), for example, 
        /// "audio", "video", "text", and "message".
        /// </summary>
        public string type;

        /// <summary>
        /// This element indicates the available status of the media stream available to the conference 
        /// participants. Not valid if the statusSpecified field is false.
        /// </summary>
        public mediastatustype status;
        
        /// <summary>
        /// If true then the status field is valid.
        /// </summary>
        [XmlIgnore()]
        public bool statusSpecified;
        
        /// <summary>
        /// Extention point for elements.
        /// </summary>
        [XmlAnyElement()]
        public List<System.Xml.XmlElement> Any = null;

        /// <summary>
        /// The ’label’ attribute is the media stream identifier assigned by the conferencing server.
        /// </summary>
        [XmlAttribute()]
        public string label;

        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
    
    /// <summary>
    /// Class that contains a list of the media in a conference. See Section 5.3.4 of RFC 4575.
    /// </summary>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(TypeName="conference-media-type", Namespace="urn:ietf:params:xml:ns:conference-info")]
    public partial class conferencemediatype {
        
        /// <summary>
        /// List of the conference media types.
        /// </summary>
        [XmlElement("entry")]
        public List<conferencemediumtype> entry = new List<conferencemediumtype>();
        
        /// <summary>
        /// Extension point for attributes.
        /// </summary>
        [XmlAnyAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr = null;
    }
}
