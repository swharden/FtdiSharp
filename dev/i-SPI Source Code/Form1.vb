Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents Button_Exit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button_Init As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Stop As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Chart As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button_Start = New System.Windows.Forms.Button
        Me.Button_Exit = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button_Init = New System.Windows.Forms.Button
        Me.Button_Stop = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Chart = New System.Windows.Forms.GroupBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Chart.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(471, 331)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(66, 30)
        Me.Button_Start.TabIndex = 1
        Me.Button_Start.Text = "Start"
        '
        'Button_Exit
        '
        Me.Button_Exit.Location = New System.Drawing.Point(689, 331)
        Me.Button_Exit.Name = "Button_Exit"
        Me.Button_Exit.Size = New System.Drawing.Size(70, 30)
        Me.Button_Exit.TabIndex = 2
        Me.Button_Exit.Text = "Exit"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(90, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 48)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "mA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(17, 22)
        Me.ProgressBar1.MarqueeAnimationSpeed = 50
        Me.ProgressBar1.Maximum = 500
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(293, 18)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 48)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "0"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Current"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(201, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(117, 77)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(38, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Voltage"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(75, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 48)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "V"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 48)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "0"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "0mA"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(279, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "500mA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(116, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Current Bar graph"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Location = New System.Drawing.Point(181, 147)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(158, 71)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Voltage"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Location = New System.Drawing.Point(201, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(117, 77)
        Me.GroupBox5.TabIndex = 24
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(38, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Voltage"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(75, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 48)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "V"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 48)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "0"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 48)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "0"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(90, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 48)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "V"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "0mA"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(279, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "500mA"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(116, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Current Bar graph"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label33)
        Me.GroupBox6.Controls.Add(Me.ProgressBar1)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 224)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(327, 65)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Current Bar Graph"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label33.Location = New System.Drawing.Point(133, 43)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(65, 13)
        Me.Label33.TabIndex = 36
        Me.Label33.Text = "Current (mA)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(298, 43)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "500"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(200, 280)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(87, 17)
        Me.CheckBox1.TabIndex = 36
        Me.CheckBox1.TabStop = False
        Me.CheckBox1.Text = "Enable Chart"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(167, 70)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(144, 20)
        Me.TextBox3.TabIndex = 23
        Me.TextBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 129)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Device Details"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(91, 99)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(0, 13)
        Me.Label35.TabIndex = 0
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(167, 96)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(144, 20)
        Me.TextBox5.TabIndex = 33
        Me.TextBox5.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 99)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Status:"
        '
        'GroupBox7
        '
        Me.GroupBox7.Location = New System.Drawing.Point(-159, 154)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox7.TabIndex = 25
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "GroupBox7"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(167, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(144, 20)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Serial Number:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(167, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(144, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Number of Devices:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description:"
        '
        'Button_Init
        '
        Me.Button_Init.Location = New System.Drawing.Point(369, 331)
        Me.Button_Init.Name = "Button_Init"
        Me.Button_Init.Size = New System.Drawing.Size(62, 30)
        Me.Button_Init.TabIndex = 1
        Me.Button_Init.Text = "Initialise"
        Me.Button_Init.UseVisualStyleBackColor = True
        '
        'Button_Stop
        '
        Me.Button_Stop.Location = New System.Drawing.Point(582, 331)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(67, 30)
        Me.Button_Stop.TabIndex = 26
        Me.Button_Stop.Text = "Stop"
        Me.Button_Stop.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(68, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(340, 253)
        Me.Panel1.TabIndex = 27
        '
        'Chart
        '
        Me.Chart.Controls.Add(Me.Label31)
        Me.Chart.Controls.Add(Me.CheckBox1)
        Me.Chart.Controls.Add(Me.Label30)
        Me.Chart.Controls.Add(Me.Label29)
        Me.Chart.Controls.Add(Me.Label28)
        Me.Chart.Controls.Add(Me.Label27)
        Me.Chart.Controls.Add(Me.Label26)
        Me.Chart.Controls.Add(Me.Label7)
        Me.Chart.Controls.Add(Me.Label6)
        Me.Chart.Controls.Add(Me.Panel1)
        Me.Chart.Location = New System.Drawing.Point(353, 12)
        Me.Chart.Name = "Chart"
        Me.Chart.Size = New System.Drawing.Size(418, 308)
        Me.Chart.TabIndex = 28
        Me.Chart.TabStop = False
        Me.Chart.Text = "Current Chart"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label31.Location = New System.Drawing.Point(2, 126)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(41, 13)
        Me.Label31.TabIndex = 35
        Me.Label31.Text = "Current"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label30.Location = New System.Drawing.Point(8, 142)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(28, 13)
        Me.Label30.TabIndex = 34
        Me.Label30.Text = "(mA)"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label29.Location = New System.Drawing.Point(43, 164)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(25, 13)
        Me.Label29.TabIndex = 33
        Me.Label29.Text = "200"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label28.Location = New System.Drawing.Point(43, 214)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(25, 13)
        Me.Label28.TabIndex = 32
        Me.Label28.Text = "100"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label27.Location = New System.Drawing.Point(43, 114)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(25, 13)
        Me.Label27.TabIndex = 31
        Me.Label27.Text = "300"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label26.Location = New System.Drawing.Point(43, 63)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(25, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "400"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(52, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(43, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "500"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.D2XXUnit_NET.My.Resources.Resources.FTDI
        Me.PictureBox1.Location = New System.Drawing.Point(12, 302)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(158, 57)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(175, 299)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(162, 16)
        Me.Label24.TabIndex = 30
        Me.Label24.Text = "FT232H SPI Current Meter"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(217, 315)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(68, 15)
        Me.Label32.TabIndex = 34
        Me.Label32.Text = "Version 1.0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(192, 345)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(122, 13)
        Me.Label34.TabIndex = 35
        Me.Label34.Text = "http://www.ftdichip.com"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 368)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Chart)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Stop)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button_Init)
        Me.Controls.Add(Me.Button_Start)
        Me.Controls.Add(Me.Button_Exit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Label24)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(790, 400)
        Me.MinimumSize = New System.Drawing.Size(790, 400)
        Me.Name = "Form1"
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "i-SPI    FT232H SPI Current Meter"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Chart.ResumeLayout(False)
        Me.Chart.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' NOTE:   This code is provided as an example only and is not supported or guaranteed by FTDI.


    ' Bits assigned on FT232H AD bus
    '	0	Out     SPI CLK (SCK)
    '	1	Out     SPI DO (MOSI)
    '	2 	In      SPI DI (MISO)
    '	3	Out     SPI CS0		
    '	4	Out     SPI CS1
    '	5	Out     Not used (optional Error LED)
    '	6	In      PWRGOOD input from power supply voltage monitor
    '	7	Out     Status LED on when pin low (flashes on during SPI read)

    Dim DeviceInit As Boolean
    Dim BytesWritten As Integer
    Dim ReadSuccess As Boolean
    Dim BytesRead As Integer
    Dim BytesToRead As Byte
    Dim SendBuffer(20) As Byte
    Dim NumBytesInQueue As Integer
    Dim ReceiveBuffer(20) As Byte
    Dim SPI_Device_Found As Boolean
    Dim LoggingEnabled As Boolean
    Dim QueueTimeOut As Byte

    Dim CurrentArray(0 To 339) As Integer
    Dim GraphIndex As Integer
    Dim GraphInputIndex As Integer
    Dim GraphInputPointer As Integer
    Dim g As Graphics

    Dim Y As Integer
    Dim X As Integer

    Dim ChartToZero As Boolean
    Dim RepaintChart As Boolean

    Dim result16 As Integer
    Dim current As Integer
    Dim voltage As Double

    Dim Pin_Values As Byte = &H0
    Dim LED_State As Byte = &H0         ' 1x1x xxxx     LED State controls bits 7 and 5, high means LED off
    Dim CS_State As Byte = &H0          ' xxx1 1xxx     CS State controls bits 4 and 3, high means not selected
    Dim Pin_Defaults As Byte = &H46     ' x1xx x110     SPI pins and inputs default to high, clock idles low
    Dim Pin_Directions As Byte = &HBB   ' 1011 1011     All pins output (1) except DI and PWRGOOD

    Public Const LED_Status_On As Byte = &H20   ' Bit 7 low, Bit 5 high
    Public Const LED_Error_On As Byte = &H80    ' Error LED not currently implemented, would be on bit 5
    Public Const LED_Both_On As Byte = &H0      ' Bit 7 and Bit 5 low
    Public Const LED_Both_Off As Byte = &HA0    ' Bit 7 and Bit 5 high

    Public Const CS_None As Byte = &H18         ' Bit 4 and Bit 3 high
    Public Const CS_CS0 As Byte = &H10          ' Bit 3 low
    Public Const CS_CS1 As Byte = &H8           ' Bit 4 low


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Init.Click
        ' Code for INIT button

        Dim DeviceCount As Integer
        Dim DeviceIndex As Integer

        Dim TempDevString As String
        Dim TempDevSerial As String

        Dim FT_Description_Temp As String
        Dim FT_Serial_Temp As String

        '############################################################################################################
        ' Initialise the MPSSE
        '############################################################################################################

        ' Prevent user clicking any buttons on user interface until Init complete
        Button_Start.Enabled = False                ' 
        Button_Exit.Enabled = False                 ' 
        Button_Init.Enabled = False                 ' 
        Button_Stop.Enabled = False                 ' 

        ' Set the focus to the Init button since the user has just clicked it
        Button_Init.Focus()                         '

        '************************************************************************************************************
        ' Get the number of FTDI devices attached
        '************************************************************************************************************

        ' Check the number of FTDI devices
        FT_Status = FT_GetNumberOfDevices(DeviceCount, vbNullChar, FT_LIST_NUMBER_ONLY)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("GetNumberOfDevices Failed")
            Exit Sub
        End If


        ' Inform user if no devices connected and exit this subroutine
        ' Enable buttons to allow user to re-try Init or to Exit 
        If DeviceCount = 0 Then
            TextBox1.Text = "0"
            TextBox5.Text = "No FTDI Devices Found"

            Button_Start.Enabled = False                   ' 
            Button_Exit.Enabled = True                     ' 
            Button_Init.Enabled = True                     ' 
            Button_Stop.Enabled = False                    ' 

            Button_Init.Focus()
            Exit Sub
        Else
            ' Otherwise display device count returned by FT_GetNumberOfDevices on form
            TextBox1.Text = DeviceCount.ToString
        End If


        '************************************************************************************************************
        ' Get a handle to the "FT232H SPI Demo" by checking the String returned by each FTDI device
        '************************************************************************************************************

        ' Go through each FTDI device and check text string to see if it is the SPI Demo 
        ' Increment device index until all devices found were checked or until device found with the correct string
        ' Note: If more than one FTDI device with the string FT232H SPI Demo is found, the first will be opened

        DeviceIndex = 0
        SPI_Device_Found = False

        ' Do for Index = 0 to Index = (number of devices found - 1)
        While ((DeviceIndex < DeviceCount) And (SPI_Device_Found = False))

            ' Reserve space for string
            TempDevString = Space(64)
            TempDevSerial = Space(64)

            ' Get the string at the specified index
            FT_Status = FT_GetDeviceString(DeviceIndex, TempDevString, FT_LIST_BY_INDEX Or FT_OPEN_BY_DESCRIPTION)

            ' Check if the function failed...
            If FT_Status <> FT_OK Then
                CommLostError("GetDeviceString Failed")
                Exit Sub
            End If

            ' Get the serial number at the specified index
            FT_Status = FT_GetDeviceString(DeviceIndex, TempDevSerial, FT_LIST_BY_INDEX Or FT_OPEN_BY_SERIAL_NUMBER)

            ' Check if the function failed...
            If FT_Status <> FT_OK Then
                CommLostError("GetDeviceString Failed")
                Exit Sub
            End If

            ' Format the strings
            FT_Description_Temp = Microsoft.VisualBasic.Left(TempDevString, InStr(1, TempDevString, vbNullChar) - 1)
            FT_Serial_Temp = Microsoft.VisualBasic.Left(TempDevSerial, InStr(1, TempDevString, vbNullChar) - 1)

            ' Check if device is the SPI Demo
            If FT_Description_Temp = "FT232H SPI Demo" Then

                ' Display serial number on form
                FT_Serial_Number = FT_Serial_Temp
                FT_Description = FT_Description_Temp
                TextBox3.Text = FT_Description
                TextBox2.Text = FT_Serial_Number

                ' Set flag to show that device was found and we can stop looking
                SPI_Device_Found = True
            Else
                ' Otherwise try the next index
                DeviceIndex = DeviceIndex + 1
            End If

        End While


        ' Tell user if no FT232H SPI Demo device found. Allow them to re-try the init or to exit
        If SPI_Device_Found = False Then
            TextBox5.Text = "No SPI Devices Found"
            Button_Start.Enabled = False                        ' 
            Button_Exit.Enabled = True                          ' 
            Button_Init.Enabled = True                          ' 
            Button_Stop.Enabled = False                         ' 

            Button_Init.Focus()

            Exit Sub

        End If

        '************************************************************************************************************
        ' Open the device using the index which was found above
        '************************************************************************************************************

        ' Open the SPI Demo using the index found above
        FT_Status = FT_OpenByIndex(DeviceIndex, FT_Handle)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("OpenByIndex Failed")
            Exit Sub
        End If


        '************************************************************************************************************
        ' Configure the MPSSE in the device
        '************************************************************************************************************

        ' Reset the device
        FT_Status = FT_ResetDevice(FT_Handle)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("ResetDevice Failed")
            Exit Sub
        End If


        ' Set Bit mode to MPSSE
        ' Mode = 2 and I/O directions are 0xBB as required for this application 
        FT_Status = FT_SetBitMode(FT_Handle, Pin_Directions, &H2)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("SetBitMode Failed")
            Exit Sub
        End If


        ' Set latency timer to 16ms (this is actually the default value)
        FT_Status = FT_SetLatencyTimer(FT_Handle, 16)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("SetLatencyTimer Failed")
            Exit Sub
        End If


        ' Set timeouts to infinite for read and infinite for write
        ' Could set a read timeout of 500ms instead if required
        FT_Status = FT_SetTimeouts(FT_Handle, 0, 0)

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("SetTimeouts Failed")
            Exit Sub
        End If


        '************************************************************************************************************
        ' Disable the /5 MPSSE divider
        '************************************************************************************************************

        SendBuffer(0) = &H8A        ' MPSSE command to disable the /5 divider for a 60MHz master clock

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Disable /5 Divider Failed")
            Exit Sub
        End If

        '************************************************************************************************************
        ' set TCK/SK divisor to 50KHz
        '************************************************************************************************************

        ' See command processor for MPSSE application note for further information
        ' TCK           = 60MHz    / ((1 + [ (0xValueH * 256) OR 0xValueL] ) * 2)
        '               = 60000000 / ((1 + [ (  0x02   * 256) OR   0x57  ] ) * 2)
        '               = 60000000 / ((1 + [ (  512           +      87  ] ) * 2)
        '               = 60000000 / ((1 + 512 + 87)                         * 2)
        '               = 60000000 / 600 * 2
        '               = 50000
        '               = 50kHz

        SendBuffer(0) = &H86        ' MPSSE command to set the divisor
        SendBuffer(1) = &H57        ' Low value = 0x57
        SendBuffer(2) = &H2         ' High value = 0x02

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Set Divider Failed")
            Exit Sub
        End If


        '************************************************************************************************************
        ' Sync 1 - Send an invalid command 0xAA to the MPSSE and check that it replies with 'Invalid Command'
        '************************************************************************************************************

        ' Send the command to the MPSSE
        SendBuffer(0) = &HAA        ' 0xAA is an invalid command for the MPSSE

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Write Failed")
            Exit Sub
        End If

        ' Now wait for a reply
        ' MPSSE will return 0xFA followed by the bad command 0xAA 

        Receive_Data(2)

        If (BytesRead = 2) Then

            ' Check that we got the correct data back otherwise cancel the initialisation
            If ((ReceiveBuffer(0) <> &HFA) Or (ReceiveBuffer(1) <> &HAA)) Then
                CommLostError("MPSSE Sync Failed")
                Exit Sub
            End If

            ' If 2 bytes not received
        Else
            Receive_Error()
            Exit Sub

        End If

        '************************************************************************************************************
        ' Sync 2 - Send an invalid command 0xAB to the MPSSE and check that it replies with 'Invalid Command'
        '************************************************************************************************************

        ' Send the command to the MPSSE
        SendBuffer(0) = &HAB        ' 0xAB is an invalid command for the MPSSE

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Write Failed")
            Exit Sub
        End If

        ' Now wait for a reply
        ' MPSSE will return 0xFA followed by the bad command 0xAB 

        Receive_Data(2)

        If (BytesRead = 2) Then

            ' Check that we got the correct data back otherwise cancel the initialisation
            If ((ReceiveBuffer(0) <> &HFA) Or (ReceiveBuffer(1) <> &HAB)) Then
                CommLostError("MPSSE Sync Failed")
                Exit Sub
            End If

            ' If 2 bytes not received
        Else
            Receive_Error()
            Exit Sub
        End If

        '************************************************************************************************************
        ' disable the loopback
        '************************************************************************************************************

        SendBuffer(0) = &H85        ' MPSSE command to disable loopback

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Disable Loopback Failed")
            Exit Sub
        End If

        '************************************************************************************************************
        ' Set the direction and value of the low data bits and set port to idle state with LED on to show initialised
        '************************************************************************************************************

        ' Set the required values for the pins
        LED_State = LED_Status_On                           ' 0x1x xxxx
        CS_State = CS_None                                  ' xxx1 1xxx
        Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

        SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port (AD7 to AD0 in the FT232H)
        SendBuffer(1) = Pin_Values          ' 
        SendBuffer(2) = Pin_Directions      ' 

        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write buffer to the device

        ' Check if the function failed...
        If FT_Status <> FT_OK Then
            CommLostError("Set Pin States Failed")
            Exit Sub
        End If


        '************************************************************************************************************
        ' Set flag to show that device now initialised
        '************************************************************************************************************

        DeviceInit = True                           ' Device is now initialised

        TextBox5.Text = "Ready"                     ' Show that the device is now ready

        Button_Start.Enabled = True                 ' Allow user to start new measurement run
        Button_Init.Enabled = False
        Button_Exit.Enabled = True                  ' Allow user to exit program
        Button_Stop.Enabled = False

        Button_Start.Focus()                        ' Switch focus to the start button

        ChartToZero = True                          ' Run chart plot routine - all values zero to set starting state
        RepaintChart = True                         ' Authorise re-paint of chart when the refresh routine is called
        Panel1.Refresh()                            ' Cause the re-paint to occur

        Update()                                    ' Update the dialog box
        Application.DoEvents()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Start.Click
        ' Code for the START button

        ' Configure the buttons on the user form
        Button_Start.Enabled = False                    ' Prevent user initialising device whilst running measurements
        Button_Exit.Enabled = False                     ' Prevent user starting a new measurement run whilst this one is running
        Button_Init.Enabled = False                     ' Prevent user exiting program whilst the measurement is running
        Button_Stop.Enabled = True                      ' Enable the Stop button so that user can stop the measurement

        Button_Stop.Focus()


        '############################################################################################################
        ' Take readings from the port pins and then ADCs (ADC0 in Chip Select 0 first, then ADC1 on Chip Select 1)
        '############################################################################################################

        TextBox5.Text = "Running"                       ' Update status to tell user that measurement is running

        LoggingEnabled = True                           ' Logging will run whilst this is True, Stop button will set it to false

        While (LoggingEnabled = True)

            If RepaintChart = False Then                ' Don't run again until chart has finished re-painting

                '************************************************************************************************************
                ' Set idle condition with LED on and no chip selects asserted
                '************************************************************************************************************

                ' Set the required values for the pins
                ' See top of code listing for pin definitions
                LED_State = LED_Status_On                           ' 0x1x xxxx
                CS_State = CS_None                                  ' xxx1 1xxx
                Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

                SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values          ' 
                SendBuffer(2) = Pin_Directions      ' 

                ' Send the buffer
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Write Failed")
                    Exit Sub
                End If

                ' Short delay
                Sleep(10)


                '************************************************************************************************************
                ' Read PWRGOOD line
                '************************************************************************************************************
                ' This command causes the MPSSE to read the pin values and sedn them to the PC

                ' Put the command into the buffer
                SendBuffer(0) = &H81        ' Command to read data bits (low byte) which is AD0 - AD7

                ' Send the buffer
                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 1, BytesWritten)

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Read Pwrgood Failed")
                    Exit Sub
                End If

                ' Short delay
                Sleep(10)

                '****************************
                ' Read
                '****************************

                ' Now read the resulting byte from the driver buffer, which contains the port value
                Receive_Data(1)

                If (BytesRead = 1) Then

                    ' Mask off bit 6 and check if it is high or low
                    If (ReceiveBuffer(0) And &H40) = 0 Then
                        ' If the line is low, the supply is out of range
                        TextBox5.Text = "Power supply out of range"

                    Else
                        TextBox5.Text = "Running"
                    End If
                Else
                    Receive_Error()
                    Exit Sub
                End If

                '************************************************************************************************************
                ' Bring CS0 low to read the Current measurement ADC and turn off Status LED (blinks off during the measurement)
                '************************************************************************************************************

                ' Set the required values for the pins
                LED_State = LED_Both_Off                            ' 1x1x xxxx
                CS_State = CS_CS0                                   ' xxx1 0xxx
                Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

                SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values          ' 
                SendBuffer(2) = Pin_Directions      ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write string data to device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Set Pin States Failed")
                    Exit Sub
                End If

                Sleep(10)


                '************************************************************************************************************
                ' Tell the MPSSE to do an SPI read and send it to the PC
                '************************************************************************************************************
                ' Send a command to ask the MPSSE to read two bytes over the SPI and send them to the PC

                SendBuffer(0) = &H20       ' MPSSE command to read bytes in from SPI, Pos clock edge, MSB first
                SendBuffer(1) = &H1        ' 0001 means clock in two bytes
                SendBuffer(2) = &H0        ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write the buffer to the FTDI device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("SPI Read Failed")
                    Exit Sub
                End If

                Sleep(10)

                '************************************
                ' Read data from the PC Driver buffer
                '************************************
                ' Now read the resulting 2 bytes from the driver buffer, which contains the ADC result

                Receive_Data(2)

                If (BytesRead = 2) Then
                    ' Combine the two received bytes into a single value
                    result16 = (((ReceiveBuffer(1) / 2) And &H7F) + ((ReceiveBuffer(0) And &H1F) * 128))    '	
                    ' Scale the result to be from 0mA to 500mA
                    current = ((result16 / 4096) * 500)
                Else
                    Receive_Error()
                    Exit Sub
                End If


                '************************************************************************************************************
                ' Disable CS0 with Status LED still off
                '************************************************************************************************************

                ' Set the required values for the pins
                LED_State = LED_Both_Off                            ' 1x1x xxxx
                CS_State = CS_None                                  ' xxx1 1xxx
                Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

                SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values          ' 
                SendBuffer(2) = Pin_Directions      ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write string data to device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Set Pin States Failed")
                    Exit Sub
                End If

                Sleep(10)

                '************************************************************************************************************
                ' Bring CS1 low to read the Voltage measurement ADC
                '************************************************************************************************************

                ' Set the required values for the pins
                LED_State = LED_Both_Off                            ' 1x1x xxxx
                CS_State = CS_CS1                                   ' xxx0 1xxx
                Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

                SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values          ' 
                SendBuffer(2) = Pin_Directions      ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write string data to device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Set Pin States Failed")
                    Exit Sub
                End If

                Sleep(10)

                '************************************************************************************************************
                ' Tell the MPSSE to do an SPI read and send it to the PC
                '************************************************************************************************************

                SendBuffer(0) = &H20       ' MPSSE command to read bytes in from SPI, Pos clock edge, MSB first
                SendBuffer(1) = &H1        ' 0001 means clock in two bytes
                SendBuffer(2) = &H0        ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write string data to device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("SPI Read Failed")
                    Exit Sub
                End If

                Sleep(10)

                '************************************
                ' Read data from the PC Driver buffer
                '************************************

                Receive_Data(2)

                If (BytesRead = 2) Then
                    ' Combine the two received bytes into a single value
                    result16 = (((ReceiveBuffer(1) / 2) And &H7F) + ((ReceiveBuffer(0) And &H1F) * 128))
                    'Scale the result to be a 0 to 6.6V value and round it to 2 places 
                    voltage = ((result16 / 4096) * 6.6)
                    voltage = Math.Round(voltage, 2)
                Else
                    Receive_Error()
                    Exit Sub
                End If


                '************************************************************************************************************
                ' Set idle condition with LED on again since the measurement cycle is complete
                '************************************************************************************************************

                ' Set the required values for the pins
                LED_State = LED_Status_On                           ' 0x1x xxxx
                CS_State = CS_None                                  ' xxx1 1xxx
                Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

                SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
                SendBuffer(1) = Pin_Values          ' 
                SendBuffer(2) = Pin_Directions      ' 

                FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)   ' Write string data to device

                ' Check if the function failed...
                If FT_Status <> FT_OK Then
                    CommLostError("Set Pin States Failed")
                    Exit Sub
                End If

                '************************************************************************************************************
                ' Update screen
                '************************************************************************************************************

                ' Meter display
                Label5.Text = current.ToString
                Label17.Text = voltage.ToString

                ' Put current value into bar graph
                ProgressBar1.Value = current

                ' Add the current vaue in mA into the buffer used by the chart plotting routine
                ' The chart Y direction is reversed and has 2mA increments and so 
                ' 0mA is stored as 250,
                ' 100mA as 200
                ' 200mA as 150
                ' 500mA as 0
                ' Note: Chart height is 251 pixels so 0mA (y = 250 on the chart) will still be visible above the axis 
                CurrentArray(GraphInputPointer) = (250 - (current / 2))    ' 250 instead of 251 so visible when zero

                ' Increment the index value so that the result is put into the next location in the array
                ' this is also read by the chart plotting routine
                ' Allow for wrap-around if last value was 339
                If GraphInputPointer = 339 Then
                    GraphInputPointer = 0
                Else
                    GraphInputPointer = GraphInputPointer + 1
                End If

                RepaintChart = True
                Panel1.Refresh()

            End If

            Update()
            Application.DoEvents()
            Sleep(30)

        End While

        ' When code gets here, LoggingEnabled = False and so the Stop button has been pressed

        Button_Init.Enabled = False
        Button_Start.Enabled = True
        Button_Exit.Enabled = True
        Button_Stop.Enabled = False
        Button_Exit.Focus()

        TextBox5.Text = "Stopped" ' Update the status

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Exit.Click
        ' Code for the EXIT button

        Button_Start.Enabled = False
        Button_Exit.Enabled = False
        Button_Init.Enabled = False
        Button_Stop.Enabled = False

        LoggingEnabled = False

        '************************************************************************************************************
        ' Set the pins back to idle states
        '************************************************************************************************************

        ' Set the required values for the pins
        LED_State = LED_Both_Off                            ' 1x1x xxxx
        CS_State = CS_None                                  ' xxx1 1xxx
        Pin_Values = Pin_Defaults Or LED_State Or CS_State  ' x1xx x110 or LED_State or CS_State

        SendBuffer(0) = &H80                ' MPSSE Command to set low bits of port
        SendBuffer(1) = Pin_Values          ' 
        SendBuffer(2) = Pin_Directions      ' 

        ' Send the buffer
        FT_Status = FT_Write_Bytes(FT_Handle, SendBuffer(0), 3, BytesWritten)

        ' Check if the function failed...
        'If FT_Status <> FT_OK Then
        '    'CommLostError("No device to close")
        'End If

        ' If device was initialised, then close it before exiting
        If (DeviceInit = True) Then
            FT_Status = FT_Close(FT_Handle)

            If FT_Status = FT_OK Then
                TextBox5.Text = "Closed"
            End If
        End If

        'Update()
        'Application.DoEvents()
        Sleep(700)

        Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Initialise the variables, buttons and progress bar when the form loads

        ProgressBar1.Value = 0

        Button_Init.Enabled = True
        Button_Start.Enabled = False
        Button_Exit.Enabled = True
        Button_Stop.Enabled = False

        DeviceInit = False          ' Not yet initialised

        LoggingEnabled = False      ' Not logging yet

        TextBox5.Text = "Unconfigured"            '

        CheckBox1.Checked = True

        Button_Init.Focus()         ' Put focus on the Init button since it will be pressed first

        '' Draw the FTDI logo, which should be in the same directory as the .exe file
        '' Logo now added as a project resource so commented out
        ' PictureBox1.Image = System.Drawing.Bitmap.FromFile( _
        ' My.Application.Info.DirectoryPath & "\FTDI.bmp")

        ' Set the entire scrolling chart to zero and trigger re-paint
        ChartToZero = True
        RepaintChart = True

        Panel1.Refresh()
        Update()
        Application.DoEvents()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Stop.Click
        ' Code for the STOP button
        LoggingEnabled = False                      ' The measurement routine will stop when this is set to False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        ' This subroutine re-draws the entire chart using the data from the CurrentArray array
        ' It is called every time a new reading is taken since the graph needs to be re-drawn each time it scrolls

        ' The panel is 250 pixels high (plus one for the X axis line) and so each pixel is 2mA.
        ' A Y value of 250 is the bottom of the chart (0mA) and a Y value of 0 is the top of the chart (500mA)

        ' It uses a kind of circular buffer where the Y values are passed in an array
        ' The measurement routine adds new values to the array in a circular fashion and updates GraphInputPointer
        ' to show the last point added

        ' This paint routine draws a chart from X values 0 to 339. It uses the last point added plus 1 as the starting point
        ' and then draws the 340 points (including wrapping back to location zero in the array once location 339 is reached)
        ' This means that the last point added is always at the right-hand side of the chart and so it scrolls right to left

        Dim PaintLoopCounter As Integer
        Dim Xval1 As Integer
        Dim Xval2 As Integer
        Dim Yval1 As Integer
        Dim Yval2 As Integer

        ' This ensures that the chart is only re-painted once a new reading is taken in case the routine is called at other 
        ' times. RepaintChart is set True when new data is put in the buffer or when the chart is being initialised with zeros
        If (RepaintChart = True) Then

            ' Create a graphics object
            g = Panel1.CreateGraphics()

            ' draw horizontal lines for the current scale 
            ' Y coordinates start from the top of the chart
            g.DrawLine(Pens.LightSkyBlue, 0, 0, 339, 0)         ' 0 = 500mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 50, 339, 50)       ' 50 = 400mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 100, 339, 100)     ' 100 = 300mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 150, 339, 150)     ' 150 = 200mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 200, 339, 200)     ' 200 = 100mA line
            g.DrawLine(Pens.LightSkyBlue, 0, 250, 339, 250)     ' 250 = 0mA line

            ' Draw the samll black tickmark next to each current value on the scale
            g.DrawLine(Pens.Black, 0, 0, 1, 0)
            g.DrawLine(Pens.Black, 0, 50, 1, 50)
            g.DrawLine(Pens.Black, 0, 100, 1, 100)
            g.DrawLine(Pens.Black, 0, 150, 1, 150)
            g.DrawLine(Pens.Black, 0, 200, 1, 200)
            g.DrawLine(Pens.Black, 0, 250, 1, 250)

            ' If starting the program or if the chart is disabled by the checkbox, set all datapoints to zero
            ' This means fill CurrentArray with the value 250 since Y starts from the top of the chart and it is 250 pixels high
            If ((ChartToZero = True) Or (CheckBox1.Checked = False)) Then
                GraphInputPointer = 0
                GraphIndex = 0

                ' This loop fills all 340 X values of the chart with the Y value 250 (== 0mA)
                While (GraphIndex < 340)
                    CurrentArray(GraphIndex) = 250
                    GraphIndex = GraphIndex + 1
                End While

                ' Clear the flag so that we can start drawing the graph the next time this subroutine is called
                ChartToZero = False

                GraphInputPointer = 0
                GraphIndex = 0



            Else
                ' If this is a normal painting cycle, then draw the chart 
                ' The CurrentArray has 340 values, which are the Y values for the chart

                ' The measurement routine writes new values one-at-a-time into the array. It updates the
                ' GraphInputPointer value to show where the last value was added
                ' This paint routine starts at that location plus one and draws the 340 points of the chart

                ' Because we do not always start painting at index 0 of the incoming data, we use this 
                ' variable as a 0 - 339 X value 
                PaintLoopCounter = 0

                ' Set the starting point in the circular buffer based upon the last data added by the measurement subroutine
                ' GraphInputPointer is the index of the last value added from the measurement subroutine
                ' GraphIndex is a copy of this taken by this paint routine and will be used to point to the values to draw the chart

                If (GraphInputPointer < 339) Then
                    GraphIndex = GraphInputPointer + 1      ' Select the first point index for drawing the chart (last data added plus one)
                Else
                    GraphIndex = 0                          ' Wrap around if the input pointer was 339
                End If

                ' Now paint the 340 points in the chart
                ' For each point plotted, we draw a line FROM the previous point TO the current point 
                ' to make a continuous chart

                While PaintLoopCounter < 339

                    ' Set the TO x and y coordinates to the current point
                    Xval2 = PaintLoopCounter
                    Yval2 = (CurrentArray(GraphIndex))

                    ' Now set the FROM x and y values using the previous point 

                    ' If the index is zero, the previous point (x-1) was 339 due to wrap-around
                    ' otherwise, previous point is the index minus 1
                    If (GraphIndex = 0) Then
                        Yval1 = CurrentArray(339)
                        Xval1 = PaintLoopCounter - 1
                    Else
                        Yval1 = CurrentArray(GraphIndex - 1)
                        Xval1 = PaintLoopCounter - 1
                    End If

                    ' Draw a line from the previous point to the current point 
                    g.DrawLine(Pens.Black, Xval1, Yval1, Xval2, Yval2)

                    ' Increment the index allowing for wrap-around at 339
                    If (GraphIndex < 339) Then
                        GraphIndex = GraphIndex + 1
                    Else
                        GraphIndex = 0
                    End If

                    ' Move on to the next chart point
                    PaintLoopCounter = PaintLoopCounter + 1

                End While

                ' g.Dispose()       ' Disabled since double-buffering is used

            End If

            ' Clear the flag to show chart has been updated and allow the next measurement to be taken
            ' Acts as handshaking
            RepaintChart = False

        End If

    End Sub

    ' If function failued to run, update status box text, display an error message and configure the buttons
    ' to allow the user to exit or to re-try initialisation

    Private Sub CommLostError(ByVal messagestring As String)
        MsgBox(messagestring)
        Button_Init.Enabled = True
        Button_Start.Enabled = False
        Button_Exit.Enabled = True
        Button_Stop.Enabled = False
        TextBox5.Text = messagestring

    End Sub

    Private Sub Receive_Error()
        MsgBox("Receive Error")
        Button_Init.Enabled = True
        Button_Start.Enabled = False
        Button_Exit.Enabled = True
        Button_Stop.Enabled = False
        TextBox5.Text = "Receive Error"

    End Sub

    Private Sub Receive_Data(ByVal BytesToRead As Integer)
        ' Function takes number of bytes to be read and returns the actual number read in a global variable

        NumBytesInQueue = 0
        QueueTimeOut = 0

        ' Check how many bytes are in the buffer
        ' Wait until bytes are available, stop if not received within approx 500ms
        While ((NumBytesInQueue < BytesToRead) And (QueueTimeOut < 500))
            FT_Status = FT_GetQueueStatus(FT_Handle, NumBytesInQueue)
            Sleep(1)
            QueueTimeOut = QueueTimeOut + 1
        End While

        ' Check if the loop above exited due to data or timing out
        If (QueueTimeOut > 499) Then
            BytesRead = 0
            Exit Sub
        Else
            ' Otherwise it was data being received
            BytesRead = 0

            ' Read required number of bytes from the driver
            FT_Status = FT_Read_Bytes(FT_Handle, ReceiveBuffer(0), BytesToRead, BytesRead)

            ' Check if the function failed...
            If FT_Status <> FT_OK Then
                BytesRead = 0
                Exit Sub
            End If

            ' Check that we got required number of bytes
            If BytesRead <> BytesToRead Then
                Button_Init.Enabled = True
                Button_Start.Enabled = False
                Button_Exit.Enabled = True
                Button_Stop.Enabled = False
                TextBox5.Text = "Read Error Occurred"
                BytesRead = 0
                Exit Sub
            End If

        End If

    End Sub

End Class



























