/////////////////////////////////////////////////////////////////////////////////////
//  File:   Roles.cs                                                24 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911CertUtils
{
    /// <summary>
    /// Static class that defines the roles for Agents, Agencies, Elements, Services
    /// and Certificate Authorities (CA).
    /// </summary>
    public static class Roles
    {
        /// <summary>
        /// Defines a list of roles for an agent. See Sections 5.3 and 10.28 of NENA-STA-010.3.
        /// </summary>
        public static readonly List<string> AgentRoles = new List<string>()
        {
            "Dispatching", 
            "Call Taking",
            "GIS Analysis",
            "IP Network Administration",
            "Database Administration",
            "IT Systems Administration",
            "Application Administration",
            "Security Administration",
            "Records Production",
            "Data Analysis", 
            "Quality Assurance Evaluation"
        };

        /// <summary>
        /// Defines a list of roles for an agency. See Sections 5.3, 10.27, 10.5, 10.6 and
        /// 10.7 of NENA-STA-010.3.
        /// </summary>
        public static readonly List<string> AgencyRoles = new List<string>()
        {
            "PSAP",
            "Dispatch",
            "911 Authority",
            "ESInet Service Provider",
            "ESRP Service Provider",
            "ECRF Service Provider",
            "LIS Service Provider",

            // See Sections 10.5, 10.6 and 10.7 of NENA-STA-010.3
            "urn:emergency:service:responder.coast_guard",
            "urn:emergency:service:responder.ems",
            "urn:emergency:service:responder.fire",
            "urn:emergency:service:responder.mountain_rescue",
            "urn:emergency:service:responder.poison_control",
            "urn:emergency:service:responder.police",
            "urn:emergency:service:responder.police.stateProvincial",
            "urn:emergency:service:responder.police.tribal",
            "urn:emergency:service:responder.police.countyParish",
            "urn:emergency:service:responder.police.sheriff",
            "urn:emergency:service:responder.police.local",

            "urn:emergency:service:responder.police.federal",
            "urn:emergency:service:responder.police.federal.fbi",
            "urn:emergency:service:responder.police.federal.rcmp",
            "urn:emergency:service:responder.police.federal.usss",
            "urn:emergency:service:responder.police.federal.dea",
            "urn:emergency:service:responder.police.federal.marshal",
            "urn:emergency:service:responder.police.federal.cbp",
            "urn:emergency:service:responder.police.federal.ice",
            "urn:emergency:service:responder.police.federal.atf",
            "urn:emergency:service:responder.police.federal.pp",
            "urn:emergency:service:responder.police.federal.dss",
            "urn:emergency:service:responder.police.federal.fps",
            "urn:emergency:service:responder.police.federal.military",

            "urn:emergency:service:responder.psap",
        };

        /// <summary>
        /// Roles for an element. This list is TBD.
        /// </summary>
        public static readonly List<string> ElementRoles = new List<string>()
        {
            "BCF",
            "ESRP",
            "ECRF",
            "LVF",
            "BRIDGE",
            "LIS",
            "OCIF",     // Outbound Call Interface Function
            "LNG",
            "LPG",
            "LSRG"
        };

        /// <summary>
        /// Roles for a Service. This list is TBD.
        /// </summary>
        public static readonly List<string> ServiceRoles = new List<string>()
        {
            "MCS",      // MSAG Conversion Service
            "GCS",      // Geocode Service
            "ADR",      // Additional Data Repository
            "MDS",      // Mapping Data Service
        };

        /// <summary>
        /// Roles for a Certificate Authority (CA). See Section 7.1.2.11 of the PCA Certificate
        /// Policy document.
        /// </summary>
        public static readonly List<string> CaRoles = new List<string>()
        {
            "PCA",      // PSAP Certificate Authority (for the root CA)
            "ICA"       // Intermediate Certificate Authority
        };
    }
}
