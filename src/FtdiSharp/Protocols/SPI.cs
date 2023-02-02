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

        // increase clock divisor to slow down signaling
        //clockDivisor *= 100;

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

    public void CsHighDisable()
    {
        byte[] bytes = new byte[]
        {
            0x80, // GPIO command for ADBUS
            0x08, // set CS high, MOSI and SCL low
            0x0b, // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
        };
        FtdiDevice.Write(bytes);
    }

    public void CsLowEnable()
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
        CsLowEnable();

        byte lengthL = (byte)length;
        byte lengthH = (byte)(length >> 8);
        if (lengthH != 0)
            throw new NotImplementedException();

        const byte DATA_IN_BYTES_FALLING_EDGE = 0x24; // app note section 3.3
        //const byte DATA_IN_BYTES_RISING_EDGE = 0x20; // app note section 3.3

        byte[] writeBytes = { DATA_IN_BYTES_FALLING_EDGE, lengthL, lengthH };
        FtdiDevice.Write(writeBytes);

        byte[] readBytes = new byte[length];
        uint bytesRead = 0;
        FtdiDevice.Read(readBytes, (uint)length, ref bytesRead).ThrowIfNotOK();

        CsHighDisable();

        return readBytes;
    }

    private static byte GetGpioMask(bool sck = false, bool mosi = false, bool miso = false, bool cs = false)
    {
        byte b = 0;

        if (sck)
            b |= (0 << 1);
        if (mosi)
            b |= (1 << 1);
        if (miso)
            b |= (2 << 1);
        if (cs)
            b |= (3 << 1);

        return b;
    }

    /// <summary>
    /// Pulse the clock line a certain number of times
    /// </summary>
    /// <param name="count"></param>
    public void PulseClock(int count)
    {
        const byte CMD_SET_GPIO_STATE = 0x80; // Application Note AN_108 (section 3.6.1)
        const byte GPIO_DIRECTION = 0b00001011; //  bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK

        byte[] bytesClockLow = new byte[] { CMD_SET_GPIO_STATE, 0b11111111, GPIO_DIRECTION };
        byte[] bytesClockHigh = new byte[] { CMD_SET_GPIO_STATE, 0b11111110, GPIO_DIRECTION };

        for (int i = 0; i < count; i++)
        {
            FtdiDevice.Write(bytesClockLow);
            FtdiDevice.Write(bytesClockHigh);
        }
    }

    public byte ReadGpioLow()
    {
        const byte READ_GPIO_LOW = 0x81; // Application Note AN_108 (section 3.6.3)
        const byte SEND_IMMEDIATE = 0x87;
        FtdiDevice.Write(new byte[] { READ_GPIO_LOW, SEND_IMMEDIATE });

        byte[] result = { 0 };
        uint numBytesRead = 0;
        FtdiDevice.Read(result, 1, ref numBytesRead).ThrowIfNotOK();

        return result[0];
    }

    /// <summary>
    /// Let the other guy do the clocking
    /// </summary>
    public byte[] RxData(uint BytesToRead)
    {
        uint NumBytesInQueue = 0;
        uint TotalBytesRead = 0;
        uint NumBytesRxd = 0;

        byte[] InputBuffer = new byte[BytesToRead];

        while (TotalBytesRead < BytesToRead)
        {
            FtdiDevice.GetRxBytesAvailable(ref NumBytesInQueue);

            if (NumBytesInQueue == 0)
                continue;

            FtdiDevice.Read(InputBuffer, NumBytesInQueue, ref NumBytesRxd);

            if (NumBytesInQueue == NumBytesRxd)
                return InputBuffer;
        }

        return InputBuffer;
    }
}
