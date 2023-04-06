/////////////////////////////////////////////////////////////////////////////////////
//  File:   ConferenceEventUnitTests.cs                             3 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using ConferenceEvent;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class ConferenceEventUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the test Conference Event data XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\ConferenceEventFiles\";

        [Fact]
        public void Rfc4575BasicExample()
        {
            string strData = Utils.GetRawData(Path, "Rfc4575BasicExample.xml");
            conferencetype Ct = XmlHelper.DeserializeFromString<conferencetype>(strData);
            Assert.NotNull(Ct);
            Verify_Rfc4575BasicExample(Ct);
        }

        private void Verify_Rfc4575BasicExample(conferencetype Ct)
        {
            Assert.True(Ct.state == statetype.full, "The conference state is wrong");
            Assert.True(Ct.conferencedescription.subject == "Agenda: This month’s goals",
                "The conferencedescription.subject is wroing");
            Assert.True(Ct.conferencedescription.serviceuris.entry[0].uri == "http://sharepoint/salesgroup/",
                "The serviceuris.entry[0].uri is wrong");
            Assert.True(Ct.conferencedescription.serviceuris.entry[0].purpose == "web-page",
                "The serviceuris.entry[0].purpose is wrong");
            Assert.True(Ct.conferencestate.usercountSpecified == true && Ct.conferencestate.usercount == 33,
                "The usercount is wrong");
            Assert.True(Ct.users.user.Count == 2, "The user.Count is wrong");

            usertype User1 = Ct.users.user[0];
            Assert.True(User1.entity == "sip:bob@example.com", "User1.entity is wrong");
            Assert.True(User1.state == statetype.full, "User1.state is wrong");
            Assert.True(User1.displaytext == "Bob Hoskins", "User1.displaytext is wrong");

            Assert.True(User1.endpoint[0].entity == "sip:bob@pc33.example.com", "User1.endpoint[0]." +
                "entity is wrong");
            Assert.True(User1.endpoint[0].displaytext == "Bob’s Laptop", "User1.endpoint[0].displaytext" +
                "is wrong");
            Assert.True(User1.endpoint[0].status == endpointstatustype.disconnected,
                "User1.endpoint[0].status is wrong");
            Assert.True(User1.endpoint[0].disconnectionmethodSpecified == true && User1.endpoint[0].
                disconnectionmethod == disconnectiontype.departed, "User1.endpoint[0].disconnectionmethod " +
                "is wrong");

            Assert.True(User1.endpoint[0].disconnectioninfo.whenSpecified == true,
                "User1.endpoint[0].disconnectioninfo.whenSpecified is wrong");
            Assert.True(User1.endpoint[0].disconnectioninfo.by == "sip:mike@example.com",
                "User1.endpoint[0].disconnectioninfo.by is wrong");
            Assert.True(User1.endpoint[0].disconnectioninfo.reason == "bad voice quality",
                "User1.endpoint[0].disconnectioninfo.reason");

            mediatype Mt1 = User1.endpoint[0].media[0];
            Assert.True(Mt1.id == "1", "Mt1.id is wrong");
            Assert.True(Mt1.displaytext == "main audio", "Mt1.displaytext is wrong");
            Assert.True(Mt1.type == "audio", "Mt1.type is wrong");
            Assert.True(Mt1.label == "34567", "Mt1.label is wrong");
            Assert.True(Mt1.srcid == "432424", "Mt1.srcid is wrong");
            Assert.True(Mt1.statusSpecified == true && Mt1.status == mediastatustype.sendrecv,
                "Mt1.status is wrong");

            usertype User2 = Ct.users.user[1];
            Assert.True(User2.entity == "sip:alice@example.com", "The User2.entity is wrong");
            Assert.True(User2.state == statetype.full, "User2.state is wrong");
            Assert.True(User2.displaytext == "Alice", "The User2.displaytext is wrong");
            endpointtype Ep2 = User2.endpoint[0];
            Assert.True(Ep2.entity == "sip:4kfk4j392jsu@example.com;grid=433kj4j3u",
                "User2.endpoint[0].entity is wrong");
            Assert.True(Ep2.status == endpointstatustype.connected, "User2.endpoint[0].status is wrong");
            Assert.True(Ep2.joiningmethodSpecified == true && Ep2.joiningmethod == joiningtype.dialedout,
                "Ep2.joingmethod is wrong");
            Assert.True(Ep2.joininginfo.whenSpecified == true, "Ep2.joininginfo.whenSpecified is wrong");
            Assert.True(Ep2.joininginfo.by == "sip:mike@example.com", "Ep2.joininginfo.by is wroing");

            mediatype Mt2 = Ep2.media[0];
            Assert.True(Mt2.displaytext == "main audio", "Mt2.displaytext is wrong");
            Assert.True(Mt2.type == "audio", "Mt2.type is wrong");
            Assert.True(Mt2.label == "34567", "Mt2.label is wrong");
            Assert.True(Mt2.srcid == "534232", "Mt2.srcid is wrong");
            Assert.True(Mt2.status == mediastatustype.sendrecv, "Mt2.status is wrong");
        }

        [Fact]
        public void Rfc4575BasicExampleSerialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc4575BasicExample.xml");
            conferencetype Ct1 = XmlHelper.DeserializeFromString<conferencetype>(strData);
            Assert.NotNull(Ct1);
            string str = XmlHelper.SerializeToString(Ct1);
            conferencetype Ct2 = XmlHelper.DeserializeFromString<conferencetype>(str);
            Verify_Rfc4575BasicExample(Ct2);
        }

        [Fact]
        public void Rfc4575RichExample()
        {
            string strData = Utils.GetRawData(Path, "Rfc4575RichExample.xml");
            conferencetype Ct = XmlHelper.DeserializeFromString<conferencetype>(strData);
            Assert.NotNull(Ct);
            Verify_Rfc4575RichExample(Ct);
        }

        private void Verify_Rfc4575RichExample(conferencetype Ct)
        {
            Assert.True(Ct.hostinfo.displaytext == "Sales Host", "The hostinfo.displaytext is wrong");
            Assert.True(Ct.conferencestate.usercountSpecified == true && Ct.conferencestate.usercount
                == 32, "The usercount is wrong");
            Assert.True(Ct.conferencestate.activeSpecified == true && Ct.conferencestate.active == true,
                "The conferencestate.active is wrong");
            Assert.True(Ct.conferencestate.lockedSpecified == true && Ct.conferencestate.locked == false,
                "The conferencestate.locked is wrong");

            Assert.True(Ct.hostinfo.webpage == "http://sharepoint/salesgroup/hosts/", "The hostinfo." +
                "webpage is wrong");
            Assert.True(Ct.hostinfo.uris.entry[0].uri == "sip:sales@example.com", "The hostinfo.uris." +
                "entry[0].uri is wrong");

            uristype SideBarByRef = Ct.sidebarsbyref;
            Assert.True(SideBarByRef.state == statetype.partial, "The sidebarsbyref.state " +
                "is wrong");
            Assert.True(SideBarByRef.entry[0].uri == "sips:conf233@example.com;grid=45",
                "The SideBarBuRef.entry[0].uri is wrong");
            Assert.True(SideBarByRef.entry[0].displaytext == "sidebar with Carol",
                "The SideBarByRef.entry[0].displaytext is wrong");
            Assert.True(SideBarByRef.entry[1].uri == "sips:conf233@example.com;grid=21",
                "The SideBarBuRef.entry[1].uri is wrong");
            Assert.True(SideBarByRef.entry[1].displaytext == "private with Peter",
                "The SideBarByRef.entry[1].displaytext is wrong");

            sidebarsbyvaltype SideBarByVal = Ct.sidebarsbyval;
            Assert.True(SideBarByVal.state == statetype.partial, "The SideBarByVal.state is wrong");
            List<usertype> Users = SideBarByVal.entry[0].users.user;
            Assert.True(Users[0].entity == "sip:bob@example.com", "The first entity is wrong");
            Assert.True(Users[1].entity == "sip:mark@example.com", "The second entity is wrong");
            Assert.True(Users[2].entity == "sip:dan@example.com", "The third entity is wrong");
        }

        [Fact]
        public void Rfc4575RichExampleSerialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc4575RichExample.xml");
            conferencetype Ct1 = XmlHelper.DeserializeFromString<conferencetype>(strData);
            Assert.NotNull(Ct1);

            string str = XmlHelper.SerializeToString(Ct1);
            conferencetype Ct2 = XmlHelper.DeserializeFromString<conferencetype>(str);
            Verify_Rfc4575RichExample(Ct2);
        }
    }
}
