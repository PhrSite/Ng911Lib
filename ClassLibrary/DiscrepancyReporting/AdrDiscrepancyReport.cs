/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdrDiscrepancyReport.cs                                 22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using AdditionalData;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the ADR/IS-ADR Discrepancy Report. See Sections 3.7.18 and E.2.1 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class AdrDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the type or problem being reported. Must be set to the string equivalent of one
        /// of the values in the AdrProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The name of the block.
        /// Conditional: REQUIRED if the problem relates to a specific block.
        /// </summary>
        public string block { get; set; }

        /// <summary>
        /// The location used to search for the Additional Data.
        /// Conditional: REQUIRED when a location was used to search for Additional Data.
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// The identity used to search for the additional data.
        /// Conditional: REQUIRED for IS-ADR (as opposed to ADR).
        /// </summary>
        public string identity { get; set; }

        /// <summary>
        /// The additional data URI.
        /// Conditional: REQUIRED for ADR(as opposed to IS-ADR).
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// The result received from the ADR/IS-ADR.
        /// Conditional: REQUIRED if a result was received from the ADR/IS-ADR.
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AdrDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems for an ADR Discrepancy Report.
    /// </summary>
    public enum AdrProblemEnum
    {
        /// <summary>
        /// The URI reference could not be resolved
        /// </summary>
        ReferenceNotResolved,
        /// <summary>
        /// Malformed or invalid request
        /// </summary>
        Malformed,
        /// <summary>
        /// Unknown block of data
        /// </summary>
        UnknownBlock,
        /// <summary>
        /// Received incorrect data as verified by the call taker with the caller
        /// </summary>
        ReceivedIncorrectData,
        /// <summary>
        /// Reported when an ECRF is provisioned with more URIs for a location than can be returned
        /// </summary>
        TooManyUris,
        /// <summary>
        /// Other ADR error or problem
        /// </summary>
        OtherAdr
    }
}
