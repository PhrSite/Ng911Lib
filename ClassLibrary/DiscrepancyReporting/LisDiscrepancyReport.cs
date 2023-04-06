/////////////////////////////////////////////////////////////////////////////////////
//  File:   LisDiscrepancyReport.cs                                 22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the LIS Discrepancy Report. See Sections 3.7.12 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class LisDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be set to the string equivalent of one of the values in the
        /// LisProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The request sent by a device for its own location.
        /// Conditional: REQUIRED when the problem is OwnLocationUnavailable.
        /// </summary>
        public string ownLocationRequest { get; set; }

        /// <summary>
        /// The location reference.
        /// Conditional: REQUIRED when a location was returned by reference.
        /// </summary>
        public string locationUrn { get; set; }

        /// <summary>
        /// The (possibly badly formed) PIDF-LO.
        /// Conditional: REQUIRED for BadPIDFLO, SHOULD be supplied when a location was returned by value.
        /// </summary>
        public string pidfLo { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LisDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of the possible problems for a LIS Discrepancy Report.
    /// </summary>
    public enum LisProblemEnum
    {
        IncorrectRecords,
        OwnLocationUnavailable,
        LocationReferenceNotResolved,
        BadPidfLo,
        IncorrectLocation,
        OtherLis
    }
}
