/////////////////////////////////////////////////////////////////////////////////////
//  File:   XmlHelper.cs                                            30 Jul 17 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ng911Lib.Utilities
{
    /// <summary>
    /// Contains various functions to perform XML related operations.
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Serializes an object into an XML string.
        /// </summary>
        /// <param name="Obj">Input object to serialize.</param>
        /// <returns>Returns an XML string if successful or null if an error occurred.</returns>
        public static string SerializeToString(object Obj)
        {
            string strResult = null;
            StringWriter writer = new Utf8StringWriter();
            
            try
            {
                XmlSerializer Xs = new XmlSerializer(Obj.GetType());
                Xs.Serialize(writer, Obj);
                strResult = writer.ToString();
            }
            catch (InvalidOperationException)
            {
                strResult = null;
            }
            catch (Exception)
            {
                strResult = null;
            }

            return strResult;
        }

        /// <summary>
        /// Serializes an object into an XML string. This version adds the name
        /// space tag prefixs specified in the Ns parameter.
        /// </summary>
        /// <param name="Obj">Input object to serialize.</param>
        /// <param name="Ns">Contains the tag prefixs and their associated
        /// namespaces.</param>
        /// <returns>Returns an XML string if successful or null if an
        /// error occurred.</returns>
        public static string SerializeToString(object Obj, XmlSerializerNamespaces Ns)
        {
            string strResult = null;
            StringWriter writer = new Utf8StringWriter();

            try
            {
                XmlSerializer Xsl = new XmlSerializer(Obj.GetType());
                Xsl.Serialize(writer, Obj, Ns);
                strResult = writer.ToString();
            }
            catch (InvalidOperationException)
            {
                strResult = null;
            }
            catch (Exception)
            {
                strResult = null;
            }

            return strResult;
        }
        
        /// <summary>
        /// Gets an XmlSerializerNamespaces object that maps XML prefix tags to the namespaces for a 
        /// PIDF-LO XML document.
        /// </summary>
        public static XmlSerializerNamespaces PidfNamespaceTags
        {
            get
            {
                XmlSerializerNamespaces Ns = new XmlSerializerNamespaces();
                Ns.Add("gs", "http://www.opengis.net/pidflo/1.0");
                Ns.Add("gml", "http://www.opengis.net/gml");
                Ns.Add("ca", "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr");
                Ns.Add("gp", "urn:ietf:params:xml:ns:pidf:geopriv10");
                Ns.Add("dm", "urn:ietf:params:xml:ns:pidf:data-model");
                Ns.Add("gbp", "urn:ietf:params:xml:ns:pidf:geopriv10:basicPolicy");
                // See RFC 7459
                Ns.Add("con", "urn:ietf:params:xml:ns:geopriv:conf");
                // See RFC 5962
                Ns.Add("dyn", "urn:ietf:params:xml:ns:pidf:geopriv10:dynamic");
                // See RFC 6848
                Ns.Add("cae", "urn:ietf:params:xml:ns:pidf:geopriv10:civicAddr:ext");

                return Ns;
            }
        }

        /// <summary>
        /// Adds the namespaces tag prefixes appropriate for a PIDF-LO XML document and the serializes
        /// the object to a string. This method adds the XML tags from the Pidf namespace so it should
        /// be used only for the Pidf classes.
        /// </summary>
        /// <param name="Obj">Input object to serialize.</param>
        /// <returns>Returns an XML string if successful or null if an error occurred.</returns>
        public static string SerializePidfToString(object Obj)
        {
            return SerializeToString(Obj, PidfNamespaceTags);
        }

        /// <summary>
        /// Serializes an object to a byte array that contains the UTF8 characters of an XML document.
        /// </summary>
        /// <param name="Obj">Input object to serialize.</param>
        /// <returns>Returns a byte array or null if an error occurred during serialization.</returns>
        public static byte[] SerializeToByteArray(object Obj)
        {
            byte[] AryResult = null;
            string strResult = XmlHelper.SerializeToString(Obj);
            if (strResult != null)
                AryResult = Encoding.UTF8.GetBytes(strResult);

            return AryResult;
        }

        /// <summary>
        /// Deserializes an XML string into an object.
        /// </summary>
        /// <param name="str">String containing an XML object.</param>
        /// <param name="ObjType">Type of the object to deserialize to.</param>
        /// <returns>Returns an object of the specified type if successful or null if an error occurred.
        /// </returns>
        /// <seealso cref="DeserializeFromString{T}(string)"/>
        /// <seealso cref="DeserializeFromString{T}(string, out Exception)"/>
        /// <remarks>Consider using one of the generic versions of this method because the generic versions
        /// eliminate the need for casting.</remarks>
        public static object DeserializeFromString(string str, Type ObjType)
        {
            object ObjResult = null;

            try
            {
                TextReader Tr = new StringReader(str);
                XmlSerializer Xsl = new XmlSerializer(ObjType);
                ObjResult = Xsl.Deserialize(Tr);
            }
            catch (InvalidOperationException)
            {
                ObjResult = null;
            }
            catch (Exception)
            {
                ObjResult = null;
            }

            return ObjResult;
        }

        /// <summary>
        /// Deserializes an XML string into an object.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the object to deserialize the XML string into.
        /// </typeparam>
        /// <param name="str">String containing an XML object.</param>
        /// <param name="Excpt">Output. Set to the exception object that was caught. This will
        /// be non-null if the return value is null.</param>
        /// <returns>Returns an object of the specified type if successful or null if an error occurred.
        /// </returns>
        /// <remarks>Use this version of the method of you need to log and/or troubleshoot XML
        /// issues.</remarks>
        public static T DeserializeFromString<T>(string str, out Exception Excpt)
        {
            T ObjResult = default(T);
            Excpt = null;
            try
            {
                TextReader Tr = new StringReader(str);
                XmlSerializer Xsl = new XmlSerializer(typeof(T));
                ObjResult = ObjResult = (T)Xsl.Deserialize(Tr);
            }
            catch (InvalidCastException Ice)
            {
                Excpt = Ice;
                return default(T);
            }
            catch (Exception Ex)
            {
                Excpt = Ex;
                return default(T);
            }

            return ObjResult;
        }

        /// <summary>
        /// Deserializes an XML string into an object.
        /// </summary>
        /// <typeparam name="T">Specifies the type of the object to deserialize the XML string into.
        /// </typeparam>
        /// <param name="str">String containing an XML object.</param>
        /// <returns>Returns an object of the specified type if successful or null if an error occurred.
        /// </returns>
        public static T DeserializeFromString<T>(string str)
        {
            T ObjResult = default(T);
            try
            {
                TextReader Tr = new StringReader(str);
                XmlSerializer Xsl = new XmlSerializer(typeof(T));
                ObjResult = ObjResult = (T)Xsl.Deserialize(Tr);
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }

            return ObjResult;
        }

        /// <summary>
        /// Gets the name of the root node of an XML document.
        /// </summary>
        /// <param name="XmlString">String containing the XML document.</param>
        /// <returns>Returns the name of the root element or null if an error occurred.</returns>
        public static XmlNode GetRootNode(string XmlString)
        {
            XmlNode root = null;

            if (XmlString == null || XmlString.Length == 0)
                return root;

            XmlDocument XmlDoc = new XmlDocument();
            try
            {
                XmlDoc.LoadXml(XmlString);
                root = XmlDoc.DocumentElement;
            }
            catch (XmlException)
            {   // Caused by a format error in the XML.
                root = null;
            }
            catch (Exception)
            {   // Unknown error.
                root = null;
            }

            return root;
        }
    }

    /// <summary>
    /// This class creates a string writer that uses UTF-8 encoding.
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        /// <summary>
        /// Use UTF8 encoding but write no BOM to the wire
        /// </summary>
        public override Encoding Encoding
        {
            get { return new UTF8Encoding(false); }
        }
    }
}
