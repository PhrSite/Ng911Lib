/////////////////////////////////////////////////////////////////////////////////////
//  File:   LostDiscrepancyReport.cs                                20 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace DiscrepancyReporting
{
    /// <summary>
    /// Data class for reporting a LoST discrepancy. See Sections 3.7.5 and E.2.1 of NENA-STA-010.3.
    /// </summary>
    public class LostDiscrepancyReport : DiscrepancyReport
    {
        /// <summary>
        /// Specifies the type of LoST query. Must be set to the string equivalent of one of the values in 
        /// the LostQueryTypeEnum. Required.
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// Contains the XML document of the request sent by the client.
        /// Required.
        /// </summary>
        public string request { get; set; }

        /// <summary>
        /// Contains the XML document of the response received by the client.
        /// Required.
        /// </summary>
        public string response { get; set; }

        /// <summary>
        /// Specifies the problem that was encountered. Must be the string equivalent of one of the values 
        /// in the LostProblemEnum.
        /// Required.
        /// </summary>
        public string problem { get; set; }

        /// <summary>
        /// To Be Determined.
        /// </summary>
        public string discrepancyDetail { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LostDiscrepancyReport()
        {
        }
    }

    /// <summary>
    /// Identifies the LoST query type.
    /// </summary>
    public enum LostQueryTypeEnum
    {
        /// <summary>
        /// Find service request
        /// </summary>
        findService, 
        /// <summary>
        /// Get service boundary request
        /// </summary>
        getServiceBoundary,
        /// <summary>
        /// List services request
        /// </summary>
        listServices,
        /// <summary>
        /// List services by location request
        /// </summary>
        listServicesByLocation
    }

    /// <summary>
    /// Types of LoST query problems.
    /// </summary>
    public enum LostProblemEnum
    {
        /// <summary>
        /// Believed to be valid
        /// </summary>
        BelievedValid,
        /// <summary>
        /// Believed to be invalid
        /// </summary>
        BelievedInvalid,
        /// <summary>
        /// No such location
        /// </summary>
        NoSuchLocation,
        /// <summary>
        /// Route is incorrect
        /// </summary>
        RouteIncorrect,
        /// <summary>
        /// Multiple mappings returned
        /// </summary>
        MultipleMappings,
        /// <summary>
        /// Service boundary is incorrect
        /// </summary>
        ServiceBoundaryIncorrect,
        /// <summary>
        /// Service number is incorrect
        /// </summary>
        ServiceNumberIncorrect,
        /// <summary>
        /// Data expired
        /// </summary>
        DataExpired,
        /// <summary>
        /// Incorrect URI returned
        /// </summary>
        IncorrectUri,
        /// <summary>
        /// Location error
        /// </summary>
        LocationErrorInError,
        /// <summary>
        /// Other loST error
        /// </summary>
        OtherLost
    }
}
