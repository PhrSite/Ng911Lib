/////////////////////////////////////////////////////////////////////////////////////
//  File:   SdpOfferCondition.cs                                    23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Text.Json.Serialization;

namespace PolicyRouting
{
    /// <summary>
    /// This condition supports routing policy based on SDP offers. See Sections 3.3.3.1.16 and 
    /// E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class SdpOfferCondition : ConditionBase
    {
        /// <summary>
        /// If true then test for video in the SDP offer.
        /// </summary>
        public bool video { get; set; } = false;

        /// <summary>
        /// If true then test for audio in the SDP offer.
        /// </summary>
        public bool audio { get; set; } = false;

        /// <summary>
        /// If true then test for RTT (media=text) in the offer.
        /// </summary>
        public bool rtt { get; set; } = false;

        /// <summary>
        /// If true then test for IM in the SDP offer.
        /// Note: IM is not a specified media type in NENA-STA-010.3. Assume
        /// that IM is MSRP (media=message).
        /// </summary>
        public bool im { get; set; } = false;

        /// <summary>
        /// If true then test for RTT and IM (MSRP).
        /// </summary>
        public bool text { get; set; } = false;

        /// <summary>
        /// Contains an array of language subtags to test for video.
        /// Optional.
        /// </summary>
        public List<string> langVideo { get; set; }

        /// <summary>
        /// Contains an array of language subtags to test for audio.
        /// Optional.
        /// </summary>
        public List<string> langAudio { get; set; }

        /// <summary>
        /// Contains an array of language subtags to test for RTT.
        /// Optional.
        /// </summary>
        public List<string> langRtt { get; set; }

        /// <summary>
        /// List of language subtags to test for IM (MSRP).
        /// Optional.
        /// </summary>
        public List<string> langIm { get; set; }

        /// <summary>
        /// List of language subtags to test for when testing for text (RTT or IM).
        /// Optional.
        /// </summary>
        public List<string> langText { get; set; }
        
        /// <summary>
        /// Language preference parameters to test for when testing for video.
        /// Optional.
        /// </summary>
        public Pref langVideoPref { get; set; }

        /// <summary>
        /// Language preference parameters to test for when testing for audio.
        /// Optional.
        /// </summary>
        public Pref langAudioPref { get; set; }

        /// <summary>
        /// Language preference parameters to test for when testing for RTT.
        /// Optional.
        /// </summary>
        public Pref langRttPref { get; set; }

        /// <summary>
        /// Language preference parameters to test for when testing for IM (MSRP).
        /// Optional.
        /// </summary>
        public Pref langImPref { get; set; }

        /// <summary>
        /// Language preference parameters to test for when testing for text.
        /// Optional.
        /// </summary>
        public Pref langTextPref { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SdpOfferCondition()
        {
            conditionType = nameof(SdpOfferCondition);
        }
    }

    /// <summary>
    /// Class for specifying language preferences
    /// </summary>
    public class Pref
    {
        /// <summary>
        /// Array of strings, each element is a language subtag.
        /// Required.
        /// </summary>
        public List<string> langList { get; set; }

        /// <summary>
        /// String containing a language subtag. Required.
        /// </summary>
        public string langTest { get; set; }
    }
}
