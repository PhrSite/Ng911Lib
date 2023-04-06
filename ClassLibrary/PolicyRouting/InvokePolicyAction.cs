/////////////////////////////////////////////////////////////////////////////////////
//  File:   InvokePolicyAction.cs                                   23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// This action causes the specified policy routing ruleset to be evaluated. See Sections 3.3.3.2.5
    /// and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class InvokePolicyAction : ActionBase
    {
        /// <summary>
        /// Must be set to one of the following subset of values from the Policy Types Registry 
        /// Section 10.33 of NENA-STA-010.3. The allowed values are OrginationRoutePolicy,
        /// NormalNexthopRoutePolicy and OtherRoutePolicy.
        /// Required.
        /// </summary>
        public string policyType { get; set; }

        /// <summary>
        /// Name of the queue that the policy applies to. 
        /// </summary>
        public string policyQueueName { get; set; }

        /// <summary>
        /// MUST exist when “policyType” is “OtherRoutePolicy” and MUST NOT exist otherwise.
        /// </summary>
        public string policyId { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public InvokePolicyAction()
        {
            actionType = nameof(InvokePolicyAction);
        }
    }
}
