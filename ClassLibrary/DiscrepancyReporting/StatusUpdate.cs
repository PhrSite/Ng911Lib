/////////////////////////////////////////////////////////////////////////////////////
//  File:   StatusUpdate.cs                                         20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class used by a discrepancy reporting service to provide a status update in response
    /// to a status request. See Sections 3.7.3 and E.2.1 or NENA-STA-010.3.
    /// </summary>
    public class StatusUpdate
    {
        /// <summary>
        /// FQDN of the entity responding to the report. Required.
        /// </summary>
        public string respondingAgencyName { get; set; }

        /// <summary>
        /// jCard of the responding agency. Required.
        /// </summary>
        public string respondingContactJcard { get; set; }

        /// <summary>
        /// UserId of agent responding to the report
        /// </summary>
        public string respondingAgentId { get; set; }

        /// <summary>
        /// Estimated date/time when response will be returned to reporting agency or the actual time, 
        /// in the past, when the response was provided. Must be in the NENA Timestamp format
        /// specified in Section 2.3 of NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string responseEstimatedReturnTime { get; set; } = TimeUtils.GetCurrentNenaTimestamp();

        /// <summary>
        /// Text comment.
        /// </summary>
        public string statusComments { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public StatusUpdate()
        {
        }
    }
}
