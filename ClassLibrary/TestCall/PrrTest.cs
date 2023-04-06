/////////////////////////////////////////////////////////////////////////////////////
//  File:   PrrTest.cs                                              22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace TestCall
{
    /// <summary>
    /// Data class for the PRR test conditions for test calls. See Sections 4.6.18 and E.6.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class PrrTest
    {
        /// <summary>
        /// ESRP Hostname that test conditions are specified for. Required.
        /// </summary>
        public string hostName { get; set; }

        /// <summary>
        /// URI of for nominal next hop that rule set conditions are applied to. Required.
        /// </summary>
        public string nominalNextHop { get; set; }

        /// <summary>
        /// An array of conditions to test. Required.
        /// </summary>
        public List<ConditionType> conditions { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PrrTest()
        {
        }
    }

    /// <summary>
    /// Data class for specifying a condition to used for a test call. See Sections 4.6.18 and E.6.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class ConditionType
    {
        /// <summary>
        /// Specifies the name of the condition to test. Must be set to the string equivalent of one of
        /// the values in the ConditionTypeEnum.
        /// Required.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Value for the condition as a string. Required.
        /// </summary>
        public string value { get; set; }
    }
}
