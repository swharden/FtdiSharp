using FtdiSharp.Protocols;
using System.Diagnostics;

namespace FtdiSharpDemo;

public partial class I2C_LIS3DH : Form
{
    I2C? I2C = null;
    int Reads = 0;
    byte DeviceAddress => i2cAddressSelector1.Address;

    public I2C_LIS3DH()
    {
        InitializeComponent();
        i2cAddressSelector1.Address = 0x18;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
    }

    private void DeviceSelector1_DeviceClosed(object? sender, EventArgs e)
    {
        I2C = null;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        I2C = new(deviceSelector1.FTMan);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null || !I2C.IsOpen)
            return;

        AssertWhoAmI();
        SetupDevice();
        ReadAxes();
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }

    private void AssertWhoAmI()
    {
        // Register 0x0F contains the number 51 for this device
        // https://www.st.com/resource/en/datasheet/cd00274221.pdf (page 34)

        if (I2C is null)
            return;

        const byte WHO_AM_I_ADDRESS = 0x0F;
        byte result = I2C.WriteThenRead(DeviceAddress, WHO_AM_I_ADDRESS);

        const byte expectedResult = 0b00110011;

        if (result != expectedResult)
        {
            throw new InvalidOperationException($"Expected a WHO_AM_I byte of {expectedResult} but got {result}");
        }
    }

    private void SetupDevice()
    {
        // https://www.st.com/resource/en/datasheet/cd00274221.pdf (section 8.8)

        byte CTRL_REG1 = 0x20;
        byte CONFIG = 0b00110111; // 25 Hz, enable all 3 axes
        I2C?.Write(DeviceAddress, new byte[] { CTRL_REG1, CONFIG });
    }

    private void ReadAxis(byte addressL, byte addressH, BarGraph bar, string title)
    {
        if (I2C is null)
            return;

        byte[] bytes = I2C.WriteThenRead(DeviceAddress, addressH, 2);

        Int16 value = BitConverter.ToInt16(bytes);
        value >>= 6;

        bar.SetValue(value, 200, $"{title}: {value}");
    }

    private void ReadAxes()
    {
        ReadAxis(0x28, 0x29, barGraph1, "X");
        ReadAxis(0x2A, 0x2B, barGraph2, "Y");
        ReadAxis(0x2C, 0x2D, barGraph3, "Z");
    }
}
