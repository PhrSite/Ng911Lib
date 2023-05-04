/////////////////////////////////////////////////////////////////////////////////////
//  File:   BcfDiscrepancyReport.cs                                 20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for sending a BCF Discrepancy Report. See Sections 3.7.6 and E.2.1 of NENA-STA-010.3
    /// </summary>
    public class BcfDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// If the discrepancy concerns a dialog, the set to the initial INVITE that initiated the dialog.
        /// Conditional: REQUIRED when the discrepancy concerns a dialog.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// Specifies the type of problem with the BCF. Must be set to the string equivalent of one of the
        /// values in the BcfProblemEnum.
        /// Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// Set to the emergency-source parameter of the dialog request (i.e., the initial INVITE).
        /// See Section 4.1.2 of NENA-STA-010.3. Required.
        /// </summary>
        public string sosSource { get; set; }

        /// <summary>
        /// Timestamp of the event being reported. Must be in the NENA Timestamp format
        /// specified in Section 2.3 of NENA-STA-010.3. Required.
        /// </summary>
        public string eventTimestamp { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// For InitialTrafficBlocked, MidTrafficBlocked, TrafficNotBlockedBadActor, TrafficNotBlocked, 
        /// or Firewall, contains the packet’s header, encoded using base64.
        /// CONDITIONAL, REQUIRED for InitialTrafficBlocked, MidTrafficBlocked, TrafficNotBlockedBadActor, 
        /// TrafficNotBlocked, or Firewall, OPTIONAL otherwise
        /// </summary>
        public string packetHeader { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BcfDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Identifies a BCF problem.
    /// </summary>
    public enum BcfProblemEnum
    {
        /// <summary>
        /// Initial traffic blocked
        /// </summary>
        InitialTrafficBlocked,
        /// <summary>
        /// Mid traffic blocked
        /// </summary>
        MidTrafficBlocked,
        /// <summary>
        /// Bad SDP
        /// </summary>
        BadSdp,
        /// <summary>
        /// Bad SIP message
        /// </summary>
        BadSip,
        /// <summary>
        /// Media loss detected
        /// </summary>
        MediaLoss,
        /// <summary>
        /// Traffic from a bad actor not blocked
        /// </summary>
        TrafficNotBlockedBadActor,
        /// <summary>
        /// Traffic was not blocked when it should have been
        /// </summary>
        TrafficNotBlocked,
        /// <summary>
        /// Media Quality of Service problem
        /// </summary>
        Qos,
        /// <summary>
        /// Bad Call Detail Report
        /// </summary>
        BadCdr,
        /// <summary>
        /// TTY related problem
        /// </summary>
        Tty,
        /// <summary>
        /// Firewall related problem
        /// </summary>
        Firewall,
        /// <summary>
        /// Other BCF problem
        /// </summary>
        OtherBcf
    }
}
