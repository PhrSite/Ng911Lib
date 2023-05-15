/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LoggingUtils.cs                                       12 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using I3V3.LogEvents;
using System.Text.RegularExpressions;

namespace I3V3.LoggingHelpers;

/// <summary>
/// Static class that provide various utility functions for working with I3 NG9-1-1 log events.
/// </summary>
public static class I3LoggingUtils
{
    private const string strPattern = "\"logEventType\": *\"(.*?)\"";

    /// <summary>
    /// Extracts the value of the logEventType property from a JSON string containing an NG9-1-1 log event.
    /// </summary>
    /// <param name="strJson">JSON string to search through.</param>
    /// <returns>Returns the type of the log event or null if the logEventType property was not found.</returns>
    public static string GetLogEventType(string strJson)
    {
        string strLet = null;
        Match match = Regex.Match(strJson, strPattern);
        if (match.Success == true && match.Groups.Count > 1)
            strLet = match.Groups[1].Value;

        return strLet;
    }
}
