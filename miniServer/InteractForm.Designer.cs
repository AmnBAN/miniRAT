namespace miniServer
{
    partial class InteractForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelAlive = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxCommands = new System.Windows.Forms.GroupBox();
            this.buttonRunPowerShell = new System.Windows.Forms.Button();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.labelParameters = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelExePass = new System.Windows.Forms.Label();
            this.lable_ID = new System.Windows.Forms.Label();
            this.label_HostName = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_Alive = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.groupBoxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label_Alive);
            this.groupBoxInfo.Controls.Add(this.label_Port);
            this.groupBoxInfo.Controls.Add(this.label_IP);
            this.groupBoxInfo.Controls.Add(this.label_HostName);
            this.groupBoxInfo.Controls.Add(this.lable_ID);
            this.groupBoxInfo.Controls.Add(this.labelAlive);
            this.groupBoxInfo.Controls.Add(this.labelPort);
            this.groupBoxInfo.Controls.Add(this.labelIP);
            this.groupBoxInfo.Controls.Add(this.labelHost);
            this.groupBoxInfo.Controls.Add(this.labelID);
            this.groupBoxInfo.ForeColor = System.Drawing.Color.Black;
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(563, 43);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Client Information";
            // 
            // labelAlive
            // 
            this.labelAlive.AutoSize = true;
            this.labelAlive.Location = new System.Drawing.Point(472, 18);
            this.labelAlive.Name = "labelAlive";
            this.labelAlive.Size = new System.Drawing.Size(33, 13);
            this.labelAlive.TabIndex = 4;
            this.labelAlive.Text = "Alive:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(364, 18);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(246, 18);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 13);
            this.labelIP.TabIndex = 2;
            this.labelIP.Text = "IP:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(102, 20);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(63, 13);
            this.labelHost.TabIndex = 1;
            this.labelHost.Text = "Host Name:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.ForeColor = System.Drawing.Color.Black;
            this.labelID.Location = new System.Drawing.Point(7, 20);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(50, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "Client ID:";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.richTextBox1);
            this.groupBoxResults.Location = new System.Drawing.Point(12, 61);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(563, 231);
            this.groupBoxResults.TabIndex = 1;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(7, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(556, 205);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBoxCommands
            // 
            this.groupBoxCommands.Controls.Add(this.buttonRunPowerShell);
            this.groupBoxCommands.Controls.Add(this.ButtonRun);
            this.groupBoxCommands.Controls.Add(this.labelParameters);
            this.groupBoxCommands.Controls.Add(this.comboBox3);
            this.groupBoxCommands.Controls.Add(this.comboBox2);
            this.groupBoxCommands.Controls.Add(this.comboBox1);
            this.groupBoxCommands.Controls.Add(this.labelExePass);
            this.groupBoxCommands.Location = new System.Drawing.Point(19, 299);
            this.groupBoxCommands.Name = "groupBoxCommands";
            this.groupBoxCommands.Size = new System.Drawing.Size(556, 122);
            this.groupBoxCommands.TabIndex = 2;
            this.groupBoxCommands.TabStop = false;
            this.groupBoxCommands.Text = "Commands:";
            this.groupBoxCommands.UseWaitCursor = true;
            // 
            // buttonRunPowerShell
            // 
            this.buttonRunPowerShell.ForeColor = System.Drawing.Color.Black;
            this.buttonRunPowerShell.Location = new System.Drawing.Point(459, 78);
            this.buttonRunPowerShell.Name = "buttonRunPowerShell";
            this.buttonRunPowerShell.Size = new System.Drawing.Size(75, 23);
            this.buttonRunPowerShell.TabIndex = 6;
            this.buttonRunPowerShell.Text = "Run PowerShell";
            this.buttonRunPowerShell.UseVisualStyleBackColor = true;
            this.buttonRunPowerShell.UseWaitCursor = true;
            // 
            // ButtonRun
            // 
            this.ButtonRun.ForeColor = System.Drawing.Color.Black;
            this.ButtonRun.Location = new System.Drawing.Point(459, 38);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonRun.TabIndex = 5;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.UseWaitCursor = true;
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.ForeColor = System.Drawing.Color.Black;
            this.labelParameters.Location = new System.Drawing.Point(138, 19);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(63, 13);
            this.labelParameters.TabIndex = 4;
            this.labelParameters.Text = "Parameters:";
            this.labelParameters.UseWaitCursor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(11, 78);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(432, 21);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.UseWaitCursor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(138, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(305, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.UseWaitCursor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.UseWaitCursor = true;
            // 
            // labelExePass
            // 
            this.labelExePass.AutoSize = true;
            this.labelExePass.ForeColor = System.Drawing.Color.Black;
            this.labelExePass.Location = new System.Drawing.Point(8, 21);
            this.labelExePass.Name = "labelExePass";
            this.labelExePass.Size = new System.Drawing.Size(53, 13);
            this.labelExePass.TabIndex = 0;
            this.labelExePass.Text = "Exe Path:";
            this.labelExePass.UseWaitCursor = true;
            // 
            // lable_ID
            // 
            this.lable_ID.AutoSize = true;
            this.lable_ID.Location = new System.Drawing.Point(64, 20);
            this.lable_ID.Name = "lable_ID";
            this.lable_ID.Size = new System.Drawing.Size(13, 13);
            this.lable_ID.TabIndex = 5;
            this.lable_ID.Text = "0";
            // 
            // label_HostName
            // 
            this.label_HostName.AutoSize = true;
            this.label_HostName.Location = new System.Drawing.Point(169, 20);
            this.label_HostName.Name = "label_HostName";
            this.label_HostName.Size = new System.Drawing.Size(36, 13);
            this.label_HostName.TabIndex = 6;
            this.label_HostName.Text = "PC-12";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(276, 18);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(52, 13);
            this.label_IP.TabIndex = 7;
            this.label_IP.Text = "127.0.0.1";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(396, 18);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(37, 13);
            this.label_Port.TabIndex = 8;
            this.label_Port.Text = "65535";
            // 
            // label_Alive
            // 
            this.label_Alive.AutoSize = true;
            this.label_Alive.Location = new System.Drawing.Point(516, 18);
            this.label_Alive.Name = "label_Alive";
            this.label_Alive.Size = new System.Drawing.Size(21, 13);
            this.label_Alive.TabIndex = 9;
            this.label_Alive.Text = "No";
            // 
            // InteractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 450);
            this.Controls.Add(this.groupBoxCommands);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxInfo);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "InteractForm";
            this.Text = "InteractForm";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxCommands.ResumeLayout(false);
            this.groupBoxCommands.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelAlive;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxCommands;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelExePass;
        private System.Windows.Forms.Button buttonRunPowerShell;
        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.Label label_Alive;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_HostName;
        private System.Windows.Forms.Label lable_ID;
    }
}