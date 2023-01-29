﻿using FtdiSharp.Protocols;
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
        if (I2C is not null)
            ReadAccel();
    }

    private void ReadAccel()
    {
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

        I2C.SendStart();
        I2C.SendAddressForWriting(DeviceAddress);
        I2C.SendByte(0x0F);

        I2C.SendStart();
        I2C.SendAddressForReading(DeviceAddress);
        byte result = I2C.ReadByte(false);
        I2C.SendStop();

        const byte expectedResult = 0b00110011;

        if (result != expectedResult)
        {
            throw new InvalidOperationException($"Expected a WHO_AM_I byte of {expectedResult} but got {result}");
        }
    }

    private void SetupDevice()
    {
        // https://www.st.com/resource/en/datasheet/cd00274221.pdf (section 8.8)

        I2C.SendStart();
        I2C.SendAddressForWriting(DeviceAddress);
        I2C.SendByte(0x20); // CTRL_REG1
        I2C.SendByte(0b00110111); // 25 Hz, enable all 3 axes

        I2C.SendStop();
    }

    private void ReadAxis(byte addressL, byte addressH, BarGraph bar)
    {
        if (I2C is null)
            return;

        byte[] bytes = { 0, 0 };

        I2C.SendStart();
        I2C.SendAddressForWriting(DeviceAddress);
        I2C.SendByte(addressL);
        I2C.SendStart();
        I2C.SendAddressForReading(DeviceAddress);
        bytes[0] = I2C.ReadByte(false);

        I2C.SendStart();
        I2C.SendAddressForWriting(DeviceAddress);
        I2C.SendByte(addressH);
        I2C.SendStart();
        I2C.SendAddressForReading(DeviceAddress);
        bytes[1] = I2C.ReadByte(false);

        I2C.SendStop();

        double value = BitConverter.ToInt16(bytes);

        bar.SetValue(value, 2000);
    }

    private void ReadAxes()
    {
        ReadAxis(0x28, 0x29, barGraph1);
        ReadAxis(0x2A, 0x2B, barGraph2);
        ReadAxis(0x2C, 0x2D, barGraph3);
    }
}