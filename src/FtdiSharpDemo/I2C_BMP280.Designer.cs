namespace FtdiSharpDemo;

partial class I2C_BMP280
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
            this.deviceSelector1 = new FtdiSharpDemo.DeviceSelector();
            this.lbCalibration = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deviceSelector1
            // 
            this.deviceSelector1.Location = new System.Drawing.Point(12, 12);
            this.deviceSelector1.Name = "deviceSelector1";
            this.deviceSelector1.Size = new System.Drawing.Size(395, 53);
            this.deviceSelector1.TabIndex = 0;
            // 
            // lbCalibration
            // 
            this.lbCalibration.FormattingEnabled = true;
            this.lbCalibration.ItemHeight = 15;
            this.lbCalibration.Location = new System.Drawing.Point(34, 105);
            this.lbCalibration.Name = "lbCalibration";
            this.lbCalibration.Size = new System.Drawing.Size(120, 199);
            this.lbCalibration.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Calibration Bytes";
            // 
            // I2C_BMP280
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCalibration);
            this.Controls.Add(this.deviceSelector1);
            this.Name = "I2C_BMP280";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp BMP280 Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DeviceSelector deviceSelector1;
    private ListBox lbCalibration;
    private Label label1;
}