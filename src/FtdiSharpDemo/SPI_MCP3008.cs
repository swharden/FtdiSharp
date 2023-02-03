namespace FtdiSharpDemo;

public partial class SPI_MCP3008 : Form
{
    FtdiSharp.Protocols.SPI? SPI;

    int Reads = 0;

    public SPI_MCP3008()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = $"Reads: 0";
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

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (SPI is null || !SPI.IsOpen)
            return;

        // See datasheet figure 6-1
        // https://cdn-shop.adafruit.com/datasheets/MCP3008.pdf

        byte[] tx = {
            0b00000001, // start
            0b10000000, // CH0 single-ended
            0b00000000, // clock for rx
        };

        SPI.CsLow();
        byte[] rx = SPI.ReadWrite(tx);
        SPI.CsHigh();

        byte msb = (byte)(rx[1] & 0b00000011);
        byte lsb = rx[2];
        double value = (msb << 8) + lsb;

        barGraph1.SetValue(value, 1 << 10, value.ToString(), centerAtZero: false);
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
