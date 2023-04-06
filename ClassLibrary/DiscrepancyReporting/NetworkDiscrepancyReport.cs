/////////////////////////////////////////////////////////////////////////////////////
//  File:   NetworkDiscrepancyReport.cs                             22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Network Discrepancy Report. See Sections 3.7.19 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class NetworkDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem encountered. Must be set to the string equivalent of one of the
        /// values in the NetworkProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The IP address of the machine experiencing the error.
        /// Conditional: REQUIRED unless DHCP related and the IP address not available.
        /// </summary>
        public string ipAddressLocal { get; set; }

        /// <summary>
        /// The IP address to/from which the problem is occurring.
        /// Conditional: REQUIRED unless problem is DNS or DHCP related.
        /// </summary>
        public string ipAddressRemote { get; set; }

        /// <summary>
        /// The URL of the resource (e.g., the DNS or DHCP server).
        /// Conditional: REQUIRED if known.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// The time at which the problem occurred. Must be in the NENA Timestamp format
        /// specified in Section 2.3 of NENA-STA-010.3. Required
        /// </summary>
        public string timestamp { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NetworkDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible network problems for a Network Discrepancy Report.
    /// </summary>
    public enum NetworkProblemEnum
    {
        ReferenceNotResolved,
        Malformed,
        UnknownBlock,
        ReceivedIncorrectData,
        TooManyUris,
        OtherNetwork
    }
}
