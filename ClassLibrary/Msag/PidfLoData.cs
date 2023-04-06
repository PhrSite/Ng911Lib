/////////////////////////////////////////////////////////////////////////////////////
//  File:   PidfLoData.cs                                           19 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Msag
{
    /// <summary>
    /// Data class used by the MSAG Conversion Service to return an address of a location in response
    /// to the MSAG to PIDF-LO conversion request. See Sections 4.4.2 and E.4.1 of NENA-STA-010.3.
    /// </summary>
    public class PidfLoData
    {
        /// <summary>
        /// Contains the address as a PIDF-LO XML document. Required.
        /// </summary>
        public string pidfLoAddress { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PidfLoData()
        {
        }
    }
}
