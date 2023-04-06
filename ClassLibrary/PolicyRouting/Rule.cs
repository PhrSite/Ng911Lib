/////////////////////////////////////////////////////////////////////////////////////
//  File:   Rule.cs                                                 23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Contains the settings for a Policy Routing Rule. See Sections 3.3.3 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Unique ID. Must be unique within a ruleset. Required.
        /// </summary>
        public string id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Priority of the rule. A value of 0 is the lowest priority. Must be unique within a ruleset.
        /// </summary>
        public int priority { get; set; } = 0;

        /// <summary>
        /// Describes the rule. Optional
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// A list of conditions for the rule.
        /// </summary>
        public List<ConditionBase> conditions { get; set; } = new List<ConditionBase>();

        /// <summary>
        /// A list of actions to perform if all conditions evaluate to true.
        /// </summary>
        public List<ActionBase> actions { get; set; } = new List<ActionBase>();
    }
}
