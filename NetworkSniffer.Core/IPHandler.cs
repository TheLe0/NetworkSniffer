using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace NetworkSniffer.Core
{
    public class IpHandler
    {
        public List<IPAddress> IpList;
        public string ErrMsg { set; get; }

        private IPHostEntry HostEntry;
        private Regex _rx;

        public IPAddress IpSelected { get; set; }

        public IpHandler()
        {
            _rx = new Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");
            try
            {
                this.IpList = new List<IPAddress>();
                this.ErrMsg = "";

                this.HostEntry = Dns.GetHostEntry((Dns.GetHostName()));
                if (HostEntry.AddressList.Length > 0)
                {
                    foreach (IPAddress ip in HostEntry.AddressList)
                    {
                        if (_rx.IsMatch(ip.ToString()))
                        {
                            this.IpList.Add(ip);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("IpHandler constructor exception: " + e.ToString());
            }

        }

        public void GetAllFoundIP()
        {
            int i = 0;
            foreach (IPAddress ip in IpList)
            {
                Console.WriteLine(IpList.IndexOf(ip)+") Ip: "+ip);
                i++;
            }

        }

        public bool SetIp(int ip)
        {

            if (ip < 0 || ip >= this.IpList.Count)
            {
                this.ErrMsg = "IP index out of range";
                return false;
            }

            if (!_rx.IsMatch(this.IpList[ip].ToString()))
            {
                this.ErrMsg = "IP v6 sniffing not supported";
                return false;
            }

            this.IpSelected = this.IpList[ip];
            return true;
        }

    }
}
