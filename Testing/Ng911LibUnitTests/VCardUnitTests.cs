/////////////////////////////////////////////////////////////////////////////////////
//  File: VCardUnitTests.cs                                         9 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using AdditionalData;
using System.Xml;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class VCardUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test additional data XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\AdditionalDataFiles\";

        /// <summary>
        /// The file XCards1.xml is from the example XML formatted VCard from Section 4 RFC 6351.
        /// </summary>
        [Fact]
        public void Xcards1()
        {
            string strData = Utils.GetRawData(Path, "Xcards1.xml");
            vcards Vcs = (vcards) XmlHelper.DeserializeFromString(strData, typeof(vcards));
            Assert.NotNull(Vcs);
            Assert.True(Vcs.vcard != null && Vcs.vcard.Length == 1, "The vcard array is null or empty");

            VerifyXcardType1(Vcs.vcard[0]);
        }

        private void VerifyXcardType1(vcardType vcard)
        {
            Assert.True(vcard.FullName == "Simon Perreault", "The FullName is wrong");

            // Verify the helper properties of the vcardType class for the name
            Assert.True(vcard.LastName == "Perreault", "The vcardType LastName is wrong");
            Assert.True(vcard.FirstName == "Simon", "The vcardType FirstName is wrong");
            Assert.True(vcard.MiddleName == "", "The vcardType MiddleName is wrong");
            Assert.True(vcard.Prefix == "", "The vcardType Prefix is wrong");
            Assert.True(vcard.Suffix == "ing. jr", "The vcardType Suffix is wrong");

            Assert.True(vcard.bday.Item.ToString() == "--0203", "The bday is wrong");
            Assert.True(vcard.bday.ItemElementName == BdayItemChoiceEnum.date, "The bday ItemElementName " +
                "is wrong");
            Assert.True(vcard.anniversary.Item.ToString() == "20090808T1430-0500", "The anniversary " +
                "is wrong");
            Assert.True(vcard.anniversary.ItemElementName == AnniversaryItemChoiceEnum.datetime,
                "The anniversary ItemElementName is wrong");
            Assert.True(vcard.gender.sex == sex.M, "The gender is wrong");
            Assert.True(vcard.lang != null && vcard.lang.Length == 2, "The lang is null or empty");
            Assert.True(vcard.lang[0].languagetag == "fr", "The first language is wrong");
            Assert.True(vcard.lang[0].parameters.pref.integer == "1", "The first language preference " +
                "is wrong");
            Assert.True(vcard.lang[1].languagetag == "en", "The second language is wrong");
            Assert.True(vcard.lang[1].parameters.pref.integer == "2", "The second language " +
                "preference is wrong");
            Assert.True(vcard.org != null && vcard.org.Length == 1, "The org is null or empty");
            Assert.True(vcard.org[0].text[0] == "Viagenie", "The org is wrong");
            Assert.True(vcard.org[0].parameters?.type != null && vcard.org[0].parameters.type.Length == 1,
                "The org type parameter is null or empty");
            Assert.True(vcard.org[0].parameters.type[0] == typeText.work, "The org type is wrong");

            // Verify the helper properties of vcardType for adr (address)
            Assert.True(vcard.PoBox == "", "The vcardType PoBox is wrong");
            Assert.True(vcard.Ext == "", "The vcardType Ext is wrong");
            Assert.True(vcard.Street == "2875 boul. Laurier, suite D2-630", "The vcardType Street is wrong");
            Assert.True(vcard.City == "Quebec", "The vcardType City is wrong");
            Assert.True(vcard.State == "QC", "The vcard State is wrong");
            Assert.True(vcard.ZipCode == "G1V 2M2", "The vcardType ZipCode is wrong");
            Assert.True(vcard.Country == "Canada", "The vcardType Country is wrong");

            // Verify the adr helper properties
            adr Adr = vcard.adr[0];
            Assert.True(Adr.PoBox == "", "The adr PoBox is wrong");
            Assert.True(Adr.Ext == "", "The adr Ext is wrong");
            Assert.True(Adr.Street == "2875 boul. Laurier, suite D2-630", "The adr Street is wrong");
            Assert.True(Adr.City == "Quebec", "The adr City is wrong");
            Assert.True(Adr.State == "QC", "The adr State is wrong");
            Assert.True(Adr.ZipCode == "G1V 2M2", "The adr ZipCode is wrong");
            Assert.True(Adr.Country == "Canada", "The adr Country is wrong");

            Assert.True(vcard.tel != null && vcard.tel.Length == 2, "The tel is null or empty");
            Assert.True(vcard.tel[0].Item == "tel:+1-418-656-9254;ext=102", "The first telephone " +
                "number is wrong");
            Assert.True(vcard.tel[0].ItemElementName == TelItemChoiceEnum.uri, "The first tel " +
                "ItemELementName is wrong");
            string[] TypeArray1 = vcard.tel?[0].parameters?.type;
            Assert.True(TypeArray1 != null && TypeArray1.Length == 2, "The first tel type is null " +
                "or the length is wrong");
            Assert.True(TypeArray1[0] == "work", "The first tel first type is wrong");
            Assert.True(TypeArray1[1] == "voice", "The first tel third type is wrong");

            Assert.True(vcard.tel[1].Item == "tel:+1-418-262-6501", "The second telephone number " +
                "is wrong");
            Assert.True(vcard.tel[1].ItemElementName == TelItemChoiceEnum.uri, "The second tel " +
                "ItemElementName is wrong");
            string[] TypeArray2 = vcard.tel?[1].parameters?.type;
            Assert.True(TypeArray2 != null && TypeArray2.Length == 5, "The second tel type is null " +
                "or the length is wrong");
            Assert.True(TypeArray2[0] == "work", "The second tel first type is wrong");
            Assert.True(TypeArray2[1] == "text", "The second tel second type is wrong");
            Assert.True(TypeArray2[2] == "voice", "The second tel third type is wrong");
            Assert.True(TypeArray2[3] == "cell", "The second tel fourth type is wrong");
            Assert.True(TypeArray2[4] == "video", "The second tel fifth type is wrong");

            Assert.True(vcard.TelephoneNumber == "tel:+1-418-656-9254;ext=102", "The vcardType " +
                "TelephoneNumber is wrong");

            Assert.True(vcard.email != null && vcard.email.Length == 1, "The email is null or empty");
            Assert.True(vcard.email[0].text == "simon.perreault@viagenie.ca", "The email value is " +
                "wrong");
            Assert.True(vcard.email[0].parameters?.type != null && vcard.email[0].parameters.type.Length
                == 1, "The email type is null or empty");
            Assert.True(vcard.email[0].parameters.type[0] == typeText.work, "The email type is wrong");
            Assert.True(vcard.EMail == "simon.perreault@viagenie.ca", "The vcardType EMail is wrong");

            Assert.True(vcard.geo != null && vcard.geo.Length == 1, "The geo is null or empty");
            Assert.True(vcard.geo[0].uri == "geo:46.766336,-71.28955", "The geo is wrong");
            typeText[] GeoTt = vcard.geo[0].parameters?.type;
            Assert.True(GeoTt != null && GeoTt.Length == 1, "The geo type is null or empty");
            Assert.True(GeoTt[0] == typeText.work, "The geo type is wrong");

            Assert.True(vcard.key != null && vcard.key.Length == 1, "The key is null or empty");
            Assert.True(vcard.key[0].Item == "http://www.viagenie.ca/simon.perreault/simon.asc",
                "The key item is wrong");
            Assert.True(vcard.key[0].ItemElementName == KeyItemChoiceEnum.uri, "The key ItemElementName " +
                "is wrong");

            Assert.True(vcard.tz != null && vcard.tz.Length == 1, "The tz is null or empty");
            Assert.True(vcard.tz[0].Item == "America/Montreal", "The tz Item is wrong");
            Assert.True(vcard.tz[0].ItemElementName == VcardTypeTzItemChoiceEnum.text, "The tz ItemElementName " +
                "is wrong");

            Assert.True(vcard.url != null && vcard.url.Length == 1, "The url is null or empty");
            Assert.True(vcard.url[0].uri == "http://nomis80.org", "The url uri is wrong");
            typeText[] UrlTt = vcard.url[0].parameters?.type;
            Assert.True(UrlTt != null && UrlTt.Length == 1, "The URL type parameter is null or empty");
            Assert.True(UrlTt[0] == typeText.home, "The url typeText is wrong");
        }

        [Fact]
        public void XCards1_ProgDeser()
        {
            string strData = Utils.GetRawData(Path, "Xcards1.xml");
            XmlNode Xn = XmlHelper.GetRootNode(strData);
            Assert.NotNull(Xn);
            vcards Vcs = new vcards(Xn);
            Assert.NotNull(Vcs);
            Assert.True(Vcs.vcard != null && Vcs.vcard.Length == 1, "The vcard array is null or empty");

            VerifyXcardType1(Vcs.vcard[0]);
        }

        [Fact]
        public void XcardType1()
        {
            string strData = Utils.GetRawData(Path, "XcardType1.xml");
            vcardType vcard = (vcardType)XmlHelper.DeserializeFromString(strData, typeof(vcardType));
            Assert.NotNull(vcard);
            VerifyXcardType1(vcard);
        }

        [Fact]
        public void XcardType1Serialization()
        {
            string strData = Utils.GetRawData(Path, "XcardType1.xml");
            vcardType vcard1 = (vcardType)XmlHelper.DeserializeFromString(strData, typeof(vcardType));
            Assert.NotNull(vcard1);

            string strVcard = XmlHelper.SerializeToString(vcard1);
            Assert.True(string.IsNullOrEmpty(strVcard) == false, "strVcard is null or empty");

            vcardType vcard2 = (vcardType) XmlHelper.DeserializeFromString(strVcard, typeof(vcardType));
            Assert.True(vcard2 != null, "vcard2 is null");

            VerifyXcardType1(vcard2);
        }

        [Fact]
        public void TestVcardToJcard()
        {
            string strData = Utils.GetRawData(Path, "XcardType1.xml");
            vcardType vcard1 = (vcardType)XmlHelper.DeserializeFromString(strData, typeof(vcardType));
            Assert.NotNull(vcard1);

            string strJcard = JCard.XcardToJsonString(vcard1);
            Assert.True(string.IsNullOrEmpty(strJcard) == false, "strJcard is null or empty");
            vcardType vcard2 = JCard.JCardStringToVCardType(strJcard);
            Assert.True(vcard2 != null, "vcard2 is null");

            VerifyXcardType1(vcard2);
        }

        [Fact]
        public void Rfc7095Jcard1()
        {
            string strData = Utils.GetRawData(Path, "Rfc7095Jcard1.json");
            vcardType vcard = JCard.JCardStringToVCardType(strData);
            Assert.NotNull(vcard);

            Assert.True(vcard.FullName == "John Doe", "The FullName is wrong");
            Assert.True(vcard.gender.sex == sex.M, "The gender is wrong");
            Assert.True(vcard.categories != null && vcard.categories.Length == 1, "The categories " +
                "is null or empty");
            string[] Cats = vcard.categories[0].text;
            Assert.True(Cats != null && Cats.Length == 2, "The categories text is null or empty");
            Assert.True(Cats[0] == "computers", "The first category is wrong");
            Assert.True(Cats[1] == "cameras", "The second category is wrong");
        }

        [Fact]
        public void Rfc7095Jcard2()
        {
            string strData = Utils.GetRawData(Path, "Rfc7095Jcard2.json");
            vcardType vcard = JCard.JCardStringToVCardType(strData);

            //            VerifyXcardType1(vcard);
            // Verify the helper properties of the vcardType class for the name
            Assert.True(vcard.LastName == "Perreault", "The vcardType LastName is wrong");
            Assert.True(vcard.FirstName == "Simon", "The vcardType FirstName is wrong");
            Assert.True(vcard.MiddleName == "", "The vcardType MiddleName is wrong");
            Assert.True(vcard.Prefix == "", "The vcardType Prefix is wrong");
            Assert.True(vcard.Suffix == "ing. jr", "The vcardType Suffix is wrong");

            Assert.True(vcard.bday.Item.ToString() == "--02-03", "The bday is wrong");
            Assert.True(vcard.bday.ItemElementName == BdayItemChoiceEnum.valuedateandortime, 
                "The bday ItemElementName is wrong");
            Assert.True(vcard.anniversary.Item.ToString() == "2009-08-08T14:30:00-05:00", 
                "The anniversary is wrong");
            Assert.True(vcard.anniversary.ItemElementName == AnniversaryItemChoiceEnum.valuedateandortime,
                "The anniversary ItemElementName is wrong");
            Assert.True(vcard.gender.sex == sex.M, "The gender is wrong");
            Assert.True(vcard.lang != null && vcard.lang.Length == 2, "The lang is null or empty");
            Assert.True(vcard.lang[0].languagetag == "fr", "The first language is wrong");
            Assert.True(vcard.lang[0].parameters.pref.integer == "1", "The first language preference " +
                "is wrong");
            Assert.True(vcard.lang[1].languagetag == "en", "The second language is wrong");
            Assert.True(vcard.lang[1].parameters.pref.integer == "2", "The second language " +
                "preference is wrong");
            Assert.True(vcard.org != null && vcard.org.Length == 1, "The org is null or empty");
            Assert.True(vcard.org[0].text[0] == "Viagenie", "The org is wrong");
            Assert.True(vcard.org[0].parameters?.type != null && vcard.org[0].parameters.type.Length == 1,
                "The org type parameter is null or empty");
            Assert.True(vcard.org[0].parameters.type[0] == typeText.work, "The org type is wrong");

            // Verify the helper properties of vcardType for adr (address)
            Assert.True(vcard.PoBox == "", "The vcardType PoBox is wrong");
            Assert.True(vcard.Ext == "Suite D2-630", "The vcardType Ext is wrong");
            Assert.True(vcard.Street == "2875 Laurier", "The vcardType Street is wrong");
            Assert.True(vcard.City == "Quebec", "The vcardType City is wrong");
            Assert.True(vcard.State == "QC", "The vcard State is wrong");
            Assert.True(vcard.ZipCode == "G1V 2M2", "The vcardType ZipCode is wrong");
            Assert.True(vcard.Country == "Canada", "The vcardType Country is wrong");

            // Verify the adr helper properties
            adr Adr = vcard.adr[0];
            Assert.True(Adr.PoBox == "", "The adr PoBox is wrong");
            Assert.True(Adr.Ext == "Suite D2-630", "The adr Ext is wrong");
            Assert.True(Adr.Street == "2875 Laurier", "The adr Street is wrong");
            Assert.True(Adr.City == "Quebec", "The adr City is wrong");
            Assert.True(Adr.State == "QC", "The adr State is wrong");
            Assert.True(Adr.ZipCode == "G1V 2M2", "The adr ZipCode is wrong");
            Assert.True(Adr.Country == "Canada", "The adr Country is wrong");

            Assert.True(vcard.tel != null && vcard.tel.Length == 2, "The tel is null or empty");
            Assert.True(vcard.tel[0].Item == "tel:+1-418-656-9254;ext=102", "The first telephone " +
                "number is wrong");
            Assert.True(vcard.tel[0].ItemElementName == TelItemChoiceEnum.uri, "The first tel " +
                "ItemELementName is wrong");
            string[] TypeArray1 = vcard.tel?[0].parameters?.type;
            Assert.True(TypeArray1 != null && TypeArray1.Length == 2, "The first tel type is null " +
                "or the length is wrong");
            Assert.True(TypeArray1[0] == "work", "The first tel first type is wrong");
            Assert.True(TypeArray1[1] == "voice", "The first tel third type is wrong");

            Assert.True(vcard.tel[1].Item == "tel:+1-418-262-6501", "The second telephone number " +
                "is wrong");
            Assert.True(vcard.tel[1].ItemElementName == TelItemChoiceEnum.uri, "The second tel " +
                "ItemElementName is wrong");
            string[] TypeArray2 = vcard.tel?[1].parameters?.type;
            Assert.True(TypeArray2 != null && TypeArray2.Length == 5, "The second tel type is null " +
                "or the length is wrong");
            Assert.True(TypeArray2[0] == "work", "The second tel first type is wrong");
            Assert.True(TypeArray2[1] == "cell", "The second tel second type is wrong");
            Assert.True(TypeArray2[2] == "voice", "The second tel third type is wrong");
            Assert.True(TypeArray2[3] == "video", "The second tel fourth type is wrong");
            Assert.True(TypeArray2[4] == "text", "The second tel fifth type is wrong");

            Assert.True(vcard.TelephoneNumber == "tel:+1-418-656-9254;ext=102", "The vcardType " +
                "TelephoneNumber is wrong");

            Assert.True(vcard.email != null && vcard.email.Length == 1, "The email is null or empty");
            Assert.True(vcard.email[0].text == "simon.perreault@viagenie.ca", "The email value is " +
                "wrong");
            Assert.True(vcard.email[0].parameters?.type != null && vcard.email[0].parameters.type.Length
                == 1, "The email type is null or empty");
            Assert.True(vcard.email[0].parameters.type[0] == typeText.work, "The email type is wrong");
            Assert.True(vcard.EMail == "simon.perreault@viagenie.ca", "The vcardType EMail is wrong");

            Assert.True(vcard.geo != null && vcard.geo.Length == 1, "The geo is null or empty");
            Assert.True(vcard.geo[0].uri == "geo:46.772673,-71.282945", "The geo is wrong");
            typeText[] GeoTt = vcard.geo[0].parameters?.type;
            Assert.True(GeoTt != null && GeoTt.Length == 1, "The geo type is null or empty");
            Assert.True(GeoTt[0] == typeText.work, "The geo type is wrong");

            Assert.True(vcard.key != null && vcard.key.Length == 1, "The key is null or empty");
            Assert.True(vcard.key[0].Item == "http://www.viagenie.ca/simon.perreault/simon.asc",
                "The key item is wrong");
            Assert.True(vcard.key[0].ItemElementName == KeyItemChoiceEnum.uri, "The key ItemElementName " +
                "is wrong");

            Assert.True(vcard.tz != null && vcard.tz.Length == 1, "The tz is null or empty");
            Assert.True(vcard.tz[0].Item == "-05:00", "The tz Item is wrong");
            Assert.True(vcard.tz[0].ItemElementName == VcardTypeTzItemChoiceEnum.utcoffset, 
                "The tz ItemElementName is wrong");

            Assert.True(vcard.url != null && vcard.url.Length == 1, "The url is null or empty");
            Assert.True(vcard.url[0].uri == "http://nomis80.org", "The url uri is wrong");
            typeText[] UrlTt = vcard.url[0].parameters?.type;
            Assert.True(UrlTt != null && UrlTt.Length == 1, "The URL type parameter is null or empty");
            Assert.True(UrlTt[0] == typeText.home, "The url typeText is wrong");

        }

    }
}
