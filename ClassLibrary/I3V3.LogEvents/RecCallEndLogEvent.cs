/////////////////////////////////////////////////////////////////////////////////////
//  File:   RecCallEndLogEvent.cs                                   15 Jan 23 PHR
//  Revised: 7 May 23 PHR -- Changed base class to CallLogEvent
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents
{
    /// <summary>
    /// Data class for the RecCallEndLogEvent. See Sections 4.12.3.7 and E.8.1 of NENA-STA-010.3.
    /// Logged when a SIPREC media recorder detects the end of a SIPREC call.
    /// </summary>
    public class RecCallEndLogEvent : CallLogEvent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RecCallEndLogEvent()
        {
            logEventType = "RecCallEndLogEvent";
        }
    }
}
