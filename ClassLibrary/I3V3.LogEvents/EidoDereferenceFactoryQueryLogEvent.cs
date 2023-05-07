/////////////////////////////////////////////////////////////////////////////////////
//  File: EidoDereferenceFactoryQueryLogEvent.cs                    5 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3V3.LogEvents;

/// <summary>
/// For logging client requests using the EIDODereferenceFactory. See Section 2.9.2 of NENA-STA-024.1a-2023.
/// </summary>
public class EidoDereferenceFactoryQueryLogEvent : LogEvent
{
    /// <summary>
    /// Sets or gets the query ID. Unique ID used for matching a response to the query. See Section 2.9 of 
    /// NENA-STA-024.1a-2023.
    /// Required
    /// </summary>
    public string queryId { get; set; }

    /// <summary>
    /// Direction of the request. Must be set to incoming or outgoing.
    /// Required
    /// </summary>
    public string direction { get; set; }

    /// <summary>
    /// For a client (direction = "outgoing"), it is the identity of the server. For the server (direction =
    /// "incoming"), it is the identity of the requesting client.
    /// </summary>
    public string peerId { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public EidoDereferenceFactoryQueryLogEvent()
    {
        logEventType = "EidoDereferenceFactoryQueryLogEvent";
    }
}
