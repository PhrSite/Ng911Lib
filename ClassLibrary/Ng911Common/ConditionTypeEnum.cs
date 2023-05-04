/////////////////////////////////////////////////////////////////////////////////////
//  File:   ConditionTypeEnum.cs                                    22 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace Ng911Common
{
    /// <summary>
    /// Enumeration of the different types of conditions for Policy Routing Rules.
    /// </summary>
    public enum ConditionTypeEnum
    {
        /// <summary>
        /// Time period condition
        /// </summary>
        TimePeriodCondition,
        /// <summary>
        /// SIP Header condition
        /// </summary>
        SipHeaderCondition,
        /// <summary>
        /// Additional data condition
        /// </summary>
        AdditionalDataCondition,
        /// <summary>
        /// MIME body condition
        /// </summary>
        MimeBodyCondition,
        /// <summary>
        /// Location condition
        /// </summary>
        LocationCondition,
        /// <summary>
        /// Call suspicion condition
        /// </summary>
        CallSuspicionCondition,
        /// <summary>
        /// Security posture condition
        /// </summary>
        SecurityPostureCondition,
        /// <summary>
        /// Queue state condition
        /// </summary>
        QueueStateCondition,
        /// <summary>
        /// LoST service URN condition
        /// </summary>
        LostServiceUrnCondition,
        /// <summary>
        /// Service state condition
        /// </summary>
        ServiceStateCondition,
        /// <summary>
        /// Call source condition
        /// </summary>
        CallSourceCondition,
        /// <summary>
        /// Body part condition
        /// </summary>
        BodyPartCondition,
        /// <summary>
        /// Request URI condition
        /// </summary>
        RequestUriCondition,
        /// <summary>
        /// Normal next hop condition
        /// </summary>
        NormalNextHopCondition,
        /// <summary>
        /// Incoming queue condition
        /// </summary>
        IncomingQueueCondition,
        /// <summary>
        /// SDP offer condition
        /// </summary>
        SdpOfferCondition,
        /// <summary>
        /// CAP (Common Alerting Protocol) condition
        /// </summary>
        CapCondition,
        /// <summary>
        /// Calling number verification status condition
        /// </summary>
        CallingNumberVerificationStatusCondition
    }
}
