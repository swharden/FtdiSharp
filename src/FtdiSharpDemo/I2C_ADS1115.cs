using FtdiSharp;

namespace FtdiSharpDemo;

public partial class I2C_ADS1115 : Form
{
    FtdiSharp.Protocols.I2C? I2C = null;

    public I2C_ADS1115()
    {
        InitializeComponent();
        i2cAddressSelector1.Address = 0x48;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        lblA0.Text = "";
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        I2C = new(deviceSelector1.FTMan);
        ConfigureADC();
    }

    private void ConfigureADC()
    {
        if (I2C is null || !I2C.IsOpen)
            throw new InvalidOperationException();

        byte deviceAddress = i2cAddressSelector1.Address;
        const byte CONFIG_REGISTER = 0x01;
        byte configH = 0b01000000; // AIN0 vs GND, ±6.144V, continuous conversion mode
        byte configL = 0b00100000; // 16 SPS

        I2C.Write(deviceAddress, new byte[] { CONFIG_REGISTER, configH, configL });
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null || !I2C.IsOpen)
            return;

        byte deviceAddress = i2cAddressSelector1.Address;
        const byte RESULT_REGISTER = 0x00;
        const byte CONFIG_REGISTER = 0x01;

        // wait for conversion
        bool isConverting = true;
        while (isConverting)
        {
            byte[] configBytes = I2C.WriteThenRead(deviceAddress, CONFIG_REGISTER, 2);
            isConverting = (configBytes[0] & 0b10000000) > 0;
        }

        // read the result
        byte[] bytes = I2C.WriteThenRead(deviceAddress, RESULT_REGISTER, 2);
        Array.Reverse(bytes);
        double value = BitConverter.ToInt16(bytes);
        value = Math.Max(value, 0);
        value *= 6.144 / (2 << 14);
        lblA0.Text = $"{value:N4} V";
    }
}
