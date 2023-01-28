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
            this.components = new System.ComponentModel.Container();
            this.deviceSelector1 = new FtdiSharpDemo.DeviceSelector();
            this.lbCalibration = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.I2cAddressSelector1 = new FtdiSharpDemo.I2cAddressSelector();
            this.lblTemperatureBytes = new System.Windows.Forms.Label();
            this.lblPressureBytes = new System.Windows.Forms.Label();
            this.lblReads = new System.Windows.Forms.Label();
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
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Temperature";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pressure";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemperature.Location = new System.Drawing.Point(193, 105);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(70, 24);
            this.lblTemperature.TabIndex = 6;
            this.lblTemperature.Text = "12345";
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPressure.Location = new System.Drawing.Point(381, 105);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(70, 24);
            this.lblPressure.TabIndex = 7;
            this.lblPressure.Text = "12345";
            // 
            // I2cAddressSelector1
            // 
            this.I2cAddressSelector1.Address = ((byte)(72));
            this.I2cAddressSelector1.Location = new System.Drawing.Point(413, 12);
            this.I2cAddressSelector1.Name = "I2cAddressSelector1";
            this.I2cAddressSelector1.Size = new System.Drawing.Size(125, 53);
            this.I2cAddressSelector1.TabIndex = 8;
            // 
            // lblTemperatureBytes
            // 
            this.lblTemperatureBytes.AutoSize = true;
            this.lblTemperatureBytes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemperatureBytes.Location = new System.Drawing.Point(193, 129);
            this.lblTemperatureBytes.Name = "lblTemperatureBytes";
            this.lblTemperatureBytes.Size = new System.Drawing.Size(42, 15);
            this.lblTemperatureBytes.TabIndex = 9;
            this.lblTemperatureBytes.Text = "12345";
            // 
            // lblPressureBytes
            // 
            this.lblPressureBytes.AutoSize = true;
            this.lblPressureBytes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPressureBytes.Location = new System.Drawing.Point(381, 129);
            this.lblPressureBytes.Name = "lblPressureBytes";
            this.lblPressureBytes.Size = new System.Drawing.Size(42, 15);
            this.lblPressureBytes.TabIndex = 10;
            this.lblPressureBytes.Text = "12345";
            // 
            // lblReads
            // 
            this.lblReads.AutoSize = true;
            this.lblReads.Location = new System.Drawing.Point(193, 289);
            this.lblReads.Name = "lblReads";
            this.lblReads.Size = new System.Drawing.Size(50, 15);
            this.lblReads.TabIndex = 11;
            this.lblReads.Text = "Reads: 0";
            // 
            // I2C_BMP280
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 344);
            this.Controls.Add(this.lblReads);
            this.Controls.Add(this.lblPressureBytes);
            this.Controls.Add(this.lblTemperatureBytes);
            this.Controls.Add(this.I2cAddressSelector1);
            this.Controls.Add(this.lblPressure);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
    private System.Windows.Forms.Timer timer1;
    private Label label2;
    private Label label3;
    private Label lblTemperature;
    private Label lblPressure;
    private I2cAddressSelector I2cAddressSelector1;
    private Label lblTemperatureBytes;
    private Label lblPressureBytes;
    private Label lblReads;
}