/////////////////////////////////////////////////////////////////////////////////////
//  File:   HookflashLogEvent.cs                                    14 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the HookflashLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged by an LPG when initiates a hookswitch flash or it detects a hookswitch flash event on
    /// the line. Not logged if the hookswitch flash event is logged with a GatewayCallLogEvent.
    /// </summary>
    public class HookflashLogEvent : LogEvent
    {
        /// <summary>
        /// Set to the ID of the line if known.
        /// </summary>
        public string lineId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public HookflashLogEvent()
        {
            logEventType = "HookflashLogEvent";
        }
    }
}
