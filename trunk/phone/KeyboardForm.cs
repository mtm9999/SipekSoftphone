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
  public partial class KeyboardForm : Form
  {
    private MainForm _main;

    public KeyboardForm(MainForm form)
    {
      _main = form;
      InitializeComponent();
    }

    private void Cancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void keypad0_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("0");
    }

    private void keypad1_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("1");
    }

    private void keypad2_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("2");
    }

    private void keypad3_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("3");
    }

    private void keypad4_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("4");
    }

    private void keypad5_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("5");
    }

    private void keypad6_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("6");
    }

    private void keypad7_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("7");
    }

    private void keypad8_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("8");
    }

    private void keypad9_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("9");
    }

    private void keypadSTAR_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("*");
    }

    private void keypadHASH_Click(object sender, EventArgs e)
    {
      _main.onUserDialDigit("#");
    }

  }
}