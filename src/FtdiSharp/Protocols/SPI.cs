using FtdiSharp.FTD2XX;

namespace FtdiSharp.Protocols;

public class SPI : ProtocolBase
{
    public SPI(FtdiDevice device) : base(device)
    {
        FTDI_ConfigureMpsse();
    }

    private void FTDI_ConfigureMpsse()
    {
        FtdiDevice.ResetDevice().ThrowIfNotOK();
        FtdiDevice.SetBitMode(0, 0).ThrowIfNotOK(); // reset
        FtdiDevice.SetBitMode(0, 0x02).ThrowIfNotOK(); // MPSSE 
        FtdiDevice.SetLatency(16).ThrowIfNotOK();
        FtdiDevice.SetTimeouts(1000, 1000).ThrowIfNotOK(); // long
        Thread.Sleep(50);

        // Configure the MPSSE for SPI communication
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

        byte[] bytes2 = new byte[]
        {
            0x80, // Set directions of lower 8 pins and force value on bits set as output
            0x00, // Set SDA, SCL high, WP disabled by SK, DO at bit ＆＊, GPIOL0 at bit ＆＊
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

    public void CsHigh()
    {
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0x08, // set CS high, MOSI and SCL low
            0x0b, // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        };
        FtdiDevice.Write(bytes);
    }

    public void CsLow()
    {
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0x00, // set CS, MOSI, and SCL all low
            0x0b, // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        };
        FtdiDevice.Write(bytes);
    }

    public void WriteBytes(byte[] bytes)
    {
    }

    public byte[] ReadBytes(int length)
    {
        CsLow();

        byte[] writeBuffer =
        {
            0x24, // MSB_FALLING_EDGE_CLOCK_BYTE_IN
            0x01, // two bytes
            0x00,
        };
        FtdiDevice.Write(writeBuffer);

        byte[] readBuffer = new byte[2];
        uint bytesRead = 0;
        FtdiDevice.Read(readBuffer, 2, ref bytesRead).ThrowIfNotOK();

        CsHigh();
        return readBuffer;
    }
}
