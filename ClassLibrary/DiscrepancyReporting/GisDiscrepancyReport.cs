/////////////////////////////////////////////////////////////////////////////////////
//  File:   GisDiscrepancyReport.cs                                 22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the GIS Discrepancy Report. See Sections 3.7.11 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class GisDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be set to the string equivalent of one of the values in the
        /// GisProblemEnum.
        /// Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The IDs of the layers as a whitespace separated list.
        /// Conditional: REQUIRED if the error is specific to a layer or set of layers.
        /// </summary>
        public string layerIds { get; set; }

        /// <summary>
        /// One or more locations where the gap or overlap can be found or for which an incorrect LoST 
        /// referral is made.
        /// Conditional: REQUIRED if the error is specific to a location or set of locations.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// The URI provisioned.
        /// Conditional: REQUIRED if a URI was provisioned.
        /// </summary>
        public string lostUri { get; set; }

        /// <summary>
        /// A string containing the name of the item that is duplicated, omitted, or contains an incorrect 
        /// data type; or the geometry or address range is bad; or the URI is malformed.
        /// Conditional: REQUIRED if the problem is an item that is duplicated, omitted, or contains an 
        /// incorrect data type; or if the problem concerns bad geometry, an incorrect address range, or 
        /// a malformed URI.
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GisDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems reported in a GIS Discrepancy Report.
    /// </summary>
    public enum GisProblemEnum
    {
        Gap,
        Overlap,
        IncorrectLost,
        BadGeometry,
        DuplicateAttribute,
        OmittedField,
        IncorrectDataType,
        AddressRange,
        GeneralProvisioning,
        MalformedUri,
        DisplayData,
        OtherGis
    }
}
