using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telephony;

namespace Sipek
{
  public partial class SettingsForm : Form
  {
    public SettingsForm()
    {
      InitializeComponent();

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
     
      textBoxDisplayName.Text = acc.Id;
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
        account.Id = textBoxUsername.Text;
        account.Username = textBoxUsername.Text;
        account.Password = textBoxPassword.Text;
        account.Domain = textBoxDomain.Text;

        if (checkBoxDefault.Checked) CAccounts.getInstance().DefAccountIndex = account.Index;

        CAccounts.getInstance()[account.Index] = account;
      }

      CAccounts.getInstance().save();
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      buttonApply_Click(sender, e);

      CCallManager.getInstance().initialize();

      Close();
    }

    private void checkBoxDefault_CheckedChanged(object sender, EventArgs e)
    {

    }

  }
}