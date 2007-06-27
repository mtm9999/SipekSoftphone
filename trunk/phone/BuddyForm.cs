using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sipek
{
  public partial class BuddyForm : Form
  {
    private int _buddyId = -1;
    public int BuddyId 
    {
      get { return _buddyId; }
      set { _buddyId = value; }
    }

    public BuddyForm()
    {
      InitializeComponent();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      CBuddyRecord record;

      if (BuddyId >= 0)
      {
        record = CBuddyList.getInstance().getRecord(BuddyId);
        CBuddyList.getInstance().deleteRecord(BuddyId);
      }
      else
      {
        record = new CBuddyRecord();
      }
      record.FirstName = textBoxName.Text;
      //record.LastName = _lname.Caption;
      record.Number = textBoxNumber.Text;

      CBuddyList.getInstance().addRecord(record);
      CBuddyList.getInstance().save();

      Close();
    }

    private void BuddyForm_Activated(object sender, EventArgs e)
    {
      CBuddyRecord record = CBuddyList.getInstance().getRecord(BuddyId);

      if (record == null) return;

      textBoxName.Text = record.FirstName;
      //textBoxName.Caption = record.LastName;
      textBoxNumber.Text = record.Number;
    }


  }
}