/////////////////////////////////////////////////////////////////////////////////////
//  File:   ElementState.cs                                         12 Jan 23 PHR
//
//  Revised:    24 Jul 25 PHR
//              -- Changed the ElementStateType class from public to internal.
//              -- Added the state, elementDomain and reason properties to the
//                 ElementState class.
//              -- Added definitions for constants the allowable values for the state
//                 property of the ElementState class.
//              -- Added the ElementStateValues property to the ElementState class.
//              -- Added new constructors to the ElementState class.
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace I3SubNot;

/// <summary>
/// Data class for the I3V3 Element State NOTIFY body. See Section 2.4.1 and Section E.11.3.1 of 
/// NENA-STA-010.3b.
/// <para>
/// Note: Section 2.4.1 does not agree with the JSON schema defined in Section E.11.3.1, so this class 
/// uses the schema defined in E.11.3.1.
/// </para>
/// </summary>
public class ElementState
{
    /// <summary>
    /// Contains the element state information. Required.
    /// </summary>
    [JsonInclude]
    private ElementStateType elementState { get; set; } = new ElementStateType();

    /// <summary>
    /// Default constructor for serialization 
    /// </summary>
    public ElementState()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="State">Current Element State. Required. Use one of the constant field values definded by this class.</param>
    /// <param name="Domain">Element ID for the functional element. Required. Must be in the format specified in Section 2.1.3 of NENA-STA-010.3b. For example: esrp1.state.pa.us</param>
    /// <param name="Reason">Reason that the element state has changed. Optional.</param>
    public ElementState(string State, string Domain, string Reason = null)
    {
        state = State;
        elementDomain = Domain;
        reason = Reason;
    }

    /// <summary>
    /// Gets or sets the current Element State.
    /// </summary>
    [JsonIgnore]
    public string state
    {
        get { return elementState.state; }
        set { elementState.state = value; } 
    }

    /// <summary>
    /// NG9-1-1 Element Identifier. Identifies the NG9-1-1 functional element reporting Element state.
    /// <para>
    /// Must be in the format specified in Section 2.1.3 of NENA-STA-010.3b. For example: esrp1.state.pa.us 
    /// </para>
    /// <para>Required.</para>
    /// </summary>
    [JsonIgnore]
    public string elementDomain
    {
        get { return elementState.elementDomain; }
        set { elementState.elementDomain = value; }
    }

    /// <summary>
    /// Text containing the reason the state was changed, if available. Optional
    /// </summary>
    [JsonIgnore]
    public string reason
    {
        get { return elementState.reason; }
        set { elementState.reason = value; }
    }

    /// <summary>
    /// The element is operating normally
    /// </summary>
    public const string Normal = "Normal";
    /// <summary>
    /// The element is undergoing maintenance activities and is not processing requests
    /// </summary>
    public const string ScheduledMaintenance = "ScheduledMaintenance";
    /// <summary>
    /// The element has significant problems and is unable to process all requests
    /// </summary>
    public const string ServiceDisruption = "ServiceDisruption";
    /// <summary>
    /// The element is completely overloaded
    /// </summary>
    public const string Overloaded = "Overloaded";
    /// <summary>
    /// The element is being taken out of service
    /// </summary>
    public const string GoingDown = "GoingDown";
    /// <summary>
    /// The element is unavailable
    /// </summary>
    public const string Down = "Down";
    /// <summary>
    /// Subscriber is unable to contact the functional element
    /// </summary>
    public const string Unreachable = "Unreachable";

    /// <summary>
    /// Allowable values for the element state of an element. See Section 10.13 of NENA-STA-010.3b.
    /// </summary>
    public static readonly string[] ElementStateValues = new string[]
    {
        Normal,
        ScheduledMaintenance,
        ServiceDisruption,
        Overloaded,
        GoingDown,
        Down,
        Unreachable
    };
}

/// <summary>
/// Class for describing element state
/// </summary>
internal class ElementStateType
{
    /// <summary>
    /// Element identifier. Required
    /// </summary>
    public string elementDomain { get; set; }

    /// <summary>
    /// Current element state. Required.
    /// Must be one of the values from the elementState Registry. See Section 10.13 of NENA-STA-010.3: 
    /// Normal, ScheduledMaintenance, ServiceDisruption, Overloaded, GoingDown, Down, Unreachable. 
    /// </summary>
    public string state { get; set; }

    /// <summary>
    /// Text containing the reason the state was changed, if available. Optional
    /// </summary>
    public string reason { get; set; }
}
