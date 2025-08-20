/////////////////////////////////////////////////////////////////////////////////////
//  File:   ServiceState.cs                                         12 Jan 23 PHR
//
//  Revised:    24 Jul 25 PHR
//              -- Added string constant definitions to the ServiceType class for the
//                 name property.
//              -- Added the ServiceTypeValues property to the ServiceType class.
//              -- Added string constant definitions to the ServiceStateType class
//                 for the state property.
//              -- Added the ServiceStateValues property to the ServiceStateType class.
//              -- Added string constant definitions to the SecurityPostureType class
//                 for the posture property.
//              -- Added the SecurityPostureValues property to the SecurityPostureType
//                 class.
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot;

/// <summary>
/// Data class for the I3 Service state NOTIFY body. See Section 2.4.2 and Section E.11.3.4 of NENA-STA-010.3.
/// </summary>
public class ServiceState
{
    /// <summary>
    /// Identifies the service. Required.
    /// </summary>
    public ServiceType service { get; set; } = new ServiceType();

    /// <summary>
    /// Contains the state information for the service. Required.
    /// </summary>
    public ServiceStateType serviceState { get; set; } = new ServiceStateType();

    /// <summary>
    /// CONDITIONAL -- If the service maintains Security Posture, the field MUST be present. Otherwise, 
    /// it is omitted. The default value is null.
    /// </summary>
    public SecurityPostureType securityPosture { get; set; } = new SecurityPostureType();

    /// <summary>
    /// Event type for the I3V3 Service State event. See Section 2.4.2 of NENA-STA-010.3.
    /// <para>This is the value that must be in the Event SIP header for a SIP SUBSCRIBE or a NOTIFY request</para>
    /// </summary>
    public const string EventName = "emergency-ServiceState";
}

/// <summary>
/// Contains service identity data.
/// </summary>
public class ServiceType
{
    /// <summary>
    /// Name of the service that specifies the type of service. Required.
    /// <para>
    /// Must be one of the values from the serviceNames registry. See Section 10.11 of NENA-STA-010.3.
    /// Allowable values: ADR, Bridge, ECRF, ESRP, GCS, IMR, Logging, LVF, MCS, MDS, PolicyStore, PSAP, 
    /// SAL.
    /// </para>
    /// <para>Use the constant field values defined by this class. For example: ServiceType.PSAP</para>
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// Service Identifier. Required. 
    /// <para>
    /// Must be in the format specified in Section 2.1.5 of NENA-STA-010.3b. For example: psap.allegheny.pa.us
    /// </para>
    /// </summary>
    public string domain { get; set; }

    /// <summary>
    /// Additional Data Repository (if hosted on an ESInet)
    /// </summary>
    public const string ADR = "ADR";
    /// <summary>
    /// Conference bridge
    /// </summary>
    public const string Bridge = "Bridge";
    /// <summary>
    /// Emergency Call Routing Function
    /// </summary>
    public const string ECRF = "ECRF";
    /// <summary>
    /// Emergency Service Routing Proxy
    /// </summary>
    public const string ESRP = "ESRP";
    /// <summary>
    /// Geocode Conversion Service
    /// </summary>
    public const string GCS = "GCS";
    /// <summary>
    /// Interactive Media Response Service
    /// </summary>
    public const string IMR = "IMR";
    /// <summary>
    /// Logging Service
    /// </summary>
    public const string Logging = "Logging";
    /// <summary>
    /// Location Validation Function
    /// </summary>
    public const string LVF = "LVF";
    /// <summary>
    /// MSAG Conversion Service
    /// </summary>
    public const string MCS = "MCS";
    /// <summary>
    /// Mapping Data Service
    /// </summary>
    public const string MDS = "MDS";
    /// <summary>
    /// Policy Store
    /// </summary>
    public const string PolicyStore = "PolicyStore";
    /// <summary>
    /// Public Service Answering Point
    /// </summary>
    public const string PSAP = "PSAP";
    /// <summary>
    /// Service/Agency Locator
    /// </summary>
    public const string SAL = "SAL";

    /// <summary>
    /// Allowable values for the name property of the ServiceType class.
    /// </summary>
    public static readonly string[] ServiceTypeValues = new string[]
    {
        ADR,
        Bridge,
        ECRF,
        ESRP,
        GCS,
        IMR,
        Logging,
        LVF,
        MCS,
        MDS,
        PolicyStore,
        PSAP,
        SAL
    };

}

