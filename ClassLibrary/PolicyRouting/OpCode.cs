/////////////////////////////////////////////////////////////////////////////////////
//  File:   OpCode.cs                                               23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Definitions for operator codes used by the operator fields of Policy Routing Rule conditions.
    /// </summary>
    public class OpCode
    {
        /// <summary>
        /// Exists
        /// </summary>
        public const string exists = "exists";
        /// <summary>
        /// The element is missing
        /// </summary>
        public const string missing = "missing";
        /// <summary>
        /// Equal to
        /// </summary>
        public const string EQ = "EQ";
        /// <summary>
        /// Contains a substring of
        /// </summary>
        public const string SS = "SS";
        /// <summary>
        /// Not equal to
        /// </summary>
        public const string NE = "NE";
        /// <summary>
        /// Greater than
        /// </summary>
        public const string GT = "GT";
        /// <summary>
        /// Less than
        /// </summary>
        public const string LT = "LT";
        /// <summary>
        /// Greater than or equal to
        /// </summary>
        public const string GE = "GE";
        /// <summary>
        /// Less than or equal to
        /// </summary>
        public const string LE = "LE";
    }
}
