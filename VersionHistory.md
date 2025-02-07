# Version History

## v1.0.0 - 25 Apr 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA       |  New      | Initial version |

## v1.0.1 - 6 May 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA       |  Addition      | Added the HttpUtils namespace and the AsyncHttpRequestor class |
| NA | Change | Changed the name of the I3LogEvents namespace to I3V3.LogEvents |
| NA | Addition | Added log event model classes for the log events defined in the NENA EIDO Conveyance Standard (NENA-STA-024.1a-2023) |
| NA | Change | Added a new class called CallLogEvent to the I3V3.LogEvents namespace and changed the base class of CallStartLogEvent, CallEndLogEvent, RecCallStartLogEvent and RecCallEndLogEvent from LogEvent to CallLogEvent.  |
| NA | Addition | Added the I3LogEventClient class to the I3V3.LoggingHelpers namespace |

## v1.0.2 - 9 June 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA| Addition | Added the I3LogEventClientMgr class that supports I3V3 logging to multiple I3V3 event loggers. |

## v1.0.3 - 19 Jun 2023
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA| Addition | Added the queryId property to the SubscriptionTerminatedLogEvent class. |

## v1.0.4 - TBD
| Issue No. | Change Type | Description |
|--------|--------|-------|
| NA| Addition | Added a constructor parameter called Enabled to the I3LogEventClient class. This parameter defaults to true. |
| NA  | Addition | Added a new bool property called Enable to the I3LogEventClient class. If enabled, the I3LogEventClient will send log events to the log event server. If not enabled the I3ClogEventClient class will run but will no attempt to communicate with the log event server. |
| NA  | Fix    | Changed ContentTypes.ConferenceEvent from application/conference+xml to application/conference-info+xml to comply with Section 9.2 of RFC 4575. |
| NA  | Addition | Added Eido = "emergency-eido" to PurposeTypes and Eido = "application/emergency.eido+json to ContentTypes" |
