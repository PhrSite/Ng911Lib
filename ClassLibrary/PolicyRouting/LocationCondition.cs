/////////////////////////////////////////////////////////////////////////////////////
//  File:   LocationCondition.cs                                    23 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace PolicyRouting
{
    /// <summary>
    /// Tests to see of the location of a call meets certain conditions. See Sections 3.3.3.1.5 
    /// and E.1.1 of NENA-STA-010.3.
    /// </summary>
    public class LocationCondition : ConditionBase
    {
        /// <summary>
        /// Contains one or more objects that describe a location. Required.
        /// </summary>
        public List<PrrLocation> location { get; set; } = new List<PrrLocation>();

        /// <summary>
        /// Extension object for future use.
        /// Optional.
        /// </summary>
        public object extension { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LocationCondition()
        {
            conditionType = nameof(LocationCondition);
        }
    }

    /// <summary>
    /// Class that conditions parameters to use to test a location against.
    /// See Section 3.3.3.1.5 of NENA-STA-010.3.
    /// </summary>
    public class PrrLocation
    {
        /// <summary>
        /// Contains a PIDF-LO XML document that identifies the location to test for.
        /// Required.
        /// </summary>
        public string lo { get; set; }

        /// <summary>
        /// Indicates the location profile. Must be "geodetic" or "civic". Required.
        /// </summary>
        public string profile { get; set; }

        /// <summary>
        /// Human-readable desciption of the location.
        /// Optional.
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// Contains a language tag for rendering the content of the label field.
        /// Optional.
        /// </summary>
        public string lang { get; set; }

        /// <summary>
        /// Extension for future use.
        /// Optional.
        /// </summary>
        public object extension { get; set; }
    }
}
