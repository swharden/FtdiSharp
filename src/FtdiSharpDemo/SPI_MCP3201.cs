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
    int MaxSeenValue = 0;

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

        // https://www.mouser.com/pdfDocs/21290c-28774.pdf

        SPI.FtdiDevice.FlushBuffer();
        SPI.CsLow();
        byte[] bytes = SPI.ReadBytes(2);
        SPI.CsHigh();

        // see MCP3201 datasheet figure 6-1
        byte b1 = (byte)(bytes[0] & 0b00011111); // first 3 clock cycles are null bits
        byte b2 = (byte)(bytes[1] & 0b11111110);
        int value = (b1 << 8) + b2;
        value >>= 1;
        MaxSeenValue = Math.Max(MaxSeenValue, value);

        toolStripStatusLabel1.Text = $"Reads: {++Reads}";
        barGraph1.SetValue(value, MaxSeenValue, value.ToString(), false);
    }
}
