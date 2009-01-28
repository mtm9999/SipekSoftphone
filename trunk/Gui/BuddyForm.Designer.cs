namespace Sipek
{
  partial class BuddyForm
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBoxPresence = new System.Windows.Forms.CheckBox();
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.textBoxNumber = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxName = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.checkBoxPresence);
      this.groupBox1.Controls.Add(this.buttonOk);
      this.groupBox1.Controls.Add(this.buttonCancel);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.textBoxNumber);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.textBoxName);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(240, 153);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // checkBoxPresence
      // 
      this.checkBoxPresence.AutoSize = true;
      this.checkBoxPresence.Location = new System.Drawing.Point(100, 85);
      this.checkBoxPresence.Name = "checkBoxPresence";
      this.checkBoxPresence.Size = new System.Drawing.Size(121, 17);
      this.checkBoxPresence.TabIndex = 9;
      this.checkBoxPresence.Text = "Subscribe Presence";
      this.checkBoxPresence.UseVisualStyleBackColor = true;
      // 
      // buttonOk
      // 
      this.buttonOk.Location = new System.Drawing.Point(146, 119);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 8;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(16, 119);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 7;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 62);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(81, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Phone/Address";
      // 
      // textBoxNumber
      // 
      this.textBoxNumber.Location = new System.Drawing.Point(100, 59);
      this.textBoxNumber.Name = "textBoxNumber";
      this.textBoxNumber.Size = new System.Drawing.Size(121, 20);
      this.textBoxNumber.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Display as";
      // 
      // textBoxName
      // 
      this.textBoxName.Location = new System.Drawing.Point(100, 33);
      this.textBoxName.Name = "textBoxName";
      this.textBoxName.Size = new System.Drawing.Size(121, 20);
      this.textBoxName.TabIndex = 0;
      // 
      // BuddyForm
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(240, 153);
      this.Controls.Add(this.groupBox1);
      this.Name = "BuddyForm";
      this.Text = "Buddy Room";
      this.Activated += new System.EventHandler(this.BuddyForm_Activated);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBoxNumber;
    private System.Windows.Forms.CheckBox checkBoxPresence;
  }
}