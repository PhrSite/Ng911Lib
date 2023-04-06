/////////////////////////////////////////////////////////////////////////////////////
//	File:	DeviceInfoEx.cs											17 Nov 15 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	public partial class DeviceInfoType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or 
		/// to create a new object of this type.
		/// </summary>
		public DeviceInfoType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public DeviceInfoType(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						dataProviderReferenceField = Node.InnerText;
						break;
					case "DeviceClassification":
						deviceClassificationField = Node.InnerText;
						break;
					case "DeviceMfgr":
						deviceMfgrField = Node.InnerText;
						break;
					case "DeviceModelNr":
						deviceModelNrField = Node.InnerText;
						break;
					case "UniqueDeviceID":
						uniqueDeviceIDField = (DeviceInfoTypeUniqueDeviceID[])
							vcardType.AddObjToObjArray(uniqueDeviceIDField, new
								DeviceInfoTypeUniqueDeviceID(Node), typeof(
								DeviceInfoTypeUniqueDeviceID));
						break;
					case "DeviceSpecificData":
						deviceSpecificDataField = Node.InnerText;
						break;
					case "DeviceSpecificType":
						deviceSpecificTypeField = Node.InnerText;
						break;
				} // end switch
			} // end foreach
		}
	}

	public partial class DeviceInfoTypeUniqueDeviceID
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or 
		/// to create a new object of this type.
		/// </summary>
		public DeviceInfoTypeUniqueDeviceID() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public DeviceInfoTypeUniqueDeviceID(XmlNode Root)
		{
			if (Root.Attributes["TypeOfDeviceID"] != null)
				typeOfDeviceIDField = Root.Attributes["TypeOfDeviceID"].Value;

			valueField = Root.InnerText;
		}
	}
}
