namespace FtdiSharpDemo;

public partial class I2CScan : Form
{
    FtdiSharp.FtdiManager FTMan => deviceSelector1.FTMan;

    public I2CScan()
    {
        InitializeComponent();
        button1.Enabled = false;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        button1.Enabled = true;
    }

    private void DeviceSelector1_DeviceClosed(object? sender, EventArgs e)
    {
        button1.Enabled = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();

        FtdiSharp.Protocols.I2C i2c = new(FTMan);
        foreach (string address in i2c.Scan())
        {
            listBox1.Items.Add(address);
        }
    }
}
