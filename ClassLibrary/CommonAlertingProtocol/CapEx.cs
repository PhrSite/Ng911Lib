/////////////////////////////////////////////////////////////////////////////////////
//  File:   CapEx.cs                                                25 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using System.Xml.Serialization;
using System.Text;
using Pidf;

namespace CommonAlertingProtocol
{
    public partial class alertInfo
    {
        /// <summary>
        /// Gets or sets the optional effective time of the information of the alert message.
        /// </summary>
        [XmlIgnore]
        public DateTime Effective
        {
            get
            {
                if (effectiveSpecified == true)
                    return effective;
                else
                    return DateTime.Now;
            }
            set
            {
                effective = value;
                effectiveSpecified = true;
            }
        }

        /// <summary>
        /// Gets or sets the expected time of the beginning of the subject event of the alert message 
        /// (OPTIONAL).
        /// </summary>
        [XmlIgnore]
        public DateTime Onset
        {
            get
            {
                if (onsetSpecified == true)
                    return onset;
                else
                    return DateTime.Now;
            }
            set
            {
                onset = value;
                onsetSpecified = true;
            }
        }

        /// <summary>
        /// Gets or sets expiry time of the information of the alert message (OPTIONAL).
        /// </summary>
        [XmlIgnore]
        public DateTime Expires
        {
            get
            {
                if (expiresSpecified == true)
                    return expires;
                else
                    return DateTime.Now;
            }
            set
            {
                expires = value;
                expiresSpecified = true;
            }
        }
    }

    public partial class alertInfoArea
    {
        /// <summary>
        /// Gets or sets a list of PIDF-LO Polygons from or to the polygon string list.
        /// Returns an empty list if there are no polygon strings or if an error occurred.
        /// </summary>
        [XmlIgnore]
        public List<Polygon> PidfPolygonList
        {
            get
            {
                List<Polygon> list = new List<Polygon>();
                if (polygon == null || polygon.Count == 0)
                    return list;

                foreach (string str in polygon)
                {
                    Polygon polygon = StringToPolygon(str);
                    if (polygon != null)
                        list.Add(polygon);
                }

                return list;
            }
            set
            {
                if (value == null || value.Count == 0)
                    return;     // Error

                polygon = new List<string>();
                foreach (Polygon poly in value)
                {
                    string str = PolygonToString(poly);
                    if (string.IsNullOrEmpty(str) == false)
                        polygon.Add(str);
                }
            }
        }

        private Polygon StringToPolygon(string strPoly)
        {
            // Each point in the string is a comma separated set of coordinates. Each set of coordinates
            // is separated by a space.
            string[] strPts = strPoly.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (strPts == null || strPts.Length < 4)
                return null;    // Error: A polygon must have at least 4 points.

            Polygon poly = new Polygon();
            poly.exterior = new Exterior();
            poly.exterior.LinearRing = new LinearRing();
            poly.exterior.LinearRing.pos = new List<Position>();
            foreach (string str in strPts)
            {
                string[] strCoords = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (strCoords == null || strCoords.Length != 2)
                    return null;    // Error

                double Lat, Long;
                if (double.TryParse(strCoords[0], out Lat) == false || double.TryParse(strCoords[1], 
                    out Long) == false)
                    return null;    // Error

                Position position = new Position(Lat, Long);
                poly.exterior.LinearRing.pos.Add(position);
            }

            return poly;
        }

        private string PolygonToString(Polygon poly)
        {
            LinearRing Lr = poly?.exterior?.LinearRing;
            if (Lr == null)
                return null;    // Error condition

            List<Position> positions = Lr.pos;
            if (positions == null)
            {   // No position list, see if the LinearRing contains the compact form of a polygon.
                if (Lr.posList == null)
                    return null;    // Error -- no points in the LinearRing

                positions = Lr.ConvertCompactFormToStandardForm();
            }

            if (positions.Count < 4)
                return null;    // Error -- for a CAP polygon, there must be at least 4 points.

            StringBuilder Sb = new StringBuilder();
            foreach (Position Pos in positions)
                Sb.Append($"{Pos.Latitude.ToString()},{Pos.Longitude.ToString()} ");

            return Sb.ToString().TrimEnd();
        }


        /// <summary>
        /// Gets or sets a list of PIDF-LO Circles from or to the string list.
        /// Returns an empty list if there are no circle strings or if an error occurred.
        /// </summary>
        [XmlIgnore]
        public List<Circle> PidfCircleList
        {
            get
            {
                List<Circle> list = new List<Circle>();
                if (circle == null || circle.Count == 0)
                    return list;

                foreach (string str in circle)
                {
                    Circle Cir = StringToCircle(str);
                    if (Cir != null)
                        list.Add(Cir);
                }

                return list;
            }
            set
            {
                if (value == null || value.Count == 0)
                    return;     // Error

                circle = new List<string>();
                foreach (Circle Cir in value)
                {
                    string str = CircleToString(Cir);
                    if (string.IsNullOrEmpty(str) == false)
                        circle.Add(str);
                }
            }
        }

        private Circle StringToCircle(string str)
        {
            if (string.IsNullOrEmpty(str) == true)
                return null;

            string[] fields = str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (fields == null || fields.Length != 3)
                return null;

            double Lat, Long, Rad;
            if (double.TryParse(fields[0], out Lat) == false || double.TryParse(fields[1], out Long) == 
                false || double.TryParse(fields[2], out Rad) == false)
                return null;
            // Convert the radius in kilometers to the radius in meters.
            Circle Cir = new Circle(Lat, Long, Convert.ToInt32(Rad/1000));

            return Cir;
        }

        private string CircleToString(Circle Cir)
        {
            double Rad;
            if (double.TryParse(Cir.radius.Value, out Rad) == false || Cir.pos == null)
                return null;    // Error

            string str = $"{Cir.pos.Latitude},{Cir.pos.Longitude} {Rad.ToString()}";
            return str;
        }

        /// <summary>
        /// Gets or sets the altitude of the area of the alert. The altitude is the specific or minimum 
        /// altitude of the affected area of the alert message (OPTIONAL).
        /// </summary>
        /// <remarks>
        /// <list type="number">
        /// <item>If used with the ceiling element this value is the lower limit of a range. 
        /// Otherwise, this value specifies a specific altitude.</item>
        /// <item>The altitude measure is in feet above mean sea level per the [WGS 84] datum.</item>
        /// </list>
        /// </remarks>
        [XmlIgnore]
        public decimal Altitude
        {
            get
            {
                if (altitudeSpecified == true)
                    return altitude;
                else
                    return 0;
            }
            set
            {
                altitude = value;
                altitudeSpecified = true;
            }
        }

        /// <summary>
        /// Gets or sets the ceiling of the alert. The maximum altitude of the affected area of the 
        /// alert message (CONDITIONAL).
        /// </summary>
        /// <remarks>
        /// <list type="number">
        /// <item>MUST NOT be used except in combination with the altitude element.</item>
        /// <item>The ceiling measure is in feet above mean sea level per the [WGS 84] datum.</item>
        /// </list>
        /// </remarks>
        [XmlIgnore]
        public decimal Ceiling
        {
            get
            {
                if (ceilingSpecified == true)
                    return ceiling;
                else
                    return 0;
            }
            set
            {
                ceiling = value;
                ceilingSpecified = true;
            }
        }
    }
}
