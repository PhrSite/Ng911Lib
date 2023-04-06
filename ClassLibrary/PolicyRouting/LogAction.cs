/////////////////////////////////////////////////////////////////////////////////////
//  File:   LogAction.cs                                            23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// This action causes a RouteRuleMsgLogEvent to be generated. See Sections 3.3.3.2.4 and E.1.1
    /// of NENA-STA-010.3.
    /// </summary>
    public class LogAction : ActionBase
    {
        /// <summary>
        /// Optional message to send using the RoutRuleMsgLogEvent.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogAction()
        {
            actionType = nameof(LogAction);
        }
    }
}
