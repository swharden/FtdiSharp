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
            this.SuspendLayout();
            // 
            // btnConnectedDevices
            // 
            this.btnConnectedDevices.Location = new System.Drawing.Point(67, 44);
            this.btnConnectedDevices.Name = "btnConnectedDevices";
            this.btnConnectedDevices.Size = new System.Drawing.Size(160, 38);
            this.btnConnectedDevices.TabIndex = 0;
            this.btnConnectedDevices.Text = "Connected Devices";
            this.btnConnectedDevices.UseVisualStyleBackColor = true;
            this.btnConnectedDevices.Click += new System.EventHandler(this.btnConnectedDevices_Click);
            // 
            // btnAddressScanner
            // 
            this.btnAddressScanner.Location = new System.Drawing.Point(67, 88);
            this.btnAddressScanner.Name = "btnAddressScanner";
            this.btnAddressScanner.Size = new System.Drawing.Size(160, 38);
            this.btnAddressScanner.TabIndex = 1;
            this.btnAddressScanner.Text = "I2C Address Scanner";
            this.btnAddressScanner.UseVisualStyleBackColor = true;
            this.btnAddressScanner.Click += new System.EventHandler(this.btnAddressScanner_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 202);
            this.Controls.Add(this.btnAddressScanner);
            this.Controls.Add(this.btnConnectedDevices);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FtdiSharp Demo";
            this.ResumeLayout(false);

    }

    #endregion

    private Button btnConnectedDevices;
    private Button btnAddressScanner;
}