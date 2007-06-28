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
  public partial class ChatForm : Form
  {
    private int _buddyId = -1;
    public int BuddyId
    {
      get { return _buddyId; }
      set { _buddyId = value; }
    }

    private string _buddyName;
    public string BuddyName
    {
      get { return _buddyName; }
      set { _buddyName = value; }
    }

    private string _lastMessage = "";
    public string LastMessage
    {
      get { return _lastMessage; }
      set 
      { 
        if (value.Length > 0)
        {
          richTextBoxChatHistory.Text += "(" + BuddyName + ") " + DateTime.Now;
          richTextBoxChatHistory.Text += ": " + value;
          richTextBoxChatHistory.Text += Environment.NewLine;
        }
      }
    }

    public ChatForm()
    {
      InitializeComponent();
    }

    private void ChatForm_Activated(object sender, EventArgs e)
    {
    }

    private void buttonSendIM_Click(object sender, EventArgs e)
    {
      if (BuddyId == -1) return;

      // get buddy data form _buddyId
      CBuddyRecord buddy = CBuddyList.getInstance()[BuddyId];
      if (buddy != null)
      {
        // Invoke SIP stack wrapper function to send message
        CPjSipProxy.sendMessage(buddy.Number, textBoxChatInput.Text);

        richTextBoxChatHistory.Text += "(me) " + DateTime.Now;
        
        //Font orgfnt = richTextBoxChatHistory.Font;
        //Font fnt = new Font("Microsoft Sans Serif",16,FontStyle.Bold);    
        //richTextBoxChatHistory.Font = fnt;
        richTextBoxChatHistory.Text += ": " + textBoxChatInput.Text;
        //richTextBoxChatHistory.Font = orgfnt; 
        richTextBoxChatHistory.Text += Environment.NewLine;
        
        textBoxChatInput.Clear();

      }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void textBoxChatInput_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 0xD)
      {
        this.buttonSendIM_Click(sender, e);
      }
    }

    private void ChatForm_Shown(object sender, EventArgs e)
    {
      // get buddy data form _buddyId
      CBuddyRecord buddy = CBuddyList.getInstance()[BuddyId];
      if (buddy != null)
      {
        tabPageChat.Text = "Chat with " + buddy.FirstName;
      }
      else
      {
        tabPageChat.Text = "Chat with " + BuddyName;
      }
    }

    private void textBoxChatInput_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 0xD)
      {
        textBoxChatInput.Clear();
      }
    }

  }
}