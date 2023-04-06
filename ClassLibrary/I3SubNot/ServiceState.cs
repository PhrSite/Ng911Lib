/////////////////////////////////////////////////////////////////////////////////////
//  File:   ServiceState.cs                                         12 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3 Service State NOTIFY body. See Section 2.4.2 and Section E.11.3.4 of 
    /// NENA-STA-010.3.
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
        /// CONDITIONAL If the service maintains Security Posture, the field MUST be present. Otherwise, 
        /// it is omitted.
        /// </summary>
        public SecurityPostureType securityPosture { get; set; } = null;
    }

    /// <summary>
    /// Contains service identity data.
    /// </summary>
    public class ServiceType
    {
        /// <summary>
        /// Name of the service. Required
        /// Must be one of the values from the serviceNames registry. See Section 10.11 of NENA-STA-010.3.
        /// Allowable values: ADR, Bridge, ECRF, ESRP, GCS, IMR, Logging, LVF, MCS, MDS, PolicyStore, PSAP, 
        /// SAL.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Service Identifier. Required.
        /// </summary>
        public string domain { get; set; }
    }

    /// <summary>
    /// Contains service state information.
    /// </summary>
    public class ServiceStateType
    {
        /// <summary>
        /// Indicates the service state. Required.
        /// Must be one of the values in the serviceState registry. See Section 10.12 of NENA-STA-010.3.
        /// Allowable values: Normal, Unstaffed, SchedulesMaintenanceDown, ScheduledMaintenanceAvailable, 
        /// MajorIncidentInProgress, Partial, Overloaded, GoingDown, Down, Unreachable.
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// Text containing the reason state was changed, if available. Otherwise, 
        /// empty
        /// </summary>
        public string reason { get; set; }
    }

    /// <summary>
    /// Contains security posture information.
    /// </summary>
    public class SecurityPostureType
    {
        /// <summary>
        /// Identifies the current security posture. Required.
        /// Must be one of the values in the securityPosture registry. See Section 10.18 of NENA-STA-010.3.
        /// Allowable values: Green, Yelow, Orange, Red.
        /// </summary>
        public string posture { get; set; }

        /// <summary>
        /// Text containing the reason posture changed, if available. Otherwise, empty.
        /// </summary>
        public string reason { get; set; }
    }
}
