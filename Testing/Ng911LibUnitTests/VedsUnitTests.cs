/////////////////////////////////////////////////////////////////////////////////////
//  File:   VedsUnitTests.cs                                        28 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using Veds;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class VedsUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test VEDS XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\VedsFiles\";

        /// <summary>
        /// The "VEDS 20180824.xml" test file is from the Example folder of the VEDS 3.1 IEPD package.
        /// </summary>
        [Fact]
        public void VEDS20180824()
        {
            string strData = Utils.GetRawData(Path, "VEDS 20180824.xml");
            Exception Ex;
            AutomatedCrashNotificationType Acn = XmlHelper.DeserializeFromString<
                AutomatedCrashNotificationType>(strData, out Ex);
            Assert.NotNull(Acn);
            Verify_VEDS20180824(Acn);
        }

        [Fact]
        public void VEDS20180824_Serialize()
        {
            string strData = Utils.GetRawData(Path, "VEDS 20180824.xml");
            Exception Ex;
            AutomatedCrashNotificationType Acn1 = XmlHelper.DeserializeFromString<
                AutomatedCrashNotificationType>(strData, out Ex);
            Assert.NotNull(Acn1);
            string str = XmlHelper.SerializeToString(Acn1);
            AutomatedCrashNotificationType Acn2 = XmlHelper.DeserializeFromString<
                AutomatedCrashNotificationType>(str, out Ex);
            Assert.NotNull(Acn2);
            Verify_VEDS20180824(Acn2);
        }

        private void Verify_VEDS20180824(AutomatedCrashNotificationType Acn)
        {
            Assert.True(Acn.DocumentDescriptionText.Value == "Vehicle accident 2018-01-04", 
                "The DocumentationDescriptionText is wrong");

            Assert.True(Acn.ContactActivity[0].ContactTelephoneNumber[0].FullTelephoneNumber.
                TelephoneNumberFullID[0].Value == "888-555-1212", "The telephone number is wrong");

            Assert.True(Acn.ContactInformation[0].id == "CXT1", "The second ContactActivity id is wrong");

            Assert.True(Acn.ContactInformation[0].ContactEmailID[0].Value == "jsponder@gmail.com",
                "The ContactEmailID is wrong");
            Assert.True(Acn.ContactInformation[0].ContactTelephoneNumber[0].FullTelephoneNumber.
                TelephoneNumberFullID[0].Value == "602-555-1212", "The FullTelephoneNumber is wrong");

            Assert.True(Acn.ContactInformation[0].ContactEntityDescriptionText.Value == "Janet Sponder",
                "The ContactEntityDescriptionText is wrong");


        }

        /// <summary>
        /// This test file is the same as "VEDS 20180824.xml" except that multiple telephone and
        /// email elements have been added to the ContactInformation element.
        /// </summary>
        [Fact]
        public void VEDS20180824MultPhoneEmail()
        {
            string strData = Utils.GetRawData(Path, "VEDS 20180824MultPhoneEmail.xml");
            Exception Ex;
            AutomatedCrashNotificationType Acn = XmlHelper.DeserializeFromString<
                AutomatedCrashNotificationType>(strData, out Ex);
            Assert.NotNull(Acn);
            Verify_VEDS20180824MultPhoneEmail(Acn);
        }

        private void Verify_VEDS20180824MultPhoneEmail(AutomatedCrashNotificationType Acn)
        {
            Assert.True(Acn.ContactInformation[0].ContactEmailID.Length == 2, "The ContactEmailID " +
                "Length is wrong");
            Assert.True(Acn.ContactInformation[0].ContactTelephoneNumber.Length == 2,
                "The ContactTelephoneNumber Length is wrong");
        }

        /// <summary>
        /// The "VEDS Example 2.xml" test file is from the Example folder of the VEDS 3.1 IEPD package.
        /// The file used here is a modified version of the original because the original contained
        /// invalid XML. Specifically, the original file contained whitespace in elements that get
        /// deserialized into enums -- This causes XmlSerializer.Deserialize() to throw an
        /// InvalidOperationException.
        /// </summary>
        [Fact]
        public void VEDSExample2()
        {
            string strData = Utils.GetRawData(Path, "VEDS Example 2.xml");
            AutomatedCrashNotificationType Acn = (AutomatedCrashNotificationType) XmlHelper.
                DeserializeFromString(strData, typeof(AutomatedCrashNotificationType));
            Assert.NotNull(Acn);

        }

        /// <summary>
        /// The "VEDS Example RFC 8148.xml" test file is from the Example folder of the VEDS 3.1 IEPD 
        /// package. The file used here is a modified version of the original because the original contained
        /// invalid XML. Specifically, the original file contained whitespace in elements that get
        /// deserialized into enums -- This causes XmlSerializer.Deserialize() to throw an
        /// InvalidOperationException.
        /// </summary>
        [Fact]
        public void VEDSExampleRFC8148()
        {
            string strData = Utils.GetRawData(Path, "VEDS Example RFC 8148.xml");
            Exception Ex;
            AutomatedCrashNotificationType Acn = XmlHelper.DeserializeFromString<
                AutomatedCrashNotificationType>(strData, out Ex);
            Assert.NotNull(Acn);

        }

    }
}
