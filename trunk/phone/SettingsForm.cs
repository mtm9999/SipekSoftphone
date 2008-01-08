using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telephony;
using WaveLib.AudioMixer;

namespace Sipek
{
  public partial class SettingsForm : Form
  {
    private Mixers mMixers;
    private bool mAvoidEvents;
    private int _lastMicVolume = 0;

    public SettingsForm()
    {
      InitializeComponent();

      //Initialization
      mMixers = new Mixers();
      mMixers.Playback.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
      mMixers.Recording.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);


      // Continued
      int size = CAccounts.getInstance().getSize();
      for (int i=0; i<size; i++)
      {
        CAccount acc = CAccounts.getInstance()[i];

        if (acc.Name.Length == 0)
        {
          comboBoxAccounts.Items.Add("--empty--");
        }
        else
        {
          comboBoxAccounts.Items.Add(acc.Name);
        }
        if (acc.Index == CAccounts.getInstance().DefAccountIndex)
        {
          comboBoxAccounts.SelectedIndex = i;
        }
      }

      /////
      checkBoxDND.Checked = CSettings.DND;
      checkBoxAA.Checked = CSettings.AA;
      checkBoxCFU.Checked = CSettings.CFU;
      checkBoxCFNR.Checked = CSettings.CFNR;

      textBoxCFU.Text = CSettings.CFUNumber;
      textBoxCFNR.Text = CSettings.CFNRNumber;
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void comboBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
      string accname = comboBoxAccounts.Text;
      if (CAccounts.getInstance().DefAccount.Name == accname)
        checkBoxDefault.Checked = true;
      else
        checkBoxDefault.Checked = false;

      textBoxAccountName.Text = accname;

      CAccount acc = getAccount(accname);

      if (acc == null) 
      {
        clearAll();
        // error!!!
        return;
      }
     
      textBoxDisplayName.Text = acc.DisplayName;
      textBoxUsername.Text = acc.Username;
      textBoxPassword.Text = acc.Password;
      textBoxProxyAddress.Text = acc.Address;
      textBoxDomain.Text = acc.Domain;
    }

    private CAccount getAccount(string accname)
    {
      CAccount acc = null;
      // get account
      int size = CAccounts.getInstance().getSize();
      for (int i=0; i<size; i++)
      {
        string tempName = CAccounts.getInstance()[i].Name;
        if (tempName == accname)
        {
          acc = CAccounts.getInstance()[i];
          break;
        }
      }
      return acc;
    }
  
    private void clearAll()
    {
      textBoxAccountName.Text = "";
      textBoxDisplayName.Text = "";
      textBoxUsername.Text = "";
      textBoxPassword.Text = "";
      textBoxProxyAddress.Text = "";
      textBoxDomain.Text = "";
    }

