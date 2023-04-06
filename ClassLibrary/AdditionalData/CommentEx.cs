/////////////////////////////////////////////////////////////////////////////////////
//	File:	CommentEx.cs											17 Nov 15 PHR
//	Revised:  15 Mar 23 PHR
//				-- Added documentation comments
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;

namespace AdditionalData
{
	/// <summary>
	/// Data class for the additional data Comment block. Provides a mechanism for the data provider to
	/// supply extra, human-readable information to the PSAP.
	/// See Section 4.5 of RFC 7851.
	/// </summary>
	public partial class CommentType
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CommentType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public CommentType(XmlNode Root)
		{
			foreach (XmlNode Node in Root.ChildNodes)
			{
				switch (Node.LocalName)
				{
					case "DataProviderReference":
						dataProviderReferenceField = Node.InnerText;
						break;
					case "Comment":
						commentField = (CommentSubType[]) vcardType.AddObjToObjArray(
							commentField, new CommentSubType(Node), typeof(
							CommentSubType));
						break;
				} // end switch
			} // end foreach
		}
	}

	public partial class CommentSubType
	{
		/// <summary>
		/// Default constructor. Used for de-serialization using XmlSerializer or 
		/// to create a new object of this type.
		/// </summary>
		public CommentSubType() { }

		/// <summary>
		/// Constructor used when manually parsing a XML document.
		/// </summary>
		/// <param name="Root">Root node containing the XML for this type</param>
		public CommentSubType(XmlNode Root)
		{
			if (Root.Attributes["xml:lang"] != null)
				langField = Root.Attributes["xml:lang"].Value;

			valueField = Root.InnerText;
		}
	}
}
