/////////////////////////////////////////////////////////////////////////////////////
//	File: Provided-ByEx.cs											19 Jul 16 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	/// <summary>
	/// Class for managing the emergency call data when it is passed in the provided-by element of a 
	/// geopriv object in the PIDF-LO.
	/// </summary>
	public class ProvidedBy
	{
		/// <summary>
		/// Contains an array of ByRefType objects that contains references to Additonal Call Data.
		/// </summary>
		public ByRefType[] dataReferencesField;
		/// <summary>
		/// Contains elements of Additional Call Data by value.
		/// </summary>
		public EmergencyCallDataValueType dataValuesField;

		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object 
		/// of this type.
		/// </summary>
		public ProvidedBy() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public ProvidedBy(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "EmergencyCallDataReference":
						dataReferencesField = (ByRefType[])vcardType.AddObjToObjArray(
							dataReferencesField, new ByRefType(Node), 
							typeof(ByRefType));
						break;
					case "EmergencyCallDataValue":
						dataValuesField = new EmergencyCallDataValueType(Node);
						break;
				} // end switch
			} // end foreach
		}
	}

	public partial class ByRefType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object 
		/// of this type.
		/// </summary>
		public ByRefType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public ByRefType(XmlNode Root)
		{
			if (Root.Attributes["purpose"] != null)
				purposeField = Root.Attributes["purpose"].Value;

			if (Root.Attributes["ref"] != null)
				refField = Root.Attributes["ref"].Value;
		}
	}

	public partial class EmergencyCallDataValueType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or to create a new object 
		/// of this type.
		/// </summary>
		public EmergencyCallDataValueType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public EmergencyCallDataValueType(XmlNode Root)
		{
			foreach (XmlNode Node in Root)
			{
				switch (Node.LocalName)
				{
					case "EmergencyCallData.ProviderInfo":
						emergencyCallDataProviderInfoField = (ProviderInfoType[])
							vcardType.AddObjToObjArray(
								emergencyCallDataProviderInfoField, 
								new ProviderInfoType(Node), typeof(ProviderInfoType));
						break;
					case "EmergencyCallData.ServiceInfo":
						emergencyCallDataServiceInfoField = (ServiceInfoType[])
							vcardType.AddObjToObjArray(
								emergencyCallDataServiceInfoField, new 
								ServiceInfoType(Node), typeof(ServiceInfoType));
						break;
					case "EmergencyCallData.DeviceInfo":
						emergencyCallDataDeviceInfoField = (DeviceInfoType[])
							vcardType.AddObjToObjArray(
								emergencyCallDataDeviceInfoField, new 
								DeviceInfoType(Node), typeof(DeviceInfoType));
						break;
					case "EmergencyCallData.SubscriberInfo":
						emergencyCallDataSubscriberInfoField = (SubscriberInfoType[])
							vcardType.AddObjToObjArray(
								emergencyCallDataSubscriberInfoField, new 
								SubscriberInfoType(Node), typeof(SubscriberInfoType));
						break;
					case "EmergencyCallData.Comment":
						emergencyCallDataCommentField = (CommentType[])
							vcardType.AddObjToObjArray(emergencyCallDataCommentField,
								new CommentType(Node), typeof(CommentType));
						break;
				} // end switch
			} // end foreach
		}
	}
}
