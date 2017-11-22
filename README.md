# OpcUaRestInterface
## About
This system is a result of a student project based at Aalborg University, in an collaboration between [School of Information and Communication Technology](http://www.sict.aau.dk/) and [Department of Manufacturing and Engineering](http://www.m-tech.aau.dk/). 
The purpose of the system is to gather all data stored on an OPC/UA enabled device and make it available via a RESTful API interface.

\
Powered by

[![N|Solid](https://opcfoundation.org/wp-content/themes/opc/images/logo.jpg)](https://opcfoundation.org/)

[OPC .NETStandard](https://opcfoundation.org/) and [.NET Core 2.0](https://www.microsoft.com/net/core)

# How to
### Requirements
The system is cross-platform, using .NET Core 2.0. This must be installed in order to run the repository: 
[Tutorial for installing .NET Core 2.0](https://www.microsoft.com/net/learn/get-started)
### Get the system running
First, change directory inside the repository folder:
```sh
$ cd API
```
Then run the solution using .NET Core 2.0:
```sh
$ dotnet run
```
The web server can now be reached on http://localhost:3000

### Add device
A HTTP POST request can be used to add a device to the configuration file, config.json, stored in the API folder on:
http://localhost:3000/api/unit
The device MUST match the config class: 
> Name
> 
> Description
> 
> Url

