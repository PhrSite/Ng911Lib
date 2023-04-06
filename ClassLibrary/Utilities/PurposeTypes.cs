/////////////////////////////////////////////////////////////////////////////////////
//  File:   PurposeTypes.cs                                         28 Mar 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911Lib.Utilities
{
    /// <summary>
    /// Static class that defines the values for the purpose parameter of Call-Info SIP headers
    /// used in NG9-1-1 applications.
    /// </summary>
    public static class PurposeTypes
    {
        /// <summary>
        /// Provide information additional data schema. See RFC 7852.
        /// </summary>
        public const string ProviderInfo = "EmergencyCallData.ProviderInfo";

        /// <summary>
        /// Service information additional data schema. See RFC 7852.
        /// </summary>
        public const string ServiceInfo = "EmergencyCallData.ServiceInfo";

        /// <summary>
        /// Device information additional data schema. See RFC 7852.
        /// </summary>
        public const string DeviceInfo = "EmergencyCallData.DeviceInfo";

        /// <summary>
        /// Subscriber information additional data schema. See RFC 7852.
        /// </summary>
        public const string SubscriberInfo = "EmergencyCallData.SubscriberInfo";

        /// <summary>
        /// Comment additional data schema. See RFC 7852.
        /// </summary>
        public const string Comment = "EmergencyCallData.Comment";

        /// <summary>
        ///  Location information additional data defined by NENA. See NENA-STA-012.2.
        /// </summary>
        public const string NenaLocationInfo = "EmergencyCallData.NENA-LocationInfo";

        /// <summary>
        /// Caller information additional data defined by NENA. See NENA-STA-012.2.
        /// </summary>
        public const string NenaCallerInfo = "EmergencyCallData.NENA-CallerInfo";

        /// <summary>
        /// Control additional data schema used in eCall and VEDS advanced automatic crash notification 
        /// calls. See RFC 8147 and RFC 8148.
        /// </summary>
        public const string Control = "EmergencyCallData.Control";

        /// <summary>
        /// E-Call Minimum Set Data schema used in Europe. See RFC 8147.
        /// </summary>
        public const string EcallMsd = "EmergencyCallData.eCall.MSD";

        /// <summary>
        /// Vehicle emergency data set schema. See RFC 8148.
        /// </summary>
        public const string Veds = "EmergencyCallData.VEDS";
    }
}
