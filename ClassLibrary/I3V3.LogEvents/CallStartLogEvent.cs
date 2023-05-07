/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallStartLogEvent.cs                                    7 May 23 PHR
////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a call starts
/// </summary>
public class CallStartLogEvent : CallLogEvent
{

    /// <summary>
    /// Constructor
    /// </summary>
    public CallStartLogEvent()
    {
        logEventType = "CallStartLogEvent";
    }
}
