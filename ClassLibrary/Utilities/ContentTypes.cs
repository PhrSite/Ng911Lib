﻿/////////////////////////////////////////////////////////////////////////////////////
//  File:   ContentTypes.cs                                         28 Mar 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911Lib.Utilities
{
    /// <summary>
    /// Static class that defines values used for the Content-Type SIP and HTTP headers for MIME
    /// types used in NG9-1-1 applications.
    /// </summary>
    public static class ContentTypes
    { 
        /// <summary>
        /// PIDF-LO location information as defined in RFC 3863 and RFC 4119.
        /// </summary>
        public const string Pidf = "application/pidf+xml";

        /// <summary>
        /// Provider information additional data. See RFC 7852.
        /// </summary>
        public const string ProviderInfo = "application/EmergencyCallData.ProviderInfo+xml";

        /// <summary>
        /// Service information additional data. See RFC 7852.
        /// </summary>
        public const string ServiceInfo = "application/EmergencyCallData.ServiceInfo+xml";

        /// <summary>
        /// Device information additional data. See RFC 7852.
        /// </summary>
        public const string DeviceInfo = "application/EmergencyCallData.DeviceInfo+xml";

        /// <summary>
        /// Subscriber information additional data. See RFC 7852.
        /// </summary>
        public const string SubscriberInfo = "application/EmergencyCallData.SubscriberInfo+xml";

        /// <summary>
        /// Comments for additional data. See RFC 7852.
        /// </summary>
        public const string Comment = "application/EmergencyCallData.Comment+xml";

        /// <summary>
        /// Location information additional data defined by NENA. See NENA-STA-012.2.
        /// </summary>
        public const string NenaLocationInfo = "application/EmergencyCallData.NENA-LocationInfo+xml";

        /// <summary>
        /// Caller information additional data defined by NENA. See NENA-STA-012.2.
        /// </summary>
        public const string NenaCallerInfo = "application/EmergencyCallData.NENA-CallerInfo+xml";

        /// <summary>
        /// Control information for eCall and VEDS advanced automatic crash notification calls.
        /// See RFC 8147.
        /// </summary>
        public const string Control = "application/EmergencyCallData.Control+xml";

        /// <summary>
        /// E-Call Minimum Set Data information used in Europe only. See RFC 8147.
        /// </summary>
        public const string EcallMsd = "application/EmergencyCallData.eCall.MSD";

        /// <summary>
        /// Vehicle emergency data set data for in-vehicle initiated emergency calls (Advanced
        /// Automatic Crash Notification). See RFC 8148.
        /// </summary>
        public const string Veds = "application/EmergencyCallData.VEDS+xml";

        /// <summary>
        /// HTTP Enabled Location Data (HELD) contents. See RFC 5985.
        /// </summary>
        public const string Held = "application/held+xml";

        /// <summary>
        /// Location to Service Translation (LoST) contents. See RFC 5222.
        /// </summary>
        public const string Lost = "application/lost+xml";

        /// <summary>
        /// Element State contents. See Section 2.4.1 of NENA-STA-010.3b.
        /// </summary>
        public const string ElementState = "application/EmergencyCallData.ElementState+json";

        /// <summary>
        /// Service State contents. See Section 2.4.2 of NENA-STA-010.3b.
        /// </summary>
        public const string ServiceState = "application/EmergencyCallData.ServiceState+json";

        /// <summary>
        /// Queue State contents. See Section 4.2.1.3 of NENA-STA-010.3b.
        /// </summary>
        public const string QueueState = "application/EmergencyCallData.QueueState+json";

        /// <summary>
        /// ESRP Route Notify body contents. See Section 4.2.1.6 of NENA-STA-010.3b.
        /// </summary>
        public const string ESRPNotify = "application/EmergencyCallData.ESRProute+json";

        /// <summary>
        /// Abandoned Call Notify body contents. See Section 4.2.2.9 of NENA-STA-010.3b.
        /// </summary>
        public const string AbandonedCall = "application/emergencyCallData.AbandonedCall+json";

        /// <summary>
        /// Gap/overlap Notify body contents. See Section 4.3.4 of NENA-STA-010.3b.
        /// </summary>
        public const string GapOverlap = "application/EmergencyCallData.GapOverlap+json";

        /// <summary>
        /// Common Alerting Protocol (CAP) contents. See Section 3.1.11 of NENA-STA-010.3b and
        /// Common Alerting Protocol Version 1.2 (CAP-v1.2-os).
        /// </summary>
        public const string Cap = "application/commonalerting-protocol+xml";

        /// <summary>
        /// Content-Type when a CAP message is enclosed in an EDXL-DE wrapper. See Section 3.1.11 of
        /// NENA-STA-010.3b.
        /// </summary>
        public const string Edxl = "application/emergency-data-exchange-language+xml";

        /// <summary>
        /// MIME type for the Route Policy. See Section 3.3.3 of NENA-STA-010.3b.
        /// </summary>
        public const string RoutePolicy = "application/EmergencyCallData.auth-policy+json";

        /// <summary>
        /// MIME type for Session Description Protocol (SDP) data. See RFC 4566.
        /// </summary>
        public const string Sdp = "application/sdp";

        /// <summary>
        /// Content-Type header value for the conference event. See Section 9.2 of RFC 4575.
        /// </summary>
        public const string ConferenceEvent = "application/conference-info+xml";

        /// <summary>
        /// SIPREC (SIP Recording Protocol) contents. See RFC 7865.
        /// </summary>
        public const string SipRecMetaData = "application/rs-metadata+xml";

        /// <summary>
        /// Emergency Indident Data Object (EIDO). See NENA-STA-024.1a-2023
        /// </summary>
        public const string Eido = "application/emergency.eido+json)";
    }
}
