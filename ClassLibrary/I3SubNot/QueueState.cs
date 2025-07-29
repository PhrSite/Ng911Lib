/////////////////////////////////////////////////////////////////////////////////////
//  File:   QueueState.cs                                           12 Jan 23 PHR
//
//  Revised:    24 Jul 25 PHR
//              -- Changed the QueueStateType class from public to internal.
//              -- Added the queueState, queueUri, queueLength, queueMaxLength and
//                 state properties to the QueueState class.
//              -- Added string constants for the state property of the QueueState
//                 class.
//              -- Added the QueueStateValues property to the QueueState class.
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace I3SubNot;

/// <summary>
/// Data class for the I3V3 Queue state NOTIFY body. See Section 4.2.1.3 and Section E.11.3.3 of NENA-STA-010.3.
/// </summary>
public class QueueState
{
    /// <summary>
    /// Contains the queue state information. Required.
    /// </summary>
    [JsonInclude]
    private QueueStateType queueState { get; set; } = new QueueStateType();

    /// <summary>
    /// SIP URI of queue. Required
    /// </summary>
    [JsonIgnore]
    public string queueUri
    {   get { return queueState.queueUri; }
        set { queueState.queueUri = value; }
    }

    /// <summary>
    /// Integer indicating current number of calls in the queue. Required
    /// </summary>
    [JsonIgnore]
    public int queueLength
    {
        get { return queueState.queueLength; }
        set { queueState.queueLength = value; }
    }

    /// <summary>
    /// Integer indicating maximum length of the queue. Required
    /// </summary>
    [JsonIgnore]
    public int queueMaxLength
    {
        get { return queueState.queueMaxLength; }
        set { queueState.queueMaxLength = value; } 
    }

    /// <summary>
    /// Current queue state. Required.
    /// <para>
    /// Must be one of the values in the queueState registry. See Section 10.17 of NENA-STA-010.3.
    /// Allowed values: Active, Inactive, Disabled, Full, Standby,  ResourceExhausted, Unreachable.
    /// </para>
    /// <para>Use one of the constant string values defined in this class. For example: QueueState.Active.</para>
    /// </summary>
    [JsonIgnore]
    public string state
    {
        get { return queueState.state; }
        set { queueState.state = value; }
    }

    /// <summary>
    /// One or more entities are actively available or are currently handling calls being enqueued
    /// </summary>
    public const string Active = "Active";
    /// <summary>
    /// No entity is available or actively handling calls being enqueued
    /// </summary>
    public const string Inactive = "Inactive";
    /// <summary>
    /// The queue is disabled by management action and no calls may be enqueued
    /// </summary>
    public const string Disabled = "Disabled";
    /// <summary>
    /// The queue is full, and no new calls can be enqueued on it
    /// </summary>
    public const string Full = "Full";
    /// <summary>
    /// The queue has one or more entities that are available to take calls, but the queue is not presently in 
    /// use. When a call is enqueued, the state changes to “Active”
    /// </summary>
    public const string Standby = "Standby";
    /// <summary>
    /// The downstream entity cannot accept any more calls for a reason other than one of the above conditions.
    /// </summary>
    public const string ResourceExhausted = "ResourceExhausted";
    /// <summary>
    /// The queue is unreachable. Used by the subscriber to provide a value when it is unable to subscribe.
    /// </summary>
    public const string Unreachable = "Unreachable";

    /// <summary>
    /// Allowable values for the queue state of a PSAP's call queue. See Section 10.17 of NENA-STA-010.3b.
    /// </summary>
    public static readonly string[] QueueStateValues = new string[]
    {
        Active,
        Inactive,
        Disabled,
        Full,
        Standby,
        ResourceExhausted,
        Unreachable
    };
}

/// <summary>
/// Class for queue state information
/// </summary>
internal class QueueStateType
{
    /// <summary>
    /// SIP URI of queue. Required
    /// </summary>
    public string queueUri { get; set; }

    /// <summary>
    /// Integer indicating current number of calls in the queue. Required
    /// </summary>
    public int queueLength { get; set; } = 0;

    /// <summary>
    /// Integer indicating maximum length of the queue. Required
    /// </summary>
    public int queueMaxLength { get; set; } = 0;

    /// <summary>
    /// Current queue state. Required.
    /// Must be one of the values in the queueState registry. See Section 10.17 of NENA-STA-010.3.
    /// Allowed values: Active, Inactive, Disabled, Full, Standby,  ResourceExhausted, Unreachable.
    /// </summary>
    public string state { get; set; }
}
