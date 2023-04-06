///////////////////////////////////////////////////////////////////////////////////////
//	File:	TelContactInfo.cs											17 Nov 15 PHR
///////////////////////////////////////////////////////////////////////////////////////

namespace AdditionalData
{
	/// <summary>
	/// This class is used to store telephone contact information that is extracted
	/// from an xcard.
	/// </summary>
	public class TelContactInfo
	{
		/// <summary>
		/// Contains the telephone number or a SIP URI.
		/// </summary>
		public String TelNumber = "";
		/// <summary>
		/// Contains the extension number if there is any.
		/// </summary>
		public String Extension = "";
		/// <summary>
		/// Contains a list of attributes such as the phone type and a list of
		/// media that can be handled.
		/// </summary>
		public String Description = "";
		/// <summary>
		/// Contains the preference value for the telephone number. The range is
		/// from 1 through 100. A value of 1 is the most preferred.
		/// </summary>
		public String Pref = null;
	}
}
