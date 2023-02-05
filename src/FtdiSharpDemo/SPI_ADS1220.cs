namespace FtdiSharpDemo;

public partial class SPI_ADS1220 : Form
{
    FtdiSharp.Protocols.SPI? SPI;
    int Reads = 0;

    public SPI_ADS1220()
    {
        InitializeComponent();
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        toolStripStatusLabel1.Text = "Reads: 0";
        timer1.Enabled = false;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI = new(e);
        SetupADC();
        timer1.Enabled = true;
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        timer1.Enabled = false;
        SPI?.Dispose();
        SPI = null;
    }

    private void SetupADC()
    {
        if (SPI is null)
            throw new InvalidOperationException();

        SPI.CsLow();
        SPI.WriteOnRisingEdge(0x06); // RESET
        SPI.CsHigh();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (SPI is null)
            return;

        // start a single conversion
        SPI.CsLow();
        SPI.WriteOnRisingEdge(0b00001000);
        SPI.CsHigh();

        // wait for conversion to be ready
        SPI.WaitForReadyToBeLow();

        // get the result
        SPI.CsLow();
        SPI.Flush();
        byte[] bytes = SPI.ReadBytes(3);
        SPI.CsHigh();

        // show the result
        double value = (bytes[0] << 16) + (bytes[1] << 8) + bytes[2];
        double v = value / (1 << 23) * 2.048;
        barGraph1.SetValue(value, 1 << 23, $"{v:N5} V", centerAtZero: false);
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
