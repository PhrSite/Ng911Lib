/////////////////////////////////////////////////////////////////////////////////////
//  File:   EsrpNotify.cs                                           16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3 ESRP NOTIFY body. See Section 3.3.3.2.3, Section 4.2.1.6 and Section 
    /// E.11.1.1 of NENA-STA-010.3.
    /// </summary>
    public class EsrpNotify
    {
        /// <summary>
        /// URI of queue that Notify Action occurred on.
        /// Required.
        /// </summary>
        public string queueUri { get; set; }

        /// <summary>
        /// Event code specified in Notify Action. Must be one of the values specified in the ESRP Notify 
        /// Event Code Registry in Section 10.19 of NENA-STA-010.3.
        /// Required.
        /// </summary>
        public string eventCode { get; set; }

        /// <summary>
        /// Urgency specified in the Notify Action
        /// Required.
        /// </summary>
        public int urgency { get; set; }

        /// <summary>
        /// Comment specified in the Notify Action.
        /// Conditional. MUST be present if Comment is specified in the Notify Action.
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// Location included with the call (by value or by reference as provided in the call)
        /// Required.
        /// </summary>
        /// <remarks>This string may contain a URI if location is provided by-reference or a
        /// PIDF-LO XML document if location is provided by-value.</remarks>
        public string callLocation { get; set; }

        /// <summary>
        /// Additional Data included with the call (by value or by reference as provided in the call), or 
        /// retrieved using the Additional Data associated with a location mechanism, or from an IS-ADR.
        /// </summary>
        public string additionalData { get; set; }

        /// <summary>
        /// Identifies the rule that triggered the event
        /// Required.
        /// </summary>
        public string esrpRule { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public EsrpNotify()
        {
        }
    }
}
