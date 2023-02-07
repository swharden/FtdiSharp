namespace FtdiSharpDemo;

public partial class GPIO_LED : Form
{
    FtdiSharp.Protocols.GPIO? GPIO;
    int Reads = 0;

    public GPIO_LED()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = $"Reads: {Reads}";
        groupBox1.Enabled = false;
        groupBox2.Enabled = false;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        GPIO = new(e);
        groupBox1.Enabled = true;
        groupBox2.Enabled = true;
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        GPIO?.Dispose();
        GPIO = null;
        groupBox1.Enabled = false;
        groupBox2.Enabled = false;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (GPIO is null)
            return;

        byte direction = 0b11110000;
        int value =
            (cbD4.Checked ? (1 << 4) : 0) +
            (cbD5.Checked ? (1 << 5) : 0) +
            (cbD6.Checked ? (1 << 6) : 0) +
            (cbD7.Checked ? (1 << 7) : 0);
        GPIO.Write(direction, (byte)value);

        byte read = GPIO.Read();
        cbD0.Checked = (read & 0b00000001) > 0;
        cbD1.Checked = (read & 0b00000010) > 0;
        cbD2.Checked = (read & 0b00000100) > 0;
        cbD3.Checked = (read & 0b00001000) > 0;

        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
