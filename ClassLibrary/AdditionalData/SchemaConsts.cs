/////////////////////////////////////////////////////////////////////////////////////
//  File:   SchemaConsts.cs                                         30 Nov 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace AdditionalData
{
    /// <summary>
    /// Defines string constants used for Additional Data Related to an Emergency Call. See RFC 7852 and 
    /// NENA-STA-012.2.
    /// </summary>
    public static class SchemaConsts
    {
        /// <summary>
        /// Content-Type header for the PIDF-LO location object
        /// </summary>
        public const string PidfContentType = "application/pidf+xml";

        /// <summary>
        /// Schema name for ProviderInfo
        /// </summary>
        public const string ProviderInfoSchema = "EmergencyCallData.ProviderInfo";
        /// <summary>
        /// Content-Type header value for ProviderInfo
        /// </summary>
        public const string ProviderInfoContentType = "application/" + ProviderInfoSchema + "+xml";
        /// <summary>
        /// Schema name for ServiceInfo
        /// </summary>
        public const string ServiceInfoSchema = "EmergencyCallData.ServiceInfo";
        /// <summary>
        /// Content-Type header value for ServiceInfo
        /// </summary>
        public const string ServiceInfoContentType = "application/" + ServiceInfoSchema + "+xml";
        /// <summary>
        /// Schema name for DeviceInfo
        /// </summary>
        public const string DeviceInfoSchema = "EmergencyCallData.DeviceInfo";
        /// <summary>
        /// Content-Type header value for DeviceInfo
        /// </summary>
        public const string DeviceInfoContentType = "application/" + DeviceInfoSchema + "+xml";
        /// <summary>
        /// Schema name for SubscriberInfo
        /// </summary>
        public const string SubscriberInfoSchema = "EmergencyCallData.SubscriberInfo";
        /// <summary>
        /// Content-Type header value for SubscriberInfo
        /// </summary>
        public const string SubscriberInfoContentType = "application/" + SubscriberInfoSchema + "+xml";
        /// <summary>
        /// Schema name for Comment blocks
        /// </summary>
        public const string CommentSchema = "EmergencyCallData.Comment";
        /// <summary>
        /// Content-Type header value for Comment blocks.
        /// </summary>
        public const string CommentContentType = "application/" + CommentSchema + "+xml";

        /// <summary>
        /// Schema name for CallerInfo block. See Section 3.5.3 of NENA-STA-012.2.
        /// </summary>
        public const string CallerInfoSchema = "EmergencyCallData.NENA-CallerInfo";
        /// <summary>
        /// Content=Type header value for CallerInfo.
        /// </summary>
        public const string CallerInfoContentType = "application/" + CallerInfoSchema + "+xml";
        /// <summary>
        /// Schema name for LocationInfo. See Section 3.4.3 of NENA=STA-012.2.
        /// </summary>
        public const string LocationInfoSchema = "EmergencyCallData.NENA-LocationInfo";
        /// <summary>
        /// Content-Type header value for LocationInfo.
        /// </summary>
        public const string LocationInfoContentType = "application/" + LocationInfoSchema + "+xml";
    }
}
