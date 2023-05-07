/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallLogEvent.cs                                         7 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// This is the base class for CallStartLogEvent, RecCallStartLogEvent, CallEndEvent and RecCallEndLogEvent
/// and others. Do not use this class directly for logging events.
/// </summary>
public class CallLogEvent : LogEvent
{
    /// <summary>
    /// Specifies the direction of the call. Must be "incoming" or "outgoing".
    /// Required.
    /// </summary>
    public string direction { get; set; } = "incoming";

    /// <summary>
    /// Type of the call. Must be one of the values specified in the LogEvent
    /// Call Types Registry. See Section 10.23 of NENA-STA-010.3.
    /// </summary>
    public string standardPrimaryCallType { get; set; } = "emergency";

    /// <summary>
    /// Not required. Must be one of the values defined in Section 10.23 of NENA-STA-010.3 if
    /// specified.
    /// </summary>
    public string standardSecondaryCallType { get; set; }

    /// <summary>
    /// Contains an application specific local call type.
    /// Optional.
    /// </summary>
    public string localCallType { get; set; }

    /// <summary>
    /// Contains application specific local use information.
    /// Optional.
    /// </summary>
    public object localUse { get; set; }

    /// <summary>
    /// Used for non-SIP interfaces, identifies the destination of the call. Not requred for SIP interfaces.
    /// </summary>
    public string to { get; set; }

    /// <summary>
    /// Used for non-SIP interfaces, identifies the source of the call. Not requred for SIP interfaces.
    /// </summary>
    public string from { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public CallLogEvent()
    {
    }
}
