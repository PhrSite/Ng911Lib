/////////////////////////////////////////////////////////////////////////////////////
//	File:	LocationInfo.cs											30 Nov 22 PHR
//	Revised:  15 Mar 23 PHR
//				-- Simplified the XML namespaces and attributes
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;

namespace AdditionalData
{
	/// <summary>
	/// Wrapper class for the LocationInfo XML document that contains additional information about a 
	/// caller. See Section 3.5.3 of NENA-STA-012.2
	/// </summary>
	[Serializable()]
	[XmlType(Namespace = "urn:nena:xml:ns:EmergencyCallData:LocationInfo")]
	[XmlRoot("EmergencyCallData.NENA-LocationInfo", Namespace = "urn:nena:xml:ns:EmergencyCallData:LocationInfo", 
		IsNullable = false)]
	public class LocationInfo
	{
		/// <summary>
		/// Default constructor to use when programmatically creating a new object.
		/// </summary>
		public LocationInfo()
		{
		}

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public LocationInfo(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						DataProviderReference = Node.InnerText;
						break;
					case "LocationContacts":
						if (LocationContacts == null)
							LocationContacts = new List<vcardType>();
						foreach (XmlNode Cn in Node.ChildNodes)
						{
							LocationContacts.Add(new vcardType(Cn));
						}
						break;
					case "LocationSpecificData":
						LocationSpecificData = Node.InnerText;
						break;
					case "LocationSpecificType":
						LocationSpecificType = Node.InnerText;
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
		/// Contains one or more xCards containing contacts related to the location.
		/// </summary>
		[XmlArrayItem("vcard", Namespace = "urn:ietf:params:xml:ns:vcard-4.0", IsNullable = false)]
		public List<vcardType> LocationContacts;

		/// <summary>
		///  URI for the document that contains the additional data for the location.
		/// </summary>
		[XmlElement("LocationSpecificData")]
		public string LocationSpecificData;

		/// <summary>
		/// String that describes the structure of the CallerSpecificData document.
		/// Values are to be determined.
		/// </summary>
		[XmlElement("LocationSpecificType")]
		public string LocationSpecificType;
	}
}
