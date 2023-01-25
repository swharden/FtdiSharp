namespace FtdiSharpDemo;

partial class DeviceInfoForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsOpen = new System.Windows.Forms.CheckBox();
            this.cbIsHighspeed = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(19, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(128, 124);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Devices";
            // 
            // cbIsOpen
            // 
            this.cbIsOpen.AutoSize = true;
            this.cbIsOpen.Location = new System.Drawing.Point(189, 47);
            this.cbIsOpen.Name = "cbIsOpen";
            this.cbIsOpen.Size = new System.Drawing.Size(55, 19);
            this.cbIsOpen.TabIndex = 2;
            this.cbIsOpen.Text = "Open";
            this.cbIsOpen.UseVisualStyleBackColor = true;
            // 
            // cbIsHighspeed
            // 
            this.cbIsHighspeed.AutoSize = true;
            this.cbIsHighspeed.Location = new System.Drawing.Point(259, 47);
            this.cbIsHighspeed.Name = "cbIsHighspeed";
            this.cbIsHighspeed.Size = new System.Drawing.Size(87, 19);
            this.cbIsHighspeed.TabIndex = 3;
            this.cbIsHighspeed.Text = "High Speed";
            this.cbIsHighspeed.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(259, 80);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(12, 15);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "?";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(259, 98);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(12, 15);
            this.lblID.TabIndex = 5;
            this.lblID.Text = "?";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(259, 116);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(12, 15);
            this.lblLoc.TabIndex = 6;
            this.lblLoc.Text = "?";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(259, 134);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(12, 15);
            this.lblSerial.TabIndex = 7;
            this.lblSerial.Text = "?";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(259, 152);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(12, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Serial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 192);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbIsHighspeed);
            this.Controls.Add(this.cbIsOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp Device Info";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private ListBox listBox1;
    private Label label1;
    private CheckBox cbIsOpen;
    private CheckBox cbIsHighspeed;
    private Label lblType;
    private Label lblID;
    private Label lblLoc;
    private Label lblSerial;
    private Label lblDescription;
    private Button button1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
}
