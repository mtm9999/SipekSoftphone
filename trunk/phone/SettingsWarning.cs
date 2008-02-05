using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sipek
{
  public partial class SettingsWarning : Form
  {
    public SettingsWarning(string text)
    {
      InitializeComponent();

      this.label1.Text = text;
    }
  }
}