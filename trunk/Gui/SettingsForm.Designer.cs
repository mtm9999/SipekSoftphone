namespace Sipek
{
  partial class SettingsForm
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
      this.tabControlSettings = new System.Windows.Forms.TabControl();
      this.tabPageSettingsSIP = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.textBoxProxyAddress = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxDomain = new System.Windows.Forms.TextBox();
      this.textBoxRegistrarAddress = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBoxPassword = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxUsername = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxDisplayName = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.textBoxAccountName = new System.Windows.Forms.TextBox();
      this.checkBoxDefault = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.checkBoxSecure = new System.Windows.Forms.CheckBox();
      this.label12 = new System.Windows.Forms.Label();
      this.textBoxListenPort = new System.Windows.Forms.TextBox();
      this.tabPageSettingsServices = new System.Windows.Forms.TabPage();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.checkBoxAA = new System.Windows.Forms.CheckBox();
      this.checkBoxDND = new System.Windows.Forms.CheckBox();
      this.groupBoxServices = new System.Windows.Forms.GroupBox();
      this.checkBoxCFB = new System.Windows.Forms.CheckBox();
      this.textBoxCFB = new System.Windows.Forms.TextBox();
      this.checkBoxCFNR = new System.Windows.Forms.CheckBox();
      this.textBoxCFNR = new System.Windows.Forms.TextBox();
      this.checkBoxCFU = new System.Windows.Forms.CheckBox();
      this.textBoxCFU = new System.Windows.Forms.TextBox();
      this.tabPageSettingsAudio = new System.Windows.Forms.TabPage();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.trackBarRecordingBalance = new System.Windows.Forms.TrackBar();
      this.checkBoxRecordingMute = new System.Windows.Forms.CheckBox();
      this.label9 = new System.Windows.Forms.Label();
      this.trackBarRecordingVolume = new System.Windows.Forms.TrackBar();
      this.comboBoxRecordingDevices = new System.Windows.Forms.ComboBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.trackBarPlaybackBalance = new System.Windows.Forms.TrackBar();
      this.comboBoxPlaybackDevices = new System.Windows.Forms.ComboBox();
      this.trackBarPlaybackVolume = new System.Windows.Forms.TrackBar();
      this.checkBoxPlaybackMute = new System.Windows.Forms.CheckBox();
      this.tabCodecsPage = new System.Windows.Forms.TabPage();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.buttonDisable = new System.Windows.Forms.Button();
      this.buttonEnable = new System.Windows.Forms.Button();
      this.listBoxEnCodecs = new System.Windows.Forms.ListBox();
      this.listBoxDisCodecs = new System.Windows.Forms.ListBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.buttonApply = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOK = new System.Windows.Forms.Button();
      this.tabPageAdvanced = new System.Windows.Forms.TabPage();
      this.groupBoxStun = new System.Windows.Forms.GroupBox();
      this.label15 = new System.Windows.Forms.Label();
      this.textBoxStunServerAddress = new System.Windows.Forms.TextBox();
      this.groupBoxSignaling = new System.Windows.Forms.GroupBox();
      this.comboBoxDtmfMode = new System.Windows.Forms.ComboBox();
      this.label16 = new System.Windows.Forms.Label();
      this.tabControlSettings.SuspendLayout();
      this.tabPageSettingsSIP.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox6.SuspendLayout();
      this.tabPageSettingsServices.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBoxServices.SuspendLayout();
      this.tabPageSettingsAudio.SuspendLayout();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingBalance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingVolume)).BeginInit();
      this.groupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackBalance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackVolume)).BeginInit();
      this.tabCodecsPage.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tabPageAdvanced.SuspendLayout();
      this.groupBoxStun.SuspendLayout();
      this.groupBoxSignaling.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControlSettings
      // 
      this.tabControlSettings.Controls.Add(this.tabPageSettingsSIP);
      this.tabControlSettings.Controls.Add(this.tabPageSettingsServices);
      this.tabControlSettings.Controls.Add(this.tabPageSettingsAudio);
      this.tabControlSettings.Controls.Add(this.tabCodecsPage);
      this.tabControlSettings.Controls.Add(this.tabPageAdvanced);
      this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
      this.tabControlSettings.Name = "tabControlSettings";
      this.tabControlSettings.SelectedIndex = 0;
      this.tabControlSettings.Size = new System.Drawing.Size(304, 397);
      this.tabControlSettings.TabIndex = 0;
      // 
      // tabPageSettingsSIP
      // 
      this.tabPageSettingsSIP.Controls.Add(this.groupBox2);
      this.tabPageSettingsSIP.Controls.Add(this.groupBox3);
      this.tabPageSettingsSIP.Controls.Add(this.groupBox6);
      this.tabPageSettingsSIP.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsSIP.Name = "tabPageSettingsSIP";
      this.tabPageSettingsSIP.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsSIP.Size = new System.Drawing.Size(296, 371);
      this.tabPageSettingsSIP.TabIndex = 1;
      this.tabPageSettingsSIP.Text = "SIP";
      this.tabPageSettingsSIP.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label14);
      this.groupBox2.Controls.Add(this.label13);
      this.groupBox2.Controls.Add(this.textBoxProxyAddress);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.textBoxDomain);
      this.groupBox2.Controls.Add(this.textBoxRegistrarAddress);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.textBoxPassword);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.textBoxUsername);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.textBoxDisplayName);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(3, 104);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(290, 184);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "User";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(252, 155);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(31, 13);
      this.label14.TabIndex = 14;
      this.label14.Text = "(opt.)";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(7, 155);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(53, 13);
      this.label13.TabIndex = 13;
      this.label13.Text = "SIP Proxy";
      // 
      // textBoxProxyAddress
      // 
      this.textBoxProxyAddress.Location = new System.Drawing.Point(90, 152);
      this.textBoxProxyAddress.Name = "textBoxProxyAddress";
      this.textBoxProxyAddress.Size = new System.Drawing.Size(155, 20);
      this.textBoxProxyAddress.TabIndex = 9;
      this.textBoxProxyAddress.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 107);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(43, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Domain";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 129);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "SIP Registrar";
      // 
      // textBoxDomain
      // 
      this.textBoxDomain.Location = new System.Drawing.Point(90, 100);
      this.textBoxDomain.Name = "textBoxDomain";
      this.textBoxDomain.Size = new System.Drawing.Size(155, 20);
      this.textBoxDomain.TabIndex = 7;
      this.textBoxDomain.Text = "*";
      this.textBoxDomain.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // textBoxRegistrarAddress
      // 
      this.textBoxRegistrarAddress.Location = new System.Drawing.Point(90, 126);
      this.textBoxRegistrarAddress.Name = "textBoxRegistrarAddress";
      this.textBoxRegistrarAddress.Size = new System.Drawing.Size(155, 20);
      this.textBoxRegistrarAddress.TabIndex = 8;
      this.textBoxRegistrarAddress.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(7, 80);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Password";
      // 
      // textBoxPassword
      // 
      this.textBoxPassword.Location = new System.Drawing.Point(90, 74);
      this.textBoxPassword.Name = "textBoxPassword";
      this.textBoxPassword.PasswordChar = '*';
      this.textBoxPassword.Size = new System.Drawing.Size(155, 20);
      this.textBoxPassword.TabIndex = 6;
      this.textBoxPassword.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 54);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Username";
      // 
      // textBoxUsername
      // 
      this.textBoxUsername.Location = new System.Drawing.Point(90, 48);
      this.textBoxUsername.Name = "textBoxUsername";
      this.textBoxUsername.Size = new System.Drawing.Size(155, 20);
      this.textBoxUsername.TabIndex = 5;
      this.textBoxUsername.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 28);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(72, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Display Name";
      // 
      // textBoxDisplayName
      // 
      this.textBoxDisplayName.Location = new System.Drawing.Point(90, 22);
      this.textBoxDisplayName.Name = "textBoxDisplayName";
      this.textBoxDisplayName.Size = new System.Drawing.Size(155, 20);
      this.textBoxDisplayName.TabIndex = 4;
      this.textBoxDisplayName.ModifiedChanged += new System.EventHandler(this.reregistrationRequired_TextChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.textBoxAccountName);
      this.groupBox3.Controls.Add(this.checkBoxDefault);
      this.groupBox3.Controls.Add(this.label6);
      this.groupBox3.Controls.Add(this.comboBoxAccounts);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox3.Location = new System.Drawing.Point(3, 3);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(290, 101);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Accounts";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 73);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(35, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "Name";
      // 
      // textBoxAccountName
      // 
      this.textBoxAccountName.Location = new System.Drawing.Point(90, 70);
      this.textBoxAccountName.Name = "textBoxAccountName";
      this.textBoxAccountName.Size = new System.Drawing.Size(155, 20);
      this.textBoxAccountName.TabIndex = 3;
      // 
      // checkBoxDefault
      // 
      this.checkBoxDefault.AutoSize = true;
      this.checkBoxDefault.Location = new System.Drawing.Point(90, 47);
      this.checkBoxDefault.Name = "checkBoxDefault";
      this.checkBoxDefault.Size = new System.Drawing.Size(91, 17);
      this.checkBoxDefault.TabIndex = 2;
      this.checkBoxDefault.Text = "Set as default";
      this.checkBoxDefault.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(5, 22);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(79, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "Select account";
      // 
      // comboBoxAccounts
      // 
      this.comboBoxAccounts.FormattingEnabled = true;
      this.comboBoxAccounts.Location = new System.Drawing.Point(90, 19);
      this.comboBoxAccounts.Name = "comboBoxAccounts";
      this.comboBoxAccounts.Size = new System.Drawing.Size(155, 21);
      this.comboBoxAccounts.TabIndex = 0;
      this.comboBoxAccounts.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccounts_SelectedIndexChanged);
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.checkBoxSecure);
      this.groupBox6.Controls.Add(this.label12);
      this.groupBox6.Controls.Add(this.textBoxListenPort);
      this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox6.Location = new System.Drawing.Point(3, 288);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(290, 80);
      this.groupBox6.TabIndex = 12;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Phone";
      // 
      // checkBoxSecure
      // 
      this.checkBoxSecure.AutoSize = true;
      this.checkBoxSecure.Location = new System.Drawing.Point(90, 45);
      this.checkBoxSecure.Name = "checkBoxSecure";
      this.checkBoxSecure.Size = new System.Drawing.Size(89, 17);
      this.checkBoxSecure.TabIndex = 11;
      this.checkBoxSecure.Text = "Secure (TLS)";
      this.checkBoxSecure.UseVisualStyleBackColor = true;
      this.checkBoxSecure.Click += new System.EventHandler(this.restartRequired_TextChanged);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(5, 26);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(70, 13);
      this.label12.TabIndex = 9;
      this.label12.Text = "Listening port";
      // 
      // textBoxListenPort
      // 
      this.textBoxListenPort.Location = new System.Drawing.Point(90, 19);
      this.textBoxListenPort.Name = "textBoxListenPort";
      this.textBoxListenPort.Size = new System.Drawing.Size(56, 20);
      this.textBoxListenPort.TabIndex = 10;
      this.textBoxListenPort.Text = "5060";
      this.textBoxListenPort.ModifiedChanged += new System.EventHandler(this.restartRequired_TextChanged);
      // 
      // tabPageSettingsServices
      // 
      this.tabPageSettingsServices.Controls.Add(this.groupBox1);
      this.tabPageSettingsServices.Controls.Add(this.groupBoxServices);
      this.tabPageSettingsServices.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsServices.Name = "tabPageSettingsServices";
      this.tabPageSettingsServices.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsServices.Size = new System.Drawing.Size(296, 371);
      this.tabPageSettingsServices.TabIndex = 2;
      this.tabPageSettingsServices.Text = "Services";
      this.tabPageSettingsServices.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.comboBox1);
      this.groupBox1.Controls.Add(this.checkBoxAA);
      this.groupBox1.Controls.Add(this.checkBoxDND);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(290, 128);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      // 
      // comboBox1
      // 
      this.comboBox1.FormatString = "N0";
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20"});
      this.comboBox1.Location = new System.Drawing.Point(207, 61);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(41, 21);
      this.comboBox1.TabIndex = 4;
      // 
      // checkBoxAA
      // 
      this.checkBoxAA.AutoSize = true;
      this.checkBoxAA.Location = new System.Drawing.Point(15, 65);
      this.checkBoxAA.Name = "checkBoxAA";
      this.checkBoxAA.Size = new System.Drawing.Size(86, 17);
      this.checkBoxAA.TabIndex = 3;
      this.checkBoxAA.Text = "Auto Answer";
      this.checkBoxAA.UseVisualStyleBackColor = true;
      // 
      // checkBoxDND
      // 
      this.checkBoxDND.AutoSize = true;
      this.checkBoxDND.Location = new System.Drawing.Point(15, 30);
      this.checkBoxDND.Name = "checkBoxDND";
      this.checkBoxDND.Size = new System.Drawing.Size(96, 17);
      this.checkBoxDND.TabIndex = 2;
      this.checkBoxDND.Text = "Do Not Disturb";
      this.checkBoxDND.UseVisualStyleBackColor = true;
      // 
      // groupBoxServices
      // 
      this.groupBoxServices.Controls.Add(this.checkBoxCFB);
      this.groupBoxServices.Controls.Add(this.textBoxCFB);
      this.groupBoxServices.Controls.Add(this.checkBoxCFNR);
      this.groupBoxServices.Controls.Add(this.textBoxCFNR);
      this.groupBoxServices.Controls.Add(this.checkBoxCFU);
      this.groupBoxServices.Controls.Add(this.textBoxCFU);
      this.groupBoxServices.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBoxServices.Location = new System.Drawing.Point(3, 131);
      this.groupBoxServices.Name = "groupBoxServices";
      this.groupBoxServices.Size = new System.Drawing.Size(290, 237);
      this.groupBoxServices.TabIndex = 0;
      this.groupBoxServices.TabStop = false;
      this.groupBoxServices.Text = "Forwardings....";
      // 
      // checkBoxCFB
      // 
      this.checkBoxCFB.AutoSize = true;
      this.checkBoxCFB.Location = new System.Drawing.Point(15, 87);
      this.checkBoxCFB.Name = "checkBoxCFB";
      this.checkBoxCFB.Size = new System.Drawing.Size(66, 17);
      this.checkBoxCFB.TabIndex = 5;
      this.checkBoxCFB.Text = "On Busy";
      this.checkBoxCFB.UseVisualStyleBackColor = true;
      // 
      // textBoxCFB
      // 
      this.textBoxCFB.Location = new System.Drawing.Point(120, 84);
      this.textBoxCFB.Name = "textBoxCFB";
      this.textBoxCFB.Size = new System.Drawing.Size(128, 20);
      this.textBoxCFB.TabIndex = 4;
      // 
      // checkBoxCFNR
      // 
      this.checkBoxCFNR.AutoSize = true;
      this.checkBoxCFNR.Location = new System.Drawing.Point(15, 61);
      this.checkBoxCFNR.Name = "checkBoxCFNR";
      this.checkBoxCFNR.Size = new System.Drawing.Size(70, 17);
      this.checkBoxCFNR.TabIndex = 3;
      this.checkBoxCFNR.Text = "No Reply";
      this.checkBoxCFNR.UseVisualStyleBackColor = true;
      // 
      // textBoxCFNR
      // 
      this.textBoxCFNR.Location = new System.Drawing.Point(120, 58);
      this.textBoxCFNR.Name = "textBoxCFNR";
      this.textBoxCFNR.Size = new System.Drawing.Size(128, 20);
      this.textBoxCFNR.TabIndex = 2;
      // 
      // checkBoxCFU
      // 
      this.checkBoxCFU.AutoSize = true;
      this.checkBoxCFU.Location = new System.Drawing.Point(15, 35);
      this.checkBoxCFU.Name = "checkBoxCFU";
      this.checkBoxCFU.Size = new System.Drawing.Size(91, 17);
      this.checkBoxCFU.TabIndex = 1;
      this.checkBoxCFU.Text = "Unconditional";
      this.checkBoxCFU.UseVisualStyleBackColor = true;
      // 
      // textBoxCFU
      // 
      this.textBoxCFU.Location = new System.Drawing.Point(120, 32);
      this.textBoxCFU.Name = "textBoxCFU";
      this.textBoxCFU.Size = new System.Drawing.Size(128, 20);
      this.textBoxCFU.TabIndex = 0;
      // 
      // tabPageSettingsAudio
      // 
      this.tabPageSettingsAudio.Controls.Add(this.groupBox5);
      this.tabPageSettingsAudio.Controls.Add(this.groupBox4);
      this.tabPageSettingsAudio.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsAudio.Name = "tabPageSettingsAudio";
      this.tabPageSettingsAudio.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsAudio.Size = new System.Drawing.Size(296, 371);
      this.tabPageSettingsAudio.TabIndex = 0;
      this.tabPageSettingsAudio.Text = "Audio";
      this.tabPageSettingsAudio.UseVisualStyleBackColor = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.trackBarRecordingBalance);
      this.groupBox5.Controls.Add(this.checkBoxRecordingMute);
      this.groupBox5.Controls.Add(this.label9);
      this.groupBox5.Controls.Add(this.trackBarRecordingVolume);
      this.groupBox5.Controls.Add(this.comboBoxRecordingDevices);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(3, 180);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(290, 188);
      this.groupBox5.TabIndex = 1;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Recording";
      // 
      // trackBarRecordingBalance
      // 
      this.trackBarRecordingBalance.LargeChange = 50;
      this.trackBarRecordingBalance.Location = new System.Drawing.Point(216, 104);
      this.trackBarRecordingBalance.Maximum = 320;
      this.trackBarRecordingBalance.Minimum = -320;
      this.trackBarRecordingBalance.Name = "trackBarRecordingBalance";
      this.trackBarRecordingBalance.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.trackBarRecordingBalance.Size = new System.Drawing.Size(42, 65);
      this.trackBarRecordingBalance.SmallChange = 10;
      this.trackBarRecordingBalance.TabIndex = 5;
      this.trackBarRecordingBalance.TickFrequency = 320;
      this.trackBarRecordingBalance.TickStyle = System.Windows.Forms.TickStyle.Both;
      // 
      // checkBoxRecordingMute
      // 
      this.checkBoxRecordingMute.AutoSize = true;
      this.checkBoxRecordingMute.Location = new System.Drawing.Point(130, 73);
      this.checkBoxRecordingMute.Name = "checkBoxRecordingMute";
      this.checkBoxRecordingMute.Size = new System.Drawing.Size(50, 17);
      this.checkBoxRecordingMute.TabIndex = 4;
      this.checkBoxRecordingMute.Text = "Mute";
      this.checkBoxRecordingMute.UseVisualStyleBackColor = true;
      this.checkBoxRecordingMute.Click += new System.EventHandler(this.checkBoxPlaybackMute_CheckedChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(8, 77);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(94, 13);
      this.label9.TabIndex = 3;
      this.label9.Text = "Recording Volume";
      // 
      // trackBarRecordingVolume
      // 
      this.trackBarRecordingVolume.LargeChange = 10000;
      this.trackBarRecordingVolume.Location = new System.Drawing.Point(10, 115);
      this.trackBarRecordingVolume.Maximum = 65535;
      this.trackBarRecordingVolume.Name = "trackBarRecordingVolume";
      this.trackBarRecordingVolume.Size = new System.Drawing.Size(170, 42);
      this.trackBarRecordingVolume.SmallChange = 6553;
      this.trackBarRecordingVolume.TabIndex = 1;
      this.trackBarRecordingVolume.TickFrequency = 6553;
      this.trackBarRecordingVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackBarRecordingVolume.ValueChanged += new System.EventHandler(this.trackBarRecordingVolume_ValueChanged);
      // 
      // comboBoxRecordingDevices
      // 
      this.comboBoxRecordingDevices.FormattingEnabled = true;
      this.comboBoxRecordingDevices.Location = new System.Drawing.Point(11, 29);
      this.comboBoxRecordingDevices.Name = "comboBoxRecordingDevices";
      this.comboBoxRecordingDevices.Size = new System.Drawing.Size(199, 21);
      this.comboBoxRecordingDevices.TabIndex = 0;
      this.comboBoxRecordingDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecordingDevices_SelectedIndexChanged);
      // 
      // groupBox4
      // 
      this.groupBox4.BackColor = System.Drawing.Color.Transparent;
      this.groupBox4.Controls.Add(this.label8);
      this.groupBox4.Controls.Add(this.trackBarPlaybackBalance);
      this.groupBox4.Controls.Add(this.comboBoxPlaybackDevices);
      this.groupBox4.Controls.Add(this.trackBarPlaybackVolume);
      this.groupBox4.Controls.Add(this.checkBoxPlaybackMute);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox4.Location = new System.Drawing.Point(3, 3);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(290, 177);
      this.groupBox4.TabIndex = 0;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Playback";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(8, 55);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(77, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "Master Volume";
      // 
      // trackBarPlaybackBalance
      // 
      this.trackBarPlaybackBalance.LargeChange = 50;
      this.trackBarPlaybackBalance.Location = new System.Drawing.Point(216, 67);
      this.trackBarPlaybackBalance.Maximum = 320;
      this.trackBarPlaybackBalance.Minimum = -320;
      this.trackBarPlaybackBalance.Name = "trackBarPlaybackBalance";
      this.trackBarPlaybackBalance.Orientation = System.Windows.Forms.Orientation.Vertical;
      this.trackBarPlaybackBalance.Size = new System.Drawing.Size(42, 65);
      this.trackBarPlaybackBalance.SmallChange = 10;
      this.trackBarPlaybackBalance.TabIndex = 1;
      this.trackBarPlaybackBalance.TickFrequency = 320;
      this.trackBarPlaybackBalance.TickStyle = System.Windows.Forms.TickStyle.Both;
      this.trackBarPlaybackBalance.ValueChanged += new System.EventHandler(this.trackBarPlaybackBalance_ValueChanged);
      // 
      // comboBoxPlaybackDevices
      // 
      this.comboBoxPlaybackDevices.FormattingEnabled = true;
      this.comboBoxPlaybackDevices.Location = new System.Drawing.Point(10, 19);
      this.comboBoxPlaybackDevices.Name = "comboBoxPlaybackDevices";
      this.comboBoxPlaybackDevices.Size = new System.Drawing.Size(200, 21);
      this.comboBoxPlaybackDevices.TabIndex = 3;
      this.comboBoxPlaybackDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaybackDevices_SelectedIndexChanged);
      // 
      // trackBarPlaybackVolume
      // 
      this.trackBarPlaybackVolume.Cursor = System.Windows.Forms.Cursors.Default;
      this.trackBarPlaybackVolume.LargeChange = 10000;
      this.trackBarPlaybackVolume.Location = new System.Drawing.Point(10, 90);
      this.trackBarPlaybackVolume.Maximum = 65535;
      this.trackBarPlaybackVolume.Name = "trackBarPlaybackVolume";
      this.trackBarPlaybackVolume.Size = new System.Drawing.Size(166, 42);
      this.trackBarPlaybackVolume.SmallChange = 6553;
      this.trackBarPlaybackVolume.TabIndex = 2;
      this.trackBarPlaybackVolume.TickFrequency = 6553;
      this.trackBarPlaybackVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackBarPlaybackVolume.ValueChanged += new System.EventHandler(this.trackBarPlaybackVolume_ValueChanged);
      // 
      // checkBoxPlaybackMute
      // 
      this.checkBoxPlaybackMute.AutoSize = true;
      this.checkBoxPlaybackMute.Location = new System.Drawing.Point(121, 51);
      this.checkBoxPlaybackMute.Name = "checkBoxPlaybackMute";
      this.checkBoxPlaybackMute.Size = new System.Drawing.Size(50, 17);
      this.checkBoxPlaybackMute.TabIndex = 0;
      this.checkBoxPlaybackMute.Text = "Mute";
      this.checkBoxPlaybackMute.UseVisualStyleBackColor = true;
      this.checkBoxPlaybackMute.CheckedChanged += new System.EventHandler(this.checkBoxPlaybackMute_CheckedChanged);
      // 
      // tabCodecsPage
      // 
      this.tabCodecsPage.Controls.Add(this.label11);
      this.tabCodecsPage.Controls.Add(this.label10);
      this.tabCodecsPage.Controls.Add(this.buttonDisable);
      this.tabCodecsPage.Controls.Add(this.buttonEnable);
      this.tabCodecsPage.Controls.Add(this.listBoxEnCodecs);
      this.tabCodecsPage.Controls.Add(this.listBoxDisCodecs);
      this.tabCodecsPage.Location = new System.Drawing.Point(4, 22);
      this.tabCodecsPage.Name = "tabCodecsPage";
      this.tabCodecsPage.Padding = new System.Windows.Forms.Padding(3);
      this.tabCodecsPage.Size = new System.Drawing.Size(296, 371);
      this.tabCodecsPage.TabIndex = 3;
      this.tabCodecsPage.Text = "Codecs";
      this.tabCodecsPage.UseVisualStyleBackColor = true;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(169, 11);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(87, 13);
      this.label11.TabIndex = 5;
      this.label11.Text = "Enabled codecs:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(9, 12);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(89, 13);
      this.label10.TabIndex = 4;
      this.label10.Text = "Disabled codecs:";
      // 
      // buttonDisable
      // 
      this.buttonDisable.Location = new System.Drawing.Point(135, 84);
      this.buttonDisable.Name = "buttonDisable";
      this.buttonDisable.Size = new System.Drawing.Size(29, 23);
      this.buttonDisable.TabIndex = 3;
      this.buttonDisable.Text = "<=";
      this.buttonDisable.UseVisualStyleBackColor = true;
      this.buttonDisable.Click += new System.EventHandler(this.buttonDisable_Click);
      // 
      // buttonEnable
      // 
      this.buttonEnable.Location = new System.Drawing.Point(135, 44);
      this.buttonEnable.Name = "buttonEnable";
      this.buttonEnable.Size = new System.Drawing.Size(29, 23);
      this.buttonEnable.TabIndex = 2;
      this.buttonEnable.Text = "=>";
      this.buttonEnable.UseVisualStyleBackColor = true;
      this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
      // 
      // listBoxEnCodecs
      // 
      this.listBoxEnCodecs.FormattingEnabled = true;
      this.listBoxEnCodecs.Location = new System.Drawing.Point(169, 31);
      this.listBoxEnCodecs.Name = "listBoxEnCodecs";
      this.listBoxEnCodecs.Size = new System.Drawing.Size(120, 303);
      this.listBoxEnCodecs.TabIndex = 1;
      // 
      // listBoxDisCodecs
      // 
      this.listBoxDisCodecs.FormattingEnabled = true;
      this.listBoxDisCodecs.Location = new System.Drawing.Point(8, 31);
      this.listBoxDisCodecs.Name = "listBoxDisCodecs";
      this.listBoxDisCodecs.Size = new System.Drawing.Size(120, 303);
      this.listBoxDisCodecs.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.buttonApply);
      this.panel2.Controls.Add(this.buttonCancel);
      this.panel2.Controls.Add(this.buttonOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 403);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(304, 49);
      this.panel2.TabIndex = 12;
      // 
      // buttonApply
      // 
      this.buttonApply.Location = new System.Drawing.Point(103, 16);
      this.buttonApply.Name = "buttonApply";
      this.buttonApply.Size = new System.Drawing.Size(75, 23);
      this.buttonApply.TabIndex = 2;
      this.buttonApply.Text = "Apply";
      this.buttonApply.UseVisualStyleBackColor = true;
      this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(17, 16);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOK
      // 
      this.buttonOK.Location = new System.Drawing.Point(190, 16);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // tabPageAdvanced
      // 
      this.tabPageAdvanced.Controls.Add(this.groupBoxSignaling);
      this.tabPageAdvanced.Controls.Add(this.groupBoxStun);
      this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
      this.tabPageAdvanced.Name = "tabPageAdvanced";
      this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageAdvanced.Size = new System.Drawing.Size(296, 371);
      this.tabPageAdvanced.TabIndex = 4;
      this.tabPageAdvanced.Text = "Advanced";
      this.tabPageAdvanced.UseVisualStyleBackColor = true;
      // 
      // groupBoxStun
      // 
      this.groupBoxStun.Controls.Add(this.textBoxStunServerAddress);
      this.groupBoxStun.Controls.Add(this.label15);
      this.groupBoxStun.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBoxStun.Location = new System.Drawing.Point(3, 3);
      this.groupBoxStun.Name = "groupBoxStun";
      this.groupBoxStun.Size = new System.Drawing.Size(290, 74);
      this.groupBoxStun.TabIndex = 0;
      this.groupBoxStun.TabStop = false;
      this.groupBoxStun.Text = "Stun";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(7, 30);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(61, 13);
      this.label15.TabIndex = 0;
      this.label15.Text = "Stun server";
      // 
      // textBoxStunServerAddress
      // 
      this.textBoxStunServerAddress.Location = new System.Drawing.Point(84, 27);
      this.textBoxStunServerAddress.Name = "textBoxStunServerAddress";
      this.textBoxStunServerAddress.Size = new System.Drawing.Size(174, 20);
      this.textBoxStunServerAddress.TabIndex = 1;
      // 
      // groupBoxSignaling
      // 
      this.groupBoxSignaling.Controls.Add(this.label16);
      this.groupBoxSignaling.Controls.Add(this.comboBoxDtmfMode);
      this.groupBoxSignaling.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBoxSignaling.Location = new System.Drawing.Point(3, 77);
      this.groupBoxSignaling.Name = "groupBoxSignaling";
      this.groupBoxSignaling.Size = new System.Drawing.Size(290, 291);
      this.groupBoxSignaling.TabIndex = 1;
      this.groupBoxSignaling.TabStop = false;
      this.groupBoxSignaling.Text = "Signalling";
      // 
      // comboBoxDtmfMode
      // 
      this.comboBoxDtmfMode.FormattingEnabled = true;
      this.comboBoxDtmfMode.Items.AddRange(new object[] {
            "Out-of-band (INFO)",
            "Inband (rfc2833)",
            "Transparent"});
      this.comboBoxDtmfMode.Location = new System.Drawing.Point(84, 30);
      this.comboBoxDtmfMode.Name = "comboBoxDtmfMode";
      this.comboBoxDtmfMode.Size = new System.Drawing.Size(174, 21);
      this.comboBoxDtmfMode.TabIndex = 0;
      this.comboBoxDtmfMode.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(7, 33);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(59, 13);
      this.label16.TabIndex = 1;
      this.label16.Text = "Dtmf Mode";
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(304, 452);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.tabControlSettings);
      this.Name = "SettingsForm";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.SettingsForm_Load);
      this.tabControlSettings.ResumeLayout(false);
      this.tabPageSettingsSIP.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      this.groupBox6.PerformLayout();
      this.tabPageSettingsServices.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBoxServices.ResumeLayout(false);
      this.groupBoxServices.PerformLayout();
      this.tabPageSettingsAudio.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingBalance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingVolume)).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackBalance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackVolume)).EndInit();
      this.tabCodecsPage.ResumeLayout(false);
      this.tabCodecsPage.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.tabPageAdvanced.ResumeLayout(false);
      this.groupBoxStun.ResumeLayout(false);
      this.groupBoxStun.PerformLayout();
      this.groupBoxSignaling.ResumeLayout(false);
      this.groupBoxSignaling.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControlSettings;
    private System.Windows.Forms.TabPage tabPageSettingsAudio;
    private System.Windows.Forms.TabPage tabPageSettingsSIP;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.CheckBox checkBoxDefault;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox comboBoxAccounts;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox textBoxAccountName;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxDomain;
    private System.Windows.Forms.TextBox textBoxRegistrarAddress;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxPassword;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxUsername;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxDisplayName;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button buttonApply;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.TabPage tabPageSettingsServices;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBoxServices;
    private System.Windows.Forms.CheckBox checkBoxCFB;
    private System.Windows.Forms.TextBox textBoxCFB;
    private System.Windows.Forms.CheckBox checkBoxCFNR;
    private System.Windows.Forms.TextBox textBoxCFNR;
    private System.Windows.Forms.CheckBox checkBoxCFU;
    private System.Windows.Forms.TextBox textBoxCFU;
    private System.Windows.Forms.CheckBox checkBoxAA;
    private System.Windows.Forms.CheckBox checkBoxDND;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.CheckBox checkBoxPlaybackMute;
    private System.Windows.Forms.TrackBar trackBarPlaybackBalance;
    private System.Windows.Forms.TrackBar trackBarPlaybackVolume;
    private System.Windows.Forms.ComboBox comboBoxPlaybackDevices;
    private System.Windows.Forms.ComboBox comboBoxRecordingDevices;
    private System.Windows.Forms.TrackBar trackBarRecordingVolume;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.CheckBox checkBoxRecordingMute;
    private System.Windows.Forms.TabPage tabCodecsPage;
    private System.Windows.Forms.ListBox listBoxDisCodecs;
    private System.Windows.Forms.ListBox listBoxEnCodecs;
    private System.Windows.Forms.Button buttonDisable;
    private System.Windows.Forms.Button buttonEnable;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox textBoxListenPort;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox textBoxProxyAddress;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TrackBar trackBarRecordingBalance;
    private System.Windows.Forms.CheckBox checkBoxSecure;
    private System.Windows.Forms.TabPage tabPageAdvanced;
    private System.Windows.Forms.GroupBox groupBoxStun;
    private System.Windows.Forms.TextBox textBoxStunServerAddress;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.GroupBox groupBoxSignaling;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.ComboBox comboBoxDtmfMode;
  }
}