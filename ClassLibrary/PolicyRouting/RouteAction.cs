/////////////////////////////////////////////////////////////////////////////////////
//  File:   RouteAction.cs                                          23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// This action forwards the call (as its SIP message) to a specific URL. See Sections 3.3.3.2.1 
    /// and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class RouteAction : ActionBase
    {
        /// <summary>
        /// Contains a URI that will become the Route header field for the outgoing SIP message.
        /// Required.
        /// </summary>
        public string recipientUri { get; set; }

        /// <summary>
        /// This is the Ring No Answer timer; it is the time in seconds the ESRP will wait for a 
        /// final response. If this member is omitted, the ESRP MUST use a provisioned value; a 
        /// suggested default for the provisioned.
        /// Optional.
        /// </summary>
        public int? rnaTimer { get; set; } = null;

        /// <summary>
        /// This contains the value to be used within the reason parameter of the topmost History-Info
        /// header field for the outgoing SIP message. The value MUST be an entry from the 
        /// RouteCause Registry (Section 10.20 of NENA-STA-010.3)
        /// </summary>
        public string cause { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RouteAction()
        {
            actionType = nameof(RouteAction);
        }
    }
}
