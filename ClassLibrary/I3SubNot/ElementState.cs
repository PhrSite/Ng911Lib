/////////////////////////////////////////////////////////////////////////////////////
//  File:   ElementState.cs                                         12 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3V3 Element State NOTIFY body. See Section 2.4.1 and Section E.11.3.1 of 
    /// NENA-STA-010.3.
    /// Note: Section 2.4.1 does not agree with the JSON schema defined in Section E.11.3.1 so this class 
    /// uses the schema defined in E.11.3.1.
    /// </summary>
    public class ElementState
    {
        /// <summary>
        /// Contains the element state information. Required.
        /// </summary>
        public ElementStateType elementState { get; set; } = new ElementStateType();
    }

    /// <summary>
    /// Class for describing element state
    /// </summary>
    public class ElementStateType
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
}
