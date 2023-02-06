using System.Configuration;
using System.Diagnostics;

namespace FtdiSharpDemo;

public partial class SPI_AD7705 : Form
{
    /* WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * WARNING WARNING WARNING WARNING WARNING
     * 
     * THIS CODE DOES NOT WORK AS EXPECTED!!!!
     * 
     */

    FtdiSharp.Protocols.SPI? SPI;

    int Reads = 0;

    public SPI_AD7705()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = "Reads: 0";
    }

    private void button1_Click(object sender, EventArgs e) => SetupADC();

    private void button2_Click(object sender, EventArgs e) => ReadADC();

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI?.Dispose();
        SPI = null;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI = new(e, spiMode: 3, slowDownFactor: 8);
    }

    private void WaitForReadyToBeLow(int maxTries = 100)
    {
        if (SPI is null)
            throw new InvalidOperationException();

        int tries = 0;
        while (true)
        {
            byte state = SPI.ReadGpioL();
            bool pinIsHigh = (state & 0b00010000) > 0;
            if (!pinIsHigh)
                return;
            if (tries++ >= maxTries)
            {
                Debug.WriteLine("WaitForLow Timeout");
                return;
            }
            Thread.Sleep(1);
        }
    }

    private void SetupADC()
    {
        if (SPI is null)
            return;

        // see datasheet https://www.analog.com/media/en/technical-documentation/data-sheets/ad7705_7706.pdf

        // WRITE TO CLOCK REGISTER
        //const byte REGISTER_SELECT_CLOCK = 0b00100000; // RS2=0, RS1=1, RS0=0 (datasheet table 11)
        //const byte CLOCK_CONFIG = 0b00001100; // CLK=1 (4.9512 MHz clock), CLKDIV=1 to divide by 2, no filtering;
        //const byte REGISTER_SELECT_SETUP = 0b00010000; // RS2=0, RS1=0, RS0=1 (datasheet table 11)
        //const byte SETUP_CONFIG = 0b01000000; // self calibration, gain 1, bipolar mode (datasheet table 14)

        SPI.CsLow();
        Thread.Sleep(10);
        SPI.Write(0x20);
        Thread.Sleep(10);
        SPI.CsHigh();

        SPI.CsLow();
        Thread.Sleep(10);
        SPI.Write(0x0C);
        Thread.Sleep(10);
        SPI.CsHigh();

        SPI.CsLow();
        Thread.Sleep(10);
        SPI.Write(0x10);
        Thread.Sleep(10);
        SPI.CsHigh();

        SPI.CsLow();
        Thread.Sleep(10);
        SPI.Write(0x40);
        Thread.Sleep(10);
        SPI.CsHigh();
    }

    private void timer1_Tick(object sender, EventArgs e) { }

    private void ReadADC()
    {
        if (SPI is null)
            return;

        SPI.Flush();
        WaitForReadyToBeLow();

        SPI.CsLow();
        SPI.Write(0x38);
        SPI.CsHigh();

        WaitForReadyToBeLow();

        SPI.CsLow();
        byte[] bytes = SPI.ReadBytes(2);
        SPI.CsHigh();

        SPI.Flush();

        Text = FtdiSharp.Display.Binary(bytes);

        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
