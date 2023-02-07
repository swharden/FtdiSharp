using ScottPlot.Plottable;

namespace FtdiSharpDemo;

public partial class I2C_ADS1115DataLogger : Form
{
    FtdiSharp.Protocols.I2C? I2C;
    int Reads = 0;
    double[] Ys = new double[1000];
    int NextIndex = 0;
    readonly ScottPlot.Plottable.SignalPlot Sig;
    readonly ScottPlot.Plottable.VLine VLine;

    public I2C_ADS1115DataLogger()
    {
        InitializeComponent();
        i2cAddressSelector1.Address = 0x48;
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = $"Reads: {Reads}";

        Sig = formsPlot1.Plot.AddSignal(Ys);
        VLine = formsPlot1.Plot.AddVerticalLine(0, Color.Red, width: 2);
        formsPlot1.Plot.SetAxisLimits(0, 1000, -.1, 5.1);
        formsPlot1.Refresh();
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        I2C?.Dispose();
        I2C = null;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        formsPlot1.Refresh();
        I2C = new(e);
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

    private double ReadVoltage()
    {
        if (I2C is null)
            return double.NaN;

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

        return value;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null)
            return;

        double value = ReadVoltage();

        AddPointToGraph(value);

        barGraph1.SetValue(value, 5.0, $"{value:N4} V", centerAtZero: false);
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }

    private void AddPointToGraph(double value)
    {
        Ys[NextIndex] = value;

        NextIndex += 1;
        if (NextIndex >= Ys.Length)
            NextIndex = 0;

        VLine.X = NextIndex;
    }

    private void plotTimer_Tick(object sender, EventArgs e)
    {
        if (I2C is null)
            return;

        formsPlot1.Refresh();
    }
}
