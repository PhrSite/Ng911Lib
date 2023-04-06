/////////////////////////////////////////////////////////////////////////////////////
//	File:	ServiceInfoEx.cs										17 Nov 15 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	public partial class ServiceInfoType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object of 
		/// this type.
		/// </summary>
		public ServiceInfoType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public ServiceInfoType(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						dataProviderReferenceField = Node.InnerText;
						break;
					case "ServiceEnvironment":
						serviceEnvironmentField = Node.InnerText;
						break;
					case "ServiceType":
						vcardType.AddStringItem(ref serviceTypeField, Node.InnerText);
						break;
					case "ServiceMobility":
						serviceMobilityField = Node.InnerText;
						break;
				} // end switch
			} // end foreach
		}
	}
}
