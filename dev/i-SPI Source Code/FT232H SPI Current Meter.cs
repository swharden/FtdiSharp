// This file was converted from VB to CS

public class Form1 : System.Windows.Forms.Form {
    
    public Form1() {
        // This call is required by the Windows Form Designer.
        this.InitializeComponent();
        // Add any initialization after the InitializeComponent() call
    }
    
    // Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (!(components == null)) {
                components.Dispose();
            }
            
        }
        
        base.Dispose(disposing);
    }
    
    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;
    
    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    internal System.Windows.Forms.Button Button_Start;
    
    internal System.Windows.Forms.Button Button_Exit;
    
    internal System.Windows.Forms.Label Label4;
    
    internal System.Windows.Forms.Label Label5;
    
    internal System.Windows.Forms.GroupBox GroupBox2;
    
    internal System.Windows.Forms.Label Label9;
    
    internal System.Windows.Forms.Label Label8;
    
    internal System.Windows.Forms.Label Label12;
    
    internal System.Windows.Forms.Label Label11;
    
    internal System.Windows.Forms.Label Label14;
    
    internal System.Windows.Forms.Label Label13;
    
    internal System.Windows.Forms.GroupBox GroupBox3;
    
    internal System.Windows.Forms.GroupBox GroupBox4;
    
    internal System.Windows.Forms.GroupBox GroupBox5;
    
    internal System.Windows.Forms.Label Label10;
    
    internal System.Windows.Forms.Label Label15;
    
    internal System.Windows.Forms.Label Label16;
    
    internal System.Windows.Forms.Label Label17;
    
    internal System.Windows.Forms.Label Label18;
    
    internal System.Windows.Forms.Label Label19;
    
    internal System.Windows.Forms.Label Label20;
    
    internal System.Windows.Forms.Label Label21;
    
    internal System.Windows.Forms.GroupBox GroupBox6;
    
    internal System.Windows.Forms.Label Label23;
    
    internal System.Windows.Forms.Label Label22;
    
    internal System.Windows.Forms.TextBox TextBox3;
    
    internal System.Windows.Forms.GroupBox GroupBox1;
    
    internal System.Windows.Forms.TextBox TextBox2;
    
    internal System.Windows.Forms.Button Button_Init;
    
    internal System.Windows.Forms.Label Label2;
    
    internal System.Windows.Forms.TextBox TextBox1;
    
    internal System.Windows.Forms.Label Label1;
    
    internal System.Windows.Forms.Label Label3;
    
    internal System.Windows.Forms.GroupBox GroupBox7;
    
    internal System.Windows.Forms.Button Button_Stop;
    
    internal System.Windows.Forms.TextBox TextBox5;
    
    internal System.Windows.Forms.Label Label25;
    
    internal System.Windows.Forms.Panel Panel1;
    
    internal System.Windows.Forms.GroupBox Chart;
    
    internal System.Windows.Forms.Label Label6;
    
    internal System.Windows.Forms.Label Label7;
    
    internal System.Windows.Forms.PictureBox PictureBox1;
    
    internal System.Windows.Forms.Label Label24;
    
    internal System.Windows.Forms.Label Label29;
    
    internal System.Windows.Forms.Label Label28;
    
    internal System.Windows.Forms.Label Label27;
    
    internal System.Windows.Forms.Label Label26;
    
    internal System.Windows.Forms.Label Label31;
    
    internal System.Windows.Forms.Label Label30;
    
    internal System.Windows.Forms.Label Label32;
    
    internal System.Windows.Forms.CheckBox CheckBox1;
    
    internal System.Windows.Forms.Label Label33;
    
    internal System.Windows.Forms.Label Label34;
    
    internal System.Windows.Forms.Label Label35;
    
    internal System.Windows.Forms.ProgressBar ProgressBar1;
    
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent() {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        this.Button_Start = new System.Windows.Forms.Button();
        this.Button_Exit = new System.Windows.Forms.Button();
        this.Label4 = new System.Windows.Forms.Label();
        this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
        this.Label5 = new System.Windows.Forms.Label();
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.Label11 = new System.Windows.Forms.Label();
        this.Label8 = new System.Windows.Forms.Label();
        this.Label9 = new System.Windows.Forms.Label();
        this.Label14 = new System.Windows.Forms.Label();
        this.Label13 = new System.Windows.Forms.Label();
        this.Label12 = new System.Windows.Forms.Label();
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.GroupBox5 = new System.Windows.Forms.GroupBox();
        this.Label10 = new System.Windows.Forms.Label();
        this.Label15 = new System.Windows.Forms.Label();
        this.Label16 = new System.Windows.Forms.Label();
        this.Label17 = new System.Windows.Forms.Label();
        this.Label18 = new System.Windows.Forms.Label();
        this.Label19 = new System.Windows.Forms.Label();
        this.Label20 = new System.Windows.Forms.Label();
        this.Label21 = new System.Windows.Forms.Label();
        this.GroupBox6 = new System.Windows.Forms.GroupBox();
        this.Label33 = new System.Windows.Forms.Label();
        this.Label22 = new System.Windows.Forms.Label();
        this.Label23 = new System.Windows.Forms.Label();
        this.CheckBox1 = new System.Windows.Forms.CheckBox();
        this.TextBox3 = new System.Windows.Forms.TextBox();
        this.GroupBox1 = new System.Windows.Forms.GroupBox();
        this.Label35 = new System.Windows.Forms.Label();
        this.TextBox5 = new System.Windows.Forms.TextBox();
        this.Label25 = new System.Windows.Forms.Label();
        this.GroupBox7 = new System.Windows.Forms.GroupBox();
        this.TextBox2 = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.TextBox1 = new System.Windows.Forms.TextBox();
        this.Label1 = new System.Windows.Forms.Label();
        this.Label3 = new System.Windows.Forms.Label();
        this.Button_Init = new System.Windows.Forms.Button();
        this.Button_Stop = new System.Windows.Forms.Button();
        this.Panel1 = new System.Windows.Forms.Panel();
        this.Chart = new System.Windows.Forms.GroupBox();
        this.Label31 = new System.Windows.Forms.Label();
        this.Label30 = new System.Windows.Forms.Label();
        this.Label29 = new System.Windows.Forms.Label();
        this.Label28 = new System.Windows.Forms.Label();
        this.Label27 = new System.Windows.Forms.Label();
        this.Label26 = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.Label6 = new System.Windows.Forms.Label();
        this.PictureBox1 = new System.Windows.Forms.PictureBox();
        this.Label24 = new System.Windows.Forms.Label();
        this.Label32 = new System.Windows.Forms.Label();
        this.Label34 = new System.Windows.Forms.Label();
        this.GroupBox2.SuspendLayout();
        this.GroupBox3.SuspendLayout();
        this.GroupBox4.SuspendLayout();
        this.GroupBox5.SuspendLayout();
        this.GroupBox6.SuspendLayout();
        this.GroupBox1.SuspendLayout();
        this.Chart.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // Button_Start
        // 
        this.Button_Start.Location = new System.Drawing.Point(471, 331);
        this.Button_Start.Name = "Button_Start";
        this.Button_Start.Size = new System.Drawing.Size(66, 30);
        this.Button_Start.TabIndex = 1;
        this.Button_Start.Text = "Start";
        this.Button_Exit.Location = new System.Drawing.Point(689, 331);
        this.Button_Exit.Name = "Button_Exit";
        this.Button_Exit.Size = new System.Drawing.Size(70, 30);
        this.Button_Exit.TabIndex = 2;
        this.Button_Exit.Text = "Exit";
        this.Label4.BackColor = System.Drawing.SystemColors.Control;
        this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label4.Location = new System.Drawing.Point(90, 17);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(55, 48);
        this.Label4.TabIndex = 9;
        this.Label4.Text = "mA";
        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ProgressBar1
        // 
        this.ProgressBar1.Location = new System.Drawing.Point(17, 22);
        this.ProgressBar1.MarqueeAnimationSpeed = 50;
        this.ProgressBar1.Maximum = 500;
        this.ProgressBar1.Name = "ProgressBar1";
        this.ProgressBar1.Size = new System.Drawing.Size(293, 18);
        this.ProgressBar1.Step = 1;
        this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        this.ProgressBar1.TabIndex = 12;
        // 
        // Label5
        // 
        this.Label5.BackColor = System.Drawing.SystemColors.Control;
        this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label5.Location = new System.Drawing.Point(11, 17);
        this.Label5.Name = "Label5";
        this.Label5.Size = new System.Drawing.Size(79, 48);
        this.Label5.TabIndex = 14;
        this.Label5.Text = "0";
        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // GroupBox2
        // 
        this.GroupBox2.Controls.Add(this.GroupBox3);
        this.GroupBox2.Controls.Add(this.Label5);
        this.GroupBox2.Controls.Add(this.Label4);
        this.GroupBox2.Controls.Add(this.Label14);
        this.GroupBox2.Controls.Add(this.Label13);
        this.GroupBox2.Controls.Add(this.Label12);
        this.GroupBox2.Location = new System.Drawing.Point(13, 147);
        this.GroupBox2.Name = "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(158, 71);
        this.GroupBox2.TabIndex = 15;
        this.GroupBox2.TabStop = false;
        this.GroupBox2.Text = "Current";
        this.GroupBox3.Controls.Add(this.Label11);
        this.GroupBox3.Controls.Add(this.Label8);
        this.GroupBox3.Controls.Add(this.Label9);
        this.GroupBox3.Location = new System.Drawing.Point(201, 16);
        this.GroupBox3.Name = "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(117, 77);
        this.GroupBox3.TabIndex = 24;
        this.GroupBox3.TabStop = false;
        this.GroupBox3.Text = "GroupBox3";
        this.Label11.AutoSize = true;
        this.Label11.BackColor = System.Drawing.SystemColors.Control;
        this.Label11.Location = new System.Drawing.Point(38, 46);
        this.Label11.Name = "Label11";
        this.Label11.Size = new System.Drawing.Size(43, 13);
        this.Label11.TabIndex = 20;
        this.Label11.Text = "Voltage";
        this.Label8.BackColor = System.Drawing.SystemColors.Control;
        this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label8.Location = new System.Drawing.Point(75, 1);
        this.Label8.Name = "Label8";
        this.Label8.Size = new System.Drawing.Size(31, 48);
        this.Label8.TabIndex = 18;
        this.Label8.Text = "V";
        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label9
        // 
        this.Label9.BackColor = System.Drawing.SystemColors.Control;
        this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label9.Location = new System.Drawing.Point(0, 1);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(79, 48);
        this.Label9.TabIndex = 18;
        this.Label9.Text = "0";
        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label14
        // 
        this.Label14.AutoSize = true;
        this.Label14.Location = new System.Drawing.Point(13, 120);
        this.Label14.Name = "Label14";
        this.Label14.Size = new System.Drawing.Size(28, 13);
        this.Label14.TabIndex = 23;
        this.Label14.Text = "0mA";
        this.Label13.AutoSize = true;
        this.Label13.Location = new System.Drawing.Point(279, 120);
        this.Label13.Name = "Label13";
        this.Label13.Size = new System.Drawing.Size(40, 13);
        this.Label13.TabIndex = 22;
        this.Label13.Text = "500mA";
        this.Label12.AutoSize = true;
        this.Label12.Location = new System.Drawing.Point(116, 120);
        this.Label12.Name = "Label12";
        this.Label12.Size = new System.Drawing.Size(90, 13);
        this.Label12.TabIndex = 21;
        this.Label12.Text = "Current Bar graph";
        this.GroupBox4.Controls.Add(this.GroupBox5);
        this.GroupBox4.Controls.Add(this.Label17);
        this.GroupBox4.Controls.Add(this.Label18);
        this.GroupBox4.Controls.Add(this.Label19);
        this.GroupBox4.Controls.Add(this.Label20);
        this.GroupBox4.Controls.Add(this.Label21);
        this.GroupBox4.Location = new System.Drawing.Point(181, 147);
        this.GroupBox4.Name = "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(158, 71);
        this.GroupBox4.TabIndex = 18;
        this.GroupBox4.TabStop = false;
        this.GroupBox4.Text = "Voltage";
        this.GroupBox5.Controls.Add(this.Label10);
        this.GroupBox5.Controls.Add(this.Label15);
        this.GroupBox5.Controls.Add(this.Label16);
        this.GroupBox5.Location = new System.Drawing.Point(201, 16);
        this.GroupBox5.Name = "GroupBox5";
        this.GroupBox5.Size = new System.Drawing.Size(117, 77);
        this.GroupBox5.TabIndex = 24;
        this.GroupBox5.TabStop = false;
        this.GroupBox5.Text = "GroupBox5";
        this.Label10.AutoSize = true;
        this.Label10.BackColor = System.Drawing.SystemColors.Control;
        this.Label10.Location = new System.Drawing.Point(38, 46);
        this.Label10.Name = "Label10";
        this.Label10.Size = new System.Drawing.Size(43, 13);
        this.Label10.TabIndex = 20;
        this.Label10.Text = "Voltage";
        this.Label15.BackColor = System.Drawing.SystemColors.Control;
        this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label15.Location = new System.Drawing.Point(75, 1);
        this.Label15.Name = "Label15";
        this.Label15.Size = new System.Drawing.Size(31, 48);
        this.Label15.TabIndex = 18;
        this.Label15.Text = "V";
        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label16
        // 
        this.Label16.BackColor = System.Drawing.SystemColors.Control;
        this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label16.Location = new System.Drawing.Point(0, 1);
        this.Label16.Name = "Label16";
        this.Label16.Size = new System.Drawing.Size(79, 48);
        this.Label16.TabIndex = 18;
        this.Label16.Text = "0";
        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label17
        // 
        this.Label17.BackColor = System.Drawing.SystemColors.Control;
        this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label17.Location = new System.Drawing.Point(11, 17);
        this.Label17.Name = "Label17";
        this.Label17.Size = new System.Drawing.Size(79, 48);
        this.Label17.TabIndex = 14;
        this.Label17.Text = "0";
        this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label18
        // 
        this.Label18.BackColor = System.Drawing.SystemColors.Control;
        this.Label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label18.Location = new System.Drawing.Point(90, 17);
        this.Label18.Name = "Label18";
        this.Label18.Size = new System.Drawing.Size(55, 48);
        this.Label18.TabIndex = 9;
        this.Label18.Text = "V";
        this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label19
        // 
        this.Label19.AutoSize = true;
        this.Label19.Location = new System.Drawing.Point(13, 120);
        this.Label19.Name = "Label19";
        this.Label19.Size = new System.Drawing.Size(28, 13);
        this.Label19.TabIndex = 23;
        this.Label19.Text = "0mA";
        this.Label20.AutoSize = true;
        this.Label20.Location = new System.Drawing.Point(279, 120);
        this.Label20.Name = "Label20";
        this.Label20.Size = new System.Drawing.Size(40, 13);
        this.Label20.TabIndex = 22;
        this.Label20.Text = "500mA";
        this.Label21.AutoSize = true;
        this.Label21.Location = new System.Drawing.Point(116, 120);
        this.Label21.Name = "Label21";
        this.Label21.Size = new System.Drawing.Size(90, 13);
        this.Label21.TabIndex = 21;
        this.Label21.Text = "Current Bar graph";
        this.GroupBox6.Controls.Add(this.Label33);
        this.GroupBox6.Controls.Add(this.ProgressBar1);
        this.GroupBox6.Controls.Add(this.Label22);
        this.GroupBox6.Controls.Add(this.Label23);
        this.GroupBox6.Location = new System.Drawing.Point(12, 224);
        this.GroupBox6.Name = "GroupBox6";
        this.GroupBox6.Size = new System.Drawing.Size(327, 65);
        this.GroupBox6.TabIndex = 19;
        this.GroupBox6.TabStop = false;
        this.GroupBox6.Text = "Current Bar Graph";
        this.Label33.AutoSize = true;
        this.Label33.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label33.Location = new System.Drawing.Point(133, 43);
        this.Label33.Name = "Label33";
        this.Label33.Size = new System.Drawing.Size(65, 13);
        this.Label33.TabIndex = 36;
        this.Label33.Text = "Current (mA)";
        this.Label22.AutoSize = true;
        this.Label22.Location = new System.Drawing.Point(12, 43);
        this.Label22.Name = "Label22";
        this.Label22.Size = new System.Drawing.Size(13, 13);
        this.Label22.TabIndex = 0;
        this.Label22.Text = "0";
        this.Label23.AutoSize = true;
        this.Label23.Location = new System.Drawing.Point(298, 43);
        this.Label23.Name = "Label23";
        this.Label23.Size = new System.Drawing.Size(25, 13);
        this.Label23.TabIndex = 1;
        this.Label23.Text = "500";
        this.CheckBox1.AutoSize = true;
        this.CheckBox1.Location = new System.Drawing.Point(200, 280);
        this.CheckBox1.Name = "CheckBox1";
        this.CheckBox1.Size = new System.Drawing.Size(87, 17);
        this.CheckBox1.TabIndex = 36;
        this.CheckBox1.TabStop = false;
        this.CheckBox1.Text = "Enable Chart";
        this.CheckBox1.UseVisualStyleBackColor = true;
        this.TextBox3.BackColor = System.Drawing.SystemColors.Window;
        this.TextBox3.Enabled = false;
        this.TextBox3.Location = new System.Drawing.Point(167, 70);
        this.TextBox3.Name = "TextBox3";
        this.TextBox3.ReadOnly = true;
        this.TextBox3.Size = new System.Drawing.Size(144, 20);
        this.TextBox3.TabIndex = 23;
        this.TextBox3.TabStop = false;
        this.GroupBox1.Controls.Add(this.Label35);
        this.GroupBox1.Controls.Add(this.TextBox5);
        this.GroupBox1.Controls.Add(this.Label25);
        this.GroupBox1.Controls.Add(this.GroupBox7);
        this.GroupBox1.Controls.Add(this.TextBox3);
        this.GroupBox1.Controls.Add(this.TextBox2);
        this.GroupBox1.Controls.Add(this.Label2);
        this.GroupBox1.Controls.Add(this.TextBox1);
        this.GroupBox1.Controls.Add(this.Label1);
        this.GroupBox1.Controls.Add(this.Label3);
        this.GroupBox1.Location = new System.Drawing.Point(12, 12);
        this.GroupBox1.Name = "GroupBox1";
        this.GroupBox1.Size = new System.Drawing.Size(327, 129);
        this.GroupBox1.TabIndex = 24;
        this.GroupBox1.TabStop = false;
        this.GroupBox1.Text = "Device Details";
        this.Label35.AutoSize = true;
        this.Label35.Location = new System.Drawing.Point(91, 99);
        this.Label35.Name = "Label35";
        this.Label35.Size = new System.Drawing.Size(0, 13);
        this.Label35.TabIndex = 0;
        // 
        // TextBox5
        // 
        this.TextBox5.BackColor = System.Drawing.SystemColors.Window;
        this.TextBox5.Enabled = false;
        this.TextBox5.Location = new System.Drawing.Point(167, 96);
        this.TextBox5.Name = "TextBox5";
        this.TextBox5.ReadOnly = true;
        this.TextBox5.Size = new System.Drawing.Size(144, 20);
        this.TextBox5.TabIndex = 33;
        this.TextBox5.TabStop = false;
        this.Label25.AutoSize = true;
        this.Label25.Location = new System.Drawing.Point(6, 99);
        this.Label25.Name = "Label25";
        this.Label25.Size = new System.Drawing.Size(40, 13);
        this.Label25.TabIndex = 32;
        this.Label25.Text = "Status:";
        this.GroupBox7.Location = new System.Drawing.Point(-159, 154);
        this.GroupBox7.Name = "GroupBox7";
        this.GroupBox7.Size = new System.Drawing.Size(200, 100);
        this.GroupBox7.TabIndex = 25;
        this.GroupBox7.TabStop = false;
        this.GroupBox7.Text = "GroupBox7";
        this.TextBox2.BackColor = System.Drawing.SystemColors.Window;
        this.TextBox2.Enabled = false;
        this.TextBox2.Location = new System.Drawing.Point(167, 44);
        this.TextBox2.Name = "TextBox2";
        this.TextBox2.ReadOnly = true;
        this.TextBox2.Size = new System.Drawing.Size(144, 20);
        this.TextBox2.TabIndex = 4;
        this.TextBox2.TabStop = false;
        this.Label2.Location = new System.Drawing.Point(6, 47);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(136, 23);
        this.Label2.TabIndex = 5;
        this.Label2.Text = "Serial Number:";
        this.TextBox1.BackColor = System.Drawing.SystemColors.Window;
        this.TextBox1.Enabled = false;
        this.TextBox1.Location = new System.Drawing.Point(167, 18);
        this.TextBox1.Name = "TextBox1";
        this.TextBox1.ReadOnly = true;
        this.TextBox1.Size = new System.Drawing.Size(144, 20);
        this.TextBox1.TabIndex = 1;
        this.TextBox1.TabStop = false;
        this.Label1.Location = new System.Drawing.Point(6, 19);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(112, 16);
        this.Label1.TabIndex = 3;
        this.Label1.Text = "Number of Devices:";
        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label3
        // 
        this.Label3.Location = new System.Drawing.Point(6, 73);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(128, 23);
        this.Label3.TabIndex = 6;
        this.Label3.Text = "Description:";
        this.Button_Init.Location = new System.Drawing.Point(369, 331);
        this.Button_Init.Name = "Button_Init";
        this.Button_Init.Size = new System.Drawing.Size(62, 30);
        this.Button_Init.TabIndex = 1;
        this.Button_Init.Text = "Initialise";
        this.Button_Init.UseVisualStyleBackColor = true;
        this.Button_Stop.Location = new System.Drawing.Point(582, 331);
        this.Button_Stop.Name = "Button_Stop";
        this.Button_Stop.Size = new System.Drawing.Size(67, 30);
        this.Button_Stop.TabIndex = 26;
        this.Button_Stop.Text = "Stop";
        this.Button_Stop.UseVisualStyleBackColor = true;
        this.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Panel1.Location = new System.Drawing.Point(68, 19);
        this.Panel1.Name = "Panel1";
        this.Panel1.Size = new System.Drawing.Size(340, 253);
        this.Panel1.TabIndex = 27;
        // 
        // Chart
        // 
        this.Chart.Controls.Add(this.Label31);
        this.Chart.Controls.Add(this.CheckBox1);
        this.Chart.Controls.Add(this.Label30);
        this.Chart.Controls.Add(this.Label29);
        this.Chart.Controls.Add(this.Label28);
        this.Chart.Controls.Add(this.Label27);
        this.Chart.Controls.Add(this.Label26);
        this.Chart.Controls.Add(this.Label7);
        this.Chart.Controls.Add(this.Label6);
        this.Chart.Controls.Add(this.Panel1);
        this.Chart.Location = new System.Drawing.Point(353, 12);
        this.Chart.Name = "Chart";
        this.Chart.Size = new System.Drawing.Size(418, 308);
        this.Chart.TabIndex = 28;
        this.Chart.TabStop = false;
        this.Chart.Text = "Current Chart";
        this.Label31.AutoSize = true;
        this.Label31.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label31.Location = new System.Drawing.Point(2, 126);
        this.Label31.Name = "Label31";
        this.Label31.Size = new System.Drawing.Size(41, 13);
        this.Label31.TabIndex = 35;
        this.Label31.Text = "Current";
        this.Label30.AutoSize = true;
        this.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label30.Location = new System.Drawing.Point(8, 142);
        this.Label30.Name = "Label30";
        this.Label30.Size = new System.Drawing.Size(28, 13);
        this.Label30.TabIndex = 34;
        this.Label30.Text = "(mA)";
        this.Label29.AutoSize = true;
        this.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label29.Location = new System.Drawing.Point(43, 164);
        this.Label29.Name = "Label29";
        this.Label29.Size = new System.Drawing.Size(25, 13);
        this.Label29.TabIndex = 33;
        this.Label29.Text = "200";
        this.Label28.AutoSize = true;
        this.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label28.Location = new System.Drawing.Point(43, 214);
        this.Label28.Name = "Label28";
        this.Label28.Size = new System.Drawing.Size(25, 13);
        this.Label28.TabIndex = 32;
        this.Label28.Text = "100";
        this.Label27.AutoSize = true;
        this.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label27.Location = new System.Drawing.Point(43, 114);
        this.Label27.Name = "Label27";
        this.Label27.Size = new System.Drawing.Size(25, 13);
        this.Label27.TabIndex = 31;
        this.Label27.Text = "300";
        this.Label26.AutoSize = true;
        this.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label26.Location = new System.Drawing.Point(43, 63);
        this.Label26.Name = "Label26";
        this.Label26.Size = new System.Drawing.Size(25, 13);
        this.Label26.TabIndex = 30;
        this.Label26.Text = "400";
        this.Label7.AutoSize = true;
        this.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label7.Location = new System.Drawing.Point(52, 264);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(13, 13);
        this.Label7.TabIndex = 29;
        this.Label7.Text = "0";
        this.Label6.AutoSize = true;
        this.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.Label6.Location = new System.Drawing.Point(43, 14);
        this.Label6.Name = "Label6";
        this.Label6.Size = new System.Drawing.Size(25, 13);
        this.Label6.TabIndex = 28;
        this.Label6.Text = "500";
        this.PictureBox1.Image = Global.D2XXUnit_NET.My.Resources.Resources.FTDI;
        this.PictureBox1.Location = new System.Drawing.Point(12, 302);
        this.PictureBox1.Name = "PictureBox1";
        this.PictureBox1.Size = new System.Drawing.Size(158, 57);
        this.PictureBox1.TabIndex = 29;
        this.PictureBox1.TabStop = false;
        this.Label24.AutoSize = true;
        this.Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label24.Location = new System.Drawing.Point(175, 299);
        this.Label24.Name = "Label24";
        this.Label24.Size = new System.Drawing.Size(162, 16);
        this.Label24.TabIndex = 30;
        this.Label24.Text = "FT232H SPI Current Meter";
        this.Label32.AutoSize = true;
        this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, !, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label32.Location = new System.Drawing.Point(217, 315);
        this.Label32.Name = "Label32";
        this.Label32.Size = new System.Drawing.Size(68, 15);
        this.Label32.TabIndex = 34;
        this.Label32.Text = "Version 1.0";
        this.Label34.AutoSize = true;
        this.Label34.Location = new System.Drawing.Point(192, 345);
        this.Label34.Name = "Label34";
        this.Label34.Size = new System.Drawing.Size(122, 13);
        this.Label34.TabIndex = 35;
        this.Label34.Text = "http://www.ftdichip.com";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(784, 368);
        this.ControlBox = false;
        this.Controls.Add(this.Label34);
        this.Controls.Add(this.Label32);
        this.Controls.Add(this.PictureBox1);
        this.Controls.Add(this.Chart);
        this.Controls.Add(this.GroupBox1);
        this.Controls.Add(this.Button_Stop);
        this.Controls.Add(this.GroupBox4);
        this.Controls.Add(this.Button_Init);
        this.Controls.Add(this.Button_Start);
        this.Controls.Add(this.Button_Exit);
        this.Controls.Add(this.GroupBox2);
        this.Controls.Add(this.GroupBox6);
        this.Controls.Add(this.Label24);
        this.DoubleBuffered = true;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MaximumSize = new System.Drawing.Size(790, 400);
        this.MinimumSize = new System.Drawing.Size(790, 400);
        this.Name = "Form1";
        this.RightToLeftLayout = true;
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.Text = "i-SPI    FT232H SPI Current Meter";
        this.GroupBox2.ResumeLayout(false);
        this.GroupBox2.PerformLayout();
        this.GroupBox3.ResumeLayout(false);
        this.GroupBox3.PerformLayout();
        this.GroupBox4.ResumeLayout(false);
        this.GroupBox4.PerformLayout();
        this.GroupBox5.ResumeLayout(false);
        this.GroupBox5.PerformLayout();
        this.GroupBox6.ResumeLayout(false);
        this.GroupBox6.PerformLayout();
        this.GroupBox1.ResumeLayout(false);
        this.GroupBox1.PerformLayout();
        this.Chart.ResumeLayout(false);
        this.Chart.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    
    //  NOTE:   This code is provided as an example only and is not supported or guaranteed by FTDI.
    //  Bits assigned on FT232H AD bus
    //     0    Out     SPI CLK (SCK)
    //     1    Out     SPI DO (MOSI)
    //     2     In      SPI DI (MISO)
    //     3    Out     SPI CS0        
    //     4    Out     SPI CS1
    //     5    Out     Not used (optional Error LED)
    //     6    In      PWRGOOD input from power supply voltage monitor
    //     7    Out     Status LED on when pin low (flashes on during SPI read)
    private bool DeviceInit;
    
    private int BytesWritten;
    
    private bool ReadSuccess;
    
    private int BytesRead;
    
    private byte BytesToRead;
    
    private int NumBytesInQueue;
    
    private bool SPI_Device_Found;
    
    private bool LoggingEnabled;
    
    private byte QueueTimeOut;
    
    private int GraphIndex;
    
    private int GraphInputIndex;
    
    private int GraphInputPointer;
    
    private Graphics g;
    
    private int Y;
    
    private int X;
    
    private bool ChartToZero;
    
    private bool RepaintChart;
    
    private int result16;
    
    private int current;
    
    private double voltage;
    
    private byte Pin_Values = 0;
    
    private byte LED_State = 0;
    
    //  1x1x xxxx     LED State controls bits 7 and 5, high means LED off
    private byte CS_State = 0;
    
    //  xxx1 1xxx     CS State controls bits 4 and 3, high means not selected
    private byte Pin_Defaults = 70;
    
    //  x1xx x110     SPI pins and inputs default to high, clock idles low
    private byte Pin_Directions = 187;
    
    //  1011 1011     All pins output (1) except DI and PWRGOOD
    public const byte LED_Status_On = 32;
    
    //  Bit 7 low, Bit 5 high
    public const byte LED_Error_On = 128;
    
    //  Error LED not currently implemented, would be on bit 5
    public const byte LED_Both_On = 0;
    
    //  Bit 7 and Bit 5 low
    public const byte LED_Both_Off = 160;
    
    //  Bit 7 and Bit 5 high
    public const byte CS_None = 24;
    
    //  Bit 4 and Bit 3 high
    public const byte CS_CS0 = 16;
    
    //  Bit 3 low
    public const byte CS_CS1 = 8;
    
    //  Bit 4 low
    private void Button3_Click(object sender, System.EventArgs e) {
        //  Code for INIT button
        int DeviceCount;
        int DeviceIndex;
        string TempDevString;
        string TempDevSerial;
        string FT_Description_Temp;
        string FT_Serial_Temp;
        // ############################################################################################################
        //  Initialise the MPSSE
        // ############################################################################################################
        //  Prevent user clicking any buttons on user interface until Init complete
        Button_Start.Enabled = false;
        Button_Exit.Enabled = false;
        Button_Init.Enabled = false;
        Button_Stop.Enabled = false;
        Button_Init.Focus();
        // 
        // ************************************************************************************************************
        //  Get the number of FTDI devices attached
        // ************************************************************************************************************
        //  Check the number of FTDI devices
        FT_Status = FT_GetNumberOfDevices(DeviceCount, vbNullChar, FT_LIST_NUMBER_ONLY);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("GetNumberOfDevices Failed");
            return;
        }
        
        //  Inform user if no devices connected and exit this subroutine
        //  Enable buttons to allow user to re-try Init or to Exit 
        if ((DeviceCount == 0)) {
            TextBox1.Text = "0";
            TextBox5.Text = "No FTDI Devices Found";
            Button_Start.Enabled = false;
            Button_Exit.Enabled = true;
            Button_Init.Enabled = true;
            Button_Stop.Enabled = false;
            Button_Init.Focus();
            return;
        }
        else {
            //  Otherwise display device count returned by FT_GetNumberOfDevices on form
            TextBox1.Text = DeviceCount.ToString;
        }
        
        // ************************************************************************************************************
        //  Get a handle to the "FT232H SPI Demo" by checking the String returned by each FTDI device
        // ************************************************************************************************************
        //  Go through each FTDI device and check text string to see if it is the SPI Demo 
        //  Increment device index until all devices found were checked or until device found with the correct string
        //  Note: If more than one FTDI device with the string FT232H SPI Demo is found, the first will be opened
        DeviceIndex = 0;
        SPI_Device_Found = false;
        while (((DeviceIndex < DeviceCount) 
                    && (SPI_Device_Found == false))) {
            TempDevString = Space(64);
            TempDevSerial = Space(64);
            //  Get the string at the specified index
            FT_Status = FT_GetDeviceString(DeviceIndex, TempDevString, (FT_LIST_BY_INDEX | FT_OPEN_BY_DESCRIPTION));
            //  Check if the function failed...
            if ((FT_Status != FT_OK)) {
                this.CommLostError("GetDeviceString Failed");
                return;
            }
            
            //  Get the serial number at the specified index
            FT_Status = FT_GetDeviceString(DeviceIndex, TempDevSerial, (FT_LIST_BY_INDEX | FT_OPEN_BY_SERIAL_NUMBER));
            //  Check if the function failed...
            if ((FT_Status != FT_OK)) {
                this.CommLostError("GetDeviceString Failed");
                return;
            }
            
            //  Format the strings
            FT_Description_Temp = TempDevString.Substring(0, ((TempDevString.IndexOf(vbNullChar, 0) + 1) 
                            - 1));
            FT_Serial_Temp = TempDevSerial.Substring(0, ((TempDevString.IndexOf(vbNullChar, 0) + 1) 
                            - 1));
            //  Check if device is the SPI Demo
            if ((FT_Description_Temp == "FT232H SPI Demo")) {
                //  Display serial number on form
                FT_Serial_Number = FT_Serial_Temp;
                FT_Description = FT_Description_Temp;
                TextBox3.Text = FT_Description;
                TextBox2.Text = FT_Serial_Number;
                //  Set flag to show that device was found and we can stop looking
                SPI_Device_Found = true;
            }
            else {
                //  Otherwise try the next index
                DeviceIndex = (DeviceIndex + 1);
            }
            
        }
        
        //  Tell user if no FT232H SPI Demo device found. Allow them to re-try the init or to exit
        if ((SPI_Device_Found == false)) {
            TextBox5.Text = "No SPI Devices Found";
            Button_Start.Enabled = false;
            Button_Exit.Enabled = true;
            Button_Init.Enabled = true;
            Button_Stop.Enabled = false;
            Button_Init.Focus();
            return;
        }
        
        // ************************************************************************************************************
        //  Open the device using the index which was found above
        // ************************************************************************************************************
        //  Open the SPI Demo using the index found above
        FT_Status = FT_OpenByIndex(DeviceIndex, FT_Handle);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("OpenByIndex Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  Configure the MPSSE in the device
        // ************************************************************************************************************
        //  Reset the device
        FT_Status = FT_ResetDevice(FT_Handle);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("ResetDevice Failed");
            return;
        }
        
        //  Set Bit mode to MPSSE
        //  Mode = 2 and I/O directions are 0xBB as required for this application 
        FT_Status = FT_SetBitMode(FT_Handle, Pin_Directions, 2);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("SetBitMode Failed");
            return;
        }
        
        //  Set latency timer to 16ms (this is actually the default value)
        FT_Status = FT_SetLatencyTimer(FT_Handle, 16);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("SetLatencyTimer Failed");
            return;
        }
        
        //  Set timeouts to infinite for read and infinite for write
        //  Could set a read timeout of 500ms instead if required
        FT_Status = FT_SetTimeouts(FT_Handle, 0, 0);
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("SetTimeouts Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  Disable the /5 MPSSE divider
        // ************************************************************************************************************
        SendBuffer(0) = 138;
        //  MPSSE command to disable the /5 divider for a 60MHz master clock
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Disable /5 Divider Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  set TCK/SK divisor to 50KHz
        // ************************************************************************************************************
        //  See command processor for MPSSE application note for further information
        //  TCK           = 60MHz    / ((1 + [ (0xValueH * 256) OR 0xValueL] ) * 2)
        //                = 60000000 / ((1 + [ (  0x02   * 256) OR   0x57  ] ) * 2)
        //                = 60000000 / ((1 + [ (  512           +      87  ] ) * 2)
        //                = 60000000 / ((1 + 512 + 87)                         * 2)
        //                = 60000000 / 600 * 2
        //                = 50000
        //                = 50kHz
        SendBuffer(0) = 134;
        //  MPSSE command to set the divisor
        SendBuffer(1) = 87;
        //  Low value = 0x57
        SendBuffer(2) = 2;
        //  High value = 0x02
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Set Divider Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  Sync 1 - Send an invalid command 0xAA to the MPSSE and check that it replies with 'Invalid Command'
        // ************************************************************************************************************
        //  Send the command to the MPSSE
        SendBuffer(0) = 170;
        //  0xAA is an invalid command for the MPSSE
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Write Failed");
            return;
        }
        
        //  Now wait for a reply
        //  MPSSE will return 0xFA followed by the bad command 0xAA 
        this.Receive_Data(2);
        if ((BytesRead == 2)) {
            //  Check that we got the correct data back otherwise cancel the initialisation
            if (((ReceiveBuffer(0) != 250) 
                        || (ReceiveBuffer(1) != 170))) {
                this.CommLostError("MPSSE Sync Failed");
                return;
            }
            
            //  If 2 bytes not received
        }
        else {
            this.Receive_Error();
            return;
        }
        
        // ************************************************************************************************************
        //  Sync 2 - Send an invalid command 0xAB to the MPSSE and check that it replies with 'Invalid Command'
        // ************************************************************************************************************
        //  Send the command to the MPSSE
        SendBuffer(0) = 171;
        //  0xAB is an invalid command for the MPSSE
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Write Failed");
            return;
        }
        
        //  Now wait for a reply
        //  MPSSE will return 0xFA followed by the bad command 0xAB 
        this.Receive_Data(2);
        if ((BytesRead == 2)) {
            //  Check that we got the correct data back otherwise cancel the initialisation
            if (((ReceiveBuffer(0) != 250) 
                        || (ReceiveBuffer(1) != 171))) {
                this.CommLostError("MPSSE Sync Failed");
                return;
            }
            
            //  If 2 bytes not received
        }
        else {
            this.Receive_Error();
            return;
        }
        
        // ************************************************************************************************************
        //  disable the loopback
        // ************************************************************************************************************
        SendBuffer(0) = 133;
        //  MPSSE command to disable loopback
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Disable Loopback Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  Set the direction and value of the low data bits and set port to idle state with LED on to show initialised
        // ************************************************************************************************************
        //  Set the required values for the pins
        LED_State = LED_Status_On;
        //  0x1x xxxx
        CS_State = CS_None;
        //  xxx1 1xxx
        Pin_Values = (Pin_Defaults 
                    | (LED_State | CS_State));
        //  x1xx x110 or LED_State or CS_State
        SendBuffer(0) = 128;
        //  MPSSE Command to set low bits of port (AD7 to AD0 in the FT232H)
        SendBuffer(1) = Pin_Values;
        //  
        SendBuffer(2) = Pin_Directions;
        //  
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
        //  Write buffer to the device
        //  Check if the function failed...
        if ((FT_Status != FT_OK)) {
            this.CommLostError("Set Pin States Failed");
            return;
        }
        
        // ************************************************************************************************************
        //  Set flag to show that device now initialised
        // ************************************************************************************************************
        DeviceInit = true;
        TextBox5.Text = "Ready";
        Button_Start.Enabled = true;
        Button_Init.Enabled = false;
        Button_Exit.Enabled = true;
        Button_Stop.Enabled = false;
        Button_Start.Focus();
        //  Switch focus to the start button
        ChartToZero = true;
        RepaintChart = true;
        Panel1.Refresh();
        //  Cause the re-paint to occur
        Update();
        //  Update the dialog box
        Application.DoEvents();
    }
    
    private void Button1_Click(object sender, System.EventArgs e) {
        //  Code for the START button
        //  Configure the buttons on the user form
        Button_Start.Enabled = false;
        Button_Exit.Enabled = false;
        Button_Init.Enabled = false;
        Button_Stop.Enabled = true;
        Button_Stop.Focus();
        // ############################################################################################################
        //  Take readings from the port pins and then ADCs (ADC0 in Chip Select 0 first, then ADC1 on Chip Select 1)
        // ############################################################################################################
        TextBox5.Text = "Running";
        LoggingEnabled = true;
        while ((LoggingEnabled == true)) {
            if ((RepaintChart == false)) {
                //  Don't run again until chart has finished re-painting
                // ************************************************************************************************************
                //  Set idle condition with LED on and no chip selects asserted
                // ************************************************************************************************************
                //  Set the required values for the pins
                //  See top of code listing for pin definitions
                LED_State = LED_Status_On;
                //  0x1x xxxx
                CS_State = CS_None;
                //  xxx1 1xxx
                Pin_Values = (Pin_Defaults 
                            | (LED_State | CS_State));
                //  x1xx x110 or LED_State or CS_State
                SendBuffer(0) = 128;
                //  MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values;
                //  
                SendBuffer(2) = Pin_Directions;
                //  
                //  Send the buffer
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Write Failed");
                    return;
                }
                
                //  Short delay
                Sleep(10);
                // ************************************************************************************************************
                //  Read PWRGOOD line
                // ************************************************************************************************************
                //  This command causes the MPSSE to read the pin values and sedn them to the PC
                //  Put the command into the buffer
                SendBuffer(0) = 129;
                //  Command to read data bits (low byte) which is AD0 - AD7
                //  Send the buffer
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten);
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Read Pwrgood Failed");
                    return;
                }
                
                //  Short delay
                Sleep(10);
                // ****************************
                //  Read
                // ****************************
                //  Now read the resulting byte from the driver buffer, which contains the port value
                this.Receive_Data(1);
                if ((BytesRead == 1)) {
                    //  Mask off bit 6 and check if it is high or low
                    if (((ReceiveBuffer(0) && 64) 
                                == 0)) {
                        //  If the line is low, the supply is out of range
                        TextBox5.Text = "Power supply out of range";
                    }
                    else {
                        TextBox5.Text = "Running";
                    }
                    
                }
                else {
                    this.Receive_Error();
                    return;
                }
                
                // ************************************************************************************************************
                //  Bring CS0 low to read the Current measurement ADC and turn off Status LED (blinks off during the measurement)
                // ************************************************************************************************************
                //  Set the required values for the pins
                LED_State = LED_Both_Off;
                //  1x1x xxxx
                CS_State = CS_CS0;
                //  xxx1 0xxx
                Pin_Values = (Pin_Defaults 
                            | (LED_State | CS_State));
                //  x1xx x110 or LED_State or CS_State
                SendBuffer(0) = 128;
                //  MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values;
                //  
                SendBuffer(2) = Pin_Directions;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write string data to device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Set Pin States Failed");
                    return;
                }
                
                Sleep(10);
                // ************************************************************************************************************
                //  Tell the MPSSE to do an SPI read and send it to the PC
                // ************************************************************************************************************
                //  Send a command to ask the MPSSE to read two bytes over the SPI and send them to the PC
                SendBuffer(0) = 32;
                //  MPSSE command to read bytes in from SPI, Pos clock edge, MSB first
                SendBuffer(1) = 1;
                //  0001 means clock in two bytes
                SendBuffer(2) = 0;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write the buffer to the FTDI device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("SPI Read Failed");
                    return;
                }
                
                Sleep(10);
                // ************************************
                //  Read data from the PC Driver buffer
                // ************************************
                //  Now read the resulting 2 bytes from the driver buffer, which contains the ADC result
                this.Receive_Data(2);
                if ((BytesRead == 2)) {
                    //  Combine the two received bytes into a single value
                    result16 = (((ReceiveBuffer(1) / 2) 
                                && 127) 
                                + ((ReceiveBuffer(0) && 31) 
                                * 128));
                    current = ((result16 / 4096) 
                                * 500);
                }
                else {
                    this.Receive_Error();
                    return;
                }
                
                // ************************************************************************************************************
                //  Disable CS0 with Status LED still off
                // ************************************************************************************************************
                //  Set the required values for the pins
                LED_State = LED_Both_Off;
                //  1x1x xxxx
                CS_State = CS_None;
                //  xxx1 1xxx
                Pin_Values = (Pin_Defaults 
                            | (LED_State | CS_State));
                //  x1xx x110 or LED_State or CS_State
                SendBuffer(0) = 128;
                //  MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values;
                //  
                SendBuffer(2) = Pin_Directions;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write string data to device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Set Pin States Failed");
                    return;
                }
                
                Sleep(10);
                // ************************************************************************************************************
                //  Bring CS1 low to read the Voltage measurement ADC
                // ************************************************************************************************************
                //  Set the required values for the pins
                LED_State = LED_Both_Off;
                //  1x1x xxxx
                CS_State = CS_CS1;
                //  xxx0 1xxx
                Pin_Values = (Pin_Defaults 
                            | (LED_State | CS_State));
                //  x1xx x110 or LED_State or CS_State
                SendBuffer(0) = 128;
                //  MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values;
                //  
                SendBuffer(2) = Pin_Directions;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write string data to device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Set Pin States Failed");
                    return;
                }
                
                Sleep(10);
                // ************************************************************************************************************
                //  Tell the MPSSE to do an SPI read and send it to the PC
                // ************************************************************************************************************
                SendBuffer(0) = 32;
                //  MPSSE command to read bytes in from SPI, Pos clock edge, MSB first
                SendBuffer(1) = 1;
                //  0001 means clock in two bytes
                SendBuffer(2) = 0;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write string data to device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("SPI Read Failed");
                    return;
                }
                
                Sleep(10);
                // ************************************
                //  Read data from the PC Driver buffer
                // ************************************
                this.Receive_Data(2);
                if ((BytesRead == 2)) {
                    //  Combine the two received bytes into a single value
                    result16 = (((ReceiveBuffer(1) / 2) 
                                && 127) 
                                + ((ReceiveBuffer(0) && 31) 
                                * 128));
                    voltage = ((result16 / 4096) 
                                * 6.6);
                    voltage = Math.Round(voltage, 2);
                }
                else {
                    this.Receive_Error();
                    return;
                }
                
                // ************************************************************************************************************
                //  Set idle condition with LED on again since the measurement cycle is complete
                // ************************************************************************************************************
                //  Set the required values for the pins
                LED_State = LED_Status_On;
                //  0x1x xxxx
                CS_State = CS_None;
                //  xxx1 1xxx
                Pin_Values = (Pin_Defaults 
                            | (LED_State | CS_State));
                //  x1xx x110 or LED_State or CS_State
                SendBuffer(0) = 128;
                //  MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values;
                //  
                SendBuffer(2) = Pin_Directions;
                //  
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
                //  Write string data to device
                //  Check if the function failed...
                if ((FT_Status != FT_OK)) {
                    this.CommLostError("Set Pin States Failed");
                    return;
                }
                
                // ************************************************************************************************************
                //  Update screen
                // ************************************************************************************************************
                //  Meter display
                Label5.Text = current.ToString;
                Label17.Text = voltage.ToString;
                //  Put current value into bar graph
                ProgressBar1.Value = current;
                //  Add the current vaue in mA into the buffer used by the chart plotting routine
                //  The chart Y direction is reversed and has 2mA increments and so 
                //  0mA is stored as 250,
                //  100mA as 200
                //  200mA as 150
                //  500mA as 0
                //  Note: Chart height is 251 pixels so 0mA (y = 250 on the chart) will still be visible above the axis 
                CurrentArray(GraphInputPointer) = (250 
                            - (current / 2));
                if ((GraphInputPointer == 339)) {
                    GraphInputPointer = 0;
                }
                else {
                    GraphInputPointer = (GraphInputPointer + 1);
                }
                
                RepaintChart = true;
                Panel1.Refresh();
            }
            
            Update();
            Application.DoEvents();
            Sleep(30);
        }
        
        //  When code gets here, LoggingEnabled = False and so the Stop button has been pressed
        Button_Init.Enabled = false;
        Button_Start.Enabled = true;
        Button_Exit.Enabled = true;
        Button_Stop.Enabled = false;
        Button_Exit.Focus();
        TextBox5.Text = "Stopped";
    }
    
    private void Button2_Click(object sender, System.EventArgs e) {
        //  Code for the EXIT button
        Button_Start.Enabled = false;
        Button_Exit.Enabled = false;
        Button_Init.Enabled = false;
        Button_Stop.Enabled = false;
        LoggingEnabled = false;
        LED_State = LED_Both_Off;
        //  1x1x xxxx
        CS_State = CS_None;
        //  xxx1 1xxx
        Pin_Values = (Pin_Defaults 
                    | (LED_State | CS_State));
        //  x1xx x110 or LED_State or CS_State
        SendBuffer(0) = 128;
        //  MPSSE Command to set low bits of port
        SendBuffer(1) = Pin_Values;
        //  
        SendBuffer(2) = Pin_Directions;
        //  
        //  Send the buffer
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten);
        //  Check if the function failed...
        // If FT_Status <> FT_OK Then
        //     'CommLostError("No device to close")
        // End If
        //  If device was initialised, then close it before exiting
        if ((DeviceInit == true)) {
            FT_Status = FT_Close(FT_Handle);
            if ((FT_Status == FT_OK)) {
                TextBox5.Text = "Closed";
            }
            
        }
        
        // Update()
        // Application.DoEvents()
        Sleep(700);
        Close();
    }
    
    private void Form1_Load(object sender, System.EventArgs e) {
        //  Initialise the variables, buttons and progress bar when the form loads
        ProgressBar1.Value = 0;
        Button_Init.Enabled = true;
        Button_Start.Enabled = false;
        Button_Exit.Enabled = true;
        Button_Stop.Enabled = false;
        DeviceInit = false;
        LoggingEnabled = false;
        TextBox5.Text = "Unconfigured";
        CheckBox1.Checked = true;
        Button_Init.Focus();
        //  Put focus on the Init button since it will be pressed first
        // ' Draw the FTDI logo, which should be in the same directory as the .exe file
        // ' Logo now added as a project resource so commented out
        //  PictureBox1.Image = System.Drawing.Bitmap.FromFile( _
        //  My.Application.Info.DirectoryPath & "\FTDI.bmp")
        //  Set the entire scrolling chart to zero and trigger re-paint
        ChartToZero = true;
        RepaintChart = true;
        Panel1.Refresh();
        Update();
        Application.DoEvents();
    }
    
    private void Button4_Click(object sender, System.EventArgs e) {
        //  Code for the STOP button
        LoggingEnabled = false;
    }
    
    private void Panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
        //  This subroutine re-draws the entire chart using the data from the CurrentArray array
        //  It is called every time a new reading is taken since the graph needs to be re-drawn each time it scrolls
        //  The panel is 250 pixels high (plus one for the X axis line) and so each pixel is 2mA.
        //  A Y value of 250 is the bottom of the chart (0mA) and a Y value of 0 is the top of the chart (500mA)
        //  It uses a kind of circular buffer where the Y values are passed in an array
        //  The measurement routine adds new values to the array in a circular fashion and updates GraphInputPointer
        //  to show the last point added
        //  This paint routine draws a chart from X values 0 to 339. It uses the last point added plus 1 as the starting point
        //  and then draws the 340 points (including wrapping back to location zero in the array once location 339 is reached)
        //  This means that the last point added is always at the right-hand side of the chart and so it scrolls right to left
        int PaintLoopCounter;
        int Xval1;
        int Xval2;
        int Yval1;
        int Yval2;
        //  This ensures that the chart is only re-painted once a new reading is taken in case the routine is called at other 
        //  times. RepaintChart is set True when new data is put in the buffer or when the chart is being initialised with zeros
        if ((RepaintChart == true)) {
            //  Create a graphics object
            g = Panel1.CreateGraphics();
            //  draw horizontal lines for the current scale 
            //  Y coordinates start from the top of the chart
            g.DrawLine(Pens.LightSkyBlue, 0, 0, 339, 0);
            //  0 = 500mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 50, 339, 50);
            //  50 = 400mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 100, 339, 100);
            //  100 = 300mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 150, 339, 150);
            //  150 = 200mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 200, 339, 200);
            //  200 = 100mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 250, 339, 250);
            //  250 = 0mA line
            //  Draw the samll black tickmark next to each current value on the scale
            g.DrawLine(Pens.Black, 0, 0, 1, 0);
            g.DrawLine(Pens.Black, 0, 50, 1, 50);
            g.DrawLine(Pens.Black, 0, 100, 1, 100);
            g.DrawLine(Pens.Black, 0, 150, 1, 150);
            g.DrawLine(Pens.Black, 0, 200, 1, 200);
            g.DrawLine(Pens.Black, 0, 250, 1, 250);
            //  If starting the program or if the chart is disabled by the checkbox, set all datapoints to zero
            //  This means fill CurrentArray with the value 250 since Y starts from the top of the chart and it is 250 pixels high
            if (((ChartToZero == true) 
                        || (CheckBox1.Checked == false))) {
                GraphInputPointer = 0;
                GraphIndex = 0;
                //  This loop fills all 340 X values of the chart with the Y value 250 (== 0mA)
                while ((GraphIndex < 340)) {
                    CurrentArray(GraphIndex) = 250;
                    GraphIndex = (GraphIndex + 1);
                }
                
                //  Clear the flag so that we can start drawing the graph the next time this subroutine is called
                ChartToZero = false;
                GraphInputPointer = 0;
                GraphIndex = 0;
            }
            else {
                //  If this is a normal painting cycle, then draw the chart 
                //  The CurrentArray has 340 values, which are the Y values for the chart
                //  The measurement routine writes new values one-at-a-time into the array. It updates the
                //  GraphInputPointer value to show where the last value was added
                //  This paint routine starts at that location plus one and draws the 340 points of the chart
                //  Because we do not always start painting at index 0 of the incoming data, we use this 
                //  variable as a 0 - 339 X value 
                PaintLoopCounter = 0;
                //  Set the starting point in the circular buffer based upon the last data added by the measurement subroutine
                //  GraphInputPointer is the index of the last value added from the measurement subroutine
                //  GraphIndex is a copy of this taken by this paint routine and will be used to point to the values to draw the chart
                if ((GraphInputPointer < 339)) {
                    GraphIndex = (GraphInputPointer + 1);
                    //  Select the first point index for drawing the chart (last data added plus one)
                }
                else {
                    GraphIndex = 0;
                    //  Wrap around if the input pointer was 339
                }
                
                //  Now paint the 340 points in the chart
                //  For each point plotted, we draw a line FROM the previous point TO the current point 
                //  to make a continuous chart
                while ((PaintLoopCounter < 339)) {
                    //  Set the TO x and y coordinates to the current point
                    Xval2 = PaintLoopCounter;
                    Yval2 = CurrentArray(GraphIndex);
                    if ((GraphIndex == 0)) {
                        Yval1 = CurrentArray(339);
                        Xval1 = (PaintLoopCounter - 1);
                    }
                    else {
                        Yval1 = CurrentArray((GraphIndex - 1));
                        Xval1 = (PaintLoopCounter - 1);
                    }
                    
                    //  Draw a line from the previous point to the current point 
                    g.DrawLine(Pens.Black, Xval1, Yval1, Xval2, Yval2);
                    //  Increment the index allowing for wrap-around at 339
                    if ((GraphIndex < 339)) {
                        GraphIndex = (GraphIndex + 1);
                    }
                    else {
                        GraphIndex = 0;
                    }
                    
                    //  Move on to the next chart point
                    PaintLoopCounter = (PaintLoopCounter + 1);
                }
                
                //  g.Dispose()       ' Disabled since double-buffering is used
            }
            
            //  Clear the flag to show chart has been updated and allow the next measurement to be taken
            //  Acts as handshaking
            RepaintChart = false;
        }
        
    }
    
    //  If function failued to run, update status box text, display an error message and configure the buttons
    //  to allow the user to exit or to re-try initialisation
    private void CommLostError(string messagestring) {
        MsgBox(messagestring);
        Button_Init.Enabled = true;
        Button_Start.Enabled = false;
        Button_Exit.Enabled = true;
        Button_Stop.Enabled = false;
        TextBox5.Text = messagestring;
    }
    
    private void Receive_Error() {
        MsgBox("Receive Error");
        Button_Init.Enabled = true;
        Button_Start.Enabled = false;
        Button_Exit.Enabled = true;
        Button_Stop.Enabled = false;
        TextBox5.Text = "Receive Error";
    }
    
    private void Receive_Data(int BytesToRead) {
        //  Function takes number of bytes to be read and returns the actual number read in a global variable
        NumBytesInQueue = 0;
        QueueTimeOut = 0;
        //  Check how many bytes are in the buffer
        //  Wait until bytes are available, stop if not received within approx 500ms
        while (((NumBytesInQueue < BytesToRead) 
                    && (QueueTimeOut < 500))) {
            FT_Status = FT_GetQueueStatus(FT_Handle, NumBytesInQueue);
            Sleep(1);
            QueueTimeOut = (QueueTimeOut + 1);
        }
        
        //  Check if the loop above exited due to data or timing out
        if ((QueueTimeOut > 499)) {
            BytesRead = 0;
            return;
        }
        else {
            //  Otherwise it was data being received
            BytesRead = 0;
            //  Read required number of bytes from the driver
            FT_Status = FT_Read_Bytes(FT_Handle, ReceiveBuffer(0), BytesToRead, BytesRead);
            //  Check if the function failed...
            if ((FT_Status != FT_OK)) {
                BytesRead = 0;
                return;
            }
            
            //  Check that we got required number of bytes
            if ((BytesRead != BytesToRead)) {
                Button_Init.Enabled = true;
                Button_Start.Enabled = false;
                Button_Exit.Enabled = true;
                Button_Stop.Enabled = false;
                TextBox5.Text = "Read Error Occurred";
                BytesRead = 0;
                return;
            }
            
        }
        
    }
}