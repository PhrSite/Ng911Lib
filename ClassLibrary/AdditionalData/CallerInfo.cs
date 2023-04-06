///////////////////////////////////////////////////////////////////////////////////////
//	File:	CallerInfo.cs												30 Nov 22 PHR
//	Revised:  15 Mar 23 PHR
//				-- Simplified the namespaces and attributes
///////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace AdditionalData
{
	/// <summary>
	/// Wrapper class for the CallerInfo XML document that contains additional information about a caller. 
	/// See Section 3.5.3 of NENA-STA-012.2
	/// </summary>
	[Serializable()]
	[XmlType(Namespace = "urn:nena:xml:ns:EmergencyCallData:CallerInfo")]
	[XmlRoot("EmergencyCallData.NENA-CallerInfo", Namespace = "urn:nena:xml:ns:EmergencyCallData:CallerInfo", 
		IsNullable = false)]
	public class CallerInfo
	{
		/// <summary>
		/// Default constructor to use when programmatically creating a new object.
		/// </summary>
		public CallerInfo()
		{
		}

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public CallerInfo(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						DataProviderReference = Node.InnerText;
						break;
					case "CallerData":
						if (CallerData == null)
							CallerData = new List<vcardType>();
						foreach (XmlNode Cn in Node.ChildNodes)
						{
							if (Cn.LocalName == "vcard")
								CallerData.Add(new vcardType(Cn));
						}
						break;
					case "CallerSpecificData":
						CallerSpecificData = Node.InnerText;
						break;
					case "CallerSpecificType":
						CallerSpecificType = Node.InnerText;
						break;
				} // end switch
			} // end foreach
		}

        /// <summary>
        /// Identifies the provider (data provider) of this block. Should match the DataProviderReference
        /// element of a ProviderInfo additional data block.
        /// </summary>
        [XmlElement("DataProviderReference")]
		public string DataProviderReference;

		/// <summary>
		/// Contains one or more xCards that identify the caller.
		/// </summary>
		[XmlArrayItem("vcard", Namespace = "urn:ietf:params:xml:ns:vcard-4.0", IsNullable = false)]
		public List<vcardType> CallerData;

		/// <summary>
		///  URI for the document that contains the additional data for the caller.
		/// </summary>
		[XmlElement("CallerSpecificData")]
		public string CallerSpecificData;

		/// <summary>
		/// String that describes the structure of the CallerSpecificData document. Values are to be
		/// determined.
		/// </summary>
		[XmlElement("CallerSpecificType")]
		public string CallerSpecificType;
	}
}
