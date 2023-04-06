/////////////////////////////////////////////////////////////////////////////////////
//  File:   JsonHelper.cs                                           9 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ng911Lib.Utilities
{
    /// <summary>
    /// This is a static class that performs various JSON related functions such as serialization
    /// and deserialization.
    /// </summary>
    public static class JsonHelper
    {
        private static JsonSerializerOptions m_Jso = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true
        };

        /// <summary>
        /// Serializes an object into an indented JSON string.
        /// </summary>
        /// <param name="Obj">Input object to serialize</param>
        /// <returns>Returns an indented JSON string if no errors occurred. Returns null if an
        /// error occurred.</returns>
        public static string SerializeToString(object Obj)
        {
            if (Obj == null)
                return null;

            string strResult = null;
            try
            {
                strResult = JsonSerializer.Serialize(Obj, m_Jso);
            }
            catch (JsonException) { strResult = null; }
            catch (Exception) { strResult = null; }

            return strResult;
        }

        /// <summary>
        /// Deserializes a JSON string into an object.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the object to deserialize the JSON string into.
        /// </typeparam>
        /// <param name="str">Input string to deserialize</param>
        /// <returns>Returns an object of the specified type if successful or null if an error occurred.
        /// </returns>
        public static T DeserializeFromString<T>(string str)
        {
            T ObjResult = default(T);
            try
            {
                ObjResult = JsonSerializer.Deserialize<T>(str);
            }
            catch (JsonException) { return default(T); }
            catch (InvalidOperationException) { return default(T); }
            catch (Exception) { return default(T); }

            return ObjResult;
        }

        /// <summary>
        /// Deserializes a JSON string into an object.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the object to deserialize the JSON string into.
        /// </typeparam>
        /// <param name="str">Input JSON string</param>
        /// <param name="Excpt">Output. Set to the exception object that was caught. This will
        /// be non-null if the return value is null.</param>
        /// <returns>Returns an object of the specified type if successful or null if an error occurred.
        /// </returns>
        /// <remarks>Use this version of the method of you need to log and/or troubleshoot JSON
        /// issues.</remarks>
        public static T DeserializeFromString<T>(string str, out Exception Excpt)
        {
            Excpt = null;
            T ObjResult = default(T);
            try
            {
                ObjResult = JsonSerializer.Deserialize<T>(str);
            }
            catch (JsonException Je)
            {
                Excpt = Je;
                return default(T);
            }
            catch (InvalidOperationException Ioe)
            {
                Excpt = Ioe;
                return default(T); 
            }
            catch (Exception Ex) 
            {
                Excpt = Ex;
                return default(T);
            }

            return ObjResult;
        }
    }
}
