﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 

/////////////////////////////////////////////////////////////////////////////////////
//  Revised:  15 Mar 23 PHR
//              -- Simplified the XML namespaces and attributes
//              -- Added documentation comments
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace AdditionalData {
    
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:Comment")]
    [XmlRoot("EmergencyCallData.Comment", Namespace="urn:ietf:params:xml:ns:EmergencyCallData:Comment", 
        IsNullable=false)]
    public partial class CommentType {
        
        private string dataProviderReferenceField;
        private CommentSubType[] commentField;
        private System.Xml.XmlElement[] anyField;
        
        /// <summary>
        /// Identifies the provider (data provider) of this block. Should match the DataProviderReference
        /// element of a ProviderInfo additional data block.
        /// </summary>
        [XmlElement(DataType="token")]
        public string DataProviderReference {
            get {
                return this.dataProviderReferenceField;
            }
            set {
                this.dataProviderReferenceField = value;
            }
        }
        
        /// <summary>
        /// Contains an array of comments. Each comment contains a free form text string.
        /// </summary>
        [XmlElement("Comment")]
        public CommentSubType[] Comment {
            get {
                return this.commentField;
            }
            set {
                this.commentField = value;
            }
        }
        
        /// <summary>
        /// Extension point for this class.
        /// </summary>
        [XmlAnyElement()]
        public System.Xml.XmlElement[] Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
            }
        }
    }
    
    /// <summary>
    /// Data class for a Comment.
    /// </summary>
    [Serializable()]
    [XmlType(Namespace="urn:ietf:params:xml:ns:EmergencyCallData:Comment")]
    public partial class CommentSubType {
        
        private string langField;
        private string valueField;
        
        /// <summary>
        /// Specifies the language of the text in the comment.
        /// </summary>
        [XmlAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, 
            Namespace="http://www.w3.org/XML/1998/namespace")]
        public string lang {
            get {
                return this.langField;
            }
            set {
                this.langField = value;
            }
        }
        
        /// <summary>
        /// Free form text of the comment
        /// </summary>
        [XmlText()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}