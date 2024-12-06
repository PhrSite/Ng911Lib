/////////////////////////////////////////////////////////////////////////////////////
//  File:   RecCallStartLogEvent.cs                                 15 Jan 23 PHR
//  Revised: 7 May 23 PHR -- Changed base class to CallLogEvent
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the RecCallStartLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3b.
    /// Logged when a SIPREC media recorder detects the start of a SIPREC call.
    /// </summary>
    public class RecCallStartLogEvent : CallLogEvent
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecCallStartLogEvent()
        {
            logEventType = "RecCallStartLogEvent";
        }
    }
}
