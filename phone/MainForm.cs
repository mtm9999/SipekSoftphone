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
      Telephony.CCallManager.getInstance().registerOnRefreshCallback(onTelephonyRefresh);

      // Initlialize telephony
      Telephony.CCallManager.getInstance().initialize();

      // Refresh data
      RefreshForm();

      // Buddies List View Init
      //listViewBuddies.Clear();

      Dictionary<int, CBuddyRecord> results = CBuddyList.getInstance().getList();

      foreach (KeyValuePair<int, CBuddyRecord> kvp in results)
      {
        ListViewItem item = new ListViewItem(new string[] { kvp.Value.FirstName + kvp.Value.LastName, "online" });
        listViewBuddies.Items.Add(item);
      }
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
            kvp.Value.getStateName(), number, ""/*kvp.Value.lastInfoMessage*/, duration});

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

    delegate void RefreshDelegate();

    public void onTelephonyRefresh()
    {
      if (this.Created)
      this.Invoke(new RefreshDelegate(this.RefreshForm));
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

  }
}