# Version History

## v2.0.1 -- 29 Sep 2025
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA | Addition | Ng911CertUtils.KeyUsageParams class -- Added the codeSigning property |
| NA | Addition | Ng911CertUtils.CertUtils class -- Added support for the Code Signing Enhanced Key Usage Extension for an X.509 certificate. |

## v2.0.0 -- 3 Sep 2025
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA | Change | Changed the target from .NET 7 to .NET 9 |
| NA | Change | Ng911CertUtils.CertUtils class -- Changed from using "new X509Certificate2()" to X509CertificateLoader.LoadPkcs12() because loading the certificate in the constructor is now obsolete in .NET 9. |
| NA | Change | I3SubNot/ElementState.cs: Changed the ElementStateType class from public to internal. Added the state, elementDomain and reason properties to the ElementState class. Added definitions for constants the allowable values for the state property of the ElementState class. Added the ElementStateValues property to the ElementState class. Added new constructors to the ElementState class. |
| NA | Change | I3SubNot/ServiceState.cs: Added string constant definitions to the ServiceType class for the name property. Added the ServiceTypeValues property to the ServiceType class. Added string constant definitions to the ServiceStateType class for the state property. Added the ServiceStateValues property to the ServiceStateType class. Added string constant definitions to the SecurityPostureType class for the posture property. Added the SecurityPostureValues property to the SecurityPostureType class. |
| NA | Addition | I3SubNot.ServiceState.cs: Added a property called serviceId per Section 2.4.2 of NENA-STA-010.3f |
| NA | Change | I3SubNot/QueueState.cs: Changed the QueueStateType class from public to internal. Added the queueState, queueUri, queueLength, queueMaxLength and state properties to the QueueState class. Added string constants for the state property of the QueueState class. Added the QueueStateValues property to the QueueState class. |

## v1.1.0 - 25 Feb 2025
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA | Addition | Added a constructor parameter called Enabled to the I3LogEventClient class. This parameter defaults to true. |
| NA | Addition | Added a new bool property called Enable to the I3LogEventClient class. If enabled, the I3LogEventClient will send log events to the log event server. If not enabled the I3ClogEventClient class will run but will no attempt to communicate with the log event server. |
| NA | Fix    | Changed ContentTypes.ConferenceEvent from application/conference+xml to application/conference-info+xml to comply with Section 9.2 of RFC 4575. |
| NA | Addition | Added Eido = "emergency-eido" to PurposeTypes and Eido = "application/emergency.eido+json to ContentTypes" |
| NA | Change   | Changed the Target Framework from .NET 7.0 to .NET 8.0 |

## v1.0.3 - 19 Jun 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA| Addition | Added the queryId property to the SubscriptionTerminatedLogEvent class. |

## v1.0.2 - 9 June 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA| Addition | Added the I3LogEventClientMgr class that supports I3V3 logging to multiple I3V3 event loggers. |

## v1.0.1 - 6 May 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA       |  Addition      | Added the HttpUtils namespace and the AsyncHttpRequestor class |
| NA | Change | Changed the name of the I3LogEvents namespace to I3V3.LogEvents |
| NA | Addition | Added log event model classes for the log events defined in the NENA EIDO Conveyance Standard (NENA-STA-024.1a-2023) |
| NA | Change | Added a new class called CallLogEvent to the I3V3.LogEvents namespace and changed the base class of CallStartLogEvent, CallEndLogEvent, RecCallStartLogEvent and RecCallEndLogEvent from LogEvent to CallLogEvent.  |
| NA | Addition | Added the I3LogEventClient class to the I3V3.LoggingHelpers namespace |

## v1.0.0 - 25 Apr 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA       |  New      | Initial version |



