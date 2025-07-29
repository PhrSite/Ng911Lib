/////////////////////////////////////////////////////////////////////////////////////
//  File: I3SubNotUnitTests.cs                                      23 Jul 25 PHR
/////////////////////////////////////////////////////////////////////////////////////

using I3SubNot;
using Ng911Lib.Utilities;
using NuGet.Frameworks;
using System.Diagnostics;

namespace Ng911LibUnitTests;

[Trait("Category", "unit")]
public class I3SubNotUnitTests
{
    [Fact]
    public void TestElementStateSerialization1()
    {
        ElementState elementState1 = new ElementState();
        elementState1.state = ElementState.Normal;
        elementState1.elementDomain = "esrp1.state.pa.us";
        elementState1.reason = "Set by user";

        string strElementState = JsonHelper.SerializeToString(elementState1);
        ElementState elementState2 = JsonHelper.DeserializeFromString<ElementState>(strElementState);
        Assert.True(elementState1.state == elementState2.state, "State is wrong");
        Assert.True(elementState1.elementDomain == elementState2.elementDomain, "Domain is wrong");
        Assert.True(elementState1.reason == elementState2.reason, "Reason is wrong");
    }

    [Fact]
    public void TestElementStateSerialization2()
    {
        ElementState elementState1 = new ElementState(ElementState.Down, "esrp1.state.pa.us");
        string strElementState = JsonHelper.SerializeToString(elementState1);
        ElementState elementState2 = JsonHelper.DeserializeFromString<ElementState>(strElementState);
        Assert.True(elementState1.state == elementState2.state, "State is wrong");
        Assert.True(elementState1.elementDomain == elementState2.elementDomain, "Domain is wrong");
        Assert.True(elementState2.reason == null, "reason is not null");
    }

    [Fact]
    public void TestServiceStateSerialization1()
    {
        ServiceState serviceState1 = new ServiceState();
        serviceState1.service.name = ServiceType.PSAP;
        serviceState1.service.domain = "psap.allegheny.pa.us";
        serviceState1.serviceState.state = ServiceStateType.Normal;
        serviceState1.serviceState.reason = "Set by user";
        string strServiceState = JsonHelper.SerializeToString(serviceState1);
        ServiceState serviceState2 = JsonHelper.DeserializeFromString<ServiceState>(strServiceState);

        Assert.True(serviceState1.service.name == serviceState2.service.name, "name mismatch");
        Assert.True(serviceState1.service.domain == serviceState2.service.domain, "domain mismatch");
        Assert.True(serviceState1.serviceState.state == serviceState2.serviceState.state, "state mismatch");
        Assert.True(serviceState1.serviceState.reason == serviceState2.serviceState.reason, "reason mismatch");
        Assert.True(serviceState2.securityPosture.posture == null, "posture is not null");
    }

    [Fact]
    public void TestServiceStateSerialization2()
    {
        ServiceState serviceState1 = new ServiceState();
        serviceState1.service.name = ServiceType.PSAP;
        serviceState1.service.domain = "psap.allegheny.pa.us";
        serviceState1.serviceState.state = ServiceStateType.Normal;
        serviceState1.serviceState.reason = "Set by user";
        serviceState1.securityPosture.posture = SecurityPostureType.Green;
        serviceState1.securityPosture.reason = "Set by the user";

        string strServiceState = JsonHelper.SerializeToString(serviceState1);
        ServiceState serviceState2 = JsonHelper.DeserializeFromString<ServiceState>(strServiceState);
        Assert.True(serviceState1.securityPosture.posture == serviceState2.securityPosture.posture, "posture mismatch");
        Assert.True(serviceState1.securityPosture.reason == serviceState2.securityPosture.reason, "reason mismatch");
    }

    [Fact]
    public void TestQueueStateSerialization1()
    {
        QueueState queueState1 = new QueueState();
        queueState1.queueUri = "urn:service:sos";
        queueState1.queueLength = 10;
        queueState1.queueMaxLength = 100;
        queueState1.state = QueueState.Active;

        string strQueueState = JsonHelper.SerializeToString(queueState1);
        QueueState queueState2 = JsonHelper.DeserializeFromString<QueueState>(strQueueState);
        Assert.True(queueState1.queueUri == queueState2.queueUri, "queueUri mismatch");
        Assert.True(queueState1.queueLength == queueState2.queueLength, "queueLength mismatch");
        Assert.True(queueState1.queueMaxLength == queueState2.queueMaxLength, "queueMaxLength mismatch");
        Assert.True(queueState1.state == queueState2.state, "state mismatch");
    }
}
