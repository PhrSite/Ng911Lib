/////////////////////////////////////////////////////////////////////////////////////
//  File:   SipRecMetaDataUnitTests.cs                              26 Jan 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using SipRecMetaData;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class SipRecMetaDataUnitTests
    {
        /// <summary>
        /// Specifies the path to the files containing the SIPREC Metadata test XML files.
        /// This path assumes that this project is being run from Visual Studio.
        /// Change this if the project directory structure changes or the location of the test files
        /// changes.
        /// </summary>
        private const string Path = @"..\..\..\SipRecMetaDataFiles\";

        [Fact]
        public void Rfc7865_8_1()
        {
            string strData = Utils.GetRawData(Path, "Rfc7865-8.1.xml");
            recording Rec = (recording) XmlHelper.DeserializeFromString(strData, typeof(recording));
            Assert.NotNull(Rec);

            VerifyRfc7865_8_1(Rec);
        }

        private void VerifyRfc7865_8_1(recording Rec)
        {
            Assert.True(Rec.datamode == dataMode.complete, "The datamode is wrong");
            Assert.True(Rec.groups != null && Rec.groups.Count == 1, "The groups is null or empty");

            // Note: The example file includes times in Zulu format (ex. 2010-12-16T23:41:07Z) instead
            // of the Timestamp format used in NG9-1-1 and for XML which is in ISO 8601 format which has
            // the local time plus a time zone offset.
            DateTime Dt1 = Rec.groups[0].associatetime;
            DateTime Dt2 = DateTime.Parse("2010-12-16T23:41:07Z").ToUniversalTime();
            Assert.True(Rec.groups[0].associatetimeSpecified == true && Dt1 == Dt2, 
                "The groups[0].associatetime is wrong");

            Assert.True(Rec.sessions != null && Rec.sessions.Count == 1, "The sessions is null or empty");
            session Session = Rec.sessions[0];
            Assert.True(Session.groupref == Rec.groups[0].group_id, "The groupref does not match the " +
                "group_id");
            Assert.True(Session.sipSessionID[0].Contains("ab30317f1a784d"), "The sipSessionID is wrong");

            Assert.True(Rec.participants != null && Rec.participants.Count == 2, "The participants " +
                "is null or the count is wrong");
            participant Part1 = Rec.participants[0];
            Assert.True(Part1.participant_id == "srfBElmCRp2QB23b7Mpk0w==", "The first " +
                "participant ID is wrong");
            Assert.True(Part1.nameIDs[0].aor == "sip:bob@biloxi.com", "The first nameID.aor is wrong");
            Assert.True(Part1.nameIDs[0].name.Value == "Bob", "The first name is wrong");
            Assert.True(Part1.nameIDs[0].name.lang == "it", "The first lang is wrong");

            participant Part2 = Rec.participants[1];
            Assert.True(Part2.participant_id == "zSfPoSvdSDCmU3A3TRDxAw==", "The second " +
                "participant ID is wrong");
            Assert.True(Part2.nameIDs[0].aor == "sip:Paul@biloxi.com", "The second nameID.aor is wrong");
            Assert.True(Part2.nameIDs[0].name.Value == "Paul", "The second name is wrong");
            Assert.True(Part2.nameIDs[0].name.lang == "it", "The second lang is wrong");

            Assert.True(Rec.streams != null && Rec.streams.Count == 4, "The streams is null or " +
                "the count is wrong");
            VerifyStream(Rec.streams[0], 0, "UAAMm5GRQKSCMVvLyl4rFw==", "hVpd7YQgRW2nD22h7q60JQ==",
                "96");
            VerifyStream(Rec.streams[1], 1, "i1Pz3to5hGk8fuXl+PbwCw==", "hVpd7YQgRW2nD22h7q60JQ==",
                "97");
            VerifyStream(Rec.streams[2], 2, "8zc6e0lYTlWIINA6GR+3ag==", "hVpd7YQgRW2nD22h7q60JQ==",
                "98");
            VerifyStream(Rec.streams[3], 3, "EiXGlc+4TruqqoDaNE76ag==", "hVpd7YQgRW2nD22h7q60JQ==",
                "99");

            Assert.True(Rec.sessionrecordingassocs != null && Rec.sessionrecordingassocs.Count == 1,
                "The sessionrecordingassocs is null or the count is wrong");
            Assert.True(Rec.sessionrecordingassocs[0].session_id == "hVpd7YQgRW2nD22h7q60JQ==",
                "The sessionrecordingassoc.session_id is wrong");

            Assert.True(Rec.participantsessionassocs != null && Rec.participantsessionassocs.Count == 2,
                "The participantsessionassocs is null or the count is wrong");
            List<participantsessionassoc> Psas = Rec.participantsessionassocs;
            Assert.True(Psas[0].participant_id == "srfBElmCRp2QB23b7Mpk0w==", "The first " + 
                "participantsessionassoc.participant_id is wrong");
            Assert.True(Psas[0].session_id == "hVpd7YQgRW2nD22h7q60JQ==", "The first " +
                "participantsessionassoc.session_id is wrong");
            Assert.True(Psas[1].participant_id == "zSfPoSvdSDCmU3A3TRDxAw==", "The second " +
                "participantsessionassoc.participant_id is wrong");
            Assert.True(Psas[1].session_id == "hVpd7YQgRW2nD22h7q60JQ==", "The second " +
                "participantsessionassoc.session_id is wrong");

            Assert.True(Rec.participantstreamassocs != null && Rec.participantstreamassocs.Count == 2,
                "The participantstreamassocs is null or the count is wrong");
            List<participantstreamassoc> PartStrmAs = Rec.participantstreamassocs;
            VerifyPartStreamAssoc(PartStrmAs[0], 0, "srfBElmCRp2QB23b7Mpk0w==", "i1Pz3to5hGk8fuXl+PbwCw==",
                "UAAMm5GRQKSCMVvLyl4rFw==", "8zc6e0lYTlWIINA6GR+3ag==", "EiXGlc+4TruqqoDaNE76ag==");
            VerifyPartStreamAssoc(PartStrmAs[1], 1, "zSfPoSvdSDCmU3A3TRDxAw==", "8zc6e0lYTlWIINA6GR+3ag==",
                "EiXGlc+4TruqqoDaNE76ag==", "UAAMm5GRQKSCMVvLyl4rFw==", "i1Pz3to5hGk8fuXl+PbwCw==");
        }

        private void VerifyPartStreamAssoc(participantstreamassoc PartStrm, int Idx, string PartId,
            string SendId1, string SendId2, string RecvId1, string RecvId2)
        {
            Assert.True(PartStrm.participant_id == PartId, $"Participant {Idx} participant_id is wrong");
            Assert.True(PartStrm.send[0] == SendId1, $"Participant {Idx} SendId1 is wrong");
            Assert.True(PartStrm.send[1] == SendId2, $"Participant {Idx} SendId2 is wrong");
            Assert.True(PartStrm.recv[0] == RecvId1, $"Participant {Idx} RecvId1 is wrong");
            Assert.True(PartStrm.recv[1] == RecvId2, $"Participant {Idx} RecvId2 is wrong");
        }

        private void VerifyStream(stream strm, int Idx, string Id, string Sess, string Lbl)
        {
            Assert.True(strm.stream_id == Id, $"stream[{Idx}] stream_id is wrong");
            Assert.True(strm.session_id == Sess, $"stream[{Idx}] session_id is wrong");
            Assert.True(strm.label == Lbl, $"stream[{Idx}] label is wrong");
        }

        [Fact]
        public void Rfc7865_8_1_Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc7865-8.1.xml");
            recording Rec1 = (recording)XmlHelper.DeserializeFromString(strData, typeof(recording));
            Assert.NotNull(Rec1);

            string str = XmlHelper.SerializeToString(Rec1);
            recording Rec2 = (recording)XmlHelper.DeserializeFromString(str, typeof(recording));
            VerifyRfc7865_8_1(Rec2);
        }

        [Fact]
        public void Rfc7865_8_2()
        {
            string strData = Utils.GetRawData(Path, "Rfc7865-8.2.xml");
            recording Rec = (recording)XmlHelper.DeserializeFromString(strData, typeof(recording));
            Assert.NotNull(Rec);
            VerifyRfc7865_8_2(Rec);
        }

        private void VerifyRfc7865_8_2(recording Rec)
        {
            Assert.True(Rec.datamode == dataMode.partial, "The datamode is wrong");
            Assert.True(Rec.participants != null && Rec.participants.Count == 1, "The participants " +
                "is null or empty");
            Assert.True(Rec.participants[0].participant_id == "srfBElmCRp2QB23b7Mpk0w==",
                "The participant_id is wrong");
            Assert.True(Rec.participants[0].nameIDs[0].aor == "sip:bob@biloxi.com", "The aor is wrong");
            Assert.True(Rec.participants[0].nameIDs[0].name.Value == "Bob", "The name is wrong");
            Assert.True(Rec.participants[0].nameIDs[0].name.lang == "it", "The lang is wrong");

            Assert.True(Rec.participantsessionassocs != null && Rec.participantsessionassocs.Count == 1,
                "The participantsessionassocs is null or empty");
            List<participantsessionassoc> PartSess = Rec.participantsessionassocs;
            Assert.True(PartSess[0].participant_id == "srfBElmCRp2QB23b7Mpk0w==", "The participant_id " +
                "is wrong");
            Assert.True(PartSess[0].session_id == "hVpd7YQgRW2nD22h7q60JQ==", "The session_id is wrong");
            Assert.True(PartSess[0].disassociatetimeSpecified == true, "The disassociatetimeSpecified " +
                "is wrong");
        }

        [Fact]
        public void Rfc7865_8_2_Serialization()
        {
            string strData = Utils.GetRawData(Path, "Rfc7865-8.2.xml");
            recording Rec1 = (recording)XmlHelper.DeserializeFromString(strData, typeof(recording));
            Assert.NotNull(Rec1);

            string strRec = XmlHelper.SerializeToString(Rec1);
            recording Rec2 = (recording)XmlHelper.DeserializeFromString(strRec, typeof(recording));
            VerifyRfc7865_8_2(Rec2);
        }
    }
}
