/////////////////////////////////////////////////////////////////////////////////////
//  File:   DequeueRegistrationResponseBody.cs                      16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the Dequeue Registration response body. See Section 4.2.1.4 and Section E.3.1 of
    /// NENA-STA-010.3
    /// </summary>
    public class DequeueRegistrationResponseBody
    {
        /// <summary>
        /// Time in seconds this registration will expire. Required.
        /// </summary>
        public int expirationTime { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DequeueRegistrationResponseBody()
        {
        }
    }
}
