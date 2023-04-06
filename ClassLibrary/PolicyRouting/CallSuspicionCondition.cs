/////////////////////////////////////////////////////////////////////////////////////
//  File:   CallSuspicionCondition.cs                               23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests the suspicion score of the call. Evaluates to ‘true’ if the call’s suspicion score is 
    /// greater than or equal to the value of “scoreFrom and less than or equal to the value of “scoreTo”.
    /// See Sections 3.3.3.1.6 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class CallSuspicionCondition : ConditionBase
    {
        /// <summary>
        /// Minimum call suspicion score. Must be between 0 and 100 and must be less than the scoreTo field.
        /// Required.
        /// </summary>
        public int scoreFrom { get; set; } = 50;

        /// <summary>
        /// Maximum call suspicion score. Must be between 0 and 100 and must be greater than the scoreFrom 
        /// field. Required.
        /// </summary>
        public int scoreTo { get; set; } = 100;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CallSuspicionCondition()
        {
            conditionType = nameof(CallSuspicionCondition);
        }
    }
}
