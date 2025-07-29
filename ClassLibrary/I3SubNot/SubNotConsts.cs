/////////////////////////////////////////////////////////////////////////////////////
//  File:   SubNotConsts.cs                                         15 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot;

/// <summary>
/// Constants for NENA NG9-1-1 i3 Subscriptions.
/// </summary>
public static class SubNotConsts
{
    /// <summary>
    /// Event type for the SIP Presence Event Package. See RFC 3856 and RFC 6442. This event is 
    /// related to a call.
    /// </summary>
    public const string PresenceEvent = "presence";

    /// <summary>
    /// Event type for the Conference Event Package. See RFC 4575. This event is related to a call.
    /// </summary>
    public const string ConferenceEvent = "conference";

    /// <summary>
    /// This is the default value for the Expires header for a subscription to the conference event 
    /// package.
    /// </summary>
    public const int ConferenceEventExpires = 86400;

    /// <summary>
    /// Event type for the I3 Element state event. See Section 2.4.1 of NENA-STA-010.3.
    /// </summary>
    public const string ElementState = "emergency-ElementState";

    /// <summary>
    /// Event type for the I3 Service state event. See Section 2.4.2 of NENA-STA-010.3.
    /// </summary>
    public const string ServiceState = "emergency-ServiceState";

    /// <summary>
    /// Event type for the I3 Queue state Event. See Section 4.2.1.3 of NENA-STA-010.3.
    /// </summary>
    public const string QueueState = "emergency-QueueState";

    /// <summary>
    /// Event type for the I3 ESRP Notify Event. See Section 4.2.1.6 of NENA-STA-010.3.
    /// </summary>
    public const string EsrpNotify = "emergency-ESRPnotify";

    /// <summary>
    /// Event type for the I3 Gap-Overlap NOTIFY event. See Section 4.3.4 of NENA-STA-010.3.
    /// </summary>
    public const string GapOverlap = "emergency-GapOverlap";

    /// <summary>
    /// Event type for the I3 Abandoned Call NOTIFY event. See Section 4.2.2.9 of NENA-STA-010.3.
    /// </summary>
    public const string AbandonedCall = "emergency-AbandonedCall";

    /// <summary>
    /// List of supported event packages.
    /// </summary>
    public static string[] SupportedEvents =
    {
        PresenceEvent,
        ConferenceEvent,
        ElementState,
        ServiceState,
        QueueState,
        EsrpNotify,
        GapOverlap,
        AbandonedCall
    };

    /// <summary>
    /// Checks to see a SIP subscription event package is supported.
    /// </summary>
    /// <param name="Event">Value of the Event header of a SUBSCRIBE request. </param>
    /// <returns>Returns true if the event package is supported or false if it is not supported.
    /// </returns>
    public static bool SubscriptionSupported(string Event)
    {
        if (string.IsNullOrEmpty(Event) == true)
            return false;

        foreach (string str in SupportedEvents)
        {
            if (Event == str)
                return true;
        }

        return false;
    }
}
