/////////////////////////////////////////////////////////////////////////////////////
//  File:   CapUnitTests.cs                                         25 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using CommonAlertingProtocol;
using Pidf;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class CapUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the XML test files for the Common Alerting Profile.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\AdditionalDataFiles\";

        /// <summary>
        /// CapExample1.xml file taken from the example1.xml file at http://docs.oasis-open.org/emergency/cap/v1.2/pr01/
        /// </summary>
        [Fact]
        public void CapExample1()
        {
            string strData = Utils.GetRawData(Path, "CapExample1.xml");
            alert Alert = (alert)XmlHelper.DeserializeFromString(strData, typeof(alert));
            Assert.NotNull(Alert);

            Assert.True(Alert.identifier == "43b080713727", "The alert.identifier is wrong");
            Assert.True(Alert.sender == "hsas@dhs.gov", "The alert.sender is wrong");

            DateTime Dt = DateTime.Parse("2003-04-02T14:39:01-05:00");
            Assert.True(Alert.sent.Equals(Dt) == true, "The alert.sent DateTime is wrong");
            Assert.True(Alert.sent.Year == 2003, "The sent year is wrong");
            Assert.True(Alert.sent.Month == 4, "The sent month is wrong");

            Assert.True(Alert.status == alertStatus.Actual, "The alert.status is wrong");
            Assert.True(Alert.msgType == alertMsgType.Alert, "The alert.msgType is wrong");
            Assert.True(Alert.scope == alertScope.Public, "The alert.scope is wrong");

            Assert.True(Alert.info != null && Alert.info.Count == 1, "The alert.info is null or empty");
            alertInfo Info = Alert.info[0];
            Assert.True(Info.category != null && Info.category.Count == 1, "The alertInfo.category " +
                "is null or empty");
            Assert.True(Info.category[0] == alertInfoCategory.Security, "The category is wrong");
            Assert.True(Info.@event == "Homeland Security Advisory System Update", "The event is wrong");
            Assert.True(Info.urgency == alertInfoUrgency.Immediate, "The urgency is wrong");
            Assert.True(Info.severity == alertInfoSeverity.Severe, "The severity is wrong");
            Assert.True(Info.certainty == alertInfoCertainty.Likely, "The certainty is wrong");
            Assert.True(Info.senderName == "U.S. Government, Department of Homeland Security",
                "The senderName is wrong");
            Assert.True(Info.headline == "Homeland Security Sets Code ORANGE", "The headline is wrong");
            Assert.True(Info.description.Contains("The Department of Homeland Security") == true,
                "The description is wrong");
            Assert.True(Info.instruction.Contains("A High Condition is declared when") == true,
                "The instruction is wrong");
            Assert.True(Info.web == "http://www.dhs.gov/dhspublic/display?theme=29", "The web is wrong");

            Assert.True(Info.parameter != null && Info.parameter.Count == 1, "The parameter is " +
                "null or empty");
            Assert.True(Info.parameter[0].valueName == "HSAS", "The valueName is wrong");
            Assert.True(Info.parameter[0].value == "ORANGE", "The value is wrong");

            Assert.True(Info.resource != null && Info.resource.Count == 1, "The resource is null " +
                "or empty");
            Assert.True(Info.resource[0].resourceDesc == "Image file (GIF)", "The resourceDesc is wrong");
            Assert.True(Info.resource[0].uri == "http://www.dhs.gov/dhspublic/getAdvisoryImage",
                "The resource uri is wrong");

            Assert.True(Info.area != null && Info.area.Count == 1, "The resource area is null or empty");
            Assert.True(Info.area[0].areaDesc == "U.S. nationwide and interests worldwide",
                "The areaDesc is wrong");
        }

        /// <summary>
        /// CapExample2.xml file taken from the example2.xml file at http://docs.oasis-open.org/emergency/cap/v1.2/pr01/
        /// This test case includes a polygon location in the area of the alert.
        /// </summary>
        [Fact]
        public void CapExample2()
        {
            string strData = Utils.GetRawData(Path, "CapExample2.xml");
            alert Alert = (alert) XmlHelper.DeserializeFromString(strData, typeof(alert));
            Assert.NotNull(Alert);

            Assert.True(Alert.info != null && Alert.info.Count == 1, "The alert.info is null or empty");
            alertInfo Info = Alert.info[0];
            Assert.True(Info.area != null && Info.area.Count == 1, "The area is null or empty");
            Assert.True(Info.area[0].polygon != null && Info.area[0].polygon.Count == 1,
                "The area polygon is null or empty");
            string str = "38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14";
            Assert.True(Info.area[0].polygon[0] == str, "The polygon string is wrong");
            List<Polygon> PolyList = Info.area[0].PidfPolygonList;
            Assert.True(PolyList != null && PolyList.Count == 1, "The PolyList is null or empty");
            List<Position> PosList = PolyList[0].exterior?.LinearRing.pos;
            Assert.True(PosList != null && PosList.Count == 5, "The PosList is null or empty");
            Assert.True(PosList[0].Latitude == 38.47, "The first latitude is wrong");
            Assert.True(PosList[0].Longitude == -120.14, "The first longitude is wrong");
            Assert.True(PosList[1].Latitude == 38.34, "The second latitude is wrong");
            Assert.True(PosList[1].Longitude == -119.95, "The second longitude is wrong");

            Assert.True(PosList[4].Latitude == PosList[0].Latitude, "The last latitude is wrong");
            Assert.True(PosList[4].Longitude == PosList[4].Longitude, "The last longitude is wrong");

            alertInfoArea Area2 = new alertInfoArea();
            Area2.PidfPolygonList = PolyList;
            Assert.True(Area2.polygon[0] == str, "The PidfPolygonList set operation failed");
        }

        /// <summary>
        /// CapExample3.xml file taken from the example3.xml file at http://docs.oasis-open.org/emergency/cap/v1.2/pr01/
        /// This test case includes a circle location in the area of the alert.
        /// </summary>
        [Fact]
        public void CapExample3()
        {
            string strData = Utils.GetRawData(Path, "CapExample3.xml");
            alert Alert = (alert)XmlHelper.DeserializeFromString(strData, typeof(alert));
            Assert.NotNull(Alert);

            Assert.True(Alert.info != null && Alert.info.Count == 1, "The alert.info is null or empty");
            alertInfo Info = Alert.info[0];
            Assert.True(Info.area != null && Info.area.Count == 1, "The area is null or empty");
            Assert.True(Info.area[0].circle != null && Info.area[0].circle.Count == 1,
                "The area circle is null or empty");
            string str = "32.9525,-115.5527 0";

            Assert.True(Info.area[0].circle[0] == str, "The circle string is wrong");
            List<Circle> CirList = Info.area[0].PidfCircleList;
            Assert.True(CirList != null && CirList.Count == 1, "The CirList is null or empty");
            Assert.True(CirList[0].pos.Latitude == 32.9525, "The circle latitude is wrong");
            Assert.True(CirList[0].pos.Longitude == -115.5527, "The circle longitude is wrong");
            Assert.True(CirList[0].radius.Value == "0", "The circle radius is wrong");

            alertInfoArea Area2 = new alertInfoArea();
            Area2.PidfCircleList = CirList;
            Assert.True(Area2.circle[0] == str, "The PidfCircleList set operation failed");
        }
    }
}
