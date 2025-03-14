# Introduction
The Ng911Lib project is a class library that provides a set of classes for the data schemas required for implementing Next Generation 9-1-1 (NG9-1-1) applications. This class library provides classes that enable application developers to create, serialize and deserialize JSON and XML documents used in NG9-1-1.

This portable, cross-platform class library is written in the C# language and the library package targets the .NET 7.0 environment. It may be used by applications that target the Windows (version 10 or later) or Linux operating systems.

The following document specifies the design and functional requirements of various functional elements as well as the protocols and interfaces required for those functional elements to communicate with each other.

>[NENA i3 Standard for Next Generation 9-1-1](https://cdn.ymaws.com/www.nena.org/resource/resmgr/standards/nena-sta-010.3b-2021_i3_stan.pdf), National Emergency Number Association (NENA) 911 Core Services Committee, i3 Architecture Working Group, NENA-STA-010.3b-2021, October 7, 2021.

This class library may be used to build many of the NG9-1-1 functional elements described in this standard.

# Documentation
The documentation pages project for this project is located at [https://phrsite.github.io/Ng911Lib](https://phrsite.github.io/Ng911Lib). The documentation web site includes class documentation and articles that explain usage of the classes in this library.

# External Dependancies
This project has no external dependencies.

# Installation
This class library is available on NuGet.

To install it from the .NET CLI type:

```
dotnet add package Ng911Lib --version 1.1.0
```

To install using the NuGET Package Manager Command window type:

```
NuGet\Install-Package Ng911Lib --version 1.1.0
```
Or, you can install it from the Visual Studio GUI.

1. Right click on the project
2. Select Manage NuGet Packages
3. Search for Ng911Lib
4. Click on Install

# Project Structure

## ClassLibrary Directory
This directory contains the project files for the Ng911Lib project and the following subdirectories.

| Directory | Description |
|--------|--------|
| AdditionalData | Provides classes for working with additional data provided with NG9-1-1 calls. RFC 7852 specifies five components of additional data: Provider Information, Device Information, Service Information, Subscriber Information and Comments. This namespace also provides classes for hangling xCard (the XML format of a vCard) and jCard (the JSON format of a vCard). |
| AgencyLocator | Contains data/model classes required by the server side and the client side of the Agency Locator service specified in Sections 4.15 and E.10 of NENA-STA-010.3b. |
| BadActor | Data/model classes for passing data to the bad actor service of a Border Control Function (BCF) |
| CertUtils | Contains utility classes for building self-signed  and signed X.509 certificates that can be used for testing. These classes can build X.509 certificates that include the certificate extensions required for NG9-1-1 systems. See [Public Safety Answering Point (PSAP) Credentialing Agency (PCA) Certificate Policy](https://ng911ioc.org/wp-content/uploads/2023/03/PSAP-Credentialing-Agency-PCA-Certificate-Policy-v1.1-02-22-2023-CLEAN.pdf) |
| CommonAlertingProtocol | Data/model classes for handling Common Alerting Protocol (CAP) calls as specified in the [Common Alerting Protocol Version 1.2 OASIS Standard](http://docs.oasis-open.org/emergency/cap/v1.2/CAP-v1.2-os.pdf)  |
| ConferenceEvent | Data/model classes for the subscribe/notify SIP interface for conference state as specified in RFC 4575 SIP Event Package for Conference State. |
| DiscrepancyReporting | Data/model classes for implementing the client side and the server side of the discrepancy reporting service. These classes can be used by the different functional elements within a NG9-1-1 system. See Sections 3.7 and E.2 of NENA-STA-010.3b. |
| Geocode | Classes for the Geocode Conversion Service specified in Sections 4.5.1, 4.5.2 and E.5 of NENA-STA-010.3b. |
| Held | Classes for the HELD protocol as specified in RFC 5985 HTTP-Enabled Location Delivery |
| HttpUtils | Contains utility classes for performing HTTP operations, such as the AsyncHttpRequestor class which is a general purpose HTTP(S) client for NG9-1-1 applications. |
| I3V3.LogEvents | Data/model classes for NG9-1-1 logging as specified in Sections 4.12.3 and E.8 of NENA-STA-010.3b. Also includes the model classes for the log events specified in the NENA EIDO Conveyance Standard (NENA-STA-024.1a-2023) |
| I3V3.LoggingHelpers | Contains helper classes for logging I3V3 log events. |
| I3SubNot | Data/model classes for handling NG9-1-1 SIP Subscribe/Notify event packages such as Element State, Service State, Queue State, etc. |
| Lost | Data/model classes for handling NG9-1-1 SIP Subscribe/Notify event packages such as Element State, Service State, Queue State, etc. |
| Msag | Data/model classes for the Master Street Address Guide (MSAG) conversion service. See Sections 4.4.1 and E.4 of NENA-STA-010.3b. |
| Ng911Common | Data/model classes used by all REST/JSON schemas defined in NENA-STA-010.3b. |
| NgWebSockets | Contains general purpose classes for performing communications using Web Sockets. |
| Pidf | Data/model and utility classes for dealing with location data in NG9-1-1 applications. |
| PolicyRouting | Data/model classes for implemting the NG9-1-1 policy routing rules. See Sections 3.3.3 and E.1 of NENA-STA-010.3b. |
| PolicyStore | Data/model classes for implementing the server side and the client side of the Policy Store Services defined in Sections 3.3.1 and E.1 of NENA-STA-010.3b. |
| SipRecMetaData | Data/model classes for dealing with the meta data XML document used in the SIP Session Recording (SIPREC) protocol. See RFC 7865 Session Initiation Protocol (SIP) Recording Metadata. |
| TestCall | Data/model classes for the NG9-1-1 test call generator interface. See Sections 4.6.18, 4.6.17.1 and E.6 of NENA-STA-010.3b. |
| Utilities | Utility classes for serializing and deserializing JSON and XML documents. |
| Veds | Data/Model classes for the Vehicle Emergency Data Set (VEDS) used in NG9-1-1 Advanced Automatic Crash Notification (AACN) calls. See RFC 8148 Next-Generation Vehicle-Initiated Emergency Calls and Advanced Automatic Collision Notification (AACN) Vehicle Emergency Data Set (VEDS) [APCO/NENA Candidate ANS 2.102.1.2022](https://www.apcointl.org/~documents/standard/21021-2022-aacn-vehicle-data-set-veds). |


## Testing Directory
This directory contains the following subdirectory.

| Directory | Description |
|--------|--------|
| Ng911UnitTests | xUnit unit test project for the Ng911Lib class library |





