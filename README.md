## Coming soon ![TeamCity (simple build status)](https://img.shields.io/teamcity/http/teamcity.jetbrains.com/s/bt428.svg)  

# miniRAT
### Codename: Resident Evil
This is miniRAT, a small tool for maintain access after Hacking a system.  
This tool is only for PenTest (Trust me!), please don't use it for illegal actions :)  

The main goal of developing miniRAT is create a lightweight reverse connection to server for running commands, normal tools like plink or other rats are so noisy, if the server don't response to them they try to make many connection and send many SYN packets that IDS can  easily detect them, but miniRAT wait for a random additive increase time for create new connection (additive wait). In other tools you can't change server address easily but in miniRAT you can add secondary (Secondary address). [this features not implement yet :(]

## Features
Develop by C# in Visual studio 2017.  
Silent  
Work with IP or Domain.  
Run CMD commands.  
Reconnect after a additive random wait.  


## Quick Start
Server side run: *miniServer.exe*    
Client side: *miniRAT.exe IP/Domain port*


## ToDo
Internal proxy resolver.  
Secondary Server address.  
Update server address.  
Download file.  
Upload file.  
Run binary in memory.  
Encrypt data.  
Linux support.  
Proxy.  
KeepAlive.  
