/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventUnitTests.cs                                  10 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using Ng911Common;
using I3V3.LogEvents;

using Newtonsoft.Json;
using System.Text.Json;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class I3LogEventUnitTests
    {
        [Fact]
        public void CallStartLogEvent_SerializeDeserialize()
        {
            CallStartLogEvent Csle1 = BuildCallStartLogEvent();
            SetLogEvent(Csle1);

            I3Jws Jws = new I3Jws(Csle1); ;
            string strJson = I3Jws.Base64UrlStringToJsonString(Jws.payload);
            CallStartLogEvent Csle2 = JsonHelper.DeserializeFromString<CallStartLogEvent>(strJson);

            VerifyCallStartLogEvent(Csle1, Csle2);
        }

        private CallStartLogEvent BuildCallStartLogEvent()
        {
            CallStartLogEvent Csle1 = new CallStartLogEvent();
            SetLogEvent(Csle1);

            Csle1.direction = "incoming";
            Csle1.standardPrimaryCallType = "emergency";
            Csle1.standardSecondaryCallType = "NG9-1-1 Call";
            Csle1.localCallType = "local call type";
            Csle1.localUse = "local use value";
            Csle1.to = "911";
            Csle1.from = "8185553333";
            return Csle1;
        }

        private void VerifyCallStartLogEvent(CallStartLogEvent Csle1, CallStartLogEvent Csle2)
        {
            VerifyLogEvent(Csle1, Csle2);
            Assert.True(Csle1.direction == Csle2.direction, "direction mismatch");
            Assert.True(Csle1.standardPrimaryCallType == Csle2.standardPrimaryCallType);
            Assert.True(Csle2.standardSecondaryCallType == Csle2.standardSecondaryCallType,
                "standardSecondaryCallType mismatch");
            Assert.True(Csle1.localCallType == Csle2.localCallType, "localCallType mismatch");
            Assert.True(Csle1.localUse.ToString() == Csle2.localUse.ToString(), "localUse mismatch");
            Assert.True(Csle1.to == Csle2.to, "to mismatch");
            Assert.True(Csle1.from == Csle2.from, "from mismatch");
        }

        private void SetLogEvent(LogEvent Le)
        {
            Le.clientAssignedIdentifier = "123456";
            Le.timestamp = TimeUtils.GetCurrentNenaTimestamp();
            Le.elementId = "psap1.police.anycity.anystate.us";
            Le.agencyId = "police.anycity.anystate.us";
            Le.agencyAgentId = "agent1@police.anycity.anystate.us";
            Le.agencyPositionId = "Position 1";
            Le.callId = "urn:emergency:uid:callid:a56e556d871:bcf.state.pa.us";
            Le.incidentId = "urn:emergency:uid:incidentid:a56e556d871:bcf.state.pa.us";
            Le.callIdSip = "243FF53D-169D-4EAF-9FBE-B9613E8CB0D5";
            Le.ipAddressPort = "192.168.1.2:5060";
        }

        private void VerifyLogEvent(LogEvent Le1, LogEvent Le2)
        {
            Assert.True(Le1.logEventType == Le2.logEventType, "logEventType mismatch");
            Assert.True(Le1.clientAssignedIdentifier == Le2.clientAssignedIdentifier,
                "clientAssignedIdentifier mismatch");
            Assert.True(Le1.timestamp == Le2.timestamp, "timestamp mismatch");
            Assert.True(Le1.elementId == Le2.elementId, "elementId mismatch");
            Assert.True(Le1.agencyId == Le2.agencyId, "agencyId mismatch");
            Assert.True(Le1.agencyAgentId == Le2.agencyAgentId, "agencyAgentId mismatch");
            Assert.True(Le1.agencyPositionId == Le2.agencyPositionId, "agencyPositionId mismatch");
            Assert.True(Le1.callId == Le2.callId, "callId mismatch");
            Assert.True(Le1.incidentId == Le2.incidentId, "incidentId mismatch");
            Assert.True(Le1.callIdSip == Le2.callIdSip, "callIdSIP mismatch");
            Assert.True(Le1.ipAddressPort == Le2.ipAddressPort, "ipAddressPort mismatch");
        }

        /// <summary>
        /// Serializes a simple C# class with Newtonsoft.Json and deserializes it with Microsoft System.Text.Json
        /// and compares the results
        /// </summary>
        [Fact]
        public void NewtonsoftToMicrosoft()
        {
            CallStartLogEvent Csle1 = BuildCallStartLogEvent();
            string strCsee1 = JsonConvert.SerializeObject(Csle1);
            CallStartLogEvent Csle2 = System.Text.Json.JsonSerializer.Deserialize<CallStartLogEvent>(
                strCsee1);
            VerifyCallStartLogEvent(Csle1, Csle2);
        }

        /// <summary>
        /// Serializes a simple C# class with System.Text.Json and deserializes it with Newtonsoft.Json and
        /// compares the results.
        /// </summary>
        [Fact]
        public void MicrosoftToNewtonsoft()
        {
            CallStartLogEvent Csle1 = BuildCallStartLogEvent();
            string strCsee1 = System.Text.Json.JsonSerializer.Serialize(Csle1);
            CallStartLogEvent Csle2 = JsonConvert.DeserializeObject<CallStartLogEvent>(strCsee1);
            VerifyCallStartLogEvent(Csle1, Csle2);
        }
    }
}
