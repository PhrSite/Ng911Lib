/////////////////////////////////////////////////////////////////////////////////////
//	File:	Confidence.cs											30 Nov 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml.Serialization;

namespace Pidf
{
    /// <summary>
    /// Class that implements the confidence XML schema described in RFC 7459. 
    /// This class is used for the confidence element within a location-info element in a PIDF-LO XML 
    /// document.
    /// </summary>
    [Serializable()]
    [XmlRoot(Namespace = "urn:ietf:params:xml:ns:geopriv:conf", IsNullable = false)]
    public class Confidence
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Confidence()
        {
        }

        /// <summary>
        /// Creates a new Confidence object given the value
        /// </summary>
        /// <param name="strVal">Confidence value. Must be either "unknown" or the string representation of 
        /// an integer value between 0 and 100.</param>
        /// <param name="strPdf">Probability distribution function. Must be "unknown", "normal" or 
        /// "rectangular".</param>
        public Confidence(string strVal, string strPdf)
        {
            Value = strVal;
            pdf = strPdf;
        }

		/// <summary>
		/// The value of a confidence element is either unknown or a string
		/// that represents an integer percentage value between 0 and 100.
		/// </summary>
		[XmlText()]
		public string Value = "unknown";

        /// <summary>
        /// Attribute that describes the shape of the Probability Distribution
        /// Function (PDF)
        /// </summary>
        [XmlAttribute("pdf")]
        public string pdf = "unknown";
    }

	/// <summary>
	/// Enumeration that describes the shape of the Probability Distribution Function (PDF) that describes 
    /// the confidence of a location.
	/// </summary>
	public enum PdfEnum
    {
		/// <summary>
		/// The PDF is unknown
		/// </summary>
		unknown,
		/// <summary>
		/// Normal (Gausian)
		/// </summary>
		normal,
		/// <summary>
		/// The PDF shape is retangular
		/// </summary>
		rectangular
    }
}
