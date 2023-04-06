/////////////////////////////////////////////////////////////////////////////////////
//  File:   GatewayCallLogEvent.cs                                  14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Dynamic;

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the GatewayCallLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by an LNG, LPG, or LSRG to log a call entering or leaving on a legacy interface.
    /// </summary>
    public class GatewayCallLogEvent : LogEvent
    {
        /// <summary>
        /// Contains the port or trunk group.
        /// </summary>
        public string portTrunkGroup { get; set; }

        /// <summary>
        /// 10-digit number when LNG or LSRG handles a call from a legacy wireless or legacy VoIP network, 
        /// or the pANI an LPG creates.
        /// </summary>
        public string pAni { get; set; }

        /// <summary>
        /// Contains what the LNG/LSRG received from the network (8, 10, or 20 digits) or what the LPG sent. 
        /// If 20 digits, the first 10 are the calling party id, and the second 10 are the pANI, separated 
        /// by a comma.
        /// </summary>
        public string digits { get; set; }

        /// <summary>
        /// Must be set to either "incoming" or "outgoing".
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        /// Must be set to either “SS7” or “CAMA”.
        /// </summary>
        public string signallingProtocol { get; set; }

        /// <summary>
        /// Not specified.
        /// </summary>
        public string legacyCallId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GatewayCallLogEvent()
        {
            logEventType = "GatewayCallLogEvent";
        }
    }
}
