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
IpHandler IP;
SnifferWorker Sniff;

try
{
    IP = new IpHandler();
    Sniff = new SnifferWorker(true);
    IP.GetAllFoundIP();
    Sniff.Start(this.IP.IpSelected);
}
catch (Exception exc)
{
    throw new Exception(exc);
}
```
