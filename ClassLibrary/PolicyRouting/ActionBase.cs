/////////////////////////////////////////////////////////////////////////////////////
//  File:   ActionBase.cs                                           23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Base class for all Policy Routing Rule actions. See Sections 3.3.3.2 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class ActionBase
    {
        /// <summary>
        /// Specifies the action type. Must be one of "RouteAction", "NotifyAction",
        /// "LogAction", BusyAction" or "InvokePolicyAction".
        /// </summary>
        public string actionType { get; set; }

        /// <summary>
        /// Describes the action.
        /// Optional.
        /// </summary>
        public string description { get; set; }
    }
}
