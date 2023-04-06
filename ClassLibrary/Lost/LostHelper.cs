/////////////////////////////////////////////////////////////////////////////////////
//  File:   LostFuncs.cs                                            10 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace Lost
{
    /// <summary>
    /// Utility class that provide various static functions for handling LoST protocol messages.
    /// </summary>
    public static class LostHelper
    {
        /// <summary>
        /// Determines the type of LoST request that is contained in the input string and deserializes 
        /// the XML document to the appropriate class.
        /// </summary>
        /// <param name="strMsg">Input string containing a LoST request XML document.</param>
        /// <returns>Returns a FindService, GetServiceBoundary, ListServices, or ListServicesByLocation 
        /// object if the input string is a valid LoST XML request document. Returns null if the document 
        /// type is not recognized or the document is not a valid XML document.</returns>
        public static object DeserializeLostRequest(string strMsg)
        {
            object Result = null;
            if (strMsg.IndexOf("findService") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(FindService));
            else if (strMsg.IndexOf("getServiceBoundary") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    GetServiceBoundary));
            else if (strMsg.IndexOf("listServices") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    ListServices));
            else if (strMsg.IndexOf("listServicesByLocation") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    ListServicesByLocation));

            return Result;
        }

        /// <summary>
        /// Determines the type of LoST response that is contained in the input string and deserializes 
        /// the XML document to the appropriate class.
        /// </summary>
        /// <param name="strMsg">Input string containing a LoST response XML document.</param>
        /// <returns>Returns a FindServiceResponse, GetServiceBoundaryResponse, ListServicesResponse, 
        /// ListServicesByLocationResponse LostRedirect, or LostErrors object if the input string is a 
        /// valid LoST XML request document. Returns null if the document type is not recognized or the 
        /// document is not a valid XML document.</returns>
        public static object DeserializeLostResponse(string strMsg)
        {
            object Result = null;
            if (strMsg.IndexOf("findServiceResponse") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    FindServiceResponse));
            else if (strMsg.IndexOf("getServiceBoundaryResponse") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    GetServiceBoundaryResponse));
            else if (strMsg.IndexOf("listServicesResponse") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    ListServicesResponse));
            else if (strMsg.IndexOf("listServicesByLocationResponse") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    ListServicesByLocationResponse));
            else if (strMsg.IndexOf("errors") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(LostErrors));
            else if (strMsg.IndexOf("redirect") >= 0)
                Result = XmlHelper.DeserializeFromString(strMsg, typeof(
                    LostRedirect));

            return Result;
        }
    }
}
