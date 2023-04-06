/////////////////////////////////////////////////////////////////////////////////////
//  File:   PidfUnitTests.cs                                        30 Nov 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Pidf;
using Ng911Lib.Utilities;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class PidfUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test PIDF-LO XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\PidfFiles\";

        private string GetRawData(string strFileName)
        {
            string strFilePath = $"{Path}{strFileName}";
            Assert.True(File.Exists(strFilePath), $"The {strFileName} input file was missing.");
            string strData = File.ReadAllText(strFilePath);
            return strData;
        }

        private Presence DeserializePresenceObject(string strFileName)
        {
            string strData = GetRawData(strFileName);
            Assert.NotNull(strData);
            Presence presence = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            Assert.NotNull(presence);
            return presence;
        }

        [Fact]
        public void DeviceAndPerson()
        {
            Presence presence = DeserializePresenceObject("DeviceAndPerson.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");
            Assert.True(presence.person != null, "The person element is null");

            CivicAddress Ca = presence.GetFirstCivicAddress();
            Assert.NotNull(Ca);
            Assert.True(Ca.country == "US", "The CivicAddress country is wrong");
            Assert.True(Ca.A1 == "CA", "The CivicAddress state is wrong");
            Assert.True(Ca.A3 == "Simi Valley", "The CivicAddress city is wrong");
            Assert.True(Ca.RD == "Stonebrook", "The CivicAddress street is wrong");
            Assert.True(Ca.STS == "Street", "The CivicAddress street suffix is wrong");
            Assert.True(Ca.HNO == "311", "The CivicAddress house number is wrong");
            Assert.True(Ca.PC == "93065", "The CivicAddress postal code is wrong");

            GeoPriv Gp = presence.GetFirstGeoGeoPriv();
            Assert.NotNull(Gp);
            Assert.NotNull(Gp.LocationInfo?.Circle);
            Circle Cir = Gp.LocationInfo.Circle;
            Assert.True(Cir.pos.Latitude == 34.247493, "The Circle latitude is wrong");
            Assert.True(Cir.pos.Longitude == -118.791885, "The Circle longitude is wrong");
            Assert.True(Cir.radius.Value == "50", "The Circle radius is wrong");

            Assert.True(presence.device.geopriv?.UsageRules != null, "The device usage rules is null");
            locPolicyType Lpt = presence.device.geopriv.UsageRules;
            Assert.True(Lpt.RetransmissionAllowed == "true", "The RetransmissionAllowed value is wrong");
            DateTime Dt = Lpt.RetentionExpiry;
            Assert.True(Dt.Year == 2016, "The RetentionExpiry year is wrong");
            Assert.True(Dt.Month == 12, "The RetentionExpiry month is wrong");
            Assert.True(Dt.Day == 10, "The RetentionExpiry day is wrong");

            Assert.True(presence.device.devicdID == "mac:00-0d-4b-30-72-df", "The deviceID is wrong");
            Dt = presence.device.timestamp;
            Assert.True(Dt.Year == 2015, "The timestamp year is wrong");
            Assert.True(Dt.Month == 7, "The timestamp month is wrong");
            Assert.True(Dt.Day == 9, "The timestamp day is wrong");

            Assert.True(presence.device.geopriv.locMethod == "802.11", "The geopriv method is wrong");
        }

        [Fact]
        public void DeviceCircleLocation()
        {
            Presence presence = DeserializePresenceObject("DeviceCircleLocation.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");
            GeoPriv Gp = presence.GetFirstGeoGeoPriv();
            Assert.NotNull(Gp);
            Assert.NotNull(Gp.LocationInfo?.Circle);
            Circle Cir = Gp.LocationInfo.Circle;
            Assert.True(Cir.pos.Latitude == 41.760537, "The Circle latitude is wrong");
            Assert.True(Cir.pos.Longitude == -88.261914, "The Circle longitude is wrong");
            Assert.True(Cir.radius.Value == "50", "The Circle radius is wrong");
        }

        [Fact]
        public void DeviceCircleWithConfidence()
        {
            Presence presence = DeserializePresenceObject("DeviceCircleWithConfidence.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");
            GeoPriv Gp = presence.GetFirstGeoGeoPriv();
            Assert.NotNull(Gp);
            Assert.NotNull(Gp.LocationInfo?.Circle);
            Circle Cir = Gp.LocationInfo.Circle;
            Assert.True(Cir.pos.Latitude == 41.760537, "The Circle latitude is wrong");
            Assert.True(Cir.pos.Longitude == -88.261914, "The Circle longitude is wrong");
            Assert.True(Cir.radius.Value == "50", "The Circle radius is wrong");

            Confidence Con = Gp.LocationInfo.confidence;
            Assert.True(Con != null, "The confidence element is null");
            Assert.True(Con.pdf == "normal", "The pdf attribute is wrong");
            Assert.True(Con.Value == "95", "The confidence value is wrong");
        }

        [Fact]
        public void DeviceCivicLocation()
        {
            Presence presence = DeserializePresenceObject("DeviceCivicLocation.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");

            CivicAddress Ca = presence.GetFirstCivicAddress(); ;
            Assert.True(Ca != null, "The civic address is null");
            Assert.True(Ca.country == "US", "The country is wrong");
            Assert.True(Ca.A1 == "IL", "The state is wrong");
            Assert.True(Ca.A2 == "KANE", "The county is wrong");
            Assert.True(Ca.A3 == "AURORA", "The city is wrong");
            Assert.True(Ca.PRD == "E", "The leading street direction is wrong");
            Assert.True(Ca.RD == "NEW YORK", "The street name is wrong");
            Assert.True(Ca.STS == "ST", "The street suffix is wrong");
            Assert.True(Ca.HNO == "2106", "The house number is wrong");
            Assert.True(Ca.PCN == "AURORA", "The postal community name is wrong");
        }

        [Fact]
        public void DevicePointLocation()
        {
            Presence presence = DeserializePresenceObject("DevicePointLocation.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");
            GeoPriv Gp = presence.GetFirstGeoGeoPriv();
            Assert.True(Gp != null, "The first GeoGeoPrive is null");
            Assert.True(Gp.LocationInfo?.Point?.pos != null, "The LocationInfo, Point or pos is null");
            Position pos = Gp.LocationInfo.Point.pos;
            Assert.True(pos.Latitude == 41.772035, "The latitude is wrong");
            Assert.True(pos.Longitude == -88.473291, "The longitude is wrong");
        }

        [Fact]
        public void PersonDeviceCivicCircleLocation()
        {
            Presence presence = DeserializePresenceObject("PersonDeviceCivicCircleLocation.xml");
            Assert.NotNull(presence);
            Assert.True(presence.device != null, "The device element is null");
            Assert.True(presence.person != null, "The person element is null");

            // Verify the person element.
            Circle Cir = presence.person.geopriv?.LocationInfo?.Circle;
            Assert.True(Cir != null, "The geopriv, LocationInfo or Circle element is null");
            Assert.True(Cir.pos != null, "The pos element of the Circle is null");
            Position pos = Cir.pos;
            Assert.True(pos.Latitude == 34.268544, "The Latitude is wrong");
            Assert.True(pos.Longitude == -118.666519, "The Longitude is wrong");
            Assert.True(Cir.radius.Value == "50", "The radius is wrong");
        }

        [Fact]
        public void DeviceDynamicOnly1()
        {
            Presence presence = DeserializePresenceObject("DeviceDynamicOnly1.xml");
            Assert.NotNull(presence);
            DynamicType Dt = presence.device?.geopriv?.LocationInfo?.Dynamic;
            VerifyDeviceDynamicOnly1(Dt);
        }

        [Fact]
        public void DeviceDynamicOnly1Serialization()
        {
            Presence pres1 = DeserializePresenceObject("DeviceDynamicOnly1.xml");
            Assert.NotNull(pres1);
            string strData = XmlHelper.SerializeToString(pres1);
            Presence pres2 = (Presence) XmlHelper.DeserializeFromString(strData, typeof(Presence));
            DynamicType Dt = pres2?.device?.geopriv?.LocationInfo?.Dynamic;
            VerifyDeviceDynamicOnly1(Dt);
        }

        private void VerifyDeviceDynamicOnly1(DynamicType Dt)
        {
            Assert.True(Dt != null, "The Dynamic element is null");
            Assert.True(Dt.orientation != null, "The orientation element is null");
            DirectionType Or = Dt.orientation;
            Assert.True(Or.Horizontal == -3, "The orientation Horizontal value is wrong");
            Assert.True(Or.Vertical == 12, "The orientation Vertical value is wrong");
            Assert.True(Dt.speedSpecified == true, "The speedSpecified value is wrong");
            Assert.True(Dt.speed == 24, "The speed is wrong");
            Assert.True(Dt.heading != null, "The heading element is null");
            Assert.True(Dt.heading.Horizontal == 278, "The heading Horizontal value is wrong");
            Assert.True(double.IsNaN(Dt.heading.Vertical) == true, "The heading Vertical value is wrong");
        }

        [Fact]
        public void DeviceCircleDynamic1()
        {
            Presence pres = DeserializePresenceObject("DeviceCircleDynamic1.xml");
            DynamicType Dt = pres.device?.geopriv?.LocationInfo?.Dynamic;
            VerifyDeviceCircleDynamic1(Dt);
        }

        [Fact]
        public void DeviceCircleDynamicSerialization()
        {
            Presence pres1 = DeserializePresenceObject("DeviceCircleDynamic1.xml");
            string strData = XmlHelper.SerializeToString(pres1);
            Presence pres2 = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            DynamicType Dt = pres2?.device?.geopriv?.LocationInfo?.Dynamic;
            VerifyDeviceCircleDynamic1(Dt);
        }

        private void VerifyDeviceCircleDynamic1(DynamicType Dt)
        {
            Assert.True(Dt != null, "Tye Dynamic element is null");
            Assert.True(Dt.orientation == null, "The orientation element is not null");
            Assert.True(Dt.heading == null, "The heading element is not null");
            Assert.True(Dt.speedSpecified == true, "The speedSpecified value is wrong");
            Assert.True(Dt.speed == 12, "The speed value is wrong");
        }

        // The PIDF-LO library does not support the civic address extension in this example.
        // This test case verifies that the library can deserialize the civic address object
        // that contains unknown extensions.
        [Fact]
        public void RFC6848CivicExtendedExample1()
        {
            Presence presence = DeserializePresenceObject("RFC6848CivicExtendedExample1.xml");
            Assert.NotNull(presence);
            CivicAddress Ca = presence.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The CivicAddress is null");
            Assert.True(presence.tuple.id == "sg89ae", "The tuple id is wrong");

            Assert.True(Ca.country == "UK", "The country is wrong");
            Assert.True(Ca.A1 == "Devon", "The state is wrong");
            Assert.True(Ca.A3 == "Monkokehampton", "The city is wrong");
            Assert.True(Ca.RD == "Deckport", "The street is wrong");
            Assert.True(Ca.STS == "Cross", "The street suffix is wrong");
        }

        [Fact]
        public void RFC6848Figure7Example()
        {
            Presence presence = DeserializePresenceObject("RFC6848Figure7Example.xml");
            Assert.NotNull(presence);
            CivicAddress Ca = presence.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The civic address is null");
            Assert.True(Ca.country == "US");
            Assert.True(Ca.A1 == "CA", "The state is wrong");
            Assert.True(Ca.A2 == "Sacramento", "The county is wrong");
            Assert.True(Ca.RD == "I5", "The street is wrong");
            Assert.True(Ca.MP == "248", "The mile post is wrong");
            Assert.True(Ca.PN == "22-109-689", "The pole number is wrong");
        }

        [Fact]
        public void RFC6848Figure8Example()
        {
            Presence presence = DeserializePresenceObject("RFC6848Figure8Example.xml");
            Assert.NotNull(presence);
            CivicAddress Ca = presence.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The civic address is null");
            Assert.True(Ca.STP == "Boulevard", "The street type prefix is wrong");
            Assert.True(Ca.HNP == "A", "The house number prefix is wrong");
        }

        // This test verifies the ability to handle unknown extensions to the CivicAddress
        // schema in the Any XmlElement array.
        [Fact]
        public void RFC6848Section3_4Example()
        {
            Presence presence = DeserializePresenceObject("RFC6848Section3.4Example.xml");
            Assert.NotNull(presence);
            CivicAddress Ca = presence.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The civic address is null");

            Assert.True(Ca.Any.Length == 6, "The number of extension points is wrong");
            Assert.True(Ca.Any[0].LocalName == "lamp", "The first local name is wrong");
            Assert.True(Ca.Any[0].InnerText == "2471", "The first inner text is wrong");

            Assert.True(Ca.Any[1].LocalName == "pylon", "The second local name is wrong");
            Assert.True(Ca.Any[1].InnerText == "AQ-374-4(c)", "The second inner text is wrong");

            Assert.True(Ca.Any[2].LocalName == "airport", "The third local name is wrong");
            Assert.True(Ca.Any[2].InnerText == "LAX", "The third inner text is wrong");

            Assert.True(Ca.Any[3].LocalName == "terminal", "The fourth local name is wrong");
            Assert.True(Ca.Any[3].InnerText == "Tom Bradley", "The fourth inner text is wrong");

            Assert.True(Ca.Any[4].LocalName == "concourse", "The fifth local name is wrong");
            Assert.True(Ca.Any[4].InnerText == "G", "The fifth inner text is wrong");

            Assert.True(Ca.Any[5].LocalName == "gate", "The sixth local name is wrong");
            Assert.True(Ca.Any[5].InnerText == "36B", "The sixth inner text is wrong");
        }

        // Verifies the ability to serialize and then deserialize unknown extensions
        [Fact]
        public void SerializeUnknownExtensions()
        {
            Presence presence = DeserializePresenceObject("RFC6848Section3.4Example.xml");
            Assert.NotNull(presence);
            string strPresence = XmlHelper.SerializeToString(presence);
            Assert.True(strPresence != null, "Serialization failed");
            Presence pres2 = (Presence) XmlHelper.DeserializeFromString(strPresence, typeof(Presence));
            Assert.NotNull(pres2);
            CivicAddress Ca = pres2.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The deserialization failed");

            Assert.True(Ca.Any.Length == 6, "The number of extension points is wrong");
            Assert.True(Ca.Any[0].LocalName == "lamp", "The first local name is wrong");
            Assert.True(Ca.Any[0].InnerText == "2471", "The first inner text is wrong");

            Assert.True(Ca.Any[1].LocalName == "pylon", "The second local name is wrong");
            Assert.True(Ca.Any[1].InnerText == "AQ-374-4(c)", "The second inner text is wrong");

            Assert.True(Ca.Any[2].LocalName == "airport", "The third local name is wrong");
            Assert.True(Ca.Any[2].InnerText == "LAX", "The third inner text is wrong");

            Assert.True(Ca.Any[3].LocalName == "terminal", "The fourth local name is wrong");
            Assert.True(Ca.Any[3].InnerText == "Tom Bradley", "The fourth inner text is wrong");

            Assert.True(Ca.Any[4].LocalName == "concourse", "The fifth local name is wrong");
            Assert.True(Ca.Any[4].InnerText == "G", "The fifth inner text is wrong");

            Assert.True(Ca.Any[5].LocalName == "gate", "The sixth local name is wrong");
            Assert.True(Ca.Any[5].InnerText == "36B", "The sixth inner text is wrong");
        }

        [Fact]
        public void RFC5941TupleArcBandLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleArcBandLocation.xml");
            Assert.NotNull(presence);
            ArcBand Ab = presence.tuple?.status?.geopriv?.LocationInfo?.ArcBand;
            Assert.NotNull(Ab);

            Position pos = Ab.pos;
            Assert.True(pos != null, "The ArcBand pos element is null");
            Assert.True(pos.Latitude == -43.5723, "The Latitude is wrong");
            Assert.True(pos.Longitude == 153.21760, "The Longitude is wrong");
            Assert.True(Ab.innerRadius.Value == 3594, "The innerRadius is wrong");
            Assert.True(Ab.innerRadius.uom == "urn:ogc:def:uom:EPSG::9001", "The innerRadius " +
                "uom is wrong");
            Assert.True(Ab.outerRadius.Value == 4148, "The outerRadius is wrong");
            Assert.True(Ab.outerRadius.uom == "urn:ogc:def:uom:EPSG::9001", "The outerRadius " +
                "uom is wrong");
            Assert.True(Ab.startAngle.Value == 20, "The startAngle is wrong");
            Assert.True(Ab.startAngle.uom == "urn:ogc:def:uom:EPSG::9102", "The startAngle uom is wrong");
            Assert.True(Ab.openingAngle.Value == 20, "The openingAngle is wrong");
            Assert.True(Ab.openingAngle.uom == "urn:ogc:def:uom:EPSG::9102", "The openingAngle uom is wrong");
        }

        [Fact]
        public void RFC5491TupleCircleLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleCircleLocation.xml");
            Assert.NotNull(presence);
            Circle Cir = presence.tuple?.status?.geopriv?.LocationInfo?.Circle;
            Assert.True(Cir != null, "The Circle element is null");
        }

        [Fact]
        public void RFC5491TupleCivicLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleCivicLocation.xml");
            Assert.NotNull(presence);
            CivicAddress Ca = presence.tuple?.status?.geopriv?.LocationInfo?.civicAddress;
            Assert.True(Ca != null, "The CivicAddress is null");
        }

        [Fact]
        public void RFC5491TupleEllipseLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleEllipseLocation.xml");
            Assert.NotNull(presence);
            Ellipse El = presence.tuple?.status?.geopriv?.LocationInfo?.Ellipse;
            Assert.True(El != null, "The Ellipse element is null");
            Assert.True(El.srsName == "urn:ogc:def:crs:EPSG::4326", "The Ellipse srsName is wrong");
            Position pos = El.pos;
            Assert.True(pos != null, "The Ellipe pos element is null");
            Assert.True(pos.Latitude == 42.5463, "The Latitude is wrong");
            Assert.True(pos.Longitude == -73.2512, "The Longitude is wrong");
            Assert.True(El.semiMajorAxis.Value == 1275, "The semiMajorAxis is wrong");
            Assert.True(El.semiMajorAxis.uom == "urn:ogc:def:uom:EPSG::9001", "The semiMajorAxis " +
                "uom is wrong");
            Assert.True(El.semiMinorAxis.Value == 670, "The semiMinorAxis is wrong");
            Assert.True(El.semiMinorAxis.uom == "urn:ogc:def:uom:EPSG::9001", "The semiMinorAxis " +
                "uom is wrong");
            Assert.True(El.orientation.Value == 43.2, "The orientation is wrong");
            Assert.True(El.orientation.uom == "urn:ogc:def:uom:EPSG::9102", "The orientation " +
                "uom is wrong");
        }

        [Fact]
        public void RFC5491TupleEllipsoidLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleEllipsoidLocation.xml");
            Assert.NotNull(presence);
            Ellipsoid El = presence.tuple?.status?.geopriv?.LocationInfo?.Ellipsoid;
            Assert.NotNull(El);
            Assert.True(El.srsName == "urn:ogc:def:crs:EPSG::4979", "The srsName is wrong");
            Assert.True(El.pos.Latitude == 42.5463, "The Latitude is wrong");
            Assert.True(El.pos.Longitude == -73.2512, "The Longitude is wrong");
            Assert.True(El.pos.Altitude == 26.3, "The Altitude is wrong");
            Assert.True(El.semiMajorAxis.Value == 7.7156, "The semiMajorAxis is wrong");
            Assert.True(El.semiMajorAxis.uom == "urn:ogc:def:uom:EPSG::9001", "The semiMajorAxis " +
                "uom is wrong");
            Assert.True(El.semiMinorAxis.Value == 3.31, "The semiMinorAxis is wrong");
            Assert.True(El.semiMinorAxis.uom == "urn:ogc:def:uom:EPSG::9001", "The semiMinorAxis " +
                "uom is wrong");
            Assert.True(El.verticalAxis.Value == 28.7, "The veriticalAxis is wrong");
            Assert.True(El.verticalAxis.uom == "urn:ogc:def:uom:EPSG::9001", "The verticalAxis " +
                "uom is wrong");
            Assert.True(El.orientation.Value == 90, "The orientation is wrong");
            Assert.True(El.orientation.uom == "urn:ogc:def:uom:EPSG::9102", "The orientation " +
                "uom is wrong");
        }

        // This test case is not valid because the Point element has a coordinates element
        // instead of a pos element and the coordinates in the coordinates element are
        // in degrees, minutes, seconds format instead of decimal degrees.
        //[Fact]
        //public void RFC5491TuplePointLocation()
        //{
        //    Presence presence = DeserializePresenceObject("RFC5491TuplePointLocation.xml");
        //    Assert.NotNull(presence);
        //    Point Pt = presence.tuple?.status?.geopriv?.LocationInfo?.Point;
        //    Assert.True(Pt != null, "The Point element is null");
        //}

        [Fact]
        public void RFC5491TuplePolygonCompactLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TuplePolygonCompactLocation.xml");
            Assert.NotNull(presence);
            Polygon Po = presence.tuple?.status?.geopriv?.LocationInfo?.Polygon;
            Assert.True(Po != null, "The Polygon element is null");
            Assert.True(string.IsNullOrEmpty(Po.exterior.LinearRing.posList) == false, 
                "The posList element is null");
            List<Position> pos = Po.exterior.LinearRing.ConvertCompactFormToStandardForm();
            Assert.True(pos != null, "The compact polygon form is not valid");
            Assert.True(ValidatePositions(pos, RFC5491PolygonPositions) == true,
                "The polygon points are wrong");
        }

        [Fact]
        public void RFC5491TuplePolygonLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TuplePolygonLocation.xml");
            Assert.NotNull(presence);
            Polygon Po = presence.tuple?.status?.geopriv?.LocationInfo?.Polygon;
            Assert.True(Po != null, "The Polygon element is null");
            Assert.True(Po.exterior.LinearRing.pos.Count == 7, "The number of pos elements is wrong");
            Assert.True(ValidatePositions(Po.exterior.LinearRing.pos, RFC5491PolygonPositions) == true,
                "The polygon points are wrong");
        }

        private static List<Position> RFC5491PolygonPositions = new List<Position>()
        { 
            new Position(43.311, -73.422),
            new Position(43.111, -73.322),
            new Position(43.111, -73.222),
            new Position(43.311, -73.122),
            new Position(43.411, -73.222),
            new Position(43.411, -73.322),
            new Position(43.311, -73.422)
        };

        [Fact]
        public void RFC5491TuplePrismLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TuplePrismLocation.xml");
            Assert.NotNull(presence);
            Prism prism = presence.tuple?.status?.geopriv?.LocationInfo?.Prism;
            Assert.True(prism != null, "The Prism element is null");
            LinearRing ring = prism.PrismBase?.Polygon?.exterior?.LinearRing;
            Assert.True(ring != null, "The LinearRing is null");
            List<Position> Pts = ring.ConvertCompactFormToStandardForm();
            Assert.True(Pts != null, "The compact posList element is not valid");
            Assert.True(ValidatePositions(Pts, PrismPositions) == true, "The prism base positions " +
                "are wrong");

            Assert.True(prism.height.Value == 2.4, "The Prism height is wrong");
            Assert.True(prism.height.uom == "urn:ogc:def:uom:EPSG::9001", "The Prism uom is wrong");
        }

        private static List<Position> PrismPositions = new List<Position>()
        {
            new Position(42.556844, -73.248157, 36.6),
            new Position(42.656844, -73.248157, 36.6),
            new Position(42.656844, -73.348157, 36.6),
            new Position(42.556844, -73.348157, 36.6),
            new Position(42.556844, -73.248157, 36.6)
        };

        private bool ValidatePositions(List<Position> list1, List<Position> list2)
        {
            if (list1.Count != list2.Count)
                return false;

            for (int i=0; i < list1.Count; i++)
            {
                if (double.IsNaN(list1[i].Altitude) == true && double.IsNaN(list2[i].Altitude) == true)
                {   // Both points don't has an Altitude
                    if (list1[i].Latitude != list2[i].Latitude || list1[i].Longitude != list2[i].Longitude)
                        return false;
        }
                else
                {
                    if (list1[i].Latitude != list2[i].Latitude || list1[i].Longitude != list2[i].Longitude ||
                        list1[i].Altitude != list2[i].Altitude)
                        return false;
                }
            }

            return true;
        }

        [Fact]
        public void RFC5491TupleSphereLocation()
        {
            Presence presence = DeserializePresenceObject("RFC5491TupleSphereLocation.xml");
            Assert.NotNull(presence);
            Sphere Sp = presence.tuple?.status?.geopriv?.LocationInfo?.Sphere;
            Assert.True(Sp != null, "The Sphere element is null");
            Position pos = Sp.pos;
            Assert.True(pos != null, "The Sphere's pos element is null");
            Assert.True(pos.Latitude == 42.5463, "The Latitude is wrong");
            Assert.True(pos.Longitude == -73.2512, "The Longitude is wrong");
            Assert.True(pos.Altitude == 26.3, "The Altitude is wrong");
            Assert.True(Sp.radius.Value == 850.24, "The radius is wrong");
            Assert.True(Sp.radius.uom == "urn:ogc:def:uom:EPSG::9001", "The radius uom is wrong");
            Assert.True(Sp.srsName == "urn:ogc:def:crs:EPSG::4979", "The srsName is wrong");
        }
    }
}