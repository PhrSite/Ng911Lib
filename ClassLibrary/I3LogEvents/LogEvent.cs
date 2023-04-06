/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogEvent.cs                                             12 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace I3LogEvents
{
    /// <summary>
    /// Base class for all I3V3 event types. See Sections 4.12.3.1 and E.8.1 of NENA-STA-010.3.
    /// </summary>
    public class LogEvent
    {
        /// <summary>
        /// An identifier assigned by the client. Optional.
        /// </summary>
        public string clientAssignedIdentifier { get; set; }

        /// <summary>
        /// Specifies type of log event. Required.
        /// </summary>
        public string logEventType { get; set; }

        /// <summary>
        /// The timestamp of the event. See Section 2.1.3 of NENA-STA-010.3
        /// for the required format. Required.
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// Element identifier (Section 2.1.3 of NENA-STA-010.3) of the element that logged the event.
        /// Required.
        /// </summary>
        public string elementId { get; set; }

        /// <summary>
        /// AgencyId (Section 2.1.1 of NENA-STA-010.3) of the agency that logged the event. Required.
        /// </summary>
        public string agencyId { get; set; }

        /// <summary>
        /// Agent identifier of the agent within the Agency. Optional.
        /// </summary>
        public string agencyAgentId { get; set; }

        /// <summary>
        /// Identifier of the operator position that is handling the call. Optional.
        /// </summary>
        public string agencyPositionId { get; set; }

        /// <summary>
        /// Emergency call ID (emergency-CallId) of the call. See Section 2.1.6 of NENA-STA-010.3.
        /// Conditional.
        /// </summary>
        public string callId { get; set; }

        /// <summary>
        /// Emergency Incident ID (emergency-IncidentId) of the call. See Section 2.1.7 of NENA-STA-010.3.
        /// Conditional.
        /// </summary>
        public string incidentId { get; set; }

        /// <summary>
        /// SIP Call-ID header value. Required if the event is related to a call.
        /// </summary>
        public string callIdSIP { get; set; }

        /// <summary>
        /// Normalized IP address and port number string or Fully Qualified Domain Name of another element 
        /// that participated in a transaction that triggered this LogEvent (e.g., an element that sent or
        /// responded to a query). This is not the address of the element that logs the event. 
        /// </summary>
        public string ipAddressPort { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogEvent()
        {
            timestamp = TimeUtils.GetCurrentNenaTimestamp();
        }

        /// <summary>
        /// Creates a deep copy of the base class fields.
        /// </summary>
        /// <param name="Let">Object to copy from</param>
        /// <returns>Returns a new LogEvent.</returns>
        public LogEvent CopyBase(LogEvent Let)
        {
            LogEvent LetBase = new LogEvent();
            LetBase.clientAssignedIdentifier = Let.clientAssignedIdentifier;
            LetBase.logEventType = Let.logEventType;
            LetBase.timestamp = Let.timestamp;
            LetBase.elementId = Let.elementId;
            LetBase.agencyId = Let.agencyId;
            LetBase.agencyAgentId = Let.agencyAgentId;
            LetBase.agencyPositionId = Let.agencyPositionId;
            LetBase.callId = Let.callId;
            LetBase.incidentId = Let.incidentId;
            LetBase.callIdSIP = Let.callIdSIP;
            LetBase.ipAddressPort = Let.ipAddressPort;

            return LetBase;
        }
    }
}
