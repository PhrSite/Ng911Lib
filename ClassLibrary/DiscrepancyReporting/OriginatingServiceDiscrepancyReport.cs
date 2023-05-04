/////////////////////////////////////////////////////////////////////////////////////
//  File:   OriginatingServiceDiscrepancyReport.cs                  22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for the Originating Service Discrepancy Report. See Sections 3.7.14 and E.2.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class OriginatingServiceDiscrepancyReport :  DiscrepancyReport
    {
        /// <summary>
        /// Specifies the problem. Must be the string equivalent of one of the values in the
        /// OriginatingServiceProblemEnum. Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// For an InvalidADR, the status code returned with the rejection of the ADR dereference attempt. 
        /// For STIerror, the status code returned in the Reason header field when the STI Verification 
        /// Service(STI-VS) encounters a validation failure (see Section 4.21.1 of NENA-STA-010.3).
        /// Conditional: REQUIRED when using InvalidADR or STIerror.
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// The location value or reference provided by the Originating Service Provider.If there is no 
        /// location, leave empty. 
        /// Conditional: REQUIRED when the discrepancy report relates to location associated with the call.
        /// /// </summary>
        public string location { get; set; }

        /// <summary>
        /// The client or endpoint identifier provided with the location.
        /// Conditional: REQUIRED when the discrepancy report relates to a location associated with the call.
        /// </summary>
        public string locationId { get; set; }

        /// <summary>
        /// Must be set to "True", "False" or "Unknown". Set to "True" if the location received with the 
        /// call is correct as verified by call taker with caller. Set to "False" if the location received 
        /// with the call is incorrect as verified by call taker with caller. 
        /// Conditional: REQUIRED when the discrepancy report relates to location associated with the call.
        /// </summary>
        public string locationCorrect { get; set; }

        /// <summary>
        /// The header field of the INVITE or MESSAGE.
        /// Conditional: REQUIRED when the discrepancy report relates to a SIP header field.
        /// </summary>
        public string callHeader { get; set; }

        /// <summary>
        /// The number of calls received within a measured period of time specified by the 
        /// callVolumnTimePeriod property.
        /// Conditional: REQUIRED when using CallDrought or CallFlood.
        /// </summary>
        public int callVolume { get; set; }

        /// <summary>
        /// The period of time in seconds during which CallVolume calls were received.
        /// Conditional: REQUIRED when using CallDrought or CallFlood.
        /// </summary>
        public int callVolumeTimePeriod { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OriginatingServiceDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Enumeration of problems for the Originating Service Discrepancy Report.
    /// </summary>
    public enum OriginatingServiceProblemEnum
    {
        /// <summary>
        /// Location was not validated by the Location Validation Function (LVF)
        /// </summary>
        LocationNotLvfValid,
        /// <summary>
        /// Location not usable
        /// </summary>
        LocationNotUsable,
        /// <summary>
        /// No ANI (legacy Automatic Number Indication)
        /// </summary>
        NoAni,
        /// <summary>
        /// Bad PIDF-LO data
        /// </summary>
        BadPidfLo,
        /// <summary>
        /// Query timeout
        /// </summary>
        QueryTimeOut,
        /// <summary>
        /// Call was dropped
        /// </summary>
        CallDropped,
        /// <summary>
        /// Incorrect location
        /// </summary>
        IncorrectLocation,
        /// <summary>
        /// Bad SIP message
        /// </summary>
        BadSip,
        /// <summary>
        /// Call drought -- no calls delivered
        /// </summary>
        CallDrought,
        /// <summary>
        /// Call flood -- call overflow
        /// </summary>
        CallFlood,
        /// <summary>
        /// Invalid Additional Data Repository problem
        /// </summary>
        InvalidAdr,
        /// <summary>
        /// Bad additional data
        /// </summary>
        BadAdditionalData,
        /// <summary>
        /// Other Originating Service Provider (OSP) problem
        /// </summary>
        OtherOsp,
        /// <summary>
        /// Secure Telephone Interface (STI) problem
        /// </summary>
        StiError
    }
}
