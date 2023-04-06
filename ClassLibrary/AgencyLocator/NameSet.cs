/////////////////////////////////////////////////////////////////////////////////////
//  File:   NameSet.cs                                              17 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AgencyLocator
{
    /// <summary>
    /// Data class for returning an agency's URI and a list of names for an agency. Used by
    /// the Agency Locator Service.
    /// See Section 4.15.5 and Section E.10.1 or NENA-010.3.    /// </summary>
    public class NameSet
    {
        /// <summary>
        /// URI of Service/Agency Locator. Required.
        /// </summary>
        public string locatorUri { get; set; }

        /// <summary>
        /// Array of Service/Agency Locator Names. Required.
        /// </summary>
        public List<string> names = new List<string>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public NameSet()
        {
        }
    }
}
