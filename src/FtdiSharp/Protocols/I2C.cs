using FtdiSharp.FTD2XX;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FtdiSharp.Protocols;

public class I2C
{
    public readonly FtdiManager FTMan;
    public FTDI FtdiDevice => FTMan.FTD2XX;

    public I2C(FtdiManager ftman)
    {
        FTMan = ftman;
        I2C_ConfigureMpsse();
    }

    public void I2C_ConfigureMpsse()
    {
        FtdiDevice.SetTimeouts(1000, 1000).ThrowIfNotOK();
        FtdiDevice.SetLatency(16).ThrowIfNotOK();
        FtdiDevice.SetFlowControl(FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0x00, 0x00).ThrowIfNotOK();
        FtdiDevice.SetBitMode(0x00, 0x00).ThrowIfNotOK(); // RESET
        FtdiDevice.SetBitMode(0x00, 0x02).ThrowIfNotOK(); // MPSSE

        FtdiDevice.FlushBuffer();

        /***** Synchronize the MPSSE interface by sending bad command 0xAA *****/
        FtdiDevice.Write(new byte[] { 0xAA }).ThrowIfNotOK();
        (FT_STATUS status1, byte[] rx1) = FtdiDevice.ReadBytes(2);
        status1.ThrowIfNotOK();
        if ((rx1[0] != 0xFA) || (rx1[1] != 0xAA))
            throw new InvalidOperationException($"bad echo bytes: {rx1[0]} {rx1[1]}");

        /***** Synchronize the MPSSE interface by sending bad command 0xAB *****/
        FtdiDevice.Write(new byte[] { 0xAB }).ThrowIfNotOK();
        (FT_STATUS status2, byte[] rx2) = FtdiDevice.ReadBytes(2);
        status2.ThrowIfNotOK();
        if ((rx2[0] != 0xFA) || (rx2[1] != 0xAB))
            throw new InvalidOperationException($"bad echo bytes: {rx2[0]} {rx2[1]}");

        const uint ClockDivisor = 49;
        const byte I2C_Data_SDAhi_SCLhi = 0x03;
        const byte I2C_Dir_SDAout_SCLout = 0x03;

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

        buffer[numBytesToSend++] = 0x9E;       //Enable the FT232H's drive-zero mode with the following enable mask...
        buffer[numBytesToSend++] = 0x07;       // ... Low byte (ADx) enables - bits 0, 1 and 2 and ... 
        buffer[numBytesToSend++] = 0x00;       //...High byte (ACx) enables - all off

        buffer[numBytesToSend++] = 0x80;   //Command to set directions of lower 8 pins and force value on bits set as output 
        buffer[numBytesToSend++] = I2C_Data_SDAhi_SCLhi;
        buffer[numBytesToSend++] = I2C_Dir_SDAout_SCLout;

        byte[] msg = buffer.Take(numBytesToSend).ToArray();
        FtdiDevice.Write(msg).ThrowIfNotOK();
    }

    public void I2C_SetStart()
    {
        List<byte> bytes = new();

        const byte I2C_Data_SDAlo_SCLlo = 0x00;
        const byte I2C_Data_SDAlo_SCLhi = 0x01;
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        const byte I2C_Data_SDAhi_SCLhi = 0x03;

        const byte I2C_ADbus = 0x80;
        const byte I2C_Dir_SDAout_SCLout = 0x03;

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAhi_SCLhi, I2C_Dir_SDAout_SCLout, });

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAlo_SCLhi, I2C_Dir_SDAout_SCLout, });

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAlo_SCLlo, I2C_Dir_SDAout_SCLout, });

        bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAhi_SCLlo, I2C_Dir_SDAout_SCLout, });

        FTMan.FTD2XX.Write(bytes.ToArray()).ThrowIfNotOK();
    }

    public void I2C_SetStop()
    {
        List<byte> bytes = new();

        const byte I2C_Data_SDAlo_SCLlo = 0x00;
        const byte I2C_Data_SDAlo_SCLhi = 0x01;
        const byte I2C_Data_SDAhi_SCLhi = 0x03;

        const byte I2C_ADbus = 0x80;
        const byte I2C_Dir_SDAout_SCLout = 0x03;

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAlo_SCLlo, I2C_Dir_SDAout_SCLout, });

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAlo_SCLhi, I2C_Dir_SDAout_SCLout, });

        for (int i = 0; i < 6; i++)
            bytes.AddRange(new byte[] { I2C_ADbus, I2C_Data_SDAhi_SCLhi, I2C_Dir_SDAout_SCLout, });

        FTMan.FTD2XX.Write(bytes.ToArray()).ThrowIfNotOK();
    }

    public bool I2C_SendDeviceAddr(byte address, bool read, bool throwOnNAK = false)
    {
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_OUT = 0x11;
        const byte I2C_Dir_SDAout_SCLout = 0x03;
        const byte MSB_RISING_EDGE_CLOCK_BIT_IN = 0x22;

        address <<= 1;
        if (read == true)
            address |= 0x01;

        byte[] buffer = new byte[100];
        int bytesToSend = 0;
        buffer[bytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
        buffer[bytesToSend++] = 0x00;                                   // 
        buffer[bytesToSend++] = 0x00;                                   //  Data length of 0x0000 means 1 byte data to clock in
        buffer[bytesToSend++] = address;           //  Byte to send

        // Put line back to idle (data released, clock pulled low)
        buffer[bytesToSend++] = 0x80;                                   // Command - set low byte
        buffer[bytesToSend++] = I2C_Data_SDAhi_SCLlo;                               // Set the values
        buffer[bytesToSend++] = I2C_Dir_SDAout_SCLout;                               // Set the directions

        // CLOCK IN ACK
        buffer[bytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data bits in
        buffer[bytesToSend++] = 0x00;                                   // Length of 0 means 1 bit

        // This command then tells the MPSSE to send any results gathered (in this case the ack bit) back immediately
        buffer[bytesToSend++] = 0x87;                                //  ' Send answer back immediate command

        // send commands to chip
        byte[] msg = buffer.Take(bytesToSend).ToArray();
        FTMan.FTD2XX.Write(msg).ThrowIfNotOK();

        (FT_STATUS status, byte[] rx1) = FTMan.FTD2XX.ReadBytes(1);
        status.ThrowIfNotOK();

        // if ack bit is 0 then sensor acked the transfer, otherwise it nak'd the transfer
        bool ack = (rx1[0] & 0x01) == 0;
        if (!ack && throwOnNAK)
            throw new InvalidOperationException("NAKd");

        return ack;
    }

    public string[] Scan()
    {
        List<string> devices = new();

        for (int address = 1; address < 127; address++)
        {
            I2C_SetStart();
            bool ack = I2C_SendDeviceAddr((byte)address, read: true);
            I2C_SetStop();

            if (ack)
                devices.Add($"0x{address:X2}");
        }

        if (devices.Count == 0)
            return new string[] { "No devices found" };

        return devices.ToArray();
    }
}
