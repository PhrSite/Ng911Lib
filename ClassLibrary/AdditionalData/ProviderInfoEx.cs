/////////////////////////////////////////////////////////////////////////////////////
//	File:	ProviderInfoEx.cs										17 Nov 15 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	public partial class ProviderInfoType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object of 
		/// this type.
		/// </summary>
		public ProviderInfoType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public ProviderInfoType(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						dataProviderReferenceField = Node.InnerText;
						break;
					case "DataProviderString":
						dataProviderStringField = Node.InnerText;
						break;
					case "ProviderID":
						providerIDField = Node.InnerText;
						break;
					case "ProviderIDSeries":
						providerIDSeriesField = Node.InnerText;
						break;
					case "TypeOfProvider":
						typeOfProviderField = Node.InnerText;
						break;
					case "ContactURI":
						contactURIField = Node.InnerText;
						break;
					case "Language":
						vcardType.AddStringItem(ref languageField, Node.InnerText);
						break;
					case "DataProviderContact":
						ProcessDataProviderContact(Node);
						break;
					case "SubcontractorPrincipal":
						subcontractorPrincipalField = Node.InnerText;
						break;
					case "SubcontractorPriority":
						subcontractorPriorityFieldSpecified = true;
						if (Node.InnerText == "sub")
							subcontractorPriorityField = SubcontractorPriorityType.sub;
						else
							subcontractorPriorityField = SubcontractorPriorityType.
								main;
						break;
				} // end switch
			} // end foreach
		}

		private void ProcessDataProviderContact(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "vcard":
						dataProviderContactField = (vcardType[]) vcardType.
							AddObjToObjArray(dataProviderContactField, new 
							vcardType(Node), typeof(vcardType));
						break;
				}
			}
		}
	}
}