/// <summary>
/// Contains service state information.
/// </summary>
public class ServiceStateType
{
    /// <summary>
    /// Indicates the service state. Required.
    /// <para>
    /// Must be one of the values in the serviceState registry. See Section 10.12 of NENA-STA-010.3.
    /// Allowable values: Normal, Unstaffed, SchedulesMaintenanceDown, ScheduledMaintenanceAvailable, 
    /// MajorIncidentInProgress, Partial, Overloaded, GoingDown, Down, Unreachable.
    /// </para>
    /// <para>Use one of the string constants defined by this class. For example: ServiceStateType.Normal</para>
    /// </summary>
    public string state { get; set; }

    /// <summary>
    /// Text containing the reason state was changed, if available. Otherwise, 
    /// empty
    /// </summary>
    public string reason { get; set; }

    /// <summary>
    /// The service is operating normally. Calls can be sent to this destination normally.
    /// </summary>
    public const string Normal = "Normal";
    /// <summary>
    /// Applies to PSAPs only. The PSAP has indicated that it is not currently answering calls.Calls must be sent to
    /// another destination.
    /// </summary>
    public const string Unstaffed = "Unstaffed";
    /// <summary>
    /// The service is undergoing maintenance activities and is not accepting service requests.Calls must
    /// be sent to another destination.
    /// </summary>
    public const string ScheduledMaintenanceDown = "ScheduledMaintenanceDown";
    /// <summary>
    /// The service is undergoing maintenance activities, but will respond to service requests, possibly
    /// with reduced availability.Calls can be sent to this destination normally.
    /// </summary>
    public const string ScheduledMaintenanceAvailable = "ScheduledMaintenanceAvailable";
    /// <summary>
    /// The element is operating normally but is handling a major incident and may be unable to accept some 
    /// requests. Calls could be sent to this destination but doing so may precipitate that destination into an 
    /// overloaded state.
    /// </summary>
    public const string MajorIncidentInProgress = "MajorIncidentInProgress";
    /// <summary>
    /// Processing some requests, but response may be delayed.Calls could be sent to this destination.
    /// </summary>
    public const string Partial = "Partial";
    /// <summary>
    /// The service is completely overloaded. Calls must be sent to another destination.
    /// </summary>
    public const string Overloaded = "Overloaded";
    /// <summary>
    /// The service is being taken out of service.Calls must be sent to another destination.
    /// </summary>
    public const string GoingDown = "GoingDown";
    /// <summary>
    /// The service is unavailable. Calls must be sent to another destination.
    /// </summary>
    public const string Down = "Down";
    /// <summary>
    /// Subscriber is unable to contact the service.
    /// </summary>
    public const string Unreachable = "Unreachable";

    /// <summary>
    /// Allowable values for the service state of a service. See Section 10.12 of NENA-STA-010.3b.
    /// </summary>
    public static readonly string[] ServiceStateValues = new string[]
    {
        Normal,
        Unstaffed,
        ScheduledMaintenanceDown,
        ScheduledMaintenanceAvailable,
        MajorIncidentInProgress,
        Partial,
        Overloaded,
        GoingDown,
        Down,
        Unreachable
    };
}

/// <summary>
/// Contains security posture information.
/// </summary>
public class SecurityPostureType
{
    /// <summary>
    /// Identifies the current security posture. Required.
    /// <para>
    /// Must be one of the values in the securityPosture registry. See Section 10.18 of NENA-STA-010.3.
    /// Allowable values: Green, Yelow, Orange, Red.
    /// </para>
    /// Use the one of the constant values defined in this class. For example: SercurityPostureType.Green.
    /// </summary>
    public string posture { get; set; }

    /// <summary>
    /// Text containing the reason posture changed, if available. Otherwise, empty.
    /// </summary>
    public string reason { get; set; }

    /// <summary>
    /// The entity is operating normally. Calls can be sent to this destination normally.
    /// </summary>
    public const string Green = "Green";
    /// <summary>
    /// The entity is receiving suspicious activity but is able to operate normally.Calls could be sent to this 
    /// destination.
    /// </summary>
    public const string Yellow = "Yellow";
    /// <summary>
    /// The entity is receiving fraudulent calls/events, is stressed, but is able to continue most operations.
    /// Calls could be sent to this destination but doing so may precipitate that destination into an overloaded 
    /// state.
    /// </summary>
    public const string Orange = "Orange";
    /// <summary>
    /// The entity is under active attack and is overwhelmed. Calls must be sent to another destination.
    /// </summary>
    public const string Red = "Red";

    /// <summary>
    /// Allowable values for the security posture of a service. See Section 10.18 of NENA-STA-010.3b.
    /// </summary>
    public static readonly string[] SecurityPostureValues = new string[]
    {
        Green,
        Yellow,
        Orange,
        Red
    };
}
