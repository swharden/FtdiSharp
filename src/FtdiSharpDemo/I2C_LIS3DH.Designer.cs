namespace FtdiSharpDemo;

partial class I2C_LIS3DH
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
            this.i2cAddressSelector1 = new FtdiSharpDemo.I2cAddressSelector();
            this.barGraph1 = new FtdiSharpDemo.BarGraph();
            this.barGraph2 = new FtdiSharpDemo.BarGraph();
            this.barGraph3 = new FtdiSharpDemo.BarGraph();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            // i2cAddressSelector1
            // 
            this.i2cAddressSelector1.Address = ((byte)(72));
            this.i2cAddressSelector1.Location = new System.Drawing.Point(413, 12);
            this.i2cAddressSelector1.Name = "i2cAddressSelector1";
            this.i2cAddressSelector1.Size = new System.Drawing.Size(125, 53);
            this.i2cAddressSelector1.TabIndex = 1;
            // 
            // barGraph1
            // 
            this.barGraph1.Location = new System.Drawing.Point(55, 101);
            this.barGraph1.Name = "barGraph1";
            this.barGraph1.Size = new System.Drawing.Size(429, 81);
            this.barGraph1.TabIndex = 2;
            // 
            // barGraph2
            // 
            this.barGraph2.Location = new System.Drawing.Point(55, 176);
            this.barGraph2.Name = "barGraph2";
            this.barGraph2.Size = new System.Drawing.Size(429, 81);
            this.barGraph2.TabIndex = 3;
            // 
            // barGraph3
            // 
            this.barGraph3.Location = new System.Drawing.Point(55, 263);
            this.barGraph3.Name = "barGraph3";
            this.barGraph3.Size = new System.Drawing.Size(429, 81);
            this.barGraph3.TabIndex = 4;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Reads: 0";
            // 
            // I2C_LIS3DH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.barGraph3);
            this.Controls.Add(this.barGraph2);
            this.Controls.Add(this.barGraph1);
            this.Controls.Add(this.i2cAddressSelector1);
            this.Controls.Add(this.deviceSelector1);
            this.Name = "I2C_LIS3DH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp LIS3DH Accelerometer Demo";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DeviceSelector deviceSelector1;
    private I2cAddressSelector i2cAddressSelector1;
    private BarGraph barGraph1;
    private BarGraph barGraph2;
    private BarGraph barGraph3;
    private System.Windows.Forms.Timer timer1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
}