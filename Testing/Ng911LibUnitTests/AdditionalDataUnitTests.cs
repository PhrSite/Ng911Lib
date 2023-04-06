/////////////////////////////////////////////////////////////////////////////////////
//  File:   AdditionalDataUnitTests.cs                              2 Dec 22 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using AdditionalData;
using Pidf;
using System.Xml;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class AdditionalDataUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test additional data XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\AdditionalDataFiles\";

        [Fact]
        public void ServiceInfo1()
        {
            string strData = Utils.GetRawData(Path, "ServiceInfo1.xml");
            ServiceInfoType Si = (ServiceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ServiceInfoType));
            VerifyServiceInfo1(Si);
        }

        private void VerifyServiceInfo1(ServiceInfoType Si)
        {
            Assert.NotNull(Si);
            Assert.True(Si.DataProviderReference == "2468.IBOC.MLTS.1359@example.org",
                "The DataProviderReference is wrong");
            Assert.True(Si.ServiceEnvironment == "Unknown", "The ServiceEnvironment is wrong");
            Assert.True(Si.ServiceType != null && Si.ServiceType.Length == 1, "The ServiceType " +
                "is null or empty");
            Assert.True(Si.ServiceType[0] == "wireless", "The ServiceType is wrong");
            Assert.True(Si.ServiceMobility == "Mobile", "The ServiceMobility is wrong");
        }

        [Fact]
        public void ServiceInfo1_ManDeser()
        {
            string strData = Utils.GetRawData(Path, "ServiceInfo1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData);
            Assert.NotNull(Xn);
            ServiceInfoType Si = new ServiceInfoType(Xn);
            VerifyServiceInfo1(Si);
        }

        [Fact]
        public void ServiceInfo1Serialization()
        {
            string strData = Utils.GetRawData(Path, "ServiceInfo1.xml");
            ServiceInfoType Si1 = (ServiceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ServiceInfoType));
            strData = XmlHelper.SerializeToString(Si1);
            ServiceInfoType Si2 = (ServiceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ServiceInfoType));
            Assert.True(Si1.DataProviderReference == Si2.DataProviderReference,
                "The DataProviderReference does not match");
            Assert.True(Si1.ServiceEnvironment == Si2.ServiceEnvironment, "The ServiceEnvironment " +
                "does not match");
            Assert.True(Si1.ServiceType[0] == Si2.ServiceType[0], "The ServiceType does not match");
            Assert.True(Si1.ServiceMobility == Si2.ServiceMobility, "The ServiceMobility does not match");
        }

        [Fact]
        public void SubscriberInfo1()
        {
            string strData = Utils.GetRawData(Path, "SubInfo1.xml");
            SubscriberInfoType Si = (SubscriberInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(SubscriberInfoType));
            VerifySubscriberInfo1(Si);
        }

        private void VerifySubscriberInfo1(SubscriberInfoType Si)
        {
            Assert.NotNull(Si);
            Assert.True(Si.privacyRequested == false, "The privacyRequested is wrong");
            Assert.True(Si.DataProviderReference == "FEABFECD901@example.org",
                "The DataProviderReference is wrong");
            Assert.True(Si.SubscriberData != null && Si.SubscriberData.Length == 1,
                "The SubscriberData is null or empty");

            vcardType Vc = Si.SubscriberData[0];
            Assert.True(Vc.fn != null && Vc.fn.Length == 1);
            Assert.True(Vc.fn[0].text == "John Smith", "The full name is wrong");

            Assert.True(Vc.FirstName == "John", "The FirstName is wrong");
            Assert.True(Vc.LastName == "Smith", "The LastName is wrong");
            Assert.True(Vc.State == "IL", "The state is wrong");
            Assert.True(Vc.Street == "500 West St.", "The Street is wrong");
            Assert.True(Vc.City == "AURORA", "The City is wrong");
            Assert.True(Vc.ZipCode == "12345", "The ZipCode is wrong");
            Assert.True(Vc.Country == "USA", "The Country is wrong");
            Assert.True(Vc.TelephoneNumber == "tel:+1 630 681 5006", "The TelephoneNumber is wrong");
            Assert.True(Vc.EMail == "JohnSmith@gmail.com", "The EMail is wrong");
        }

        [Fact]
        public void SubscriberInfo1_ManDeser()
        {
            string strData = Utils.GetRawData(Path, "SubInfo1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData); ;
            Assert.NotNull(Xn);
            SubscriberInfoType Si = new SubscriberInfoType(Xn);
            Assert.NotNull(Si);
            VerifySubscriberInfo1(Si);
        }

        [Fact]
        public void SubscriberInfo1Serialization()
        {
            string strData = Utils.GetRawData(Path, "SubInfo1.xml");
            SubscriberInfoType Si1 = (SubscriberInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(SubscriberInfoType));
            Assert.NotNull(Si1);
            strData = XmlHelper.SerializeToString(Si1);
            SubscriberInfoType Si2 = (SubscriberInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(SubscriberInfoType));
            Assert.NotNull(Si2);

            Assert.True(Si1.privacyRequested == Si2.privacyRequested, "privacyRequested mismatch");
            Assert.True(Si1.DataProviderReference == Si2.DataProviderReference,
                "DataProviderReference mismatch");

            vcardType Vc1 = Si1.SubscriberData[0];
            vcardType Vc2 = Si2.SubscriberData[0];
            Assert.NotNull(Vc1);
            Assert.NotNull(Vc2);

            Assert.True(Vc1.FirstName == Vc2.FirstName, "FirstName mismatch");
            Assert.True(Vc1.LastName == Vc2.LastName, "LastName mismatch");
            Assert.True(Vc1.State == Vc2.State, "State mismatch");
            Assert.True(Vc1.Street == Vc2.Street, "Street mismatch");
            Assert.True(Vc1.City == Vc2.City, "City mismatch");
            Assert.True(Vc1.ZipCode == Vc2.ZipCode, "ZipCode mismatch");
            Assert.True(Vc1.Country == Vc2.Country, "Country match");
            Assert.True(Vc1.TelephoneNumber == Vc2.TelephoneNumber, "TelephoneNumber mismatch");
            Assert.True(Vc1.EMail == Vc2.EMail, "EMail mismatch");
        }

        [Fact]
        public void DeviceInfo1()
        {
            string strData = Utils.GetRawData(Path, "DeviceInfo1.xml");
            DeviceInfoType Di = (DeviceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(DeviceInfoType));
            VerifyDeviceInfo1(Di);
        }

        private void VerifyDeviceInfo1(DeviceInfoType Di)
        {
            Assert.NotNull(Di);
            Assert.True(Di.DataProviderReference == "d4b3072df.201409182208075@example.org",
                "The DataProviderReference is wrong");
            Assert.True(Di.DeviceClassification == "fixed", "The DeviceClassification is wrong");
            Assert.True(Di.DeviceMfgr == "Nokia", "The DeviceMfgr is wrong");
            Assert.True(Di.DeviceModelNr == "Lumia 800", "The DeviceModelNr is wrong");
            Assert.True(Di.UniqueDeviceID != null && Di.UniqueDeviceID.Length == 1, "The " +
                "UniqueDeviceID is null or empty");
            Assert.True(Di.UniqueDeviceID[0].TypeOfDeviceID == "IMEI", "The TypeOfDeviceID is wrong");
            Assert.True(Di.UniqueDeviceID[0].Value == "35788104 ", "The UniqueDeviceID is wrong");
        }

        [Fact]
        public void DeviceInfo1_ManDeser()
        {
            string strData = Utils.GetRawData(Path, "DeviceInfo1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData);
            DeviceInfoType Di = new DeviceInfoType(Xn);
            VerifyDeviceInfo1(Di);
        }

        [Fact]
        public void DeviceInfo1Serialization()
        {
            string strData = Utils.GetRawData(Path, "DeviceInfo1.xml");
            DeviceInfoType Di1 = (DeviceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(DeviceInfoType));
            Assert.NotNull(Di1);
            strData = XmlHelper.SerializeToString(Di1);
            DeviceInfoType Di2 = (DeviceInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(DeviceInfoType));

            Assert.True(Di1.DataProviderReference == Di2.DataProviderReference,
                "DataProviderReference mismatch");
            Assert.True(Di1.DeviceClassification == Di2.DeviceClassification,
                "DeviceClassification mismatch");
            Assert.True(Di1.DeviceMfgr == Di2.DeviceMfgr, "DeviceMfgr mismatch");
            Assert.True(Di1.DeviceModelNr == Di2.DeviceModelNr, "DeviceModelNr mismatch");
            Assert.True(Di1.UniqueDeviceID != null && Di1.UniqueDeviceID.Length == 1, "The " +
                "UniqueDeviceID is null or empty for Di1");
            Assert.True(Di2.UniqueDeviceID != null && Di2.UniqueDeviceID.Length == 1, "The " +
                "UniqueDeviceID is null or empty for Di2");
            Assert.True(Di1.UniqueDeviceID[0].TypeOfDeviceID == Di2.UniqueDeviceID[0].TypeOfDeviceID,
                "TypeOfDeviceID mismatch");
            Assert.True(Di1.UniqueDeviceID[0].Value == Di2.UniqueDeviceID[0].Value,
                "UniqueDeviceID mismatch");
        }

        [Fact]
        public void Comment1()
        {
            string strData = Utils.GetRawData(Path, "Comment1.xml");
            CommentType Co = (CommentType)XmlHelper.DeserializeFromString(strData, typeof(CommentType));
            VerifyComment1(Co);
        }

        private void VerifyComment1(CommentType Co)
        {
            Assert.NotNull(Co);
            Assert.True(Co.DataProviderReference == "string0987654321@example.org",
                "The DataProviderReference is wrong");
            Assert.True(Co.Comment != null && Co.Comment.Length == 1, "The Comment is null or empty");
            Assert.True(Co.Comment[0].lang == "en", "The language is wrong");
            Assert.True(Co.Comment[0].Value == "This is an example of a comment.",
                "The Comment value is wrong");
        }

        [Fact]
        public void Comment1_ManDeser()
        {
            string strData = Utils.GetRawData(Path, "Comment1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData);
            CommentType Co = new CommentType(Xn);
            VerifyComment1(Co);
        }

        [Fact]
        public void Comment1Serialization()
        {
            string strData = Utils.GetRawData(Path, "Comment1.xml");
            CommentType Co1 = (CommentType)XmlHelper.DeserializeFromString(strData, typeof(CommentType));
            Assert.NotNull(Co1);
            strData = XmlHelper.SerializeToString(Co1);
            CommentType Co2 = (CommentType)XmlHelper.DeserializeFromString(strData, typeof(CommentType));
            Assert.NotNull(Co2);
            Assert.True(Co1.DataProviderReference == Co2.DataProviderReference, "DataProviderReference 0" +
                "mismatch");
            Assert.True(Co2.Comment != null && Co2.Comment.Length == 1, "The Comment is null or empty");
            Assert.True(Co1.Comment[0].lang == Co2.Comment[0].lang, "Language mismatch");
            Assert.True(Co1.Comment[0].Value == Co2.Comment[0].Value, "Comment Value mismatch");
        }

        [Fact]
        public void ProvInfo1()
        {
            string strData = Utils.GetRawData(Path, "ProvInfo1.xml");
            ProviderInfoType Pi = (ProviderInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ProviderInfoType));
            VerifyProviderInfo1(Pi);
        }

        private void VerifyProviderInfo1(ProviderInfoType Pi)
        {
            Assert.NotNull(Pi);
            Assert.True(Pi.DataProviderReference == "string0987654321@example.org",
                "The DataProviderReference is wrong");
            Assert.True(Pi.DataProviderString == "Smith Telecom Inc.", "The DataProviderString is wrong");
            Assert.True(Pi.ProviderID == "urn:nena:companyid:ID123", "The ProviderID is wroing");
            Assert.True(Pi.ProviderIDSeries == "NENA", "The ProviderIDSeries is wrong");
            Assert.True(Pi.TypeOfProvider == "Telecom Provider", "The TypeOfProvider is wrong");
            Assert.True(Pi.ContactURI == "tel:+1-201-555-0123", "The ContactURI is wrong");
            Assert.True(Pi.Language != null && Pi.Language.Length == 1, "The Language is null or empty");
            Assert.True(Pi.Language[0] == "en", "The Language is wrong");

            Assert.True(Pi.DataProviderContact != null && Pi.DataProviderContact.Length == 1);
            vcardType Vc = Pi.DataProviderContact[0];
            Assert.True(Vc.FirstName == "John", "The FirstName is wrong");
            Assert.True(Vc.LastName == "Smith", "The LastName is wrong");
            Assert.True(Vc.Country == "USA", "The Country is wrong");
            Assert.True(Vc.State == "NY", "The State is wrong");
            Assert.True(Vc.City == "New York", "The City is wrong");
            Assert.True(Vc.Street == "123 First St.", "The Street is wrong");
            Assert.True(Vc.ZipCode == "12345", "The ZipCode is wrong");
            Assert.True(Vc.TelephoneNumber == "tel:+1 800-123-4567", "The TelephoneNumber is wrong");
            Assert.True(Vc.EMail == "John.Smith@SmithTelecom.com", "The EMail is wrong");
        }

        [Fact]
        public void ProvInfo1_ManDeser()
        {
            string strData = Utils.GetRawData(Path, "ProvInfo1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData);
            ProviderInfoType Pi = new ProviderInfoType(Xn);
            VerifyProviderInfo1(Pi);
        }

        [Fact]
        public void ProvInfo1Serialization()
        {
            string strData = Utils.GetRawData(Path, "ProvInfo1.xml");
            ProviderInfoType Pi1 = (ProviderInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ProviderInfoType));
            Assert.NotNull(Pi1);
            strData = XmlHelper.SerializeToString(Pi1);
            ProviderInfoType Pi2 = (ProviderInfoType)XmlHelper.DeserializeFromString(strData,
                typeof(ProviderInfoType));
            Assert.NotNull(Pi2); ;
            Assert.True(Pi1.DataProviderReference == Pi2.DataProviderReference,
                "DataProviderReference mismatch");
            Assert.True(Pi1.DataProviderString == Pi2.DataProviderString, "DataProviderString mismatch");
            Assert.True(Pi1.ProviderID == Pi2.ProviderID, "ProviderID mismatch");
            Assert.True(Pi1.ProviderIDSeries == Pi2.ProviderIDSeries, "ProviderIDSeries mismatch");
            Assert.True(Pi1.TypeOfProvider == Pi2.TypeOfProvider, "TypeOfProvider mismatch");
            Assert.True(Pi1.ContactURI == Pi2.ContactURI, "ContactURI mismatch");
            Assert.True(Pi2.Language != null && Pi2.Language.Length == 1, "The Language is null or empty");
            Assert.True(Pi1.Language[0] == Pi2.Language[0], "Language mismatch");
            Assert.True(Pi2.DataProviderContact != null && Pi2.DataProviderContact.Length == 1);
            vcardType Vc1 = Pi1.DataProviderContact[0];
            vcardType Vc2 = Pi2.DataProviderContact[0];

            Assert.True(Vc1.FirstName == Vc2.FirstName, "FirstName mismatch");
            Assert.True(Vc1.LastName == Vc2.LastName, "LastName mismatch");
            Assert.True(Vc1.Country == Vc2.Country, "Country mismatch");
            Assert.True(Vc1.State == Vc2.State, "State mismatch");
            Assert.True(Vc1.City == Vc2.City, "City mismatch");
            Assert.True(Vc1.Street == Vc2.Street, "Street mismatch");
            Assert.True(Vc1.ZipCode == Vc2.ZipCode, "ZipCode mismatch");
            Assert.True(Vc1.TelephoneNumber == Vc2.TelephoneNumber, "TelephoneNumber mismatch");
            Assert.True(Vc1.EMail == Vc2.EMail, "EMail mismatch");
        }

        [Fact]
        public void PidfLoProvidedByByValue()
        {
            string strData = Utils.GetRawData(Path, "PidfLoProvidedByByValue.xml");
            Presence pres = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            Assert.NotNull(pres);
            GeoPriv Gp = pres.device?.geopriv;
            Assert.NotNull(Gp?.ProvidedBy);
            ProvidedByType Pb = Gp.ProvidedBy;
            Assert.True(Pb.EmergencyCallDataValue != null, "The EmergencyCallDataValue is null");
            EmergencyCallDataValueType Ecd = Pb.EmergencyCallDataValue;

            Assert.True(Ecd.EmergencyCallDataComment != null && Ecd.EmergencyCallDataComment.Length == 1, 
                "The Comment element is null");
            CommentType Ct = Ecd.EmergencyCallDataComment[0];
            Assert.True(Ct.DataProviderReference == "string0987654321@example.org", 
                "The Comment DataProviderReference is wrong");
            
            Assert.True(Ct.Comment != null && Ct.Comment.Length == 1, "The Comment is null or empty");
            Assert.True(Ct.Comment[0].Value == "This is an example of a comment.", "The Comment is wrong");
            Assert.True(Ct.Comment[0].lang == "en", "The Comment language is wrong");

            Assert.True(Ecd.EmergencyCallDataDeviceInfo != null && Ecd.EmergencyCallDataDeviceInfo.
                Length == 1, "The DeviceInfo is null or empty");
            DeviceInfoType Di = Ecd.EmergencyCallDataDeviceInfo[0];
            Assert.True(Di.DataProviderReference == "d4b3072df.201409182208075@example.org",
                "The Device DataProviderReference is wrong");
            Assert.True(Di.DeviceClassification == "fixed", "The DeviceClassification is wrong");
            Assert.True(Di.DeviceMfgr == "Nokia", "The DeficeMfgr is wrong");
            Assert.True(Di.DeviceModelNr == "Lumia 800", "The DeviceModelNr is wrong");
            Assert.True(Di.UniqueDeviceID != null && Di.UniqueDeviceID.Length == 1, 
                "The UniqueDeviceID is null or empty");
            Assert.True(Di.UniqueDeviceID[0].Value == "35788104", "The UniqueDeviceID is wrong");
            Assert.True(Di.UniqueDeviceID[0].TypeOfDeviceID == "IMEI", "The TypeOfDeviceID is wrong");

            Assert.True(Ecd.EmergencyCallDataProviderInfo != null && Ecd.EmergencyCallDataProviderInfo.
                Length == 1, "The ProviderInfo is null or empty");
            ProviderInfoType Pi = Ecd.EmergencyCallDataProviderInfo[0];
            Assert.True(Pi.DataProviderReference == "string0987654321@example.org", 
                "The DataProviderReference is wrong");
            Assert.True(Pi.ContactURI == "tel:+1-201-555-0123", "The ContactURI is wrong");
            Assert.True(Pi.DataProviderContact != null && Pi.DataProviderContact.Length == 1,
                "The DataProviderContact is null or empty");
            vcardType PiVc = Pi.DataProviderContact[0];
            Assert.True(PiVc.LastName == "Smith");

            Assert.True(Ecd.EmergencyCallDataSubscriberInfo != null && Ecd.EmergencyCallDataSubscriberInfo.
                Length == 1, "The SubscriberInfo is null or empty");
            SubscriberInfoType Si = Ecd.EmergencyCallDataSubscriberInfo[0];
            Assert.True(Si.DataProviderReference == "FEABFECD901@example.org", "The SubscriberInfo" +
                "DataProviderReference is wrong");
            Assert.True(Si.SubscriberData != null && Si.SubscriberData.Length == 1);
            vcardType SubVc = Si.SubscriberData[0];
            Assert.True(SubVc.LastName == "Jones", "The SubscriberInfo LastName is wrong");

            Assert.True(Ecd.EmergencyCallDataServiceInfo != null && Ecd.EmergencyCallDataServiceInfo.
                Length == 1, "The ServiceInfo is null or empty");
            ServiceInfoType SerInfo = Ecd.EmergencyCallDataServiceInfo[0];
            Assert.True(SerInfo.DataProviderReference == "2468.IBOC.MLTS.1359@example.org",
                "The ServiceInfo DataProviderReference is wrong");
            Assert.True(SerInfo.ServiceEnvironment == "Business", "The ServiceEnvironment is wrong");
        }

        [Fact]
        public void PidfLoProvidedByByValueSerialization()
        {
            string strData = Utils.GetRawData(Path, "PidfLoProvidedByByValue.xml");
            Presence pres1 = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            EmergencyCallDataValueType Ecd1 = pres1.device.geopriv?.ProvidedBy?.EmergencyCallDataValue;

            strData = XmlHelper.SerializeToString(pres1);
            Presence pres2 = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            Assert.NotNull(pres2);
            EmergencyCallDataValueType Ecd2 = pres2.device?.geopriv?.ProvidedBy?.EmergencyCallDataValue;
            Assert.True(Ecd2 != null, "Ecd2 is null");

            CommentType Ct1 = Ecd1.EmergencyCallDataComment?[0];
            CommentType Ct2 = Ecd2.EmergencyCallDataComment?[0];
            Assert.True(Ct2 != null, "The Comment for Ct2 is null or empty");
            Assert.True(Ct1.DataProviderReference == Ct2.DataProviderReference,
                "Comment DataProviderReference mismatch");
            Assert.True(Ct2.Comment != null && Ct2.Comment.Length == 1, 
                "The Ct2 CommentSubType is null or empty");
            Assert.True(Ct1.Comment[0].Value == Ct2.Comment[0].Value, "Comment Value mismatch");

            DeviceInfoType Di1 = Ecd1.EmergencyCallDataDeviceInfo[0];
            Assert.True(Ecd2.EmergencyCallDataDeviceInfo != null && Ecd2.EmergencyCallDataDeviceInfo.Length
                == 1, "The Ecd2 EmergencyDataDeviceInfo is null or empty");
            DeviceInfoType Di2 = Ecd2.EmergencyCallDataDeviceInfo[0];
            Assert.True(Di1.UniqueDeviceID[0].Value == Di2.UniqueDeviceID[0].Value, 
                "UniqueDeviceID mismatch");

            ProviderInfoType Pt1 = Ecd1.EmergencyCallDataProviderInfo?[0];
            Assert.True(Ecd2.EmergencyCallDataProviderInfo != null &&
                Ecd2.EmergencyCallDataProviderInfo.Length == 1, "The Ecd2 EmergencyCallDataProviderInfo" +
                "is null or empty");
            ProviderInfoType Pt2 = Ecd2.EmergencyCallDataProviderInfo[0];
            Assert.True(Pt2.DataProviderString == Pt2.DataProviderString, "DataProviderString mismatch");

            ServiceInfoType Si1 = Ecd1.EmergencyCallDataServiceInfo[0];
            Assert.True(Ecd2.EmergencyCallDataServiceInfo != null && Ecd2.EmergencyCallDataServiceInfo.Length
                == 1, "The Ecd2 EmergencyCallDataServiceInfo is null or empty");
            ServiceInfoType Si2 = Ecd2.EmergencyCallDataServiceInfo[0];
            Assert.True(Si1.ServiceType[0] == Si2.ServiceType[0], "ServiceType mismatch");

            SubscriberInfoType Sub1 = Ecd1.EmergencyCallDataSubscriberInfo[0];
            Assert.True(Ecd2.EmergencyCallDataSubscriberInfo != null && Ecd2.EmergencyCallDataSubscriberInfo.
                Length == 1, "The Ecd2 EmergencyCallDataSubscriber is null or empty");
            SubscriberInfoType Sub2 = Ecd2.EmergencyCallDataSubscriberInfo[0];
            Assert.True(Sub1.DataProviderReference == Sub2.DataProviderReference,
                "DataProviderReference mismatch");
            vcardType SubVc1 = Sub1.SubscriberData[0];
            vcardType SubVc2 = Sub2.SubscriberData?[0];
            Assert.True(SubVc2 != null, "SubVc2 is null");
            Assert.True(SubVc1.LastName == SubVc2.LastName, "LastName mismatch");
        }

        [Fact]
        public void PidfLoProvidedByByReference()
        {
            string strData = Utils.GetRawData(Path, "PidfLoProvidedByByReference.xml");
            Presence pres = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            Assert.NotNull(pres);
            GeoPriv Gp = pres.device?.geopriv;
            Assert.NotNull(Gp?.ProvidedBy);
            ProvidedByType Pb = Gp.ProvidedBy;

            Assert.True(Pb.EmergencyCallDataReference != null && Pb.EmergencyCallDataReference.Count == 5,
                "The EmergencyCallDataReference is null or empty");
            VerifyByRefType(Pb.EmergencyCallDataReference);
        }

        private void VerifyByRefType(List<ByRefType> Ecdr)
        {
            Assert.True(Ecdr[0].purpose == "EmergencyCallData.ServiceInfo", "The first purpose is wrong");
            Assert.True(Ecdr[0].@ref == "https://example.com/ref1", "The first ref is wrong");
            Assert.True(Ecdr[1].purpose == "EmergencyCallData.ProviderInfo", "The second purpose is wrong");
            Assert.True(Ecdr[1].@ref == "https://example.com/ref2", "The second ref is wrong");
            Assert.True(Ecdr[2].purpose == "EmergencyCallData.Comment", "The third purpose is wrong");
            Assert.True(Ecdr[2].@ref == "https://example.com/ref3", "The third ref is wrong");
            Assert.True(Ecdr[3].purpose == "EmergencyCallData.ServiceInfo", "The fourth purpose is wrong");
            Assert.True(Ecdr[3].@ref == "https://example.com/ref4", "The fourth ref is wrong");
            Assert.True(Ecdr[4].purpose == "EmergencyCallData.DeviceInfo", "The fifth purpose is wrong");
            Assert.True(Ecdr[4].@ref == "https://example.com/ref5", "The fifth ref is wrong");
        }

        [Fact]
        public void PidfLoProvidedByByReferenceSerialization()
        {
            string strData = Utils.GetRawData(Path, "PidfLoProvidedByByReference.xml");
            Presence pres1 = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            strData = XmlHelper.SerializeToString(pres1);
            Presence pres2 = (Presence)XmlHelper.DeserializeFromString(strData, typeof(Presence));
            GeoPriv Gp = pres2.device?.geopriv;
            Assert.NotNull(Gp?.ProvidedBy);
            ProvidedByType Pb = Gp.ProvidedBy;
            Assert.True(Pb.EmergencyCallDataReference != null && Pb.EmergencyCallDataReference.Count == 5,
                "The EmergencyCallDataReference is null or empty");
            VerifyByRefType(Pb.EmergencyCallDataReference);
        }
    }
}
