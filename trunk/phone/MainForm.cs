using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Telephony;

namespace Sipek
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();

      // register callback
      Telephony.CCallManager.getInstance().CallStateChanged += onTelephonyRefresh;
      Telephony.CCallManager.getInstance().MessageReceived += onMessageReceived;

      // Initlialize telephony
      Telephony.CCallManager.getInstance().initialize();
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
        }

        ListViewItem item = new ListViewItem(new string[] { name, acc.RegState.ToString() });

        listViewAccounts.Items.Add(item);
      }
    }

    /// <summary>
    /// UpdateCallLines delegate
    /// </summary>
    private void UpdateCallLines()
    {
      listViewCallLines.Items.Clear();

      //
      Dictionary<int, Telephony.CStateMachine> callList = Telephony.CCallManager.getInstance().getCallList();

      foreach (KeyValuePair<int, Telephony.CStateMachine> kvp in callList)
      {
        string number = kvp.Value.CallingNo;

        string duration = kvp.Value.Duration.ToString();
        if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds

        ListViewItem lvi = new ListViewItem(new string[] {
            kvp.Value.getStateName(), number, duration});

        lvi.Tag = kvp.Value.Session;
        listViewCallLines.Items.Add(lvi);
        lvi.Selected = true;

        // display info
        //toolStripStatusLabel1.Text = kvp.Value.lastInfoMessage;
      }
      //listViewCallLines.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    private void UpdateCallRegister()
    {
      listViewCallRegister.Items.Clear();

      Collection<CCallRecord> results = CCallLog.getInstance().getList();

      foreach (CCallRecord item in results)
      {
        string duration = item.Duration.ToString();
        if (duration.IndexOf('.') > 0) duration = duration.Remove(duration.IndexOf('.')); // remove miliseconds

        ListViewItem lvi = new ListViewItem(new string[] {
             item.Number + " " + item.Name, item.Time.ToString(), duration});

        //lvi.SubItems.Add(item.Number);
        
        listViewCallRegister.Items.Add(lvi);
      }
    }

    delegate void StateChangedDelegate();
    delegate void MessageReceivedDelegate(string from, string message);

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

    private void MessageReceived(string from, string message)
    {
      // check if ChatForm already opened
      foreach (Form ctrl in Application.OpenForms)
      {
        if (ctrl.Name == "ChatForm")
        {
          ((ChatForm)ctrl).LastMessage = message;
          ((ChatForm)ctrl).BuddyName = from;
          ctrl.Focus();
          return;
        }
      }

      // if not, create new instance
      ChatForm bf = new ChatForm();
      // extract buddy ID
      string buddyId = parseFrom(from);
      int id = CBuddyList.getInstance().getBuddy(buddyId);
      if (id >= 0)
      {
        //_buddyId = id;        
        CBuddyRecord buddy = CBuddyList.getInstance()[id];
        //_titleText.Caption = buddy.FirstName + ", " + buddy.LastName;
        bf.BuddyId = (int)id;
      }
      bf.LastMessage = message;
      bf.BuddyName = buddyId;
      bf.ShowDialog();
    }

    private string parseFrom(string from)
    {
      string number = from.Replace("<sip:", "");

      int atPos = number.IndexOf('@');
      if (atPos >= 0)
      {
        number = number.Remove(atPos);
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
    private void toolStripComboDial_KeyPress(object sender, KeyPressEventArgs e)
    {
      // if enter
      if (e.KeyChar <= 0x7A && e.KeyChar >= 0x41)
      {
      }
/*      else if (e.KeyChar <= 0x39 && e.KeyChar >= 0x30)
      {
        if (listViewCallLines.SelectedItems.Count > 0)
        {
          telephoneObj.sendDigit((int)listViewCallLines.SelectedItems[0].Tag, e.KeyChar);
        }
      }
*/
      base.OnKeyPress(e);
    }

    private void toolStripComboDial_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 0x0d)
      {
        if (toolStripComboDial.Text.Length > 0)
        {
          //makeCall(toolStripComboDial.Text);
          Telephony.CCallManager.getInstance().createSession(toolStripComboDial.Text);
        }
      }

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Telephony.CCallManager.getInstance().shutdown();
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

    private void listViewBuddies_Enter(object sender, EventArgs e)
    {

    }

    private void toolStripButtonCall_Click(object sender, EventArgs e)
    {
      if (toolStripComboDial.Text.Length > 0)
      {
        //makeCall(toolStripComboDial.Text);
        Telephony.CCallManager.getInstance().createSession(toolStripComboDial.Text);
      }
    }

    private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewCallLines.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewCallLines.SelectedItems[0];
        //telephoneObj.releaseCall((int)lvi.Tag);
        Telephony.CCallManager.getInstance().onUserRelease((int)lvi.Tag);
      }
    }

    private void contextMenuStripCalls_Opening(object sender, CancelEventArgs e)
    {
      // Hide all items...
      foreach (ToolStripMenuItem mi in contextMenuStripCalls.Items)
      {
        mi.Visible = false;
      }
      if (Telephony.CCallManager.getInstance().Count <= 0) 
      {
        return;
      }
      // call
      contextMenuStripCalls.Items["releaseToolStripMenuItem"].Visible = true;
    }

    private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
    {
      (new BuddyForm()).ShowDialog();
    }

    private void tabPageBuddies_Enter(object sender, EventArgs e)
    {
      UpdateBuddyList();
    }

    private void UpdateBuddyList()
    {
      Dictionary<int, CBuddyRecord> results = CBuddyList.getInstance().getList();
      listViewBuddies.Items.Clear();
      foreach (KeyValuePair<int, CBuddyRecord> kvp in results)
      {
        ListViewItem item = new ListViewItem(new string[] { kvp.Value.FirstName + kvp.Value.LastName, "online" });
        item.Tag = kvp.Value.Id;
        listViewBuddies.Items.Add(item);
      }
    }

    private void tabPageAccounts_Enter(object sender, EventArgs e)
    {
      UpdateAccountList();
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

    private void MainForm_Activated(object sender, EventArgs e)
    {
      // Refresh data
      //RefreshForm();
      UpdateBuddyList();
    }

    private void placeACallToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewBuddies.SelectedItems.Count > 0)
      {
        ListViewItem lvi = listViewBuddies.SelectedItems[0];
        
        CBuddyRecord rec = CBuddyList.getInstance().getRecord((int)lvi.Tag);
        if (rec != null)
        {
          Telephony.CCallManager.getInstance().createSession(rec.Number);
        }
      }
    }

    private void textBoxChatInput_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

  }
}