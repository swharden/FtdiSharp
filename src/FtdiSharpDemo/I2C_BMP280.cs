using FtdiSharp;
using System.Net;

namespace FtdiSharpDemo;

public partial class I2C_BMP280 : Form
{
    public I2C_BMP280()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
    }

    private int ReadConfigValue(FtdiSharp.Protocols.I2C i2c, byte deviceAddress, byte memoryAddress)
    {
        i2c.I2C_SetStart();

        i2c.I2C_SendDeviceAddr(deviceAddress, read: true);

        //TODO: write bytes to I2C device

        i2c.I2C_SetStop();

        byte[] bytes = i2c.ReadBytes(deviceAddress, 2);

        return 123456;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        FtdiSharp.Protocols.I2C i2c = new(deviceSelector1.FTMan);

        byte deviceAddress = 0x72;

        int[] calPressure =
        {
            ReadConfigValue(i2c, deviceAddress, 0x88),
            ReadConfigValue(i2c, deviceAddress, 0x8A),
            ReadConfigValue(i2c, deviceAddress, 0x8C),
        };

        int[] tempPressure =
        {
            ReadConfigValue(i2c, deviceAddress, 0x8E),
            ReadConfigValue(i2c, deviceAddress, 0x90),
            ReadConfigValue(i2c, deviceAddress, 0x92),
            ReadConfigValue(i2c, deviceAddress, 0x94),
            ReadConfigValue(i2c, deviceAddress, 0x96),
            ReadConfigValue(i2c, deviceAddress, 0x98),
            ReadConfigValue(i2c, deviceAddress, 0x9A),
            ReadConfigValue(i2c, deviceAddress, 0x9C),
            ReadConfigValue(i2c, deviceAddress, 0x9E),
        };

        lbCalibration.Items.Clear();

        for (int i = 0; i < calPressure.Length; i++)
        {
            lbCalibration.Items.Add($"[T{i + 1}] {calPressure[i]}");
        }
    }
}
