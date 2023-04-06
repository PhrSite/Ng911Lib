/////////////////////////////////////////////////////////////////////////////////////
//  File: I3Jws.cs                                                  13 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ng911Common
{
    /// <summary>
    /// Data class for the NENA I3V3 JSON Web Signature type. See Section E.10.4.1 of NENA-STA-010.3.
    /// </summary>
    public class I3Jws
    {
        /// <summary>
        /// Base64Url encoded payload of the JWS
        /// </summary>
        public string payload { get; set; }

        /// <summary>
        /// Base64Url encoded protected header part of the JWs
        /// </summary>
        [JsonPropertyName("protected")]
        public string Protected { get; set; }

        /// <summary>
        /// Base64Url encoded digital signature
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public I3Jws()
        {
        }

        /// <summary>
        /// Constructs an I3Jws from an object.
        /// </summary>
        /// <param name="Obj">Object to build the I3Jws object for.</param>
        public I3Jws(object Obj)
        {
            Protected = JsonObjToBase64Url(new I3JoseHeader());
            payload = JsonObjToBase64Url(Obj);
        }

        /// <summary>
        /// Converts an object to a Base64Url string by serializing it as a JSON string then encoding it 
        /// using Base64Url encoding.
        /// </summary>
        /// <param name="Obj">Contains the object to convert to JSON</param>
        /// <returns>Returns the Base64Url encoded JSON binary object</returns>
        public static string JsonObjToBase64Url(object Obj)
        {
            //JsonSerializerSettings Jss = new JsonSerializerSettings();
            //Jss.NullValueHandling = NullValueHandling.Ignore;
            //string str = JsonConvert.SerializeObject(Obj, Formatting.Indented, Jss);
            //string b64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

            JsonSerializerOptions Jso = new JsonSerializerOptions();
            Jso.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            Jso.WriteIndented = true;
            byte[] UtfBytes = JsonSerializer.SerializeToUtf8Bytes(Obj, Obj.GetType(), Jso);
            string str = Convert.ToBase64String(UtfBytes);
            return Base64ToBase64Url(str);
        }

        /// <summary>
        /// Converts a Base64Url encode string into a string that represents a JSON object.
        /// </summary>
        /// <param name="b64UrlString">Input Base64Url encode string.</param>
        /// <returns>Returns a string containing the JSON representation of the object</returns>
        public static string Base64UrlStringToJsonString(string b64UrlString)
        {
            string b64 = Bas64UrlToBase64(b64UrlString);
            byte[] Bytes = Convert.FromBase64String(b64);
            return Encoding.UTF8.GetString(Bytes);
        }

        /// <summary>
        /// Converts a Base64 encoded string to a Base64Url encode string by replacing '+' with '-' 
        /// and '/' with '_'. See Section 5 of RFC 4648.
        /// The padding character ('=') is not modified.
        /// </summary>
        /// <param name="b64string"></param>
        /// <returns>The Base64Url encoded string</returns>
        public static string Base64ToBase64Url(string b64string)
        {
            return b64string.Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// Converts a Base64Url encoded string to a Base64 encoded string by replacing '-' with '+' 
        /// and '_' with '/'. See Section 5 of RFC 4648.
        /// The padding character ('=') is not modified.
        /// </summary>
        /// <param name="b64string"></param>
        /// <returns>The Base64Url encoded string</returns>
        public static string Bas64UrlToBase64(string b64Urlstring)
        {
            return b64Urlstring.Replace('-', '+').Replace('_', '/');
        }
    }
}
