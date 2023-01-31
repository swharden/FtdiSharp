using FtdiSharp;

namespace FtdiSharpDemo;

public partial class I2C_LM75A : Form
{
    FtdiSharp.Protocols.I2C? I2CCOM;

    int Reads = 0;

    public I2C_LM75A()
    {
        InitializeComponent();
        lblSensor.Text = "";
        lblTemperature.Text = "";
        nudAddress_ValueChanged(null!, EventArgs.Empty);
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        FormClosing += I2C_LM75A_FormClosing;
        toolStripStatusLabel1.Text = "Reads: 0";
    }

    private void I2C_LM75A_FormClosing(object? sender, FormClosingEventArgs e)
    {
        timer1.Enabled = false;
        I2CCOM?.Dispose();
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiDevice device)
    {
        I2CCOM = new(device);
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        I2CCOM?.Dispose();
        I2CCOM = null;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2CCOM is null || !I2CCOM.IsOpen)
            return;

        // https://www.mouser.com/datasheet/2/302/LM75A-1126516.pdf

        byte deviceAddress = (byte)nudAddress.Value;
        byte[] bytes = I2CCOM.Read(deviceAddress, 2);

        lblSensor.Text = Convert.ToString(bytes[0], 2).PadLeft(8, '0') +
            Environment.NewLine +
            Convert.ToString(bytes[1], 2).PadLeft(8, '0');

        Array.Reverse(bytes);
        int value = BitConverter.ToInt16(bytes);
        double temperatureC = value / 256.0;
        double temperatureF = temperatureC * 9 / 5 + 32;

        lblTemperature.Text = $"{temperatureF:N3} F\n{temperatureC:N3} C";
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }

    private void nudAddress_ValueChanged(object sender, EventArgs e)
    {
        lblAddress.Text = "0x" + ((int)nudAddress.Value).ToString("X2");
    }
}
