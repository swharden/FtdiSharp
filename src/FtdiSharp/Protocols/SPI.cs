using FtdiSharp.FTD2XX;
using System.Diagnostics;

namespace FtdiSharp.Protocols;

public class SPI : ProtocolBase
{
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_178_User-Guide-for-LibMPSSE-SPI-1.pdf
    // http://www.ftdichip.com/Support/Documents/AppNotes/AN_108_Command_Processor_for_MPSSE_and_MCU_Host_Bus_Emulation_Modes.pdf
    // https://www.ftdichip.com/Support/Documents/ProgramGuides/D2XX_Programmer's_Guide(FT_000071).pdf
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_180_FT232H-MPSSE-Example-USB-Current-Meter-using-the-SPI-interface.pdf
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_114_FTDI_Hi_Speed_USB_To_SPI_Example.pdf

    readonly bool ClockIdlesLow;
    readonly bool SampleOnRisingClock;
    readonly bool TransmitOnRisingClock;

    /// <summary>
    /// This class provides high level operations for SPI communication
    /// </summary>
    /// <param name="device">FTDI device to use for this communicator</param>
    /// <param name="spiMode">
    /// Mode 0: clock idles LOW, data in on the RISING edge and out on the FALLING edge
    /// Mode 1: clock idles LOW, data in on the FALLING edge and out on the RISING edge
    /// Mode 2: clock idles HIGH, data in on the RISING edge and out on the FALLING edge
    /// Mode 3: clock idles HIGH, data in on the FALLING edge and out on the RISING edge
    /// </param>
    /// <exception cref="ArgumentException"></exception>
    public SPI(FtdiDevice device, int spiMode = 1, int slowDownFactor = 1) : base(device)
    {
        // TODO: use SPI MODE and CPOL/CPHA terms to define clock line states


        if (spiMode < 0 || spiMode > 3)
            throw new ArgumentException(nameof(spiMode));

        ClockIdlesLow = spiMode == 0 || spiMode == 1;
        SampleOnRisingClock = spiMode == 0 || spiMode == 2;
        TransmitOnRisingClock = spiMode == 1 || spiMode == 3;

        FTDI_ConfigureMpsse(slowDownFactor);
        CsHigh();
    }

    private void FTDI_ConfigureMpsse(int slowDownFactor = 1)
    {
        FtdiDevice.ResetDevice().ThrowIfNotOK();
        FtdiDevice.SetBitMode(0, 0).ThrowIfNotOK(); // reset
        FtdiDevice.SetBitMode(0, 0x02).ThrowIfNotOK(); // MPSSE 
        FtdiDevice.SetLatency(16).ThrowIfNotOK();
        FtdiDevice.SetTimeouts(1000, 1000).ThrowIfNotOK(); // long
        Thread.Sleep(50);

        // Configure the MPSSE for SPI communication (app note FT_000109 section 6)
        byte[] bytes1 = new byte[]
        {
            0x8A, // disable clock divide by 5 for 60Mhz master clock
            0x97, // turn off adaptive clocking
            0x8d // disable 3 phase data clock
        };
        FtdiDevice.Write(bytes1).ThrowIfNotOK();

        // The SK clock frequency can be worked out by below algorithm with divide by 5 set as off
        // SCL Frequency (MHz) = 60 / ((1 + DIVISOR) * 2)
        UInt32 clockDivisor = 29; // for 1 MHz

        // increase clock divisor to slow down signaling
        clockDivisor *= (uint)slowDownFactor;

        byte[] bytes2 = new byte[]
        {
            0x80, // Set directions of lower 8 pins and force value on bits set as output
            0x08, // Set SDA, SCL high, WP disabled by SK, DO at bit ＆＊, GPIOL0 at bit ＆＊
            0x0b, // Set SK,DO,GPIOL0 pins as output with bit ＊, other pins as input with bit ＆＊
            0x86, // use clock divisor
            (byte)(clockDivisor & 0xFF), // clock divisor low byte
            (byte)(clockDivisor >> 8), // clock divisor high byte
        };
        FtdiDevice.Write(bytes2).ThrowIfNotOK();
        Thread.Sleep(50);

        // disable loopback
        FtdiDevice.Write(new byte[] { 0x85 }).ThrowIfNotOK();
        Thread.Sleep(50);
    }

    /// <summary>
    /// CS pin is D3
    /// </summary>
    public void CsHigh()
    {
        // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0b00001000, // value
            0b00001011, // direction
        };

        if (!ClockIdlesLow)
            bytes[1] |= 0b00000001;

