/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdditionalAgencyLogEvent.cs                             13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json;
using System.Text.Json.Serialization;

namespace I3LogEvents
{
    /// <summary>
    /// Data class for the AdditionalAgencyLogEvent. See Sections 4.12.3.7 and E.8.1 
    /// of NENA-STA-010.3.
    /// Logged when an agency becomes aware that another agency becomes involved with an incident.
    /// </summary>
    public class AdditionalAgencyLogEvent : LogEvent
    {
        /// <summary>
        /// Agency ID of the agency that became involved. Required.
        /// Note: This is different that the agencyId field of the base class. It will be written
        /// and read as the agencyId property of this derived class.
        /// </summary>
        [JsonPropertyName("agencyId")]
        public string NewAgencyId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AdditionalAgencyLogEvent()
        {
            logEventType = "AdditionalAgencyLogEvent";
        }
    }
}
