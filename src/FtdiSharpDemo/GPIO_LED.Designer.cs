namespace FtdiSharpDemo;

partial class GPIO_LED
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
            this.components = new System.ComponentModel.Container();
            this.deviceSelector1 = new FtdiSharpDemo.DeviceSelector();
            this.cbD3 = new System.Windows.Forms.CheckBox();
            this.cbD2 = new System.Windows.Forms.CheckBox();
            this.cbD1 = new System.Windows.Forms.CheckBox();
            this.cbD0 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbD7 = new System.Windows.Forms.CheckBox();
            this.cbD6 = new System.Windows.Forms.CheckBox();
            this.cbD5 = new System.Windows.Forms.CheckBox();
            this.cbD4 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceSelector1
            // 
            this.deviceSelector1.Location = new System.Drawing.Point(12, 12);
            this.deviceSelector1.Name = "deviceSelector1";
            this.deviceSelector1.Size = new System.Drawing.Size(395, 53);
            this.deviceSelector1.TabIndex = 0;
            // 
            // cbD3
            // 
            this.cbD3.AutoSize = true;
            this.cbD3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD3.Location = new System.Drawing.Point(17, 121);
            this.cbD3.Name = "cbD3";
            this.cbD3.Size = new System.Drawing.Size(49, 25);
            this.cbD3.TabIndex = 1;
            this.cbD3.Text = "D3";
            this.cbD3.UseVisualStyleBackColor = true;
            // 
            // cbD2
            // 
            this.cbD2.AutoSize = true;
            this.cbD2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD2.Location = new System.Drawing.Point(17, 90);
            this.cbD2.Name = "cbD2";
            this.cbD2.Size = new System.Drawing.Size(49, 25);
            this.cbD2.TabIndex = 2;
            this.cbD2.Text = "D2";
            this.cbD2.UseVisualStyleBackColor = true;
            // 
            // cbD1
            // 
            this.cbD1.AutoSize = true;
            this.cbD1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD1.Location = new System.Drawing.Point(17, 59);
            this.cbD1.Name = "cbD1";
            this.cbD1.Size = new System.Drawing.Size(49, 25);
            this.cbD1.TabIndex = 3;
            this.cbD1.Text = "D1";
            this.cbD1.UseVisualStyleBackColor = true;
            // 
            // cbD0
            // 
            this.cbD0.AutoSize = true;
            this.cbD0.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD0.Location = new System.Drawing.Point(17, 28);
            this.cbD0.Name = "cbD0";
            this.cbD0.Size = new System.Drawing.Size(49, 25);
            this.cbD0.TabIndex = 4;
            this.cbD0.Text = "D0";
            this.cbD0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbD3);
            this.groupBox1.Controls.Add(this.cbD2);
            this.groupBox1.Controls.Add(this.cbD1);
            this.groupBox1.Controls.Add(this.cbD0);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(32, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 156);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbD7);
            this.groupBox2.Controls.Add(this.cbD6);
            this.groupBox2.Controls.Add(this.cbD5);
            this.groupBox2.Controls.Add(this.cbD4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(147, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(88, 156);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // cbD7
            // 
            this.cbD7.AutoSize = true;
            this.cbD7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD7.Location = new System.Drawing.Point(17, 121);
            this.cbD7.Name = "cbD7";
            this.cbD7.Size = new System.Drawing.Size(49, 25);
            this.cbD7.TabIndex = 1;
            this.cbD7.Text = "D7";
            this.cbD7.UseVisualStyleBackColor = true;
            // 
            // cbD6
            // 
            this.cbD6.AutoSize = true;
            this.cbD6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD6.Location = new System.Drawing.Point(17, 90);
            this.cbD6.Name = "cbD6";
            this.cbD6.Size = new System.Drawing.Size(49, 25);
            this.cbD6.TabIndex = 2;
            this.cbD6.Text = "D6";
            this.cbD6.UseVisualStyleBackColor = true;
            // 
            // cbD5
            // 
            this.cbD5.AutoSize = true;
            this.cbD5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD5.Location = new System.Drawing.Point(17, 59);
            this.cbD5.Name = "cbD5";
            this.cbD5.Size = new System.Drawing.Size(49, 25);
            this.cbD5.TabIndex = 3;
            this.cbD5.Text = "D5";
            this.cbD5.UseVisualStyleBackColor = true;
            // 
            // cbD4
            // 
            this.cbD4.AutoSize = true;
            this.cbD4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbD4.Location = new System.Drawing.Point(17, 28);
            this.cbD4.Name = "cbD4";
            this.cbD4.Size = new System.Drawing.Size(49, 25);
            this.cbD4.TabIndex = 4;
            this.cbD4.Text = "D4";
            this.cbD4.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 256);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // GPIO_LED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 278);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.deviceSelector1);
            this.Name = "GPIO_LED";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp GPIO LED Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DeviceSelector deviceSelector1;
    private CheckBox cbD3;
    private CheckBox cbD2;
    private CheckBox cbD1;
    private CheckBox cbD0;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CheckBox cbD4;
    private CheckBox cbD7;
    private CheckBox cbD6;
    private CheckBox cbD5;
    private System.Windows.Forms.Timer timer1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
}