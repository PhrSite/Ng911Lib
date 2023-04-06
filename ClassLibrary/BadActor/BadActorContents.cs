/////////////////////////////////////////////////////////////////////////////////////
//  File:   BadActorContents.cs                                     23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace BadActor
{
    /// <summary>
    /// Data class for passing the identity of a bad actor in the body of a POST request to
    /// a Bad Actor service.
    /// See Sections 4.1.2 and E.9.1 of NENA-STA-010.3.
    /// </summary>
    public class BadActorContents
    {
        /// <summary>
        /// Contains the Bad Actor source-id as a string.
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BadActorContents()
        {
        }
    }
}
