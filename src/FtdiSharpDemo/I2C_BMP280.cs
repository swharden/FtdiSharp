using FtdiSharp;
using System;
using System.Diagnostics;
using System.Net;

namespace FtdiSharpDemo;

public partial class I2C_BMP280 : Form
{
    FtdiSharp.Protocols.I2C? I2C;

    public I2C_BMP280()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        lblSensor.Text = string.Empty;
        lblPressure.Text = string.Empty;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        I2C = new(deviceSelector1.FTMan);
    }

    private void DeviceSelector1_DeviceClosed(object? sender, EventArgs e)
    {
        I2C = null;
        lblSensor.Text = string.Empty;
        lblPressure.Text = string.Empty;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        byte deviceAddress = 0x76;
        MakeReading(deviceAddress);
    }

    private byte[] GetConfigBytes(byte deviceAddress, byte memoryAddress)
    {
        if (I2C is null)
            throw new InvalidOperationException();

        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.I2C_SendByte(memoryAddress);

        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: true);
        byte[] bytes = new byte[] { 0, 0 };
        bytes[0] = I2C.I2C_ReadByte();
        bytes[1] = I2C.I2C_ReadByte();
        I2C.I2C_SetStop();

        //Debug.WriteLine($"CALIBRATION [{memoryAddress:X2}] = {bytes[0]}, {bytes[1]}");

        return bytes;

        /*
            KNOWN GOOD VALUES FROM ARDUINO

            20:32:06.972 -> bytes at 136 are 223, 109
            20:32:06.972 -> bytes at 138 are 181, 105
            20:32:07.006 -> bytes at 140 are 24, 252

            20:32:07.039 -> bytes at 142 are 247, 146
            20:32:07.071 -> bytes at 144 are 50, 214
            20:32:07.104 -> bytes at 146 are 208, 11
            20:32:07.136 -> bytes at 148 are 143, 6
            20:32:07.136 -> bytes at 150 are 116, 0
            20:32:07.169 -> bytes at 152 are 249, 255
            20:32:07.202 -> bytes at 154 are 140, 60
            20:32:07.235 -> bytes at 156 are 248, 198
            20:32:07.267 -> bytes at 158 are 112, 23
        */
    }

    private void MakeReading(byte deviceAddress)
    {
        if (I2C is null)
            return;

        UInt16 T1 = BitConverter.ToUInt16(GetConfigBytes(deviceAddress, 0x88));
        Int16 T2 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x8A));
        Int16 T3 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x8C));

        // setup config register
        byte configAddress = 0xF5;
        byte config = 0;
        config |= 0b00000000;  // t_sb (0.5ms)
        config |= 0b00000000;  // filter (disable filter)
        config |= 0b00000000;  // spi3w_en (disable 3-wire)

        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.I2C_SendByte(configAddress);
        I2C.I2C_SendByte(config);
        I2C.I2C_SetStop();

        // setup control register
        byte ctrlAddress = 0xF4;
        byte ctrl = 0;
        ctrl |= 0b00100000;  // oversampling (x1)
        ctrl |= 0b00000100;  // osrs_p (disable oversampling)
        ctrl |= 0b00000011;  // mode (normal)

        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.I2C_SendByte(ctrlAddress);
        I2C.I2C_SendByte(ctrl);
        I2C.I2C_SetStop();

        // read temperature
        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.I2C_SendByte(0xFA);
        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: true);
        byte temp0 = I2C.I2C_ReadByte();
        byte temp1 = I2C.I2C_ReadByte();
        byte temp2 = I2C.I2C_ReadByte();
        I2C.I2C_SetStop();

        UInt32 result = 0;
        result += (UInt32)(temp0 << 16);
        result += (UInt32)(temp1 << 8);
        result += (UInt32)(temp2 << 0);
        lblSensor.Text = result.ToString();

        double temperature = ConvertTemperature(result, T1, T2, T3);
        lblPressure.Text = $"{temperature:N3} F";

        Debug.WriteLine($"T={temp0}, {temp1}, {temp2}");
    }

    double ConvertTemperature(UInt32 adc_T, UInt16 dig_T1, Int16 dig_T2, Int16 dig_T3)
    {
        adc_T >>= 4;

        long var1 = (((adc_T >> 3) - (dig_T1 << 1)) * (dig_T2)) >> 11;

        long var2 = (((((adc_T >> 4) - ((int)dig_T1)) * ((adc_T >> 4) - ((int)dig_T1))) >> 12) * ((int)dig_T3)) >> 14;

        long t_fine = var1 + var2;

        double T = (t_fine * 5 + 128) >> 8;

        T = T * 9.0 / 5 + 3200;  // C to F

        return T / 100.0;
    }
}
