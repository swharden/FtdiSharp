using FtdiSharp.FTD2XX;
using System.Diagnostics;
using System.Linq;

// Why didn't I use dotnet/iot's Ft232H bus?
// Because the readme has incorrect information and I could never get the code to run on my computer.
// I think it's a good effort, but not carefully maintained.
// If it works for you though, use it.
// https://github.com/dotnet/iot/blob/f3870a8e3af355da17ad7453183e7b2fd7a10402/src/devices/Ft232H/Ft232HI2cBus.cs

namespace FtdiSharp.Protocols;

public class I2C : ProtocolBase
{
    public I2C(FtdiDevice device) : base(device)
    {
        FTDI_ConfigureMpsse();
    }

    #region PRIVATE

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

    private void FTDI_Start()
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

        FtdiDevice.Write(bytes.ToArray()).ThrowIfNotOK();
    }

    private void FTDI_Stop()
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

        FtdiDevice.Write(bytes.ToArray()).ThrowIfNotOK();
    }

    private bool FTDI_CommandWrite(byte address)
    {
        address <<= 1;
        return FTDI_SendByte(address);
    }

    private bool FTDI_CommandRead(byte address)
    {
        address <<= 1;
        address |= 0x01;
        return FTDI_SendByte(address);
    }

    private bool FTDI_SendByte(byte byteToSend)
    {
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        const byte MSB_FALLING_EDGE_CLOCK_BYTE_OUT = 0x11;
        const byte I2C_Dir_SDAout_SCLout = 0x03;
        const byte MSB_RISING_EDGE_CLOCK_BIT_IN = 0x22;

        byte[] buffer = new byte[100];
        int bytesToSend = 0;
        buffer[bytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;        // clock data byte out
        buffer[bytesToSend++] = 0x00;                                   // 
        buffer[bytesToSend++] = 0x00;                                   //  Data length of 0x0000 means 1 byte data to clock in
        buffer[bytesToSend++] = byteToSend;                             //  Byte to send

        // Put line back to idle (data released, clock pulled low)
        buffer[bytesToSend++] = 0x80;                                   // Command - set low byte
        buffer[bytesToSend++] = I2C_Data_SDAhi_SCLlo;                   // Set the values
        buffer[bytesToSend++] = I2C_Dir_SDAout_SCLout;                  // Set the directions

        // CLOCK IN ACK
        buffer[bytesToSend++] = MSB_RISING_EDGE_CLOCK_BIT_IN;           // clock data bits in
        buffer[bytesToSend++] = 0x00;                                   // Length of 0 means 1 bit

        // This command then tells the MPSSE to send any results gathered (in this case the ack bit) back immediately
        buffer[bytesToSend++] = 0x87;

        // send commands to chip
        byte[] msg = buffer.Take(bytesToSend).ToArray();
        FtdiDevice.Write(msg).ThrowIfNotOK();

        byte[] rx1 = FtdiDevice.ReadBytes(1, out FT_STATUS status);
        status.ThrowIfNotOK();

        // if ack bit is 0 then sensor acked the transfer, otherwise it nak'd the transfer
        bool ack = (rx1[0] & 0x01) == 0;

        return ack;
    }

    private byte FTDI_ReadByte(bool ACK = true)
    {
        const byte MSB_RISING_EDGE_CLOCK_BYTE_IN = 0x20;
        const byte MSB_FALLING_EDGE_CLOCK_BIT_OUT = 0x13;
        const byte I2C_Data_SDAhi_SCLlo = 0x02;
        const byte I2C_Dir_SDAout_SCLout = 0x03;
        int bytesToSend = 0;

        // Clock in one data byte
        byte[] buffer = new byte[100];
        buffer[bytesToSend++] = MSB_RISING_EDGE_CLOCK_BYTE_IN;      // Clock data byte in
        buffer[bytesToSend++] = 0x00;
        buffer[bytesToSend++] = 0x00;                               // Data length of 0x0000 means 1 byte data to clock in

        // clock out one bit as ack/nak bit
        buffer[bytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;     // Clock data bit out
        buffer[bytesToSend++] = 0x00;                               // Length of 0 means 1 bit
        if (ACK == true)
            buffer[bytesToSend++] = 0x00;                           // Data bit to send is a '0'
        else
            buffer[bytesToSend++] = 0xFF;                           // Data bit to send is a '1'

        // I2C lines back to idle state 
        buffer[bytesToSend++] = 0x80;                               //       ' Command - set low byte
        buffer[bytesToSend++] = I2C_Data_SDAhi_SCLlo;                            //      ' Set the values
        buffer[bytesToSend++] = I2C_Dir_SDAout_SCLout;                             //     ' Set the directions

        // This command then tells the MPSSE to send any results gathered back immediately
        buffer[bytesToSend++] = 0x87;                                  //    ' Send answer back immediate command

        // send commands to chip
        byte[] msg = buffer.Take(bytesToSend).ToArray();
        FtdiDevice.Write(msg).ThrowIfNotOK();

        // get the byte which has been read from the driver's receive buffer
        byte[] readBuffer = new byte[1];
        uint bytesRead = 0;
        FtdiDevice.Read(readBuffer, 1, ref bytesRead).ThrowIfNotOK();

        return readBuffer[0];
    }

    #endregion

    #region PUBLIC

    public byte[] Scan()
    {
        List<byte> devices = new();

        for (byte address = 0; address < 127; address++)
        {
            FTDI_Start();
            bool ack = FTDI_CommandRead(address);
            FTDI_Stop();

            if (ack)
                devices.Add(address);
        }

        return devices.ToArray();
    }

    public byte Read(byte address) => Read(address, 1)[0];

    public byte[] Read(byte address, int length)
    {
        FTDI_Start();

        FTDI_CommandRead(address);

        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = FTDI_ReadByte(ACK: true);
        }

        FTDI_Stop();

        return bytes;
    }

    public void Write(byte address, byte byte1) => Write(address, new byte[] { byte1 });

    public void Write(byte deviceAddress, byte[] bytes)
    {
        bool[] ack = new bool[bytes.Length + 1];

        FTDI_Start();
        ack[0] = FTDI_CommandWrite(deviceAddress);
        for (int i = 0; i < bytes.Length; i++)
        {
            ack[i + 1] = FTDI_SendByte(bytes[i]);
        }
        FTDI_Stop();

        if (ack.Where(x => x == false).Any())
        {
            Debug.WriteLine("WARNING: not all writes were ACK'd");
            Debug.WriteLine(string.Join(",", ack.Select(x => x.ToString())));
        }
    }

    public byte WriteThenRead(byte deviceAddress, byte memoryAddress) => WriteThenRead(deviceAddress, memoryAddress, 1)[0];

    public byte[] WriteThenRead(byte deviceAddress, byte memoryAddress, int byteCount)
    {
        bool[] ack = new bool[3];
        byte[] bytes = new byte[byteCount];

        FTDI_Start();
        ack[0] = FTDI_CommandWrite(deviceAddress);

        // TODO: ensure ack?
        ack[1] = FTDI_SendByte(memoryAddress);

        FTDI_Start();
        ack[2] = FTDI_CommandRead(deviceAddress);
        for (int i = 0; i < byteCount; i++)
        {
            bool isLastByte = i == byteCount - 1;
            bytes[i] = FTDI_ReadByte(ACK: !isLastByte);
        }
        FTDI_Stop();

        if (ack.Where(x => x == false).Any())
        {
            Debug.WriteLine("WARNING: not all reads were ACK'd");
            Debug.WriteLine(string.Join(",", ack.Select(x => x.ToString())));
        }

        return bytes;
    }

    #endregion
}