        for (int i = 0; i < 5; i++)
            FtdiDevice.Write(bytes);
    }

    /// <summary>
    /// CS pin is D3
    /// </summary>
    public void CsLow()
    {
        // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0b00000000, // value
            0b00001011, // direction
        };

        if (!ClockIdlesLow)
            bytes[1] |= 0b00000001;

        for (int i = 0; i < 5; i++)
            FtdiDevice.Write(bytes);
    }

    /// <summary>
    /// Return a byte representing the voltage of the first 8 pins
    /// </summary>
    public byte ReadGpioL()
    {
        Flush();
        const byte READ_GPIO_LOW = 0x81; // Application Note AN_108 (section 3.6.3) 
        const byte SEND_IMMEDIATE = 0x87; // This will make the chip flush its buffer back to the PC.

        FtdiDevice.Write(new byte[] { READ_GPIO_LOW, SEND_IMMEDIATE });

        byte[] result = { 0 };
        uint numBytesRead = 0;
        FtdiDevice.Read(result, 1, ref numBytesRead).ThrowIfNotOK();

        return result[0];
    }

    /// <summary>
    /// Return a byte representing the voltage of the upper 8 pins
    /// </summary>
    public byte ReadGpioH()
    {
        Flush();
        const byte READ_GPIO_HIGH = 0x83; // Application Note AN_108 (section 3.6.4) 
        const byte SEND_IMMEDIATE = 0x87; // This will make the chip flush its buffer back to the PC.

        FtdiDevice.Write(new byte[] { READ_GPIO_HIGH, SEND_IMMEDIATE });

        byte[] result = { 0 };
        uint numBytesRead = 0;
        FtdiDevice.Read(result, 1, ref numBytesRead).ThrowIfNotOK();

        return result[0];
    }

    /// <summary>
    /// Shift data outward and inward at the same time and return what we receive
    /// </summary>
    public byte[] ReadWrite(byte[] tx)
    {
        byte[] shiftOut = new byte[tx.Length + 3];
        shiftOut[0] = SampleOnRisingClock ? (byte)0x31 : (byte)0x34;
        shiftOut[1] = (byte)(tx.Length - 1);
        shiftOut[2] = (byte)((tx.Length - 1) >> 8);
        Array.Copy(tx, 0, shiftOut, 3, tx.Length);

        FtdiDevice.FlushBuffer();
        FtdiDevice.Write(shiftOut).ThrowIfNotOK();

        byte[] rx = new byte[tx.Length];
        uint NumBytesRead = 0;
        FtdiDevice.Read(rx, (uint)rx.Length, ref NumBytesRead).ThrowIfNotOK();
        return rx;
    }

    /// <summary>
    /// Send a single byte
    /// </summary>
    public void Write(byte b)
    {
        byte cmd = TransmitOnRisingClock ? (byte)0x10 : (byte)0x11; // AN_108 section 3.3
        byte lengthL = 0;
        byte lengthH = 0;
        byte[] bytes = { cmd, lengthL, lengthH, b };
        FtdiDevice.Write(bytes).ThrowIfNotOK();
    }

    public byte[] ReadBytes(int length)
    {
        byte cmd = SampleOnRisingClock ? (byte)0x20 : (byte)0x24; // AN_108 (section 3.3)
        byte lengthL = (byte)length;
        byte lengthH = (byte)(length >> 8);

        byte[] writeBytes = { cmd, lengthL, lengthH };
        FtdiDevice.Write(writeBytes).ThrowIfNotOK();

        byte[] readBytes = new byte[length];
        uint bytesRead = 0;
        FtdiDevice.Read(readBytes, (uint)length, ref bytesRead).ThrowIfNotOK();

        return readBytes;
    }

    /// <summary>
    /// Pulse the clock line a certain number of times
    /// </summary>
    /// <param name="count"></param>
    public void PulseClock(int count)
    {
        const byte CMD_SET_GPIO_STATE = 0x80; // Application Note AN_108 (section 3.6.1)
        const byte GPIO_DIRECTION = 0b00001011; //  bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK

        byte clockOn = ClockIdlesLow ? (byte)0b11110111 : (byte)0b11110110;
        byte clockOff = ClockIdlesLow ? (byte)0b11110110 : (byte)0b11110111;

        byte[] bytesClockLow = new byte[] { CMD_SET_GPIO_STATE, clockOn, GPIO_DIRECTION };
        byte[] bytesClockHigh = new byte[] { CMD_SET_GPIO_STATE, clockOff, GPIO_DIRECTION };

        for (int i = 0; i < count; i++)
        {
            FtdiDevice.Write(bytesClockLow);
            FtdiDevice.Write(bytesClockHigh);
        }
    }

    /// <summary>
    /// Ready pin is D4
    /// </summary>
    public void WaitForReadyToBeLow(int maxTries = 100, int msBetweenRetries = 1)
    {
        int tries = 0;
        while (true)
        {
            byte state = ReadGpioL();
            bool pinIsHigh = (state & 0b00010000) > 0;
            if (!pinIsHigh)
                return;
            if (tries++ >= maxTries)
            {
                Debug.WriteLine("WaitForReadyToBeLow Timeout");
                return;
            }
            Thread.Sleep(msBetweenRetries);
        }
    }
}
