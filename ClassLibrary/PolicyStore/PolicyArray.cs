/////////////////////////////////////////////////////////////////////////////////////
//  File:   PolicyArray.cs                                          23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Common;

namespace PolicyStore
{
    /// <summary>
    /// Data class for passing an array of policies to and from a policy store.
    /// See Sections 3.3.1.2.1 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class PolicyArray
    {
        /// <summary>
        /// Number of items in the policies array. Required.
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// Total number of policies. Required.
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// Array of Policy objects, each in JWS format (JWS using flattened JSON serialization).
        /// Required.
        /// </summary>
        public List<I3Jws> policies { get; set; } = new List<I3Jws>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PolicyArray()
        {
        }
    }
}
