using FtdiSharp;

namespace FtdiSharpDemo;

public partial class I2C_Scan : Form
{
    public I2C_Scan()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiDevice device)
    {
        using FtdiSharp.Protocols.I2C i2c = new(device);
        string[] addressStrings = i2c.Scan().Select(x => $"0x{x:X2}").ToArray();
        listBox1.Items.Clear();
        listBox1.Items.AddRange(addressStrings);
    }
}
