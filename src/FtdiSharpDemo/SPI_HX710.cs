using System.Buffers.Binary;

namespace FtdiSharpDemo;

public partial class SPI_HX710 : Form
{
    FtdiSharp.Protocols.SPI? SPI;

    int Reads = 0;

    public SPI_HX710()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;

        toolStripStatusLabel1.Text = $"Reads: 0";
        lblSensor.Text = "";
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI = new(e);
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI?.Dispose();
        SPI = null;
    }

    private void WaitForConversionToStart()
    {
        if (SPI is null || !SPI.IsOpen)
            return;

        bool isConverting = true;
        while (isConverting)
        {
            byte gpio = SPI.ReadGpioLow();
            isConverting = (gpio & 0b00000100) > 0;
        }
    }

    private void WaitForConversionComplete()
    {
        if (SPI is null || !SPI.IsOpen)
            return;

        bool isConverting = true;
        while (isConverting)
        {
            byte gpio = SPI.ReadGpioLow();
            isConverting = (gpio & 0b00000100) > 0;
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (SPI is null || !SPI.IsOpen)
            return;

        WaitForConversionComplete();
        SPI.FtdiDevice.FlushBuffer();
        SPI.CsLow();
        byte[] data = SPI.ReadBytes(3);
        SPI.PulseClock(3); // set mode for next conversion (see datasheet)
        SPI.CsHigh();

        data[0] ^= 0b10000000;  // flip the most significant bit
        long result = (data[0] << 16) + (data[1] << 8) + data[2];

        lblSensor.Text = FtdiSharp.Display.Binary(data) + Environment.NewLine + result.ToString();

        toolStripStatusLabel1.Text = $"Reads: {Reads++}";
        barGraph1.SetValue(result, 1 << 24, "sensor", centerAtZero: false);
    }
}
