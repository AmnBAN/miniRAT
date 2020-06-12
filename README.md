# miniRAT
### Codename: BatMAN begins
This is miniRAT, a small tool for maintain access after Hacking a system.  
This tool is only for PenTest (Trust me!), please don't use it for illegal actions :)  

The main goal of developing miniRAT is create a lightweight reverse connection to server for running commands, normal tools like plink or other rats are so noisy, if the server don't response to them they try to make many connection and send many SYN packets that IDS can  easily detect them, but miniRAT wait for a random additive increase time for create new connection (additive wait). In other tools you can't change server address easily but in miniRAT you can add secondary (Secondary address). [this features not implement yet :(]

## Features
Develop with C# in Visual studio 2017.  
Silent  
Work with IP or Domain.  
Run CMD commands.  
Reconnect after a additive random wait.  


## Quick Start
Server side run: *miniServer.exe*    
Client side: *miniRAT.exe Server(IP/Domain) port*


## ToDo:
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

## DISCLAIMER
This tool is intended to be used in a legal and legitimate way only:

either on your own systems as a means of learning, of demonstrating what can be done and how, or testing your defense and detection mechanisms
on systems you've been officially and legitimately entitled to perform some security assessments (pentest, security audits)

Quoting Empire's authors

There is no way to build offensive tools useful to the legitimate infosec industry while simultaneously preventing malicious actors from abusing them.

