using FtdiSharp.FTD2XX;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace FtdiSharpDemo;

public partial class I2C_BMP280 : Form
{
    FtdiSharp.Protocols.I2C? I2C;

    readonly CalibrationValues Cal = new();

    int Reads = 0;

    class CalibrationValues
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
        private string BytesString(UInt16 value) => string.Join(", ", BitConverter.GetBytes(value).Select(x => x.ToString()));
        private string BytesString(Int16 value) => string.Join(", ", BitConverter.GetBytes(value).Select(x => x.ToString()));
        public string[] GetSummary()
        {
            return new string[]
            {
                $"[T1] {BytesString(T1)} ({T1})",
                $"[T2] {BytesString(T2)} ({T2})",
                $"[T3] {BytesString(T3)} ({T3})",
                $"[P1] {BytesString(P1)} ({P1})",
                $"[P2] {BytesString(P2)} ({P2})",
                $"[P3] {BytesString(P3)} ({P3})",
                $"[P4] {BytesString(P4)} ({P4})",
                $"[P5] {BytesString(P5)} ({P5})",
                $"[P6] {BytesString(P6)} ({P6})",
                $"[P7] {BytesString(P7)} ({P7})",
                $"[P8] {BytesString(P8)} ({P8})",
                $"[P9] {BytesString(P9)} ({P9})",
            };
        }
    }

    public I2C_BMP280()
    {
        InitializeComponent();
        deviceSelector1.DeviceOpened += DeviceSelector1_DeviceOpened;
        deviceSelector1.DeviceClosed += DeviceSelector1_DeviceClosed;
        lblTemperature.Text = string.Empty;
        lblPressure.Text = string.Empty;
        lblTemperatureBytes.Text = string.Empty;
        lblPressureBytes.Text = string.Empty;
        I2cAddressSelector1.Address = 0x76;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        I2C?.FtdiDevice.Close();
        timer1.Enabled = false;
        base.OnClosing(e);
    }

    private void DeviceSelector1_DeviceOpened(object? sender, EventArgs e)
    {
        I2C = new(deviceSelector1.FTMan);
        ResetDevice(I2cAddressSelector1.Address);
        Thread.Sleep(100);
        timer1.Enabled = true;
    }

    private void DeviceSelector1_DeviceClosed(object? sender, EventArgs e)
    {
        timer1.Enabled = false;
        I2C = null;
        lblTemperature.Text = string.Empty;
        lblPressure.Text = string.Empty;
        lbCalibration.Items.Clear();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (I2C is null)
            return;

        I2C.ConfigureMpsse();
        if (!IsValidID(I2cAddressSelector1.Address))
        {
            lblTemperature.Text = "INVALID DEVICE ID";
            return;
        }

        ReadCalibrationData(I2cAddressSelector1.Address);
        SetupConfigRegister(I2cAddressSelector1.Address);
        SetupControlRegister(I2cAddressSelector1.Address);
        WaitForConversion(I2cAddressSelector1.Address);
        MakeReading(I2cAddressSelector1.Address);
        lblReads.Text = $"Reads: {++Reads}";
        Application.DoEvents();
    }

    private bool IsValidID(byte deviceAddress)
    {
        // according to the datsheet section 4.3.1 register 0xD0 will contain 0x58
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf

        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(0xD0);

        I2C.SendStart();
        I2C.SendAddressForReading(deviceAddress);
        byte id = I2C.ReadByte(false);
        I2C.SendStop();

        return id == 0x58;
    }

    private byte[] GetConfigBytes(byte deviceAddress, byte memoryAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(memoryAddress);

        I2C.SendStart();
        I2C.SendAddressForReading(deviceAddress);
        byte[] bytes = {
            I2C.ReadByte(true),
            I2C.ReadByte(false),
        };
        I2C.SendStop();

        //Debug.WriteLine($"Config bytes at {memoryAddress} are {bytes[0]}, {bytes[1]}");

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

    private void ResetDevice(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        // write 0xB6 to register 0xE0 to reset (datasheet section 4.3.2)
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf
        I2C.SendStart();
        I2C.I2C_SendDeviceAddr(deviceAddress, read: false);
        I2C.SendByte(0xE0);
        I2C.SendByte(0xB6);
        I2C.SendStop();
    }

    private void ReadCalibrationData(byte deviceAddress)
    {
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf page 21

        GetConfigBytes(deviceAddress, 0); // burn one

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

        foreach (string item in Cal.GetSummary())
            lbCalibration.Items.Add(item);
    }

    private void SetupConfigRegister(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        // setup config register
        byte configAddress = 0xF5;
        byte config = 0;
        config |= 0b00000000;  // t_sb (0.5ms)
        config |= 0b00000000;  // filter (disable filter)
        config |= 0b00000000;  // spi3w_en (disable 3-wire)

        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(configAddress);
        I2C.SendByte(config);
        I2C.SendStop();
    }

    private void SetupControlRegister(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        // setup control register
        byte ctrlAddress = 0xF4;

        byte ctrl = 0;
        ctrl |= 0b01100000; // temperature resolution
        ctrl |= 0b00001100; // pressure resolution
        ctrl |= 0b00000011; // normal mode (continous running)

        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(ctrlAddress);
        I2C.SendByte(ctrl);
        I2C.SendStop();
    }

    private void WaitForConversion(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        bool isMeasuring = true;
        bool isConverting = false;
        while (isMeasuring || isConverting)
        {
            I2C.SendStart();
            I2C.SendAddressForWriting(deviceAddress);
            I2C.SendByte(0xF3);
            I2C.SendByte(0xF3);
            I2C.SendStart();
            I2C.SendAddressForReading(deviceAddress);
            byte status = I2C.ReadByte(false);
            I2C.SendStop();
            isMeasuring = (status & 0b00001000) > 0;
            isConverting = (status & 0b00000001) > 0;
            if (isMeasuring)
                Debug.WriteLine("Waiting on measurement...");
            else if (isConverting)
                Debug.WriteLine("Waiting on conversion...");
            else
                Debug.WriteLine("Ready");
        }
    }

    private void MakeReading(byte deviceAddress)
    {
        if (I2C is null)
            throw new NullReferenceException(nameof(I2C));

        // read temperature
        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(0xFA);

        I2C.SendStart();
        I2C.SendAddressForReading(deviceAddress);
        byte[] temperatureBytes = {
            I2C.ReadByte(true),
            I2C.ReadByte(true),
            I2C.ReadByte(false),
        };
        I2C.SendStop();

        // read pressure
        I2C.SendStart();
        I2C.SendAddressForWriting(deviceAddress);
        I2C.SendByte(0xF7);

        I2C.SendStart();
        I2C.SendAddressForReading(deviceAddress);
        byte[] pressureBytes = {
            I2C.ReadByte(true),
            I2C.ReadByte(true),
            I2C.ReadByte(false),
        };
        I2C.SendStop();

        lblTemperatureBytes.Text = string.Join(", ", temperatureBytes.Select(x => x.ToString()));
        lblPressureBytes.Text = string.Join(", ", pressureBytes.Select(x => x.ToString()));

        (double temperature, double pressure) = GetTemperatureAndPressure(temperatureBytes, pressureBytes);
        lblTemperature.Text = $"{temperature:N3} F";
        lblPressure.Text = $"{pressure:N4} PSI";
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
        long t1, t2, t3;
        t1 = (((adc_T >> 3) - ((long)Cal.T1 << 1)) * Cal.T2) >> 11;
        t2 = (((((adc_T >> 4) - Cal.T1) * ((adc_T >> 4) - Cal.T1)) >> 12) * Cal.T3) >> 14;
        long t_fine = t1 + t2;
        t3 = (t_fine * 5 + 128) >> 8;
        double temperatureC = t3 / 100.0;
        double temperatureF = temperatureC * 9 / 5 + 32;

        // pressure conversion according to datasheet page 22
        // https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf
        long var1, var2, p;
        var1 = ((long)t_fine) - 128000;
        var2 = var1 * var1 * (long)Cal.P6;
        var2 = var2 + ((var1 * (long)Cal.P5) << 17);
        var2 = var2 + (((long)Cal.P4) << 35);
        var1 = ((var1 * var1 * (long)Cal.P3) >> 8) + ((var1 * (long)Cal.P2) << 12);
        var1 = (((((long)1) << 47) + var1)) * ((long)Cal.P1) >> 33;
        if (var1 == 0)
        {
            return (temperatureF, 0);
        }
        p = 1048576 - adc_P;
        p = (((p << 31) - var2) * 3125) / var1;
        var1 = (((long)Cal.P9) * (p >> 13) * (p >> 13)) >> 25;
        var2 = (((long)Cal.P8) * p) >> 19;
        p = ((p + var1 + var2) >> 8) + (((long)Cal.P7) << 4);

        double pressurePa = p / 256.0;
        double pressurePSI = pressurePa / 6894.76;

        return (temperatureF, pressurePSI);
    }
}
