/////////////////////////////////////////////////////////////////////////////////////
//	File:	SubscriberInfoEx.cs										17 Nov 15 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	public partial class SubscriberInfoType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object 
		/// of this type.
		/// </summary>
		public SubscriberInfoType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public SubscriberInfoType(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						dataProviderReferenceField = Node.InnerText;
						break;
					case "SubscriberData":
						foreach (XmlNode Cn in Node.ChildNodes)
						{
							if (Cn.LocalName == "vcard")
								subscriberDataField = (vcardType[]) vcardType.
									AddObjToObjArray(subscriberDataField, new 
									vcardType(Cn), typeof(vcardType));
						}
						break;
					case "privacyRequested":
						if (Node.InnerText == "true")
							privacyRequestedField = true;
						else
							privacyRequestedField = false;
						break;
				} // end switch
			} // end foreach
		}
	}
}
