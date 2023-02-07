using FtdiSharp.FTD2XX;
using System.Linq;

namespace FtdiSharp.Protocols;

public class GPIO : ProtocolBase
{
    public GPIO(FtdiDevice device) : base(device)
    {
        FTDI_ConfigureMpsse();
        Write(0b00000000, 0b00000000);
    }

    private void FTDI_ConfigureMpsse()
    {
        FtdiDevice.SetTimeouts(1000, 1000).ThrowIfNotOK();
        FtdiDevice.SetLatency(16).ThrowIfNotOK();
        FtdiDevice.SetFlowControl(FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x00, 0x00).ThrowIfNotOK();
        FtdiDevice.SetBitMode(0x00, 0x00).ThrowIfNotOK(); // RESET
        FtdiDevice.SetBitMode(0x00, 0x02).ThrowIfNotOK(); // MPSSE

        FtdiDevice.FlushBuffer();

        /***** Synchronize the MPSSE interface by sending bad command 0xAA *****/
        FtdiDevice.Write(new byte[] { 0xAA }).ThrowIfNotOK();
        byte[] rx1 = FtdiDevice.ReadBytes(2, out FT_STATUS status1);
        status1.ThrowIfNotOK();
        if ((rx1[0] != 0xFA) || (rx1[1] != 0xAA))
            throw new InvalidOperationException($"bad echo bytes: {rx1[0]} {rx1[1]}");

        /***** Synchronize the MPSSE interface by sending bad command 0xAB *****/
        FtdiDevice.Write(new byte[] { 0xAB }).ThrowIfNotOK();
        byte[] rx2 = FtdiDevice.ReadBytes(2, out FT_STATUS status2);
        status2.ThrowIfNotOK();
        if ((rx2[0] != 0xFA) || (rx2[1] != 0xAB))
            throw new InvalidOperationException($"bad echo bytes: {rx2[0]} {rx2[1]}");

        const uint ClockDivisor = 199; //49 for 200 KHz, 199 for 100 KHz

        int numBytesToSend = 0;
        byte[] buffer = new byte[100];
        buffer[numBytesToSend++] = 0x8A;   // Disable clock divide by 5 for 60Mhz master clock
        buffer[numBytesToSend++] = 0x97;   // Turn off adaptive clocking
        buffer[numBytesToSend++] = 0x8C;   // Enable 3 phase data clock, used by I2C to allow data on both clock edges
                                           // The SK clock frequency can be worked out by below algorithm with divide by 5 set as off
                                           // SK frequency  = 60MHz /((1 +  [(1 +0xValueH*256) OR 0xValueL])*2)
        buffer[numBytesToSend++] = 0x86;   //Command to set clock divisor
        buffer[numBytesToSend++] = (byte)(ClockDivisor & 0x00FF);  //Set 0xValueL of clock divisor
        buffer[numBytesToSend++] = (byte)((ClockDivisor >> 8) & 0x00FF);   //Set 0xValueH of clock divisor
        buffer[numBytesToSend++] = 0x85;           // loopback off

        byte[] msg = buffer.Take(numBytesToSend).ToArray();
        FtdiDevice.Write(msg).ThrowIfNotOK();
    }

    /// <summary>
    /// Bits in each byte represent pins D0-D7.
    /// Setting a direction bit to 1 means output.
    /// Setting a value bit to 1 means high.
    /// </summary>
    public void Write(byte direction, byte value)
    {
        byte[] bytes = new byte[] { 0x80, value, direction };
        for (int i = 0; i < 5; i++)
            FtdiDevice.Write(bytes);
    }

    public byte Read()
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
}
