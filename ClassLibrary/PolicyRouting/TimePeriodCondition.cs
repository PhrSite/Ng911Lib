/////////////////////////////////////////////////////////////////////////////////////
//  File:   TimePeriodCondition.cs                                  23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;

namespace PolicyRouting
{
    /// <summary>
    /// This condition class allows a rule to make decisions based on time, date
    /// and time zone. See Sections 3.3.3.1.1 and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class TimePeriodCondition : ConditionBase
    {
        /// <summary>
        /// Start of interval (Timestamp, see Section 2.3 of NENA-STA-010.3). Required
        /// </summary>
        public string dateStart { get; set; }

        /// <summary>
        /// End of interval (Timestamp, see Section 2.3 of NENA-STA-010.3). Required.
        /// </summary>
        public string dateStop { get; set; }

        /// <summary>
        /// Start of time interval in a particular day. It uses the partial-time date type as described 
        /// in Section 5.6 of RFC 3339 interpreted as having the same offset from UTC as found in 
        /// dateStart and dateEnd. Optional.
        /// </summary>
        public string timeStart { get; set; } = "00:00:00";

        /// <summary>
        /// End of time interval in a particular day. It uses the partial-time data type as described in 
        /// Section 5.6 of RFC 3339 [135], interpreted as having the same offset from UTC as found in 
        /// dateStart and dateEnd. This member is OPTIONAL; if specified MUST be greater than the value of 
        /// timeStart.
        /// </summary>
        public string timeEnd { get; set; } = "23:59:59";

        /// <summary>
        /// List of days of the week. The "weekdayList" member specifies a comma-separated list of days
        /// of the week: MO, TU, WE, TH, FR, SA, SU.
        /// Optional.
        /// </summary>
        public string weekdayList { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TimePeriodCondition()
        {
            conditionType = nameof(TimePeriodCondition);
            DateTime Now = DateTime.Now;
            dateStart = TimeUtils.DateTimeToNenaTimeStamp(Now);
            dateStop = TimeUtils.DateTimeToNenaTimeStamp(Now + TimeSpan.FromDays(7));
        }
    }
}
