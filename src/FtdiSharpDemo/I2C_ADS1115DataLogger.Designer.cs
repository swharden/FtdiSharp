namespace FtdiSharpDemo;

partial class I2C_ADS1115DataLogger
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
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.adcTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.plotTimer = new System.Windows.Forms.Timer(this.components);
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
            this.barGraph1.Location = new System.Drawing.Point(12, 71);
            this.barGraph1.Name = "barGraph1";
            this.barGraph1.Size = new System.Drawing.Size(429, 70);
            this.barGraph1.TabIndex = 2;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formsPlot1.Location = new System.Drawing.Point(13, 147);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(687, 317);
            this.formsPlot1.TabIndex = 3;
            // 
            // adcTimer
            // 
            this.adcTimer.Enabled = true;
            this.adcTimer.Interval = 10;
            this.adcTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(713, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // plotTimer
            // 
            this.plotTimer.Enabled = true;
            this.plotTimer.Tick += new System.EventHandler(this.plotTimer_Tick);
            // 
            // I2C_ADS1115DataLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 489);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.barGraph1);
            this.Controls.Add(this.i2cAddressSelector1);
            this.Controls.Add(this.deviceSelector1);
            this.Name = "I2C_ADS1115DataLogger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp ADS1115 Data Logger";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DeviceSelector deviceSelector1;
    private I2cAddressSelector i2cAddressSelector1;
    private BarGraph barGraph1;
    private ScottPlot.FormsPlot formsPlot1;
    private System.Windows.Forms.Timer adcTimer;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Timer plotTimer;
}