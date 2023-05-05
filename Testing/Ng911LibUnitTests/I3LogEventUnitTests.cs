/////////////////////////////////////////////////////////////////////////////////////
//  File:   I3LogEventUnitTests.cs                                  10 Feb 23 PHR
/////////////////////////////////////////////////////////////////////////////////////

using Ng911Lib.Utilities;
using Ng911Common;
using I3LogEvents;

using Newtonsoft.Json;
using System.Text.Json;

namespace UnitTests
{
    [Trait("Category", "unit")]
    public class I3LogEventUnitTests
    {
        [Fact]
        public void CallStartLogEvent()
        {
            CallStartEndLogEvent Csee1 = BuildCallStartLogEvent();
            SetLogEvent(Csee1);

            Csee1.direction = "incoming";
            Csee1.standardPrimaryCallType = "emergency";
            Csee1.standardSecondaryCallType = "NG9-1-1 Call";
            Csee1.localCallType = "local call type";
            Csee1.localUse = "local use value";
            Csee1.to = "911";
            Csee1.from = "8185553333";

            I3Jws Jws = new I3Jws(Csee1); ;
            string strJson = I3Jws.Base64UrlStringToJsonString(Jws.payload);
            CallStartEndLogEvent Csee2 = JsonHelper.DeserializeFromString<CallStartEndLogEvent>(strJson);

            VerifyCallStartLogEvent(Csee1, Csee2);
        }

        private CallStartEndLogEvent BuildCallStartLogEvent()
        {
            CallStartEndLogEvent Csee1 = new CallStartEndLogEvent("CallStartLogEvent");
            SetLogEvent(Csee1);

            Csee1.direction = "incoming";
            Csee1.standardPrimaryCallType = "emergency";
            Csee1.standardSecondaryCallType = "NG9-1-1 Call";
            Csee1.localCallType = "local call type";
            Csee1.localUse = "local use value";
            Csee1.to = "911";
            Csee1.from = "8185553333";
            return Csee1;
        }

        private void VerifyCallStartLogEvent(CallStartEndLogEvent Csee1, CallStartEndLogEvent Csee2)
        {
            VerifyLogEvent(Csee1, Csee2);
            Assert.True(Csee1.direction == Csee2.direction, "direction mismatch");
            Assert.True(Csee1.standardPrimaryCallType == Csee2.standardPrimaryCallType);
            Assert.True(Csee2.standardSecondaryCallType == Csee2.standardSecondaryCallType,
                "standardSecondaryCallType mismatch");
            Assert.True(Csee1.localCallType == Csee2.localCallType, "localCallType mismatch");
            Assert.True(Csee1.localUse == Csee2.localUse, "localUse mismatch");
            Assert.True(Csee1.to == Csee2.to, "to mismatch");
            Assert.True(Csee1.from == Csee2.from, "from mismatch");
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
            Le.callIdSIP = "243FF53D-169D-4EAF-9FBE-B9613E8CB0D5";
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
            Assert.True(Le1.callIdSIP == Le2.callIdSIP, "callIdSIP mismatch");
            Assert.True(Le1.ipAddressPort == Le2.ipAddressPort, "ipAddressPort mismatch");
        }

        /// <summary>
        /// Serializes a simple C# class with Newtonsoft.Json and deserializes it with Microsoft System.Text.Json
        /// and compares the results
        /// </summary>
        [Fact]
        public void NewtonsoftToMicrosoft()
        {
            CallStartEndLogEvent Csee1 = BuildCallStartLogEvent();
            string strCsee1 = JsonConvert.SerializeObject(Csee1);
            CallStartEndLogEvent Csee2 = System.Text.Json.JsonSerializer.Deserialize<CallStartEndLogEvent>(
                strCsee1);
            VerifyCallStartLogEvent(Csee1, Csee2);
        }

        /// <summary>
        /// Serializes a simple C# class with System.Text.Json and deserializes it with Newtonsoft.Json and
        /// compares the results.
        /// </summary>
        [Fact]
        public void MicrosoftToNewtonsoft()
        {
            CallStartEndLogEvent Csee1 = BuildCallStartLogEvent();
            string strCsee1 = System.Text.Json.JsonSerializer.Serialize(Csee1);
            CallStartEndLogEvent Csee2 = JsonConvert.DeserializeObject<CallStartEndLogEvent>(strCsee1);
            VerifyCallStartLogEvent(Csee1, Csee2);
        }
    }
}
