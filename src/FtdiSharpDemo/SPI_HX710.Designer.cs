namespace FtdiSharpDemo;

partial class SPI_HX710
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
            this.lblSensor = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.barGraph1 = new FtdiSharpDemo.BarGraph();
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
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSensor.Location = new System.Drawing.Point(45, 86);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(70, 24);
            this.lblSensor.TabIndex = 6;
            this.lblSensor.Text = "12345";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 231);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // barGraph1
            // 
            this.barGraph1.Location = new System.Drawing.Point(60, 146);
            this.barGraph1.Name = "barGraph1";
            this.barGraph1.Size = new System.Drawing.Size(429, 70);
            this.barGraph1.TabIndex = 8;
            // 
            // SPI_HX710
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 253);
            this.Controls.Add(this.barGraph1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblSensor);
            this.Controls.Add(this.deviceSelector1);
            this.Name = "SPI_HX710";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp HX710 Demo";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DeviceSelector deviceSelector1;
    private Label lblSensor;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.Timer timer1;
    private BarGraph barGraph1;
}