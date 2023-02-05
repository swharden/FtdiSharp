namespace FtdiSharpDemo;

partial class MenuForm
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
            this.btnConnectedDevices = new System.Windows.Forms.Button();
            this.btnAddressScanner = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBH1750 = new System.Windows.Forms.Button();
            this.btnADS1115 = new System.Windows.Forms.Button();
            this.btnLIS3DH = new System.Windows.Forms.Button();
            this.btnBMP280 = new System.Windows.Forms.Button();
            this.btnLM75A = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAD7705 = new System.Windows.Forms.Button();
            this.btnMCP3008 = new System.Windows.Forms.Button();
            this.btnHX710 = new System.Windows.Forms.Button();
            this.btnMCP3201 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnADS1220 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectedDevices
            // 
            this.btnConnectedDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectedDevices.Location = new System.Drawing.Point(6, 22);
            this.btnConnectedDevices.Name = "btnConnectedDevices";
            this.btnConnectedDevices.Size = new System.Drawing.Size(188, 38);
            this.btnConnectedDevices.TabIndex = 0;
            this.btnConnectedDevices.Text = "Connected Devices";
            this.btnConnectedDevices.UseVisualStyleBackColor = true;
            this.btnConnectedDevices.Click += new System.EventHandler(this.btnConnectedDevices_Click);
            // 
            // btnAddressScanner
            // 
            this.btnAddressScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddressScanner.Location = new System.Drawing.Point(6, 22);
            this.btnAddressScanner.Name = "btnAddressScanner";
            this.btnAddressScanner.Size = new System.Drawing.Size(186, 38);
            this.btnAddressScanner.TabIndex = 1;
            this.btnAddressScanner.Text = "Address Scanner";
            this.btnAddressScanner.UseVisualStyleBackColor = true;
            this.btnAddressScanner.Click += new System.EventHandler(this.btnAddressScanner_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBH1750);
            this.groupBox1.Controls.Add(this.btnADS1115);
            this.groupBox1.Controls.Add(this.btnLIS3DH);
            this.groupBox1.Controls.Add(this.btnBMP280);
            this.groupBox1.Controls.Add(this.btnLM75A);
            this.groupBox1.Controls.Add(this.btnAddressScanner);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 314);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "I2C";
            // 
            // lblBH1750
            // 
            this.lblBH1750.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBH1750.Location = new System.Drawing.Point(6, 242);
            this.lblBH1750.Name = "lblBH1750";
            this.lblBH1750.Size = new System.Drawing.Size(186, 38);
            this.lblBH1750.TabIndex = 6;
            this.lblBH1750.Text = "BH1750 Light Sensor";
            this.lblBH1750.UseVisualStyleBackColor = true;
            this.lblBH1750.Click += new System.EventHandler(this.lblBH1750_Click);
            // 
            // btnADS1115
            // 
            this.btnADS1115.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADS1115.Location = new System.Drawing.Point(6, 198);
            this.btnADS1115.Name = "btnADS1115";
            this.btnADS1115.Size = new System.Drawing.Size(186, 38);
            this.btnADS1115.TabIndex = 5;
            this.btnADS1115.Text = "ADS1115 ADC";
            this.btnADS1115.UseVisualStyleBackColor = true;
            this.btnADS1115.Click += new System.EventHandler(this.btnADS1115_Click);
            // 
            // btnLIS3DH
            // 
            this.btnLIS3DH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLIS3DH.Location = new System.Drawing.Point(6, 154);
            this.btnLIS3DH.Name = "btnLIS3DH";
            this.btnLIS3DH.Size = new System.Drawing.Size(186, 38);
            this.btnLIS3DH.TabIndex = 4;
            this.btnLIS3DH.Text = "LIS3DH Accelerometer";
            this.btnLIS3DH.UseVisualStyleBackColor = true;
            this.btnLIS3DH.Click += new System.EventHandler(this.btnLIS3DH_Click);
            // 
            // btnBMP280
            // 
            this.btnBMP280.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBMP280.Location = new System.Drawing.Point(6, 110);
            this.btnBMP280.Name = "btnBMP280";
            this.btnBMP280.Size = new System.Drawing.Size(186, 38);
            this.btnBMP280.TabIndex = 3;
            this.btnBMP280.Text = "BMP280 Pressure Sensor";
            this.btnBMP280.UseVisualStyleBackColor = true;
            this.btnBMP280.Click += new System.EventHandler(this.btnBMP280_Click);
            // 
            // btnLM75A
            // 
            this.btnLM75A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLM75A.Location = new System.Drawing.Point(6, 66);
            this.btnLM75A.Name = "btnLM75A";
            this.btnLM75A.Size = new System.Drawing.Size(186, 38);
            this.btnLM75A.TabIndex = 2;
            this.btnLM75A.Text = "LM75A Temperature Sensor";
            this.btnLM75A.UseVisualStyleBackColor = true;
            this.btnLM75A.Click += new System.EventHandler(this.btnLM75A_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConnectedDevices);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 314);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FTDI Devices";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnADS1220);
            this.groupBox3.Controls.Add(this.btnAD7705);
            this.groupBox3.Controls.Add(this.btnMCP3008);
            this.groupBox3.Controls.Add(this.btnHX710);
            this.groupBox3.Controls.Add(this.btnMCP3201);
            this.groupBox3.Location = new System.Drawing.Point(422, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 314);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SPI";
            // 
            // btnAD7705
            // 
            this.btnAD7705.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAD7705.Enabled = false;
            this.btnAD7705.Location = new System.Drawing.Point(8, 154);
            this.btnAD7705.Name = "btnAD7705";
            this.btnAD7705.Size = new System.Drawing.Size(186, 38);
            this.btnAD7705.TabIndex = 5;
            this.btnAD7705.Text = "AD7705 ADC";
            this.btnAD7705.UseVisualStyleBackColor = true;
            this.btnAD7705.Click += new System.EventHandler(this.btnAD7705_Click);
            // 
            // btnMCP3008
            // 
            this.btnMCP3008.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMCP3008.Location = new System.Drawing.Point(8, 110);
            this.btnMCP3008.Name = "btnMCP3008";
            this.btnMCP3008.Size = new System.Drawing.Size(186, 38);
            this.btnMCP3008.TabIndex = 4;
            this.btnMCP3008.Text = "MCP3008 ADC";
            this.btnMCP3008.UseVisualStyleBackColor = true;
            this.btnMCP3008.Click += new System.EventHandler(this.btnMCP3008_Click);
            // 
            // btnHX710
            // 
            this.btnHX710.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHX710.Location = new System.Drawing.Point(8, 66);
            this.btnHX710.Name = "btnHX710";
            this.btnHX710.Size = new System.Drawing.Size(186, 38);
            this.btnHX710.TabIndex = 3;
            this.btnHX710.Text = "HX710 ADC";
            this.btnHX710.UseVisualStyleBackColor = true;
            this.btnHX710.Click += new System.EventHandler(this.btnHX710_Click);
            // 
            // btnMCP3201
            // 
            this.btnMCP3201.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMCP3201.Location = new System.Drawing.Point(8, 22);
            this.btnMCP3201.Name = "btnMCP3201";
            this.btnMCP3201.Size = new System.Drawing.Size(186, 38);
            this.btnMCP3201.TabIndex = 2;
            this.btnMCP3201.Text = "MCP3201 ADC";
            this.btnMCP3201.UseVisualStyleBackColor = true;
            this.btnMCP3201.Click += new System.EventHandler(this.btnMCP3201_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(628, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "USART";
            // 
            // btnADS1220
            // 
            this.btnADS1220.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADS1220.Location = new System.Drawing.Point(8, 198);
            this.btnADS1220.Name = "btnADS1220";
            this.btnADS1220.Size = new System.Drawing.Size(186, 38);
            this.btnADS1220.TabIndex = 6;
            this.btnADS1220.Text = "ADS1220 ADC";
            this.btnADS1220.UseVisualStyleBackColor = true;
            this.btnADS1220.Click += new System.EventHandler(this.btnADS1220_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 345);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button btnConnectedDevices;
    private Button btnAddressScanner;
    private GroupBox groupBox1;
    private Button btnLM75A;
    private GroupBox groupBox2;
    private GroupBox groupBox3;
    private GroupBox groupBox4;
    private Button btnBMP280;
    private Button btnLIS3DH;
    private Button btnADS1115;
    private Button lblBH1750;
    private Button btnMCP3201;
    private Button btnHX710;
    private Button btnMCP3008;
    private Button btnAD7705;
    private Button btnADS1220;
}