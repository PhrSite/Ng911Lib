/////////////////////////////////////////////////////////////////////////////////////
//  File:   MsagData.cs                                             19 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Msag
{
    /// <summary>
    /// Data class used by the MSAG Conversion Service to return an address in ALI XML 4.0 format (NENA 02-010 
    /// Version 4 XML Format for Data Exchange) in the response to a PIDF-LO to MSAG request. See Section 
    /// 4.4.1 and E.4.1 of NENA-STA-010.3.
    /// </summary>
    public class MsagData
    {
        /// <summary>
        /// Contains the MSAG address as an ALI 4.0 XML document. Required.
        /// </summary>
        public string msagAddress { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MsagData()
        {
        }
    }
}
