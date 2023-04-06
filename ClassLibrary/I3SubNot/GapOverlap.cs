/////////////////////////////////////////////////////////////////////////////////////
//  File:   GapOverlap.cs                                           16 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

namespace I3SubNot
{
    /// <summary>
    /// Data class for the I3 Gap Overlay NOTIFY body. See Section 4.3.4 and Section E.11.1.3 of
    /// NENA-STA-010.3.
    /// </summary>
    public class GapOverlap
    {
        /// <summary>
        /// Array of URIs of Agency with gap/overlap. Will be repeated at least twice
        /// Required.
        /// </summary>
        public List<string> agencies = new List<string>();

        /// <summary>
        /// Array of layers in which gap/overlap exists. May occur multiple times.
        /// Required.
        /// </summary>
        public List<string> layers = new List<string>();

        /// <summary>
        /// True if a gap, else False.
        /// Required.
        /// </summary>
        public bool gap { get; set; } = false;

        /// <summary>
        /// Timestamp when gap/overlap will occur.
        /// Required.
        /// </summary>
        public string dateTime { get; set; }

        /// <summary>
        /// GML Polygon area of gap/overlap.
        /// Required.
        /// </summary>
        public string area { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GapOverlap()
        {
        }
    }
}
