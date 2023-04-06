/////////////////////////////////////////////////////////////////////////////////////
//  File:   PolicyEnumArray.cs                                      23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyStore
{
    /// <summary>
    /// Data class for enumerating policies from a policy store. See Sections 3.3.1.3.1 and E.1.1
    /// of NENA-STA-010.3.
    /// </summary>
    public class PolicyEnumArray
    {
        /// <summary>
        /// Number of PolicyEnum objects in the array. Required.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Total number of PolicyEnum objects available. Required.
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// Array of PolicyEnum objects. Required.
        /// </summary>
        public List<PolicyEnum> policyEnums { get; set; } = new List<PolicyEnum>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PolicyEnumArray()
        {
        }
    }
}
