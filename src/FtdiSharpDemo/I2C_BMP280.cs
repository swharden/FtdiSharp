using FtdiSharp;
using System;
using System.Diagnostics;
using System.Net;

namespace FtdiSharpDemo;

public partial class I2C_BMP280 : Form
{
    FtdiSharp.Protocols.I2C? I2C;

    CalibrationValues Cal;

    struct CalibrationValues
    {
        public UInt16 T1;
        public Int16 T2;
        public Int16 T3;
        public UInt16 P1;
        public Int16 P2;
        public Int16 P3;
        public Int16 P4;
        public Int16 P5;
        public Int16 P6;
        public Int16 P7;
        public Int16 P8;
        public Int16 P9;
    }

    public I2C_BMP280()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        lblTemperature.Text = string.Empty;
        lblPressure.Text = string.Empty;
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        I2C = new(deviceSelector1.FTMan);
    }

    private void DeviceSelector1_DeviceClosed(object? sender, EventArgs e)
    {
        I2C = null;
        lblTemperature.Text = string.Empty;
        lblPressure.Text = string.Empty;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null)
            return;

        byte deviceAddress = 0x76;
        ReadCalibrationData(deviceAddress);
        MakeReading(deviceAddress);
    }

    private byte[] GetConfigBytes(byte deviceAddress, byte memoryAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

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

    private void ReadCalibrationData(byte deviceAddress)
    {
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf page 21

        Cal.T1 = BitConverter.ToUInt16(GetConfigBytes(deviceAddress, 0x88));
        Cal.T2 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x8A));
        Cal.T3 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x8C));

        Cal.P1 = BitConverter.ToUInt16(GetConfigBytes(deviceAddress, 0x8E));
        Cal.P2 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x90));
        Cal.P3 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x92));
        Cal.P4 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x94));
        Cal.P5 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x96));
        Cal.P6 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x98));
        Cal.P7 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x9A));
        Cal.P8 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x9C));
        Cal.P9 = BitConverter.ToInt16(GetConfigBytes(deviceAddress, 0x9E));

        lbCalibration.Items.Clear();

        lbCalibration.Items.Add($"[T1] {Cal.T1}");
        lbCalibration.Items.Add($"[T2] {Cal.T2}");
        lbCalibration.Items.Add($"[T3] {Cal.T3}");

        lbCalibration.Items.Add($"[P1] {Cal.P1}");
        lbCalibration.Items.Add($"[P2] {Cal.P2}");
        lbCalibration.Items.Add($"[P3] {Cal.P3}");
        lbCalibration.Items.Add($"[P4] {Cal.P4}");
        lbCalibration.Items.Add($"[P5] {Cal.P5}");
        lbCalibration.Items.Add($"[P6] {Cal.P6}");
        lbCalibration.Items.Add($"[P7] {Cal.P7}");
        lbCalibration.Items.Add($"[P8] {Cal.P8}");
        lbCalibration.Items.Add($"[P9] {Cal.P9}");
    }

    private void MakeReading(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

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
        byte[] temperatureBytes =
        {
            I2C.I2C_ReadByte(),
            I2C.I2C_ReadByte(),
            I2C.I2C_ReadByte(),
        };
        I2C.I2C_SetStop();

        // read pressure
        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.I2C_SendByte(0xF7);
        I2C.I2C_SetStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: true);
        byte[] pressureBytes =
        {
            I2C.I2C_ReadByte(),
            I2C.I2C_ReadByte(),
            I2C.I2C_ReadByte(),
        };
        I2C.I2C_SetStop();

        (double temperature, double pressure) = GetTemperatureAndPressure(temperatureBytes, pressureBytes);
        lblTemperature.Text = $"{temperature:N3} F";
        lblPressure.Text = $"{pressure}";
    }

    (double t, double p) GetTemperatureAndPressure(byte[] temperatureBytes, byte[] pressureBytes)
    {
        // convert bytes into unsigned integers
        long adc_T = 0;
        adc_T += temperatureBytes[0] << 16;
        adc_T += temperatureBytes[1] << 8;
        adc_T += temperatureBytes[2] << 0;
        adc_T >>= 4;

        long adc_P = 0;
        adc_P += pressureBytes[0] << 16;
        adc_P += pressureBytes[1] << 8;
        adc_P += pressureBytes[2] << 0;
        adc_P >>= 4;

        // temperature conversion according to datasheet page 22
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf
        long tv1 = (((adc_T >> 3) - (Cal.T1 << 1)) * (Cal.T2)) >> 11;
        long tv2 = (((((adc_T >> 4) - Cal.T1) * ((adc_T >> 4) - Cal.T1)) >> 12) * Cal.T3) >> 14;
        long t_fine = tv1 + tv2;
        double T = (t_fine * 5 + 128) >> 8;
        T = T * 9.0 / 5 + 3200;  // C to F
        double temperature = T / 100.0;

        // pressure conversion according to datasheet page 22
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf
        double pressure = adc_P; // TODO: I give up reading that thing...

        return (temperature, pressure);
    }
}
