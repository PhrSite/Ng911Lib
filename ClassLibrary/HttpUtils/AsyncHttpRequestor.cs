/////////////////////////////////////////////////////////////////////////////////////
//  File:   AsyncHttpRequestor.cs                                   1 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;
using System.Text;

namespace HttpUtils;

/// <summary>
/// Class for performing asynchronous HTTP requests. This class may be used to perform GET, POST, PUT and
/// DELETE requests. It may also be used when a persistent connection to a server is desired.
/// </summary>
public class AsyncHttpRequestor : IDisposable
{
    private HttpClientHandler m_Handler = null;
    private HttpClient m_Hcl = null;
    private const int TimeoutDefaultMs = 1000;

    /// <summary>
    /// If set to true, the all server certificates will be accepted. If false the server authentication
    /// is tested. The default is true.
    /// </summary>
    public bool AcceptAllServerCertificates { get; set; } = true;

    /// <summary>
    /// Constructs a new AsyncHttpRequestor object. Once this constructor is called, the object is ready
    /// to start making requests.
    /// </summary>
    /// <param name="clientCertificate">Client X.509 certificate. May be null in applications where
    /// mutual authentication is not required.</param>
    /// <param name="TimeoutMs">Sets the request timeout in milliseconds. Defaults to 1000 ms.</param>
    /// <param name="strAcceptHeader">Value to add to the default headers. For example: application/json.
    /// May contain a comma separated list of MIME types. May be null.</param>
    public AsyncHttpRequestor(X509Certificate2 clientCertificate, int TimeoutMs = TimeoutDefaultMs,
        string strAcceptHeader = null)
    {
        m_Handler = new HttpClientHandler();
        m_Handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        m_Handler.ServerCertificateCustomValidationCallback = OnCustomValidation;
        if (clientCertificate != null)
            m_Handler.ClientCertificates.Add(clientCertificate);
        m_Hcl = new HttpClient(m_Handler);
        m_Hcl.Timeout = TimeSpan.FromMilliseconds(TimeoutMs);
        if (string.IsNullOrEmpty(strAcceptHeader) == false)
            m_Hcl.DefaultRequestHeaders.Add("Accept", strAcceptHeader);
    }

    /// <summary>
    /// Sends the HTTP request asynchronously and waits for a response.
    /// </summary>
    /// <param name="Method">HTTP method to use.</param>
    /// <param name="strUrl">URL of the request.</param>
    /// <param name="strContentType">Specifies the Content-Type header to send if the request message will 
    /// contain a body. For example: application/json. May be null if strContents is null.</param>
    /// <param name="strContents">Contains the request body. May be null if there is no body to send.</param>
    /// <param name="ExpectRespBody">If true, then a response containing a message body is expected and this 
    /// method will read it. If false, then the response is not expected to contain a message body.</param>
    /// <returns>Returns a HttpResults object. This method always returns  a value, even if an exception 
    /// occurred.</returns>
    public async Task<HttpResults> DoRequestAsync(HttpMethodEnum Method, string strUrl, string strContentType, 
        string strContents, bool ExpectRespBody)
    {
        HttpResults Results = new HttpResults();
        HttpResponseMessage Hrm = null;
        StringContent Sc = null;
        if (string.IsNullOrEmpty(strContentType) == false && string.
            IsNullOrEmpty(strContents) == false)
        {
            Sc = new StringContent(strContents, UnicodeEncoding.UTF8,
                strContentType);
        }

        try
        {
            switch (Method)
            {
                case HttpMethodEnum.GET:
                    Hrm = await m_Hcl.GetAsync(strUrl);
                    break;
                case HttpMethodEnum.POST:
                    Hrm = await m_Hcl.PostAsync(strUrl, Sc);
                    break;
                case HttpMethodEnum.PUT:
                    Hrm = await m_Hcl.PutAsync(strUrl, Sc);
                    break;
                case HttpMethodEnum.DELETE:
                    Hrm = await m_Hcl.DeleteAsync(strUrl);
                    break;
                default:
                    Results.Excpt = new ArgumentException("Unsupported HTTP method");
                    return (Results);
            } // end switch

            Results.StatusCode = Hrm.StatusCode;
            Results.Reason = Hrm.ReasonPhrase;
            if (ExpectRespBody == true)
            {   // Get the response body
                if (Hrm.Content?.Headers.ContentType?.MediaType != null)
                {
                    Results.ContentType = Hrm.Content.Headers.ContentType.MediaType;
                    Results.Body = await Hrm.Content.ReadAsStringAsync();
                }
            }
        }
        catch (SocketException Se) { Results.Excpt = Se; }
        catch (HttpRequestException Hre) { Results.Excpt = Hre; }
        catch (TaskCanceledException Tce)
        {
            Results.StatusCode = HttpStatusCode.RequestTimeout;
            Results.Excpt = Tce;
        }
        catch (Exception Ex) { Results.Excpt = Ex; }

        return Results;
    }

    /// <summary>
    /// Sends a GET request and returns a string response asynchronously.
    /// </summary>
    /// <param name="strUrl">URL to request.</param>
    /// <returns>Returns a string from the response body if the server returned a 200 OK response and a 
    /// string in the response body. Returns null if an error occurred.</returns>
    public async Task<string> GetStringResponseAsync(string strUrl)
    {
        string Result = null;
        HttpResults Hr = await DoRequestAsync(HttpMethodEnum.GET, strUrl, null, null, true);
        if (Hr.Excpt == null && Hr.StatusCode == HttpStatusCode.OK && string.IsNullOrEmpty(Hr.ContentType)
            == false && string.IsNullOrEmpty(Hr.Body) == false)
            Result = Hr.Body;

        return Result;
    }

    /// <summary>
    /// Disposes the HttpClient object used by this class. Do not call any other methods or properties after
    /// calling this method.
    /// </summary>
    public void Dispose()
    {
        if (m_Hcl != null)
        {
            m_Hcl.Dispose();
            m_Hcl = null;
        }
    }

    /// <summary>
    /// Called by the .NET framework to perform the custom certificate validation.
    /// </summary>
    /// <param name="Hre">HTTP request.</param>
    /// <param name="cert">The offerred X.509 certificate.</param>
    /// <param name="chain">The certificate chain for verifying the trusted
    /// issuing authority</param>
    /// <param name="errors">Contains policy errors detected by the .NET
    /// framework and/or the operating system.</param>
    /// <returns></returns>
    private bool OnCustomValidation(HttpRequestMessage Hre, X509Certificate2 cert, X509Chain chain, 
        SslPolicyErrors errors)
    {
        if (AcceptAllServerCertificates == true)
            return true;
        else
        {
            if (errors == SslPolicyErrors.None)
                return true;
            else
                return false;
        }
    }
}

/// <summary>
/// Enumeration of the supported HTTP methods.
/// </summary>
public enum HttpMethodEnum
{
    /// <summary>
    /// HTTP GET request
    /// </summary>
    GET,
    /// <summary>
    /// HTTP POST request
    /// </summary>
    POST,
    /// <summary>
    /// HTTP PUT request
    /// </summary>
    PUT,
    /// <summary>
    /// HTTP DELETE request
    /// </summary>
    DELETE,
}
