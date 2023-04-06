/////////////////////////////////////////////////////////////////////////////////////
//  File: TimeUtils.cs                                              13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911Lib.Utilities
{
    /// <summary>
    /// Static class for time related functionality for NG9-1-1.
    /// </summary>
    public static class TimeUtils
    {
        /// <summary>
        /// Gets the current time using the NENA Timestamp format specified in Section 2.3 Timestamp of 
        /// NENA-STA-010.3.
        /// </summary>
        /// <returns>Returns the NENA formatted Timestamp</returns>
        public static string GetCurrentNenaTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffzzz");
        }

        /// <summary>
        /// Converts a DateTime to a strung using the NENA Timestamp format specified in Section 2.3 
        /// Timestamp of NENA-STA-010.3.
        /// </summary>
        /// <returns>Returns the NENA formatted Timestamp</returns>
        public static string DateTimeToNenaTimeStamp(DateTime Dt)
        {
            return Dt.ToString("yyyy-MM-ddTHH:mm:ss.fffffzzz");
        }
    }
}
