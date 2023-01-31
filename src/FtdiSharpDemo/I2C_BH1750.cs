using FtdiSharp;

namespace FtdiSharpDemo;

public partial class I2C_BH1750 : Form
{
    FtdiSharp.Protocols.I2C? I2C;
    int Reads = 0;
    double MaxSeenValue = 0;

    public I2C_BH1750()
    {
        InitializeComponent();
        i2cAddressSelector1.Address = 0x23;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = "Reads: 0";
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiDevice device)
    {
        I2C = new FtdiSharp.Protocols.I2C(device);
        SetupDevice();
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiDevice e)
    {
        I2C?.Dispose();
        I2C = null;
    }

    private void SetupDevice()
    {
        if (I2C is null || !I2C.IsOpen)
            return;

        byte deviceAddress = i2cAddressSelector1.Address;

        const byte CONTINUOUS_H_RESOLUTION_MODE = 0b00010000; // page 5 of datasheet

        I2C.Write(deviceAddress, CONTINUOUS_H_RESOLUTION_MODE);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null || !I2C.IsOpen)
            return;

        // https://www.mouser.com/datasheet/2/348/Rohm_11162017_ROHMS34826-1-1279292.pdf
        byte deviceAddress = i2cAddressSelector1.Address;
        byte[] bytes = I2C.Read(deviceAddress, 2);
        double value = bytes[0] * 256 + bytes[1];
        MaxSeenValue = Math.Max(value, MaxSeenValue);

        barGraph1.SetValue(value, MaxSeenValue, value.ToString(), centerAtZero: false);
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
