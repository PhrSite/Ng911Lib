/////////////////////////////////////////////////////////////////////////////////////
//  File:   NotifyAction.cs                                         23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Diagnostics.Tracing;
using System;
using static System.Collections.Specialized.BitVector32;

namespace PolicyRouting
{
    /// <summary>
    /// This action sends a NOTIFY message to entities subscribing to the ESRP’s "ESRPnotify” event package
    /// for the specified “eventCode”. See Sections 3.3.3.2.3 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class NotifyAction : ActionBase
    {
        /// <summary>
        /// When present, it MUST be either a URI or a service URN.This member is used to notify a 
        /// single entity registered for the “eventCode”. If “recipient” is a URI, notification is
        /// generated for that specific recipient.If “recipient” is a service URN, the ECRF is 
        /// used to map the service URN to a URI, and a notification is generated for that URI.
        /// Recipients MUST have subscribed for the “eventCode” to get the notification. If “recipient”
        /// is omitted, notification is generated for all subscribers to the “eventCode”. In all cases,
        /// notifications are subject to perrecipient throttling.
        /// Optional.
        /// </summary>
        public string recipient { get; set; }

        /// <summary>
        /// Must be set to a value contained in the EsrpNotifyEventCodes registry (Section 10.19 of
        /// NENA-STA-010.3). Required.
        /// </summary>
        public string eventCode { get; set; }

        /// <summary>
        /// Must be set to an integer value from 0 and 100 where 0 is no urgency and 100 is the highest 
        /// possible urgency. Required.
        /// </summary>
        public int urgency { get; set; } = 0;

        /// <summary>
        /// If present, it is a text string that is included in the “Comment” field of the NOTIFY message.
        /// Optional.
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NotifyAction()
        {
            actionType = nameof(NotifyAction);
        }
    }
}
