/////////////////////////////////////////////////////////////////////////////////////
//  File:   EidoDeniedLogEvent.cs                                   5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged when a client has requested an EIDO from the Dereference Service and that request has been denied 
/// or deemed invalid. See Section 2.9.4 of NENA-STA-024.1a-2023.
/// </summary>
public class EidoDeniedLogEvent : LogEvent
{
    /// <summary>
    /// If logged by the server then set to the ID of the client. If logged by the client, set to the ID
    /// of the server. Required.
    /// </summary>
    public string peerId { get; set; }

    /// <summary>
    /// Contains the reason code for the denial. Required
    /// </summary>
    public string reasonCode { get; set; }

    /// <summary>
    /// Contains a text explanation for the denial. Required.
    /// </summary>
    public string reasonText { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public EidoDeniedLogEvent()
    {
        logEventType = "EidoDeniedLogEvent";
    }
}
