/////////////////////////////////////////////////////////////////////////////////////
//  File:   HeldConsts.cs                                           10 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Held
{
    /// <summary>
    /// Defines constants used for the HELD protocol
    /// </summary>
    public class HeldConsts
    {

        /// <summary>
        /// HTTP Content-Type header value to use when sending HELD requests
        /// </summary>
        public const string HeldContentType = "application/held+xml;charset=utf-8";

        /// <summary>
        /// Check for this HTTP Content-Type when receiving HELD responses.
        /// </summary>
        public const string ContentType = "application/held+xml";
    }
}
