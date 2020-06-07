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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InteractForm));
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
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
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.comboBoxRun = new System.Windows.Forms.ComboBox();
            this.labelExePass = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelPort);
            this.groupBoxInfo.Controls.Add(this.labelIP);
            this.groupBoxInfo.Controls.Add(this.labelHost);
            this.groupBoxInfo.Controls.Add(this.labelID);
            this.groupBoxInfo.ForeColor = System.Drawing.Color.Black;
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(586, 43);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Client Information";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(442, 20);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Port:";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(314, 20);
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
            this.groupBoxResults.Location = new System.Drawing.Point(12, 61);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(586, 231);
            this.groupBoxResults.TabIndex = 1;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(22, 81);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(579, 205);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBoxCommands
            // 
            this.groupBoxCommands.Controls.Add(this.buttonRunPowerShell);
            this.groupBoxCommands.Controls.Add(this.ButtonRun);
            this.groupBoxCommands.Controls.Add(this.labelParameters);
            this.groupBoxCommands.Controls.Add(this.comboBox3);
            this.groupBoxCommands.Controls.Add(this.comboBoxParameters);
            this.groupBoxCommands.Controls.Add(this.comboBoxRun);
            this.groupBoxCommands.Controls.Add(this.labelExePass);
            this.groupBoxCommands.Location = new System.Drawing.Point(19, 299);
            this.groupBoxCommands.Name = "groupBoxCommands";
            this.groupBoxCommands.Size = new System.Drawing.Size(579, 122);
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
            this.buttonRunPowerShell.Size = new System.Drawing.Size(97, 23);
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
            this.ButtonRun.Size = new System.Drawing.Size(97, 23);
            this.ButtonRun.TabIndex = 5;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.UseWaitCursor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
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
            this.comboBox3.Items.AddRange(new object[] {
            "Get-ChildItem",
            "ls -recurse",
            "Copy-Item src.txt dst.txt",
            "Get-Location"});
            this.comboBox3.Location = new System.Drawing.Point(11, 78);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(432, 21);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.Text = "Get-Location";
            this.comboBox3.UseWaitCursor = true;
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Items.AddRange(new object[] {
            "cd",
            "dir c:",
            "dir d:",
            "dir",
            "net users",
            "query session",
            "query user",
            "ver",
            "netstat -n",
            "net user Help /add",
            "Netsh firewall show opmode"});
            this.comboBoxParameters.Location = new System.Drawing.Point(138, 38);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(305, 21);
            this.comboBoxParameters.TabIndex = 2;
            this.comboBoxParameters.Text = "dir";
            this.comboBoxParameters.UseWaitCursor = true;
            // 
            // comboBoxRun
            // 
            this.comboBoxRun.FormattingEnabled = true;
            this.comboBoxRun.Items.AddRange(new object[] {
            "cmd.exe",
            "nc.exe",
            "nc64.exe"});
            this.comboBoxRun.Location = new System.Drawing.Point(11, 38);
            this.comboBoxRun.Name = "comboBoxRun";
            this.comboBoxRun.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRun.TabIndex = 1;
            this.comboBoxRun.Text = "cmd.exe";
            this.comboBoxRun.UseWaitCursor = true;
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
            // InteractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 452);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxCommands);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxInfo);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InteractForm";
            this.Text = "InteractForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InteractForm_FormClosed);
            this.Load += new System.EventHandler(this.InteractForm_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxCommands.ResumeLayout(false);
            this.groupBoxCommands.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxCommands;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        private System.Windows.Forms.ComboBox comboBoxRun;
        private System.Windows.Forms.Label labelExePass;
        private System.Windows.Forms.Button buttonRunPowerShell;
        private System.Windows.Forms.Button ButtonRun;
    }
}