    private void buttonApply_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < 5; i++)
      {
        CAccount account = getAccount(comboBoxAccounts.Text);

        if (account == null)
        {
          account = new CAccount();
          account.Index = comboBoxAccounts.SelectedIndex;
        }

        account.Address = textBoxProxyAddress.Text;
        account.Port = 5060; //int.Parse(_editProxyPort.Caption);
        account.Name = textBoxAccountName.Text;
        account.DisplayName = textBoxDisplayName.Text;
        account.Id = textBoxUsername.Text;
        account.Username = textBoxUsername.Text;
        account.Password = textBoxPassword.Text;
        account.Domain = textBoxDomain.Text;

        if (checkBoxDefault.Checked) CAccounts.getInstance().DefAccountIndex = account.Index;

        CAccounts.getInstance()[account.Index] = account;
      }
      // Settings
      CSettings.DND = checkBoxDND.Checked ;
      CSettings.AA = checkBoxAA.Checked ;
      CSettings.CFU = checkBoxCFU.Checked ;
      CSettings.CFNR = checkBoxCFNR.Checked ;

      CSettings.CFUNumber = textBoxCFU.Text ;
      CSettings.CFNRNumber = textBoxCFNR.Text ;
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      buttonApply_Click(sender, e);

      CAccounts.getInstance().save();

      CCallManager.getInstance().initialize();

      Close();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
      LoadDeviceCombos(mMixers);
    }


    //////////////////////////////////////////////////////////////////////////////////
    /// Audio controls
    /// 
    /// 
    private void comboBoxPlaybackDevices_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadValues(MixerType.Playback);
    }

    private void comboBoxRecordingDevices_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadValues(MixerType.Recording);
    }

    private void LoadValues(MixerType mixerType)
    {
      MixerLine line;

      //Get info about the lines
      if (mixerType == MixerType.Recording)
      {
        mMixers.Recording.DeviceId = ((MixerDetail)comboBoxRecordingDevices.SelectedItem).DeviceId;
        line = mMixers.Recording.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.SRC_MICROPHONE);
        trackBarRecordingVolume.Tag = line;
        checkBoxSelectMic.Tag = line;
        checkBoxRecordingMute.Tag = line;
        _lastMicVolume = line.Volume;
        this.checkBoxRecordingMute.Checked = line.Volume == 0 ? true : false;
      }
      else
      {
        mMixers.Playback.DeviceId = ((MixerDetail)comboBoxPlaybackDevices.SelectedItem).DeviceId;
        line = mMixers.Playback.UserLines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.DST_SPEAKERS);
        trackBarPlaybackVolume.Tag = line;
        trackBarPlaybackBalance.Tag = line;
        checkBoxPlaybackMute.Tag = line;
      }

      //If it is 2 channels then ask both and set the volume to the bigger but keep relation between them (Balance)
      int volume = 0;
      float balance = 0;
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
          balance = (volume > 0) ? -(1 - (right / (float)left)) : 0;
        }
        else
        {
          volume = right;
          balance = (volume > 0) ? (1 - (left / (float)right)) : 0;
        }
      }

      if (mixerType == MixerType.Recording)
      {
        if (volume >= 0)
            this.trackBarRecordingVolume.Value = volume;
          else
            this.trackBarRecordingVolume.Enabled = false;
      }
      else
      {
        if (volume >= 0)
          this.trackBarPlaybackVolume.Value = volume;
        else
          this.trackBarPlaybackVolume.Enabled = false;

        //MONO OR MORE THAN 2 CHANNELS, then let disable balance
        if (line.Channels != 2)
          this.trackBarPlaybackBalance.Enabled = false;
        else
          this.trackBarPlaybackBalance.Value = (int)(trackBarPlaybackBalance.Maximum * balance);
      }
      
      // checkbox
      this.checkBoxPlaybackMute.Checked = line.Mute;
      this.checkBoxSelectMic.Checked = line.Selected;
    }

    private void LoadDeviceCombos(Mixers mixers)
    {
      //Load Output Combo
      MixerDetail mixerDetailDefault = new MixerDetail();
      mixerDetailDefault.DeviceId = -1;
      mixerDetailDefault.MixerName = "Default";
      mixerDetailDefault.SupportWaveOut = true;
      comboBoxPlaybackDevices.Items.Add(mixerDetailDefault);
      foreach (MixerDetail mixerDetail in mixers.Playback.Devices)
      {
        comboBoxPlaybackDevices.Items.Add(mixerDetail);
      }
      comboBoxPlaybackDevices.SelectedIndex = 0;

      //Load Input Combo
      mixerDetailDefault = new MixerDetail();
      mixerDetailDefault.DeviceId = -1;
      mixerDetailDefault.MixerName = "Default";
      mixerDetailDefault.SupportWaveIn = true;
      comboBoxRecordingDevices.Items.Add(mixerDetailDefault);
      foreach (MixerDetail mixerDetail in mixers.Recording.Devices)
      {
        comboBoxRecordingDevices.Items.Add(mixerDetail);
      }
      comboBoxRecordingDevices.SelectedIndex = 0;
    }

    private void mMixer_MixerLineChanged(Mixer mixer, MixerLine line)
    {
      mAvoidEvents = true;

      try
      {
        float balance = adjustValues(line, trackBarPlaybackVolume);

        //Set the balance
        if (balance != -1)
        {
          if ((MixerLine)trackBarPlaybackBalance.Tag == line)
          {
            trackBarPlaybackBalance.Value = (int)(trackBarPlaybackBalance.Maximum * balance);
          }
        }

        // adjust recording 
        adjustValues(line, trackBarRecordingVolume);

        // adjust checkboxes
        if ((MixerLine)checkBoxPlaybackMute.Tag == line)
        {
          if (line.Direction == MixerType.Recording)
            checkBoxPlaybackMute.Checked = line.Selected;
          else
            checkBoxPlaybackMute.Checked = line.Mute;
        }
        else if ((MixerLine)checkBoxSelectMic.Tag == line)
        {
          if (line.Direction == MixerType.Recording)
          {
            checkBoxSelectMic.Checked = line.Selected;
          }
        }
      }
      finally
      {
        mAvoidEvents = false;
      }
    }

    private float adjustValues(MixerLine line, TrackBar tBar)
    {
      float balance = -1;
      MixerLine frontEndLine = (MixerLine)tBar.Tag;
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
          tBar.Value = volume;

      }
      return balance;
    }

    private void trackBarPlaybackVolume_ValueChanged(object sender, EventArgs e)
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
        TrackBar tBarBalance = trackBarPlaybackBalance;
        //Set independent volume
        //foreach (TrackBar tBarBalance in tBarBalanceArray[(int)line.Mixer.MixerType])
        {
          MixerLine frontEndLine = (MixerLine)tBarBalance.Tag;
          if (frontEndLine == line)
          {
            if (tBarBalance.Value == 0)
            {
              line.Channel = Channel.Uniform;
              line.Volume = tBar.Value;
            }
            if (tBarBalance.Value <= 0)
            {
              // Left channel is bigger
              line.Channel = Channel.Left;
              line.Volume = tBar.Value;
              line.Channel = Channel.Right;
              line.Volume = (int)(tBar.Value * (1 + (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
            else
            {
              // Right channel is bigger
              line.Channel = Channel.Right;
              line.Volume = tBar.Value;
              line.Channel = Channel.Left;
              line.Volume = (int)(tBar.Value * (1 - (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
            //break;
          }
        }
      }
    }

    private void trackBarPlaybackBalance_ValueChanged(object sender, EventArgs e)
    {
      if (mAvoidEvents)
        return;

      TrackBar tBarBalance = (TrackBar)sender;
      MixerLine line = (MixerLine)tBarBalance.Tag;

      //This demo just set balance when they are just 2 channels
      if (line.Channels == 2)
      {
        //Set independent volume
        TrackBar tBarVolume = trackBarPlaybackVolume;
        //foreach (TrackBar tBarVolume in tBarArray[(int)line.Mixer.MixerType])
        {
          MixerLine frontEndLine = (MixerLine)tBarVolume.Tag;
          if (frontEndLine == line)
          {
            if (tBarBalance.Value == 0)
            {
              line.Channel = Channel.Uniform;
              line.Volume = tBarVolume.Value;
            }
            if (tBarBalance.Value <= 0)
            {
              // Left channel is bigger
              line.Channel = Channel.Left;
              line.Volume = tBarVolume.Value;
              line.Channel = Channel.Right;
              line.Volume = (int)(tBarVolume.Value * (1 + (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
            else
            {
              // Rigth channel is bigger
              line.Channel = Channel.Right;
              line.Volume = tBarVolume.Value;
              line.Channel = Channel.Left;
              line.Volume = (int)(tBarVolume.Value * (1 - (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
            //break;
          }
        }
      }

    }

    private void trackBarRecordingVolume_ValueChanged(object sender, EventArgs e)
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
        TrackBar tBarBalance = trackBarRecordingVolume;
        //Set independent volume
        //foreach (TrackBar tBarBalance in tBarBalanceArray[(int)line.Mixer.MixerType])
        {
          MixerLine frontEndLine = (MixerLine)tBarBalance.Tag;
          if (frontEndLine == line)
          {
            if (tBarBalance.Value == 0)
            {
              line.Channel = Channel.Uniform;
              line.Volume = tBar.Value;
            }
            if (tBarBalance.Value <= 0)
            {
              // Left channel is bigger
              line.Channel = Channel.Left;
              line.Volume = tBar.Value;
              line.Channel = Channel.Right;
              line.Volume = (int)(tBar.Value * (1 + (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
            else
            {
              // Right channel is bigger
              line.Channel = Channel.Right;
              line.Volume = tBar.Value;
              line.Channel = Channel.Left;
              line.Volume = (int)(tBar.Value * (1 - (tBarBalance.Value / (float)tBarBalance.Maximum)));
            }
          }
        }
      }
      _lastMicVolume = line.Volume;
      this.checkBoxRecordingMute.Checked = line.Volume == 0 ? true : false;
    }

    private void checkBoxPlaybackMute_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox chkBox = (CheckBox)sender;
      MixerLine line = (MixerLine)chkBox.Tag;
      if (line.Direction == MixerType.Recording)
      {
        line.Selected = chkBox.Checked;
        if (checkBoxRecordingMute.Checked == true)
        {
          _lastMicVolume = line.Volume;
          line.Volume = 0;
        }
        else
        {
          line.Volume = _lastMicVolume;
        }
      }
      else
      {
        line.Mute = chkBox.Checked;
      }
    }

  }
}
