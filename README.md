# NetworkSniffer
A sniffer for TCP and UDP packages

## IP V4  Protocol Header ##

![IP Header](./images/IpHeader.gif)

## TCP Protocol Header ## 

![TCP Header](./images/tcpHeader.gif)

## UDP Protocol Header ##

![UDP Header](./images/UdpHeader.gif)

## Information Given ##

* [x] IP Version;
* [x] An overall of packages sniffed;
* [x] Total TCP packages sniffed;
* [x] Information about each package header.

## Configuration ##

You will need to execute the application as a administrator, if you are going to run on VS or VS Code, run the VS as an administrator.

## Usage ##

```C#
//get machine local ip's
IPAddress[] hosts = Dns.Resolve(Dns.GetHostName()).AddressList;
//create sniffer for each ip
workers = new SnifferWorker[hosts.Length];

for (int i = 0; i < workers.Length; i++)
{
 //flag if export also the packet data
 workers[i] = new SnifferWorker(true);
 //sign to report event
 workers[i].NewPacket += Worker_NewPacket;
 workers[i].start(hosts[i]);
}

//dont kill the application
while (true) {
 Thread.Sleep(1000);
}
```
