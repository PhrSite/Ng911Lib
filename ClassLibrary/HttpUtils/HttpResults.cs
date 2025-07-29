/////////////////////////////////////////////////////////////////////////////////////
//  File:   HttpResults.cs                                          1 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Net;

namespace HttpUtils;

/// <summary>
/// Class for returning the results of an HTTP request
/// </summary>
public class HttpResults
{
    /// <summary>
    /// HTTP status code that was returned in the HTTP response
    /// </summary>
    public HttpStatusCode StatusCode;
    /// <summary>
    /// reason phrase that was returned in the HTTP response
    /// </summary>
    public string Reason;
    /// <summary>
    /// Contains the value of the Content-Type header. Set to null if the response did not contain a body.
    /// </summary>
    public string ContentType;
    /// <summary>
    /// Contains the body of the response message or null if there was no response body.
    /// </summary>
    public string Body;
    /// <summary>
    /// Contains an Exception object if an exception occurred. If this member is non-null then none of the
    /// other members are valid.
    /// </summary>
    public Exception Excpt = null;
}
