using FtdiSharp.FTD2XX;
using System;

namespace FtdiSharp.Protocols;

public class SPI : ProtocolBase
{
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_178_User-Guide-for-LibMPSSE-SPI-1.pdf
    // http://www.ftdichip.com/Support/Documents/AppNotes/AN_108_Command_Processor_for_MPSSE_and_MCU_Host_Bus_Emulation_Modes.pdf
    // https://www.ftdichip.com/Support/Documents/ProgramGuides/D2XX_Programmer's_Guide(FT_000071).pdf
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_180_FT232H-MPSSE-Example-USB-Current-Meter-using-the-SPI-interface.pdf
    // https://ftdichip.com/wp-content/uploads/2020/08/AN_114_FTDI_Hi_Speed_USB_To_SPI_Example.pdf

    public SPI(FtdiDevice device, int slowDownFactor = 1) : base(device)
    {
        FTDI_ConfigureMpsse(slowDownFactor);
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

    public void Flush()
    {
        FtdiDevice.FlushBuffer();
    }

    public void CsHigh(bool clockLineHigh = false)
    {
        // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0b00001000, // value
            0b00001011, // direction
        };

        if (clockLineHigh)
            bytes[1] |= 0b00000001;

        for (int i = 0; i < 5; i++)
            FtdiDevice.Write(bytes);
    }

    public void CsLow(bool clockLineHigh = false)
    {
        // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0b00000000, // value
            0b00001011, // direction
        };

        if (clockLineHigh)
            bytes[1] |= 0b00000001;

        for (int i = 0; i < 5; i++)
            FtdiDevice.Write(bytes);
    }

    public byte ReadGpioLow()
    {
        Flush();

        // This will read the current state of the first 8 pins and send back 1 byte.
        const byte READ_GPIO_LOW = 0x81; // Application Note AN_108 (section 3.6.3) 

        // This will make the chip flush its buffer back to the PC.
        const byte SEND_IMMEDIATE = 0x87;

        FtdiDevice.Write(new byte[] { READ_GPIO_LOW, SEND_IMMEDIATE });

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
        shiftOut[0] = 0x31; // 31 or 34
        shiftOut[1] = (byte)tx.Length;
        shiftOut[2] = (byte)(tx.Length >> 8);
        Array.Copy(tx, 0, shiftOut, tx.Length, tx.Length);

        FtdiDevice.FlushBuffer();
        FtdiDevice.Write(shiftOut).ThrowIfNotOK();

        byte[] rx = new byte[tx.Length];
        uint NumBytesRead = 0;
        FtdiDevice.Read(rx, (uint)rx.Length, ref NumBytesRead).ThrowIfNotOK();
        return rx;
    }

    /// <summary>
    /// use this when the clock line rests low
    /// </summary>
    /// <param name="b"></param>
    public void WriteOnRisingEdge(byte b)
    {
        byte[] bytes = { 0x10, 0, 0, b }; // see AN_108 section 3.3
        FtdiDevice.Write(bytes).ThrowIfNotOK();
    }

    /// <summary>
    /// use this when the clock line rests high
    /// </summary>
    public void WriteOnFallingEdge(byte b)
    {
        byte[] bytes = { 0x11, 0, 0, b }; // see AN_108 section 3.3
        FtdiDevice.Write(bytes).ThrowIfNotOK();
    }

    public byte[] ReadBytes(int length, bool fallingEdge = true)
    {
        byte lengthL = (byte)length;
        byte lengthH = (byte)(length >> 8);

        byte cmd = fallingEdge ? (byte)0x24 : (byte)0x20; // see AN_108 (section 3.3)

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

        byte[] bytesClockLow = new byte[] { CMD_SET_GPIO_STATE, 0b11110111, GPIO_DIRECTION };
        byte[] bytesClockHigh = new byte[] { CMD_SET_GPIO_STATE, 0b11110110, GPIO_DIRECTION };

        for (int i = 0; i < count; i++)
        {
            FtdiDevice.Write(bytesClockLow);
            FtdiDevice.Write(bytesClockHigh);
        }
    }
}
