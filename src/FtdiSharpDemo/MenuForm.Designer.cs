﻿namespace FtdiSharpDemo;

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
            this.btnLM75A = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBMP280 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox3.Location = new System.Drawing.Point(422, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SPI";
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
}