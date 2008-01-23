/* 
 * Copyright (C) 2008 Sasa Coh <sasacoh@gmail.com>
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 
 * 
 * WaveLib library sources http://www.codeproject.com/KB/graphics/AudioLib.aspx
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Telephony;
using System.Windows.Forms.Design;
using WaveLib.AudioMixer; // see http://www.codeproject.com/KB/graphics/AudioLib.aspx


namespace Sipek
{
  public partial class MainForm : Form
  {
    const string HEADER_TEXT = "Sipek2";
 
    Timer tmr = new Timer();  // Refresh Call List
    EUserStatus _lastUserStatus = EUserStatus.AVAILABLE;
    private AbstractFactory _factory;
    private AbstractFactory SipekFactory
    {
      get { return _factory; }
    }

    public MainForm()
    {
      InitializeComponent();
    }

    /////////////////////////////////////////////////////////////////////////////////

    private void RefreshForm()
    {
      // Update Call Status
      UpdateCallLines();

      // Update Account Status
      UpdateAccountList();

      // Update Call Register
      UpdateCallRegister();

      // Update Buddy List
      UpdateBuddyList();

      // Refresh toolstripbuttons
      toolStripButtonDND.Checked = CSettings.DND;
      toolStripButtonAA.Checked = CSettings.AA;
    }

    private void UpdateAccountList()
    {
      listViewAccounts.Items.Clear();

      int size = CAccounts.getInstance().getSize();
      for (int i = 0; i < size; i++)
      {
        CAccount acc = CAccounts.getInstance()[i];
        string name;

        if (acc.Name.Length == 0)
        {
          name = "--empty--";
        }
        else
        {
          name = acc.Name;
        }

        if (acc.Index == CAccounts.getInstance().DefAccountIndex)
        {
          // todo!!! Coloring!

          // check registration status
          if (acc.RegState == 200)
          {
            toolStripStatusLabel.Text = "Registered"; //acc.Name + " - " + acc.DisplayName; 
            this.Text = HEADER_TEXT + " - " + acc.Name + " (" + acc.DisplayName + ")";
          }
          else if (acc.RegState == 0)
          {
            this.Text = HEADER_TEXT;
            toolStripStatusLabel.Text = "Registering...";
          }
          else
          {
            this.Text = HEADER_TEXT;
            toolStripStatusLabel.Text = "Not registered!";
          }
        }


        ListViewItem item = new ListViewItem(new string[] { name, acc.RegState.ToString() });

        listViewAccounts.Items.Add(item);
      }
    }

    private void UpdateCallRegister()
    {
      listViewCallRegister.Items.Clear();

      Stack<CCallRecord> results = SipekFactory.getCallLogger().getList();
      
      foreach (CCallRecord item in results)
      {
        string duration = item.Duration.ToString();
        if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds

        string recorditem = item.Number;
        CBuddyRecord rec = null;
        int buddyId = CBuddyList.getInstance().getBuddyId(item.Number);
        if (buddyId > -1)
        {
          string name = "";
          rec = CBuddyList.getInstance()[buddyId];
          name = rec.FirstName + " " + rec.LastName;
          name = name.Trim();
          recorditem = name + ", " + item.Number;
        }
        else if (item.Name.Length > 0)
        {
          recorditem = item.Name + ", " + item.Number;
        }

        ListViewItem lvi = new ListViewItem(new string[] {
             item.Type.ToString(), recorditem.Trim(), item.Time.ToString(), duration});

        lvi.Tag = item;
        
        listViewCallRegister.Items.Add(lvi);
      }
    }

    //////////////////////////////////////////////////////////////////////////////////////
    /// 
    delegate void StateChangedDelegate();
    delegate void MessageReceivedDelegate(string from, string message);
    delegate void BuddyStateChangedDelegate(int buddyId, int status, string text);

    public void onTelephonyRefresh()
    {
      if (this.Created)
        this.BeginInvoke(new StateChangedDelegate(this.RefreshForm));
    }

    public void onMessageReceived(string from, string message)
    {
      if (this.Created)
        this.BeginInvoke(new MessageReceivedDelegate(this.MessageReceived), new object[] { from, message });
    }

    public void onBuddyStateChanged(int buddyId, int status, string text)
    {
      if (this.Created)
        this.BeginInvoke(new BuddyStateChangedDelegate(this.BuddyStateChanged), new object[] { buddyId, status, text});
    }


    /////////////////////////////////////////////////////////////////////////////////////
    /// Buddy List Methods
    #region Buddy List Methods

    private void UpdateBuddyList()
    {
      Dictionary<int, CBuddyRecord> results = CBuddyList.getInstance().getList();
      listViewBuddies.Items.Clear();
      foreach (KeyValuePair<int, CBuddyRecord> kvp in results)
      {
        string status;
        switch (kvp.Value.Status)
        {
          case 0: status = "unknown"; break;
          case 1: status = "online"; break;
          case 2: status = "offline"; break;
          default: status = "?"; break;
        }
        //if ((null != kvp.Value.StatusText) && (kvp.Value.StatusText.Length > 0))
        //{
        //  status += " (" + kvp.Value.StatusText + ")";
        //}
        status = kvp.Value.StatusText;

        ListViewItem item = new ListViewItem(new string[] { kvp.Value.FirstName + kvp.Value.LastName, status });
        item.Tag = kvp.Value.Id;
        //item.BackColor = Color.Blue;
        listViewBuddies.Items.Add(item);
      }
    }

    private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
    {
      (new BuddyForm()).ShowDialog();
    }

    private void tabPageBuddies_Enter(object sender, EventArgs e)
    {
      UpdateBuddyList();
    }

    private void BuddyStateChanged(int buddyId, int status, string text)
    {
      CBuddyList.getInstance()[buddyId].Status = status;
      CBuddyList.getInstance()[buddyId].StatusText = text;
      this.RefreshForm();
    }

    private void MessageReceived(string from, string message)
    {
      // extract buddy ID
      string buddyId = parseFrom(from);

      // check if ChatForm already opened
      foreach (Form ctrl in Application.OpenForms)
      {
        if (ctrl.Name == "ChatForm")
        {
          ((ChatForm)ctrl).BuddyName = buddyId;
          ((ChatForm)ctrl).LastMessage = message;
          ctrl.Focus();
          return;
        }
      }

      // if not, create new instance
      ChatForm bf = new ChatForm();
      int id = CBuddyList.getInstance().getBuddyId(buddyId);
      if (id >= 0)
      {
        //_buddyId = id;        
        CBuddyRecord buddy = CBuddyList.getInstance()[id];
        //_titleText.Caption = buddy.FirstName + ", " + buddy.LastName;
        bf.BuddyId = (int)id;
      }
      bf.BuddyName = buddyId;
      bf.LastMessage = message;
      bf.ShowDialog();
    }

    private string parseFrom(string from)
    {
      string number = from.Replace("<sip:", "");

      int atPos = number.IndexOf('@');
      if (atPos >= 0)
      {
        number = number.Remove(atPos);
        int first = number.IndexOf('"');
        if (first >= 0)
        {
          int last = number.LastIndexOf('"');
          number = number.Remove(0,last + 1);
          number = number.Trim();
        }
      }
      else
      {
        int semiPos = number.IndexOf(';');
        if (semiPos >= 0)
        {
          number = number.Remove(semiPos);
        }
        else
        {
          int colPos = number.IndexOf(':');
          if (colPos >= 0)
          {
            number = number.Remove(colPos);
          }
        }
      }
      return number;
    }

    private void toolStripMenuItemIM_Click(object sender, EventArgs e)
    {
      if (listViewBuddies.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewBuddies.SelectedItems[0];
        ChatForm bf = new ChatForm();
        bf.BuddyId = (int)lvi.Tag;
        bf.ShowDialog();
      }

    }

    private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
    {
      if (listViewBuddies.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewBuddies.SelectedItems[0];

        BuddyForm bf = new BuddyForm();
        bf.BuddyId = (int)lvi.Tag;
        bf.ShowDialog();
      }
    }
    #endregion


    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CCallManager.getInstance().shutdown();
      this.Close();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      (new AboutBox()).ShowDialog();
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
      (new SettingsForm()).ShowDialog();
    }

    /// <summary>
    /// Enable or disable menu items regarding to call state...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void contextMenuStripCalls_Opening(object sender, CancelEventArgs e)
    {
      // Hide all items...
      foreach (ToolStripMenuItem mi in contextMenuStripCalls.Items)
      {
        mi.Visible = false;
      }

      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];

        if (CCallManager.getInstance().Count <= 0)
        {
          return;
        }
        else
        {
          EStateId stateId = CCallManager.getInstance().getCall((int)lvi.Tag).getStateId();
          switch (stateId)
          {
            case EStateId.INCOMING:
              acceptToolStripMenuItem.Visible = true;
              transferToolStripMenuItem.Visible = true;
              break;
            case EStateId.ACTIVE:
              holdRetrieveToolStripMenuItem.Text = "Hold";
              holdRetrieveToolStripMenuItem.Visible = true;
              transferToolStripMenuItem.Visible = true;
              //sendMessageToolStripMenuItem.Visible = true;
              break;
            case EStateId.HOLDING:
              holdRetrieveToolStripMenuItem.Text = "Retrieve";
              holdRetrieveToolStripMenuItem.Visible = true;
              break;
          }

        }
        // call
        releaseToolStripMenuItem.Visible = true;
      }
    }

    private void tabPageAccounts_Enter(object sender, EventArgs e)
    {
      UpdateAccountList();
    }

    private void MainForm_Activated(object sender, EventArgs e)
    {
      // Refresh data
      //RefreshForm();
      //UpdateBuddyList();
    }

    ///////////////////////////////////////////////////////////////////////////////////
    // Call Related Methods
    #region Call Related Methods

    /// <summary>
    /// UpdateCallLines delegate
    /// </summary>
    private void UpdateCallLines()
    {     
      listViewCallLines.Items.Clear();

      try
      {
        // get entire call list
        Dictionary<int, CStateMachine> callList = CCallManager.getInstance().CallList;

        foreach (KeyValuePair<int, CStateMachine> kvp in callList)
        {
          string number = kvp.Value.CallingNo;
          string name = kvp.Value.CallingName; 

          string duration = kvp.Value.Duration.ToString();
          if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds
          // show name & number or just number
          string display = name.Length > 0 ? name + " / " + number : number;
          ListViewItem lvi = new ListViewItem(new string[] {
            kvp.Value.getStateName(), display, duration});

          lvi.Tag = kvp.Value.Session;
          listViewCallLines.Items.Add(lvi);
          lvi.Selected = true;

          // display info
          //toolStripStatusLabel1.Text = item.Value.lastInfoMessage;
        }


        if (callList.Count > 0)
        {
          // control refresh timer
          tmr.Start();

          // Remember last status
          if (toolStripComboBoxUserStatus.SelectedIndex != (int)EUserStatus.OTP) 
            _lastUserStatus = (EUserStatus)toolStripComboBoxUserStatus.SelectedIndex;

          // Set user status "On the Phone"
          toolStripComboBoxUserStatus.SelectedIndex = (int)EUserStatus.OTP;
        }
        else
        {
          toolStripComboBoxUserStatus.SelectedIndex = (int)_lastUserStatus;
        }

      }
      catch (Exception e)
      {
        // TODO!!!!!!!!!!! Sychronize SHARED RESOURCES!!!!
      }
      //listViewCallLines.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    public void UpdateCallTimeout(object sender, EventArgs e)
    {
      if (listViewCallLines.Items.Count == 0) return;

      for (int i = 0; i < listViewCallLines.Items.Count; i++ )
      {
        ListViewItem item = listViewCallLines.Items[i];
        CStateMachine sm = CCallManager.getInstance().getCall((int)item.Tag);
        if (null == sm) continue;

        string duration = sm.RuntimeDuration.ToString();
        if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds

        item.SubItems[2].Text = duration;
      }
      // restart timer
      if (listViewCallLines.Items.Count > 0)
      {
        tmr.Start();
      }

    }

    private void placeACallToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewBuddies.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewBuddies.SelectedItems[0];

        CBuddyRecord rec = CBuddyList.getInstance().getRecord((int)lvi.Tag);
        if (rec != null)
        {
          CCallManager.getInstance().createOutboundCall(rec.Number);
        }
      }
    }

    private void toolStripButtonHoldRetrieve_Click(object sender, EventArgs e)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];

        CCallManager.getInstance().onUserHoldRetrieve((int)lvi.Tag);
      }
    }

    private void toolStripButtonCall_Click(object sender, EventArgs e)
    {
      if (toolStripComboDial.Text.Length > 0)
      {
        CCallManager.getInstance().createOutboundCall(toolStripComboDial.Text);
      }
      else
      {
        // check selected line state
        if (listViewCallLines.SelectedItems.Count > 0)
        {
          // if in incoming state, answer call
          ListViewItem lvi = listViewCallLines.SelectedItems[0];
          CStateMachine call = CCallManager.getInstance().getCall((int)lvi.Tag);
          if (call.getStateId() == EStateId.INCOMING)
          {
            CCallManager.getInstance().onUserAnswer(call.Session);
          }
        }
      }
    }

    private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];
        //telephoneObj.releaseCall((int)lvi.Tag);
        CCallManager.getInstance().onUserRelease((int)lvi.Tag);
      }
    }

    private void toolStripComboDial_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 0x0d)
      {
        if (toolStripComboDial.Text.Length > 0)
        {
          //makeCall(toolStripComboDial.Text);
          CCallManager.getInstance().createOutboundCall(toolStripComboDial.Text);
        }
      }
    }

    private void listViewCallRegister_DoubleClick(object sender, EventArgs e)
    {
      if (listViewCallRegister.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallRegister.SelectedItems[0];
        CCallRecord record = (CCallRecord)lvi.Tag;
        CCallManager.getInstance().createOutboundCall(record.Number);
      }
    }

    private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];
        CCallManager.getInstance().onUserAnswer((int)lvi.Tag);
      }
    }

    #endregion

    private void removeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewCallRegister.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallRegister.SelectedItems[0];
        CCallRecord record = (CCallRecord) lvi.Tag;
        SipekFactory.getCallLogger().deleteRecord(record);
      }
      this.UpdateCallRegister();

    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      SipekFactory.getCallLogger().save();
      CBuddyList.getInstance().save();
      CSettings.Save();
    }

    private void toolStripTextBoxTransferTo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 0x0d)
      {
        if (listViewCallLines.SelectedItems.Count > 0)
        {
          ListViewItem lvi = listViewCallLines.SelectedItems[0];
          if (toolStripTextBoxTransferTo.Text.Length > 0)
          {
            CCallManager.getInstance().onUserTransfer((int)lvi.Tag, toolStripTextBoxTransferTo.Text);
          }
        }
        contextMenuStripCalls.Close();
      }
    }

    private void toolStripButtonDND_Click(object sender, EventArgs e)
    {
      CSettings.DND = toolStripButtonDND.Checked;
    }

    private void toolStripButtonAA_Click(object sender, EventArgs e)
    {
      CSettings.AA = toolStripButtonAA.Checked;
    }

    private void sendInstantMessageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewCallRegister.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallRegister.SelectedItems[0];
        CCallRecord record = (CCallRecord)lvi.Tag;
        int id = CBuddyList.getInstance().getBuddyId(record.Number);
        if (id > 0)
        {
          ChatForm bf = new ChatForm();
          bf.BuddyId = id;
          bf.ShowDialog();
        }
      }
    }

    private void toolStripComboBoxUserStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      /*
       * AVAILABLE, BUSY, OTP, IDLE, AWAY, BRB, OFFLINE
       * 
      Available
      Busy
      On the Phone
      Idle
      Away
      Be Right Back
      Offline
       */

      EUserStatus status = (EUserStatus)toolStripComboBoxUserStatus.SelectedIndex;

      SipekFactory.getCommonProxy().setStatus(CAccounts.getInstance().DefAccountIndex, status);
    }

    private void toolStripKeyboardButton_Click(object sender, EventArgs e)
    {
      (new KeyboardForm(this)).Show();
    }

    public void onUserDialDigit(string digits)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];
        CCallManager.getInstance().onUserDialDigit((int)lvi.Tag, digits, 0);
      }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    /// Audio Control

    private Mixers mMixers;
    private bool mAvoidEvents = false;

    private void LoadAudioValues()
    {
      mMixers = new Mixers();
      // set callback
      mMixers.Playback.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
      mMixers.Recording.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);

      MixerLine pbline = mMixers.Playback.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_WAVEOUT);

      toolStripTrackBar1.Tag = pbline;
      toolStripMuteButton.Tag = pbline;
      MixerLine recline = mMixers.Recording.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_MICROPHONE); ;
      toolStripMicMuteButton.Tag = recline;

      //If it is 2 channels then ask both and set the volume to the bigger but keep relation between them (Balance)
      int volume = 0;
      float balance = 0;
      if (pbline.Channels != 2)
        volume = pbline.Volume;
      else
      {
        pbline.Channel = Channel.Left;
        int left = pbline.Volume;
        pbline.Channel = Channel.Right;
        int right = pbline.Volume;
        if (left > right)
        {
          volume = left;
          balance = (volume > 0) ? -(1 - (right / (float)left)) : 0;
        }
        else
        {
          volume = right;
          balance = (volume > 0) ? (1 - (left / (float)right)) : 0;
        }
      }

      if (volume >= 0)
        this.toolStripTrackBar1.Value = volume;
      else
        this.toolStripTrackBar1.Enabled = false;

      // toolstrip checkboxes
      this.toolStripMuteButton.Checked = pbline.Mute;
      this.toolStripMicMuteButton.Checked = recline.Volume == 0 ? true : false;
      _lastMicVol = recline.Volume;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      LoadAudioValues();
      
      // create factory
      _factory = new ConcreteFactory(this);
      // Set factory for CallManager
      CCallManager.getInstance().Factory = _factory;
      CCallManager.getInstance().initialize();

      // load settings
      unconditionalToolStripMenuItem.Checked = CSettings.CFU;
      toolStripTextBoxCFUNumber.Text = CSettings.CFUNumber;
      
      noReplyToolStripMenuItem.Checked = CSettings.CFNR;
      toolStripTextBoxCFNRNumber.Text = CSettings.CFNRNumber;

      busyToolStripMenuItem.Checked = CSettings.CFB;
      toolStripTextBoxCFBNumber.Text = CSettings.CFBNumber;


      // register callback
      CCallManager.getInstance().CallStateChanged += onTelephonyRefresh;
      CCallManager.getInstance().MessageReceived += onMessageReceived;
      CCallManager.getInstance().BuddyStatusChanged += onBuddyStateChanged;

      // Initialize dial combo box
      toolStripComboDial.Items.Clear();
      Stack<CCallRecord> clist = SipekFactory.getCallLogger().getList(ECallType.EDialed);
      foreach (CCallRecord item in clist)
      {
        toolStripComboDial.Items.Add(item.Number);
      }
      this.UpdateCallRegister();

      // Init Buddy list
      this.UpdateBuddyList();

      // Set user status
      toolStripComboBoxUserStatus.SelectedIndex = (int)EUserStatus.AVAILABLE;

      // timer 
      tmr.Interval = 1000;
      tmr.Tick += new EventHandler(UpdateCallTimeout);
    }

    private void toolStripTrackBar1_ValueChanged(object sender, EventArgs e)
    {
      if (mAvoidEvents)
        return;

      TrackBar tBar = (TrackBar)sender;
      MixerLine line = (MixerLine)tBar.Tag;
      if (line.Channels != 2)
      {
        // One channel or more than two let set the volume uniform
        line.Channel = Channel.Uniform;
        line.Volume = tBar.Value;
      }
      else
      {
        //Set independent volume
        line.Channel = Channel.Uniform;
        line.Volume = toolStripTrackBar1.Value;
      }
    }

    /// <summary>
    /// Callback from Windows Volume Control
    /// </summary>
    /// <param name="mixer"></param>
    /// <param name="line"></param>
    private void mMixer_MixerLineChanged(Mixer mixer, MixerLine line)
    {
      mAvoidEvents = true;

      try
      {
        float balance = -1;
        MixerLine frontEndLine = (MixerLine)toolStripTrackBar1.Tag;
        if (frontEndLine == line)
        {
          int volume = 0;
          if (line.Channels != 2)
            volume = line.Volume;
          else
          {
            line.Channel = Channel.Left;
            int left = line.Volume;
            line.Channel = Channel.Right;
            int right = line.Volume;
            if (left > right)
            {
              volume = left;
              // TIP: Do not reset the balance if both left and right channel have 0 value
              if (left != 0 && right != 0)
                balance = (volume > 0) ? -(1 - (right / (float)left)) : 0;
            }
            else
            {
              volume = right;
              // TIP: Do not reset the balance if both left and right channel have 0 value
              if (left != 0 && right != 0)
                balance = (volume > 0) ? 1 - (left / (float)right) : 0;
            }
          }

          if (volume >= 0)
            toolStripTrackBar1.Value = volume;

        }

        // adjust toolstrip checkboxes
        if ((MixerLine)toolStripMicMuteButton.Tag == line)
        {
          toolStripMicMuteButton.Checked = line.Volume == 0 ? true : false;
        }
        else if ((MixerLine)toolStripMuteButton.Tag == line)
        {
           toolStripMuteButton.Checked = line.Mute;
        }
      }
      finally
      {
        mAvoidEvents = false;
      }
    }

    private int _lastMicVol = 0;

    private void toolStripMuteButton_Click(object sender, EventArgs e)
    {
      ToolStripButton chkBox = (ToolStripButton)sender;
      MixerLine line = (MixerLine)chkBox.Tag;
      if (line.Direction == MixerType.Recording)
      {
        //line.Selected = chkBox.Checked;
        if (chkBox.Checked == true)
        {
          _lastMicVol = line.Volume;
          line.Volume = 0;
        }
        else 
        {
          line.Volume = _lastMicVol;
        }
      }
      else
      {
        line.Mute = chkBox.Checked;
      }
    }

    private void listViewAccounts_DoubleClick(object sender, EventArgs e)
    {
      SettingsForm sf = new SettingsForm();
      //sf.activateTab("");
      sf.ShowDialog();
    }

    private void unconditionalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CSettings.CFU = unconditionalToolStripMenuItem.Checked;
    }

    private void noReplyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CSettings.CFNR = noReplyToolStripMenuItem.Checked;
    }

    private void busyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CSettings.CFB = busyToolStripMenuItem.Checked;
    }

    private void toolStripTextBoxCFUNumber_TextChanged(object sender, EventArgs e)
    {
      CSettings.CFUNumber = toolStripTextBoxCFUNumber.Text;
    }

    private void toolStripTextBoxCFNRNumber_TextChanged(object sender, EventArgs e)
    {
      CSettings.CFNRNumber = toolStripTextBoxCFNRNumber.Text;
    }

    private void toolStripTextBoxCFBNumber_TextChanged(object sender, EventArgs e)
    {
      CSettings.CFBNumber = toolStripTextBoxCFBNumber.Text;
    }

    private void toolStrip3PtyButton_Click(object sender, EventArgs e)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];
        // TODO implement 3Pty
        CCallManager.getInstance().onUserConference((int)lvi.Tag);
      }
    }
  }

  //[System.ComponentModel.DesignerCategory("code")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
  public partial class ToolStripTrackBar : ToolStripControlHost
  {
    public ToolStripTrackBar()
      : base(CreateControlInstance())
    {

    }

    /// <summary>
    /// Create a strongly typed property called TrackBar - handy to prevent casting everywhere.
    /// </summary>
    public TrackBar TrackBar
    {
      get
      {
        return Control as TrackBar;
      }
    }

    /// <summary>
    /// Create the actual control, note this is static so it can be called from the
    /// constructor.
    ///
    /// </summary>
    /// <returns></returns>
    private static Control CreateControlInstance()
    {
      TrackBar t = new TrackBar();
      t.AutoSize = false;
      t.Height = 16;
      t.TickFrequency = 6553;
      t.SmallChange = 6553;
      t.LargeChange = 10000;
      t.Minimum = 0;
      t.Maximum = 65535;

      // Add other initialization code here.
      return t;
    }

    [DefaultValue(0)]
    public int Value
    {
      get { return TrackBar.Value; }
      set { TrackBar.Value = value; }
    }
    
    [DefaultValue(0)]
    public object Tag
    {
      get { return TrackBar.Tag; }
      set { TrackBar.Tag = value; }
    }

    /// <summary>
    /// Attach to events we want to re-wrap
    /// </summary>
    /// <param name="control"></param>
    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      TrackBar trackBar = control as TrackBar;
      trackBar.ValueChanged += new EventHandler(trackBar_ValueChanged);
    }

    /// <summary>
    /// Detach from events.
    /// </summary>
    /// <param name="control"></param>
    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      TrackBar trackBar = control as TrackBar;
      trackBar.ValueChanged -= new EventHandler(trackBar_ValueChanged);

    }


    /// <summary>
    /// Routing for event
    /// TrackBar.ValueChanged -> ToolStripTrackBar.ValueChanged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void trackBar_ValueChanged(object sender, EventArgs e)
    {
      // when the trackbar value changes, fire an event.
      if (this.ValueChanged != null)
      {
        ValueChanged(sender, e);
      }
    }

    // add an event that is subscribable from the designer.
    public event EventHandler ValueChanged;


    // set other defaults that are interesting
    protected override Size DefaultSize
    {
      get
      {
        return new Size(200, 16);
      }
    }

  }
}