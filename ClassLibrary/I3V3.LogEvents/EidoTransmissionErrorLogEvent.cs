/////////////////////////////////////////////////////////////////////////////////////
//  File:   EidoTransmissionErrorLogEvent.cs                        5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// Logged if an error in the process of sending or receiving an EIDO occurs. See Section 2.9.5 of
/// NENA-STA-024.1a-2023.
/// </summary>
public class EidoTransmissionErrorLogEvent : LogEvent
{
    /// <summary>
    /// If logged by the server then set to the ID of the client. If logged by the client then set to the
    /// ID of the server. Required.
    /// </summary>
    public string peerId { get; set; }

    /// <summary>
    /// Must be set to either "incoming" or "outgoing". Required.
    /// </summary>
    public string direction { get; set; }

    /// <summary>
    /// Number of transmission attempts. Required.
    /// </summary>
    public int retries { get; set; }

    /// <summary>
    /// Set to the reason code for the failure. Must be set to one of the values listed in Section 3.4
    /// of NENA-STA-024.1a-2023. Required.
    /// </summary>
    public string reasonCode { get; set; }

    /// <summary>
    /// Text that describes the reason for the failure. Required.
    /// </summary>
    public string reasonText { get; set; }

    /// <summary>
    /// Transaction ID for the transmission request. Required.
    /// </summary>
    public string transactionId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public EidoTransmissionErrorLogEvent()
    {
        logEventType = "EidoTransmissionErrorLogEvent";
    }
}
