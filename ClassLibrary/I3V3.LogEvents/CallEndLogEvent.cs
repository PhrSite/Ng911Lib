/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallEndLogEvent.cs                                      7 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a call ends.
/// </summary>
public class CallEndLogEvent : CallLogEvent
{
    /// <summary>
    /// Constructor
    /// </summary>
    public CallEndLogEvent()
    {
        logEventType = "CallEndLogEvent";
    }
}
