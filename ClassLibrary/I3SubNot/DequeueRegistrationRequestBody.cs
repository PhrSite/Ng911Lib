/////////////////////////////////////////////////////////////////////////////////////
//  File:   DequeueRegistrationRequestBody.cs                       16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the Dequeue Registration request body. See Section 4.2.1.4 and Section E.3.1 of
    /// NENA-STA-010.3.
    /// </summary>
    public class DequeueRegistrationRequestBody
    {
        /// <summary>
        /// SIP URI of queue on which to register. Required.
        /// </summary>
        public string queueUri { get; set; }

        /// <summary>
        /// SIP URI of dequeuer (where to send calls). Required.
        /// </summary>
        public string dequeuerUri { get; set; }

        /// <summary>
        /// Time in seconds this registration will expire. expirationTime set to zero is a request to 
        /// deregister.
        /// Required.
        /// </summary>
        public int expirationTime { get; set; }

        /// <summary>
        /// Integer from 1-5 indicating queuing preference. The minimum value is 1 and the maximum
        /// value is 5. A value of 5 indicates the highest preference.
        /// Optional
        /// </summary>
        public int dequeuePreference { get; set; } = 1;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DequeueRegistrationRequestBody()
        {
        }
    }
}
