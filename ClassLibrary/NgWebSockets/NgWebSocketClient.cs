/////////////////////////////////////////////////////////////////////////////////////
//  File:   NgWebSocketClient.cs                                    3 May 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Net.WebSockets;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace NgWebSockets;

/// <summary>
/// Class for a Web Socket Client that can be used for NG9-1-1 applications.
/// </summary>
public class NgWebSocketClient
{
    private ClientWebSocket m_WebSocket;
    private CancellationTokenSource m_CancellationTokenSource = new CancellationTokenSource();

    /// <summary>
    /// Constructs a new Web Socket client object. After calling this constructor, hook the MessageReceived
    /// event, then call Connect().
    /// </summary>
    /// <param name="clientCertificate">Client X.509 certificate to use if mutual authentication is required
    /// (i.e., the server requires a client certificate). May be null if mutual authentication is not
    /// required.</param>
    /// <param name="strSubProtocol">Sets the sub-protocol for the web socket connection. If not null,
    /// then the Sec-WebSocket-Protocol HTTP header will be set to this value. May be null if a sub-protocol
    /// is not being used.</param>
    /// <param name="validationCallback">Specifies an application provided callback function that will be
    /// called to valicate the web socket server's X.509 certificate. May be null if extended certificate
    /// validation is not required. If null, then this class will use its own validation callback function
    /// that accepts all server certificates.</param>
    public NgWebSocketClient(X509Certificate2 clientCertificate, string strSubProtocol,
        RemoteCertificateValidationCallback validationCallback)
    {
        m_WebSocket = new ClientWebSocket();
        if (string.IsNullOrEmpty(strSubProtocol) == false)

            m_WebSocket.Options.AddSubProtocol(strSubProtocol);
        if (clientCertificate != null)
            m_WebSocket.Options.ClientCertificates.Add(clientCertificate);

        if (validationCallback != null)
            m_WebSocket.Options.RemoteCertificateValidationCallback = validationCallback;
        else
            m_WebSocket.Options.RemoteCertificateValidationCallback = CertificateValidationCallback;
    }

    /// <summary>
    /// Connects to the web socket server. Messages may be sent and received if the connection was successful.
    /// </summary>
    /// <param name="strUrl">URL of the web socket server to connect to. The URL scheme must be wss: or ws:</param>
    /// <returns>Returns true if successful or false if the connection attempt failed.</returns>
    public async Task<bool> Connect(string strUrl)
    {
        Uri uri = new Uri(strUrl);
        bool Success = false;
        try
        {
            await m_WebSocket.ConnectAsync(uri, CancellationToken.None);
            Success = true;
        }
        catch (Exception)
        {
            Success = false;
        }

        if (Success == true)
        {   // Start listening for messages
            Task Tsk = ReceiveMessage(m_CancellationTokenSource.Token);
        }

        return Success;
    }

    /// <summary>
    /// Closes the web socket connection in an orderly manner.
    /// </summary>
    public void Close()
    {
        try
        {
            m_CancellationTokenSource.Cancel();
            m_WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None).
                Wait();
            m_WebSocket.Dispose();
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// Task for receiving messages from the web socket server.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task ReceiveMessage(CancellationToken cancellationToken)
    {
        try
        {
            MemoryStream ms = new MemoryStream();
            ArraySegment<byte> Buffer = new ArraySegment<byte>(new byte[10000]);
            WebSocketReceiveResult result;
            while (m_WebSocket.State == WebSocketState.Open)
            {
                do
                {
                    result = await m_WebSocket.ReceiveAsync(Buffer, cancellationToken);
                    ms.Write(Buffer.Array, Buffer.Offset, result.Count);
                }
                while (result.EndOfMessage == false);

                if (result.MessageType != WebSocketMessageType.Close)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    string strMsg = Encoding.UTF8.GetString(ms.ToArray());
                    MessageReceived?.Invoke(strMsg, this);
                }
                else
                {
                    await m_WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty,
                        CancellationToken.None);
                }
            }
        }
        catch (TaskCanceledException)
        {   // This is normal during an orderly shutdown
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// For synchronizing send requests because the ClientWebSocket class only allows one Send() request at
    /// a time.
    /// </summary>
    private object m_SocketLock = new object();

    /// <summary>
    /// Sends an arbitrally long message as a string to the server. This method is thread-safe, i.e., send
    /// operations are synchronized.
    /// </summary>
    /// <param name="strMessage">Message to be sent.</param>
    /// <returns>Returns true if successful. Returns false if an error occurred, probably because the connection
    /// to the server is broken.</returns>
    public async Task<bool> SendMessage(string strMessage)
    {
        bool Success = false;
        if (m_WebSocket.State != WebSocketState.Open)
            return false;

        try
        {
            ReadOnlyMemory<byte> MsgBytes = Encoding.UTF8.GetBytes(strMessage);
            Monitor.Enter(m_SocketLock);
            await m_WebSocket.SendAsync(MsgBytes, WebSocketMessageType.Text, true, CancellationToken.None);
            Success = true;
        }
        catch (Exception)
        {
            Success = false;
        }
        finally
        {
            Monitor.Exit(m_SocketLock);
        }

        return Success;
    }

    /// <summary>
    /// Event that is fired when a complete message is received. It is OK to call the SendMessage() method
    /// from within the event handler of this event, but don't hold onto a reference to it and use it outside
    /// of the event handler.
    /// </summary>
    public event WebSocketMessageReceived MessageReceived;

    private bool CertificateValidationCallback(object sender, X509Certificate certificate,
        X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {        
        return true;    // Accepts all server certificates
    }
}

/// <summary>
/// Delegate type for the MessageReceived event of the NgWebSocketClient class.
/// </summary>
/// <param name="strMessage">Contains the message string received.</param>
/// <param name="webSocketClient">NgWebSocketClient object that received the message. This object can be
/// used to send a response to the web socket server.</param>
public delegate void WebSocketMessageReceived(string strMessage, NgWebSocketClient webSocketClient);