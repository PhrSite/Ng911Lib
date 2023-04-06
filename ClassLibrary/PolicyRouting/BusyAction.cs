/////////////////////////////////////////////////////////////////////////////////////
//  File:   BusyAction.cs                                           23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Causes a final status of 600 Busy Everywhere to be sent toward the caller. See Sections
    /// 3.3.3.2.2 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class BusyAction : ActionBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BusyAction()
        {
            actionType = nameof(BusyAction);
        }
    }
}
