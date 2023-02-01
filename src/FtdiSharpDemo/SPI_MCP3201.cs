using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtdiSharpDemo;
public partial class SPI_MCP3201 : Form
{
    FtdiSharp.Protocols.SPI? SPI;

    int Reads = 0;

    public SPI_MCP3201()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        toolStripStatusLabel1.Text = "Reads: 0";
    }

    private void DeviceSelector1_DeviceClosed(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI?.Dispose();
        SPI = null;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, FtdiSharp.FtdiDevice e)
    {
        SPI = new(e);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (SPI is null || !SPI.IsOpen)
            return;

        byte[] bytes = SPI.ReadBytes(2);

        byte b1 = (byte)(bytes[0] & 0b00011111); // see MCP3201 datasheet figure 6-1
        byte b2 = (byte)(bytes[1] & 0b11111110);
        int value = (b1 << 8) + b2;

        lblSensor.Text = value.ToString();
        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
    }
}
