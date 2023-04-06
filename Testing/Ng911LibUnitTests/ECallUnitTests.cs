/////////////////////////////////////////////////////////////////////////////////////
//  File:   ECallUnitTests.cs                                       7 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using ECall;
using Ng911Lib.Utilities;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class ECallUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test VEDS XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\VedsFiles\";

        [Fact]
        public void Rfc8147_9_1_1_3()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.1.3.xml");
            Exception Ex;
            controlType Ct = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct);
            Verify_Rfc8147_9_1_1_3(Ct);
        }

        [Fact]
        public void Rfc8147_9_1_1_3Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.1.3.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8147_9_1_1_3(Ct2);
        }

        private void Verify_Rfc8147_9_1_1_3(controlType Ct)
        {
            Assert.True(Ct.ack != null, "The ack element is null");
            Assert.True(Ct.ack.received == true, "The ack.received is wrong");
            Assert.True(Ct.ack.@ref == "1234567890@atlanta.example.com", "The ack.ref is wrong");
        }

        [Fact]
        public void Rfc8147_9_1_2_2()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.2.2.xml");
            Exception Ex;
            controlType Ct = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct);
            Verify_Rfc8147_9_1_2_2(Ct);
        }

        [Fact]
        public void Rfc8147_9_1_2_2Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.2.2.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8147_9_1_2_2(Ct2);
        }

        private void Verify_Rfc8147_9_1_2_2(controlType Ct)
        {
            Assert.True(Ct.capabilities.request[0].action == "send-data", "The action is wrong");
            Assert.True(Ct.capabilities.request[0].supportedvalues == "eCall.MSD", "The supportedvalues " +
                "is wrong");
        }

        [Fact]
        public void Rfc8147_9_1_3_3()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.3.3.xml");
            Exception Ex;
            controlType Ct = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct);
            Verify_Rfc8147_9_1_3_3(Ct);
        }

        [Fact]
        public void Rfc8147_9_1_3_3Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc8147-9.1.3.3.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8147_9_1_3_3(Ct2);
        }

        private void Verify_Rfc8147_9_1_3_3(controlType Ct)
        {
            Assert.True(Ct.request[0].action == "send-data", "The request.action is wrong");
            Assert.True(Ct.request[0].datatype == "eCall.MSD", "The datatype is wrong");
        }

        [Fact]
        public void Rfc8148_9_2()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.2.xml");
            Exception Ex;
            controlType Ct = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct);
            Verify_Rfc8148_9_2(Ct);
        }

        [Fact]
        public void Rfc8148_9_2Serialize()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.2.xml");
            Exception Ex;
            controlType Ct1= XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8148_9_2(Ct2);
        }

        private void Verify_Rfc8148_9_2(controlType Ct)
        {
            Assert.True(Ct.request[0].action == "send-data", "request[0].action is wrong");
            Assert.True(Ct.request[0].datatype == "VEDS", "request[0].datatype is wrong");
            Assert.True(Ct.request[1].action == "lamp", "request[1].action is wrong");
            Assert.True(Ct.request[1].elementid == "hazard", "request[1].elementid is wrong");
            Assert.True(Ct.request[1].requestedstate == "flash", "request[1].requestedstate is wrong");
            Assert.True(Ct.request[1].persistence == "PT1H", "request[1].persistence is wrong");
            Assert.True(Ct.request[2].action == "msg-static", "request[2].action is wrong");
            Assert.True(Ct.request[2].intid == 1, "The request[2].intid is wrong");
            Assert.True(Ct.request[3].action == "msg-dynamic", "request[3].action is wrong");
            Assert.True(Ct.request[3].text[0].Value == "Remain calm. Help is on the way.",
                "request[3].text[0].Value is wrong");
        }

        [Fact]
        public void Rfc8148_9_3_1()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.3.1.xml");
            Exception Ex;
            controlType Ct = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct);
            Verify_Rfc8148_9_3_1(Ct);
        }

        [Fact]
        public void Rfc8148_9_3_1Serialize()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.3.1.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8148_9_3_1(Ct2);
        }

        private void Verify_Rfc8148_9_3_1(controlType Ct)
        {
            Assert.True(Ct.ack.@ref == "1234567890@atlanta.example.com", "ack.ref is wrong");
            Assert.True(Ct.ack.actionResult[0].action == "msg-dynamic", "ack.actionResult[0].action is wrong");
            Assert.True(Ct.ack.actionResult[0].success == true, "ack.actionResult[0].success is wrong");
            Assert.True(Ct.ack.actionResult[1].action == "lamp", "ack.actionResult[1].action is wrong");
            Assert.True(Ct.ack.actionResult[1].success == false, "ack.actionResult[1].success is wrong");
            Assert.True(Ct.ack.actionResult[1].reason == "unable", "ack.actionResult[1].reason is wrong");
            Assert.True(Ct.ack.actionResult[1].details == "The requested lamp is inoperable",
                "ack.actionResult[1].details is wrong");
        }

        [Fact]
        public void Rfc8148_9_4_1()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.4.1.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            Verify_Rfc8148_9_4_1(Ct1);
        }

        [Fact]
        public void Rfc8148_9_4_1Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc8148-9.4.1.xml");
            Exception Ex;
            controlType Ct1 = XmlHelper.DeserializeFromString<controlType>(strData, out Ex);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            controlType Ct2 = XmlHelper.DeserializeFromString<controlType>(str, out Ex);
            Verify_Rfc8148_9_4_1(Ct2);
        }

        private void Verify_Rfc8148_9_4_1(controlType Ct)
        {
            Assert.True(Ct.capabilities.request[0].action == "send-data", "request[0].action is wrong");
            Assert.True(Ct.capabilities.request[0].supportedvalues == "VEDS", "request[0].supportvalues is wrong");
            Assert.True(Ct.capabilities.request[1].action == "lamp", "request[1].action is wrong");
            Assert.True(Ct.capabilities.request[1].supportedvalues == "head;interior;fog-front;fog-rear;brake;position-front;position-rear;turn-left;turn-right;hazard",
                "request[1].supportedvalues is wrong");
            Assert.True(Ct.capabilities.request[2].action == "msg-static", "request[2].action is wrong");
            Assert.True(Ct.capabilities.request[2].intidSpecified == true, "request[2].intidspecified is wrong");
            Assert.True(Ct.capabilities.request[2].intid == 3, "request[2].intid is wrong");
            Assert.True(Ct.capabilities.request[3].action == "msg-dynamic", "request[3].action is wrong");
            Assert.True(Ct.capabilities.request[4].action == "honk", "request[4].action is wrong");
            Assert.True(Ct.capabilities.request[5].action == "enable-camera", "request[5].action is wrong");
            Assert.True(Ct.capabilities.request[5].supportedvalues == "backup; interior",
                "request[5].supportedvalues is wrong");
            Assert.True(Ct.capabilities.request[6].action == "door-lock", "request[6].action is wrong");
        }
    }
}
