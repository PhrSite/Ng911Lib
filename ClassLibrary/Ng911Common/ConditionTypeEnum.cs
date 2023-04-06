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
        TimePeriodCondition,
        SipHeaderCondition,
        AdditionalDataCondition,
        MimeBodyCondition,
        LocationCondition,
        CallSuspicionCondition,
        SecurityPostureCondition,
        QueueStateCondition,
        LostServiceUrnCondition,
        ServiceStateCondition,
        CallSourceCondition,
        BodyPartCondition,
        RequestUriCondition,
        NormalNextHopCondition,
        IncomingQueueCondition,
        SdpOfferCondition,
        CapCondition,
        CallingNumberVerificationStatusCondition
    }
}
