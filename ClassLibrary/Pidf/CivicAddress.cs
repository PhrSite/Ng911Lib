/////////////////////////////////////////////////////////////////////////////////////
//	File:	ArcCivicAddressBand.cs									20 Jul 17 PHR
//  Revised:    30 Nov 22 PHR -- Code cleanup for .NET 6. Added documentation
//                comments.
//				1 Dec 22 PHR -- Added the Any element array so that unknown
//				  extensions can be handled.
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace Pidf
{
	/// <summary>
	/// Class that implements the a civicAddress XML schema. See RFC 4119, RFC 5139 and RFC 6848 for 
	/// the definition of the civicAddress XML schema.
	/// </summary>
	[Serializable()]
	[XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr")]
	[XmlRoot("civicAddress", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr", 
		IsNullable = false)]
	public class CivicAddress
	{
		/// <summary>
		/// Default constructor. Initializes all elements to null;
		/// </summary>
		public CivicAddress()
		{
		}

		/// <summary>
		/// The country identified by a two letter code. Example "US".
		/// </summary>
		[XmlElement("country")]
		public string country = null;
		/// <summary>
		/// The state or national subdivision.
		/// </summary>
		[XmlElement("A1")]
		public string A1 = null;
		/// <summary>
		/// The county name.
		/// </summary>
		public string A2 = null;
		/// <summary>
		///  The city or township.
		/// </summary>
		public string A3 = null;
		/// <summary>
		/// City division, borough, city district or ward.
		/// </summary>
		public string A4 = null;
		/// <summary>
		/// Neighborhood or block.
		/// </summary>
		public string A5 = null;
		/// <summary>
		/// Street name. No longer used, use RD.
		/// </summary>
		public string A6 = null;
		/// <summary>
		/// Road pre-modifier such as "Old". (RFC 5139)
		/// </summary>
		public string PRM = null;
		/// <summary>
		/// Leading street direction, such as N, W
		/// </summary>
		public string PRD = null;
		/// <summary>
		/// Primary road or street. (RFC 5139)
		/// </summary>
		public string RD = null;
		/// <summary>
		/// Street suffix such as "Avenue", "Street".
		/// </summary>
		public string STS = null;
		/// <summary>
		/// Trailing street suffix.
		/// </summary>
		public string POD = null;
		/// <summary>
		/// Road post-modifier. (RFC 5139) Ex. "Extended".
		/// </summary>
		public string POM = null;
		/// <summary>
		/// Road section (RFC 5139).
		/// </summary>
		public string RDSEC = null;
		/// <summary>
		/// Road branch. (RFC 5139).
		/// </summary>
		public string RDBR = null;
		/// <summary>
		/// Road sub-branch (RFC 5139).
		/// </summary>
		public string RDSUBBR = null;
		/// <summary>
		/// House number, numeric part only.
		/// </summary>
		public string HNO = null;
		/// <summary>
		/// House number suffix. Ex. "A" or "1/2".
		/// </summary>
		public string HNS = null;
		/// <summary>
		/// Landmark or vanity address.
		/// </summary>
		public string LMK = null;
		/// <summary>
		/// Additional location information. Ex. "Room 543".
		/// </summary>
		public string LOC = null;
		/// <summary>
		/// Floor number.
		/// </summary>
		public string FLR = null;
		/// <summary>
		/// Name (residence, business or office occupant).
		/// </summary>
		public string NAM = null;
		/// <summary>
		/// Postal or zip code.
		/// </summary>
		public string PC = null;
		/// <summary>
		/// Building name or structure name. (RFC 5139)
		/// </summary>
		public string BLD = null;
		/// <summary>
		/// Unit, appartment or suite number. (RFC 5139)
		/// </summary>
		public string UNIT = null;
		/// <summary>
		/// Room number. (RFC 5139)
		/// </summary>
		public string ROOM = null;
		/// <summary>
		/// Seat (desk, cubicle, or workstation) (RFC 5139)
		/// </summary>
		public string SEAT = null;
		/// <summary>
		/// Place-type, Ex. office. (RFC 5139)
		/// </summary>
		public string PLC = null;
		/// <summary>
		/// Postal community name. (RFC 5139)
		/// </summary>
		public string PCN = null;
		/// <summary>
		/// Post office box number. (RFC 5139)
		/// </summary>
		public string POBOX = null;
		/// <summary>
		/// Additional code. (RFC 5139)
		/// </summary>
		public string ADDCODE = null;

        /// <summary>
        /// Pole Number -- See Section 5.1 of RFC 6848
        /// </summary>
        [XmlElement("PN", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr:ext")]
        public string PN = null;

        /// <summary>
        /// Mile Post -- See Section 5.2 of RFC 6848
        /// </summary>
        [XmlElement("MP", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr:ext")]
        public string MP = null;

        /// <summary>
        /// Street Type Prefix -- See Section 5.3 of RFC 6848 
        /// </summary>
        [XmlElement("STP", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr:ext")]
        public string STP = null;

        /// <summary>
        /// House Number Prefix -- See Section 5.4 of RFC 6848
        /// </summary>
        [XmlElement("HNP", Namespace = "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr:ext")]
        public string HNP = null;

		// 1 Dec 22 PHR
        private System.Xml.XmlElement[] anyField;

		// 1 Dec 22 PHR
		/// <summary>
		/// Stores any unknown extensions to the CivicAddress schema
		/// </summary>
        [XmlAnyElement()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }

        /// <summary>
        /// Builds a string that can be used for a human readable form of this civic address
		/// object.
        /// </summary>
        /// <returns>Returns a human readable street address.</returns>
        public string BuildFormattedStreetAddress()
        {
            StringBuilder Sb = new StringBuilder();
            if (string.IsNullOrEmpty(HNP) == false) Sb.Append(HNP + " ");
            if (string.IsNullOrEmpty(HNO) == false) Sb.Append(HNO);
            if (string.IsNullOrEmpty(HNS) == false) Sb.Append(HNS);
            if (string.IsNullOrEmpty(PRM) == false) Sb.Append(" " + PRM);
            if (string.IsNullOrEmpty(PRD) == false) Sb.Append(" " + PRD);
            if (string.IsNullOrEmpty(STP) == false) Sb.Append(" " + STP);
            if (string.IsNullOrEmpty(RD) == false) Sb.Append(" " + RD);
            if (string.IsNullOrEmpty(STS) == false) Sb.Append(" " + STS);
            if (string.IsNullOrEmpty(POD) == false) Sb.Append(" " + POD);
            if (string.IsNullOrEmpty(POM) == false) Sb.Append(" " + POM);
            if (string.IsNullOrEmpty(RDSEC) == false) Sb.Append(" " + RDSEC);
            if (string.IsNullOrEmpty(RDBR) == false) Sb.Append(" " + RDBR);
            if (string.IsNullOrEmpty(RDSUBBR) == false) Sb.Append(" " + RDSUBBR);

            return Sb.ToString();
        }
	}
}
