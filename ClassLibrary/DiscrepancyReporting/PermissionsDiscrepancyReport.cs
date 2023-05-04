/////////////////////////////////////////////////////////////////////////////////////
//  File:   PermissionsDiscrepancyReport.cs                         22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Permissions Discrepancy Report. See Sections 3.7.10 and E.2.1 of 
    /// NENA-STA-010.3.
    /// </summary>
    public class PermissionsDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Describes the problem. Must be set to the string equivalent of one of the values in the
        /// PermissionsProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// The resource being SUBSCRIBEd, read, written/modified, or deleted, or at which authentication 
        /// failed (URL if available). Required.
        /// </summary>
        public string resource { get; set; }

        /// <summary>
        /// AgentID (Agent Identifier, Agent Id or AgencyID(Agency Identifier, AgencyId of entity that 
        /// attempted the action. Required.
        /// </summary>
        public string identity { get; set; }

        /// <summary>
        /// The result returned from the requested operation.
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// Provides more detail (e.g., specifics of the security failure).
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PermissionsDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of possible problems for the Permissions Discrepancy Report.
    /// </summary>
    public enum PermissionsProblemEnum
    {
        /// <summary>
        /// Unable to authenticate
        /// </summary>
        UnableAuthenticate,
        /// <summary>
        /// Unable to subscribe
        /// </summary>
        UnableSubscribe,
        /// <summary>
        /// Able to subscribe
        /// </summary>
        AbleSubscribe,
        /// <summary>
        /// Unable to read
        /// </summary>
        UnableRead,
        /// <summary>
        /// Unable to write
        /// </summary>
        UnableWrite,
        /// <summary>
        /// Unable to delete
        /// </summary>
        UnableDelete,
        /// <summary>
        /// Able to read
        /// </summary>
        AbleRead,
        /// <summary>
        /// Able to write
        /// </summary>
        AbleWrite,
        /// <summary>
        /// Able to delete
        /// </summary>
        AbleDelete,
        /// <summary>
        /// Other permissions related data
        /// </summary>
        OtherPermissions
    }
}
