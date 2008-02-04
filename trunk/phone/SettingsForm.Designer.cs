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
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxDomain = new System.Windows.Forms.TextBox();
      this.textBoxProxyAddress = new System.Windows.Forms.TextBox();
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
      this.tabPageSettingsGeneral = new System.Windows.Forms.TabPage();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.checkBoxRecordingMute = new System.Windows.Forms.CheckBox();
      this.label9 = new System.Windows.Forms.Label();
      this.checkBoxSelectMic = new System.Windows.Forms.CheckBox();
      this.trackBarRecordingVolume = new System.Windows.Forms.TrackBar();
      this.comboBoxRecordingDevices = new System.Windows.Forms.ComboBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.trackBarPlaybackBalance = new System.Windows.Forms.TrackBar();
      this.comboBoxPlaybackDevices = new System.Windows.Forms.ComboBox();
      this.trackBarPlaybackVolume = new System.Windows.Forms.TrackBar();
      this.checkBoxPlaybackMute = new System.Windows.Forms.CheckBox();
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.buttonApply = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonOK = new System.Windows.Forms.Button();
      this.tabControlSettings.SuspendLayout();
      this.tabPageSettingsSIP.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.tabPageSettingsGeneral.SuspendLayout();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingVolume)).BeginInit();
      this.groupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackBalance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackVolume)).BeginInit();
      this.tabPageSettingsServices.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBoxServices.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControlSettings
      // 
      this.tabControlSettings.Controls.Add(this.tabPageSettingsSIP);
      this.tabControlSettings.Controls.Add(this.tabPageSettingsGeneral);
      this.tabControlSettings.Controls.Add(this.tabPageSettingsServices);
      this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Top;
      this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
      this.tabControlSettings.Name = "tabControlSettings";
      this.tabControlSettings.SelectedIndex = 0;
      this.tabControlSettings.Size = new System.Drawing.Size(275, 350);
      this.tabControlSettings.TabIndex = 0;
      // 
      // tabPageSettingsSIP
      // 
      this.tabPageSettingsSIP.Controls.Add(this.groupBox2);
      this.tabPageSettingsSIP.Controls.Add(this.groupBox3);
      this.tabPageSettingsSIP.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsSIP.Name = "tabPageSettingsSIP";
      this.tabPageSettingsSIP.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsSIP.Size = new System.Drawing.Size(267, 324);
      this.tabPageSettingsSIP.TabIndex = 1;
      this.tabPageSettingsSIP.Text = "SIP";
      this.tabPageSettingsSIP.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.textBoxDomain);
      this.groupBox2.Controls.Add(this.textBoxProxyAddress);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.textBoxPassword);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.textBoxUsername);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.textBoxDisplayName);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(3, 110);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(261, 211);
      this.groupBox2.TabIndex = 10;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "User";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 155);
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
      this.label1.Size = new System.Drawing.Size(95, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "SIP Proxy/registrar";
      // 
      // textBoxDomain
      // 
      this.textBoxDomain.Location = new System.Drawing.Point(108, 149);
      this.textBoxDomain.Name = "textBoxDomain";
      this.textBoxDomain.Size = new System.Drawing.Size(137, 20);
      this.textBoxDomain.TabIndex = 8;
      this.textBoxDomain.Text = "*";
      // 
      // textBoxProxyAddress
      // 
      this.textBoxProxyAddress.Location = new System.Drawing.Point(108, 123);
      this.textBoxProxyAddress.Name = "textBoxProxyAddress";
      this.textBoxProxyAddress.Size = new System.Drawing.Size(137, 20);
      this.textBoxProxyAddress.TabIndex = 7;
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
      this.groupBox3.Size = new System.Drawing.Size(261, 107);
      this.groupBox3.TabIndex = 3;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Accounts";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(7, 77);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(35, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "Name";
      // 
      // textBoxAccountName
      // 
      this.textBoxAccountName.Location = new System.Drawing.Point(90, 74);
      this.textBoxAccountName.Name = "textBoxAccountName";
      this.textBoxAccountName.Size = new System.Drawing.Size(155, 20);
      this.textBoxAccountName.TabIndex = 3;
      // 
      // checkBoxDefault
      // 
      this.checkBoxDefault.AutoSize = true;
      this.checkBoxDefault.Location = new System.Drawing.Point(90, 51);
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
      // tabPageSettingsGeneral
      // 
      this.tabPageSettingsGeneral.Controls.Add(this.groupBox5);
      this.tabPageSettingsGeneral.Controls.Add(this.groupBox4);
      this.tabPageSettingsGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsGeneral.Name = "tabPageSettingsGeneral";
      this.tabPageSettingsGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsGeneral.Size = new System.Drawing.Size(267, 324);
      this.tabPageSettingsGeneral.TabIndex = 0;
      this.tabPageSettingsGeneral.Text = "Audio";
      this.tabPageSettingsGeneral.UseVisualStyleBackColor = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.checkBoxRecordingMute);
      this.groupBox5.Controls.Add(this.label9);
      this.groupBox5.Controls.Add(this.checkBoxSelectMic);
      this.groupBox5.Controls.Add(this.trackBarRecordingVolume);
      this.groupBox5.Controls.Add(this.comboBoxRecordingDevices);
      this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox5.Location = new System.Drawing.Point(3, 163);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(261, 158);
      this.groupBox5.TabIndex = 1;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Recording";
      // 
      // checkBoxRecordingMute
      // 
      this.checkBoxRecordingMute.AutoSize = true;
      this.checkBoxRecordingMute.Location = new System.Drawing.Point(185, 59);
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
      this.label9.Location = new System.Drawing.Point(7, 60);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(94, 13);
      this.label9.TabIndex = 3;
      this.label9.Text = "Recording Volume";
      // 
      // checkBoxSelectMic
      // 
      this.checkBoxSelectMic.AutoSize = true;
      this.checkBoxSelectMic.Location = new System.Drawing.Point(117, 59);
      this.checkBoxSelectMic.Name = "checkBoxSelectMic";
      this.checkBoxSelectMic.Size = new System.Drawing.Size(56, 17);
      this.checkBoxSelectMic.TabIndex = 2;
      this.checkBoxSelectMic.Text = "Select";
      this.checkBoxSelectMic.UseVisualStyleBackColor = true;
      this.checkBoxSelectMic.CheckedChanged += new System.EventHandler(this.checkBoxPlaybackMute_CheckedChanged);
      // 
      // trackBarRecordingVolume
      // 
      this.trackBarRecordingVolume.LargeChange = 10000;
      this.trackBarRecordingVolume.Location = new System.Drawing.Point(6, 97);
      this.trackBarRecordingVolume.Maximum = 65535;
      this.trackBarRecordingVolume.Name = "trackBarRecordingVolume";
      this.trackBarRecordingVolume.Size = new System.Drawing.Size(165, 42);
      this.trackBarRecordingVolume.SmallChange = 6553;
      this.trackBarRecordingVolume.TabIndex = 1;
      this.trackBarRecordingVolume.TickFrequency = 6553;
      this.trackBarRecordingVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackBarRecordingVolume.ValueChanged += new System.EventHandler(this.trackBarRecordingVolume_ValueChanged);
      // 
      // comboBoxRecordingDevices
      // 
      this.comboBoxRecordingDevices.FormattingEnabled = true;
      this.comboBoxRecordingDevices.Location = new System.Drawing.Point(7, 19);
      this.comboBoxRecordingDevices.Name = "comboBoxRecordingDevices";
      this.comboBoxRecordingDevices.Size = new System.Drawing.Size(165, 21);
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
      this.groupBox4.Size = new System.Drawing.Size(261, 160);
      this.groupBox4.TabIndex = 0;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Playback";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(4, 59);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(77, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "Master Volume";
      // 
      // trackBarPlaybackBalance
      // 
      this.trackBarPlaybackBalance.LargeChange = 50;
      this.trackBarPlaybackBalance.Location = new System.Drawing.Point(190, 85);
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
      this.comboBoxPlaybackDevices.Location = new System.Drawing.Point(7, 19);
      this.comboBoxPlaybackDevices.Name = "comboBoxPlaybackDevices";
      this.comboBoxPlaybackDevices.Size = new System.Drawing.Size(166, 21);
      this.comboBoxPlaybackDevices.TabIndex = 3;
      this.comboBoxPlaybackDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaybackDevices_SelectedIndexChanged);
      // 
      // trackBarPlaybackVolume
      // 
      this.trackBarPlaybackVolume.Cursor = System.Windows.Forms.Cursors.Default;
      this.trackBarPlaybackVolume.LargeChange = 10000;
      this.trackBarPlaybackVolume.Location = new System.Drawing.Point(7, 92);
      this.trackBarPlaybackVolume.Maximum = 65535;
      this.trackBarPlaybackVolume.Name = "trackBarPlaybackVolume";
      this.trackBarPlaybackVolume.Size = new System.Drawing.Size(167, 42);
      this.trackBarPlaybackVolume.SmallChange = 6553;
      this.trackBarPlaybackVolume.TabIndex = 2;
      this.trackBarPlaybackVolume.TickFrequency = 6553;
      this.trackBarPlaybackVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.trackBarPlaybackVolume.ValueChanged += new System.EventHandler(this.trackBarPlaybackVolume_ValueChanged);
      // 
      // checkBoxPlaybackMute
      // 
      this.checkBoxPlaybackMute.AutoSize = true;
      this.checkBoxPlaybackMute.Location = new System.Drawing.Point(123, 59);
      this.checkBoxPlaybackMute.Name = "checkBoxPlaybackMute";
      this.checkBoxPlaybackMute.Size = new System.Drawing.Size(50, 17);
      this.checkBoxPlaybackMute.TabIndex = 0;
      this.checkBoxPlaybackMute.Text = "Mute";
      this.checkBoxPlaybackMute.UseVisualStyleBackColor = true;
      this.checkBoxPlaybackMute.CheckedChanged += new System.EventHandler(this.checkBoxPlaybackMute_CheckedChanged);
      // 
      // tabPageSettingsServices
      // 
      this.tabPageSettingsServices.Controls.Add(this.groupBox1);
      this.tabPageSettingsServices.Controls.Add(this.groupBoxServices);
      this.tabPageSettingsServices.Location = new System.Drawing.Point(4, 22);
      this.tabPageSettingsServices.Name = "tabPageSettingsServices";
      this.tabPageSettingsServices.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSettingsServices.Size = new System.Drawing.Size(267, 324);
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
      this.groupBox1.Size = new System.Drawing.Size(261, 192);
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
      this.comboBox1.Location = new System.Drawing.Point(120, 124);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(41, 21);
      this.comboBox1.TabIndex = 4;
      // 
      // checkBoxAA
      // 
      this.checkBoxAA.AutoSize = true;
      this.checkBoxAA.Location = new System.Drawing.Point(15, 128);
      this.checkBoxAA.Name = "checkBoxAA";
      this.checkBoxAA.Size = new System.Drawing.Size(86, 17);
      this.checkBoxAA.TabIndex = 3;
      this.checkBoxAA.Text = "Auto Answer";
      this.checkBoxAA.UseVisualStyleBackColor = true;
      // 
      // checkBoxDND
      // 
      this.checkBoxDND.AutoSize = true;
      this.checkBoxDND.Location = new System.Drawing.Point(15, 105);
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
      this.groupBoxServices.Location = new System.Drawing.Point(3, 195);
      this.groupBoxServices.Name = "groupBoxServices";
      this.groupBoxServices.Size = new System.Drawing.Size(261, 126);
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
      // panel2
      // 
      this.panel2.Controls.Add(this.buttonApply);
      this.panel2.Controls.Add(this.buttonCancel);
      this.panel2.Controls.Add(this.buttonOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 350);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(275, 55);
      this.panel2.TabIndex = 12;
      // 
      // buttonApply
      // 
      this.buttonApply.Location = new System.Drawing.Point(93, 16);
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
      this.buttonCancel.Location = new System.Drawing.Point(7, 16);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonOK
      // 
      this.buttonOK.Location = new System.Drawing.Point(180, 16);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(275, 405);
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
      this.tabPageSettingsGeneral.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRecordingVolume)).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackBalance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarPlaybackVolume)).EndInit();
      this.tabPageSettingsServices.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBoxServices.ResumeLayout(false);
      this.groupBoxServices.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControlSettings;
    private System.Windows.Forms.TabPage tabPageSettingsGeneral;
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
    private System.Windows.Forms.TextBox textBoxProxyAddress;
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
    private System.Windows.Forms.CheckBox checkBoxSelectMic;
    private System.Windows.Forms.TrackBar trackBarRecordingVolume;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.CheckBox checkBoxRecordingMute;
  }
}