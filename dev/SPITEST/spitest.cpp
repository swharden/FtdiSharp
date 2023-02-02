/* A reformatted version of the source code shown in the FTDI FT232H Application Note AN_180
 * http://www.ftdichip.com/Support/Documents/AppNotes/AN_114_FTDI_Hi_Speed_USB_To_SPI_Example.pdf
 * Presumably this demonstrates how to use the SPI bus by interacting with FT232 series chips over USB
 * The software originally had a permissive license file, but it is no longer available.
 * Because of this, copyright holder and redistribution rights remain unclear.
 */

// SPITEST.cpp : VC++ console application.
// this example project use port A of FT2232H to access SPI EEPROM 93C56
// we send 16 word data to 93C56 and read them back, user can see the test
// result in command mode.
#include "stdafx.h"
#include <windows.h>
#include "FTD2XX.h"
#include <stdlib.h>

// declare parameters for 93C56
#define MemSize 16             // define data quantity you want to send out
const BYTE SPIDATALENGTH = 11; // 3 digit command + 8 digit address
const BYTE READ = '\xC0';      // 110xxxxx
const BYTE WRITE = '\xA0';     // 101xxxxx
const BYTE WREN = '\x98';      // 10011xxx
const BYTE ERAL = '\x90';      // 10010xxx

// declare for BAD command
const BYTE AA_ECHO_CMD_1 = '\xAA';
const BYTE AB_ECHO_CMD_2 = '\xAB';
const BYTE BAD_COMMAND_RESPONSE = '\xFA';

// declare for MPSSE command
const BYTE MSB_RISING_EDGE_CLOCK_BYTE_OUT = '\x10';
const BYTE MSB_FALLING_EDGE_CLOCK_BYTE_OUT = '\x11';
const BYTE MSB_RISING_EDGE_CLOCK_BIT_OUT = '\x12';
const BYTE MSB_FALLING_EDGE_CLOCK_BIT_OUT = '\x13';
const BYTE MSB_RISING_EDGE_CLOCK_BYTE_IN = '\x20';
const BYTE MSB_RISING_EDGE_CLOCK_BIT_IN = '\x22';
const BYTE MSB_FALLING_EDGE_CLOCK_BYTE_IN = '\x24';
const BYTE MSB_FALLING_EDGE_CLOCK_BIT_IN = '\x26';

FT_STATUS ftStatus;     // Status defined in D2XX to indicate operation result
BYTE OutputBuffer[512]; // Buffer to hold MPSSE commands and data to be sent to FT2232H
BYTE InputBuffer[512];  // Buffer to hold Data bytes to be read from
FT2232H
DWORD dwClockDivisor = 29;  // Value of clock divisor, SCL Frequency = 60 / ((1 + 29) * 2)(MHz) = 1Mhz
DWORD dwNumBytesToSend = 0; // Index of output buffer
DWORD dwNumBytesSent = 0, dwNumBytesRead = 0, dwNumInputBuffer = 0;
BYTE ByteDataRead;
WORD MemAddress = 0x00;
WORD i = 0;
WORD DataOutBuffer[MemSize];
WORD DataInBuffer[MemSize];

// this routine is used to enable SPI device
void SPI_CSEnable()
{
    for (int loop = 0; loop < 5; loop++) // one 0x80 command can keep 0.2us, do 5 times to stay in this situation for 1us
    {
        OutputBuffer[dwNumBytesToSend++] = '\x80'; // GPIO command for ADBUS
        OutputBuffer[dwNumBytesToSend++] = '\x08'; // set CS high, MOSI and SCL low
        OutputBuffer[dwNumBytesToSend++] = '\x0b'; // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
    }
}

// this routine is used to disable SPI device
void SPI_CSDisable()
{
    for (int loop = 0; loop < 5; loop++) // one 0x80 command can keep 0.2us, do 5 times to stay in this situation for 1us
    {
        OutputBuffer[dwNumBytesToSend++] = '\x80'; // GPIO command for ADBUS
        OutputBuffer[dwNumBytesToSend++] = '\x00'; // set CS, MOSI and SCL low
        OutputBuffer[dwNumBytesToSend++] = '\x0b'; // bit3:CS, bit2:MISO, bit1:MOSI, bit0:SCK
    }
}

// this routine is used to send command to 93C56 EEPROM
FT_STATUS WriteEECmd(FT_HANDLE ftHandle, BYTE command)
{
    dwNumBytesSent = 0;

    SPI_CSEnable();

    // SPIDATALENGTH = 11, it can be divide into 8+3 bits
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = 7; // 7+1 = 8
    OutputBuffer[dwNumBytesToSend++] = command;
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = SPIDATALENGTH - (8 + 1);
    OutputBuffer[dwNumBytesToSend++] = '\xff';

    SPI_CSDisable();

    // send MPSSE command to MPSSE engine.
    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent);

    // Clear output buffer
    dwNumBytesToSend = 0;

    return ftStatus;
}

// this routine is used to initial SPI interface
BOOL SPI_Initial(FT_HANDLE ftHandle)
{
    DWORD dwCount;
    // Reset USB device
    ftStatus = FT_ResetDevice(ftHandle);

    // Purge USB receive buffer first by reading out all old data from FT2232H receive buffer
    // Get the number of bytes in the FT2232H receive buffer
    ftStatus |= FT_GetQueueStatus(ftHandle, &dwNumInputBuffer);

    // Read out the data from FT2232H receive buffer
    if ((ftStatus == FT_OK) && (dwNumInputBuffer > 0))
        ftStatus |= FT_Read(ftHandle, InputBuffer, dwNumInputBuffer, &dwNumBytesRead);

    ftStatus |= FT_SetUSBParameters(ftHandle, 65535, 65535); // Set USB request transfer size
    ftStatus |= FT_SetChars(ftHandle, false, 0, false, 0);   // Disable event and error characters
    ftStatus |= FT_SetTimeouts(ftHandle, 3000, 3000);        // Sets the read and write timeouts in 3 sec for the FT2232H
    ftStatus |= FT_SetLatencyTimer(ftHandle, 1);             // Set the latency timer
    ftStatus |= FT_SetBitMode(ftHandle, 0x0, 0x00);          // Reset controller
    ftStatus |= FT_SetBitMode(ftHandle, 0x0, 0x02);          // Enable MPSSE mode
    if (ftStatus != FT_OK)
    {
        printf("fail on initialize FT2232H device ! \n");
        return false;
    }

    // Wait 50ms for all the USB stuff to complete and work
    Sleep(50);

    //////////////////////////////////////////////////////////////////
    // Synchronize the MPSSE interface by sending bad command ＆xAA＊
    //////////////////////////////////////////////////////////////////
    dwNumBytesToSend = 0;
    OutputBuffer[dwNumBytesToSend++] = '\xAA'; // Add BAD command ＆ xAA＊

    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // Send off the BAD commands

    // Clear output buffer
    dwNumBytesToSend = 0;
    do
    {
        ftStatus = FT_GetQueueStatus(ftHandle, &dwNumInputBuffer); // Get the number of bytes in the device input buffer
    } while ((dwNumInputBuffer == 0) && (ftStatus == FT_OK));      // or Timeout

    bool bCommandEchod = false;
    ftStatus = FT_Read(ftHandle, InputBuffer, dwNumInputBuffer, &dwNumBytesRead); // Read out the data from input buffer

    // Check if Bad command and echo command received
    for (dwCount = 0; dwCount < (dwNumBytesRead - 1); dwCount++)
    {
        if ((InputBuffer[dwCount] == BYTE('\xFA')) && (InputBuffer[dwCount + 1] == BYTE('\xAA')))
        {
            bCommandEchod = true;
            break;
        }
    }

    if (bCommandEchod == false)
    {
        // Error, can't receive echo command, fail to synchronize MPSSE interface
        printf("fail to synchronize MPSSE with command '0xAA' \n");
        return false;
    }

    //////////////////////////////////////////////////////////////////
    // Synchronize the MPSSE interface by sending bad command ＆xAB＊
    //////////////////////////////////////////////////////////////////
    // dwNumBytesToSend = 0; //Clear output buffer
    OutputBuffer[dwNumBytesToSend++] = '\xAB';                                      // Send BAD command ＆xAB＊
    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // Send off the BAD commands
    dwNumBytesToSend = 0;                                                           // Clear output buffer
    do
    {
        ftStatus = FT_GetQueueStatus(ftHandle, &dwNumInputBuffer); // Get the number of bytes in the device input buffer
    } while ((dwNumInputBuffer == 0) && (ftStatus == FT_OK));      // or Timeout

    bCommandEchod = false;

    ftStatus = FT_Read(ftHandle, InputBuffer, dwNumInputBuffer, &dwNumBytesRead); // Read out the data from input buffer

    for (dwCount = 0; dwCount < (dwNumBytesRead - 1); dwCount++) // Check if Bad command and echo command received
    {
        if ((InputBuffer[dwCount] == BYTE('\xFA')) && (InputBuffer[dwCount + 1] == BYTE('\xAB')))
        {
            bCommandEchod = true;
            break;
        }
    }

    if (bCommandEchod == false)
    {
        // Error, can't receive echo command , fail to synchronize MPSSE interface
        printf("fail to synchronize MPSSE with command '0xAB' \n");
        return false;
    }

    ////////////////////////////////////////////////////////////////////
    // Configure the MPSSE for SPI communication with EEPROM
    ////////////////////////////////////////////////////////////////////

    // NOTE: The SK clock frequency can be worked out by below algorithm with divide by 5 set as off
    // SK frequency = 60MHz /((1 + [(1 +0xValueH*256) OR 0xValueL])*2)

    OutputBuffer[dwNumBytesToSend++] = '\x8A';                                      // Ensure disable clock divide by 5 for 60Mhz master clock
    OutputBuffer[dwNumBytesToSend++] = '\x97';                                      // Ensure turn off adaptive clocking
    OutputBuffer[dwNumBytesToSend++] = '\x8D';                                      // disable 3 phase data clock
    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // Send out the commands
    dwNumBytesToSend = 0;                                                           // Clear output buffer

    OutputBuffer[dwNumBytesToSend++] = '\x80';                                      // Command to set directions of lower 8 pins and force value on bits set as output
    OutputBuffer[dwNumBytesToSend++] = '\x00';                                      // Set SDA, SCL high, WP disabled by SK, DO at bit ＆＊, GPIOL0 at bit ＆＊
    OutputBuffer[dwNumBytesToSend++] = '\x0b';                                      // Set SK, DO, GPIOL0 pins as output with bit ＊, other pins as input with bit
    OutputBuffer[dwNumBytesToSend++] = '\x86';                                      // Command to set clock divisor
    OutputBuffer[dwNumBytesToSend++] = BYTE(dwClockDivisor & '\xFF');               // Set 0xValueL of clock divisor
    OutputBuffer[dwNumBytesToSend++] = BYTE(dwClockDivisor >> 8);                   // Set 0xValueH of clock divisor
    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // Send out the commands
    dwNumBytesToSend = 0;                                                           // Clear output buffer
    Sleep(20);                                                                      // Delay for a while

    // Turn off loop back in case
    OutputBuffer[dwNumBytesToSend++] = '\x85';                                      // Command to turn off loop back of TDI / TDO connection
    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // Send out the commands
    dwNumBytesToSend = 0;                                                           // Clear output buffer
    Sleep(30);                                                                      // Delay for a while

    printf("SPI initial successful\n");
    return true;
}

// this routine is used to write one word data to a random address
BOOL SPI_WriteByte2RandomAddr(FT_HANDLE ftHandle, WORD address, WORD bdata)
{
    dwNumBytesSent = 0;
    SPI_CSEnable();

    // send WRITE command
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = 2;
    OutputBuffer[dwNumBytesToSend++] = WRITE;

    // send address
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = 7;
    OutputBuffer[dwNumBytesToSend++] = (BYTE)(address);

    // send data
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_OUT;
    OutputBuffer[dwNumBytesToSend++] = 1;
    OutputBuffer[dwNumBytesToSend++] = 0;            // Data length of 0x0001 means 2 byte data to clock out
    OutputBuffer[dwNumBytesToSend++] = bdata >> 8;   // output high byte
    OutputBuffer[dwNumBytesToSend++] = bdata & 0xff; // output low byte

    SPI_CSDisable();

    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // send out MPSSE command to MPSSE engine
    dwNumBytesToSend = 0;                                                           // Clear output buffer
    return ftStatus;
}

// this routine is used to read one word data from a random address
BOOL SPI_ReadByteRandomAddr(FT_HANDLE ftHandle, WORD address, WORD *bdata)
{
    dwNumBytesSent = 0;
    SPI_CSEnable();

    // send WRITE command
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = 2;
    OutputBuffer[dwNumBytesToSend++] = READ;

    // send address
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BIT_OUT;
    OutputBuffer[dwNumBytesToSend++] = 7;
    OutputBuffer[dwNumBytesToSend++] = (BYTE)(address);

    // read data
    OutputBuffer[dwNumBytesToSend++] = MSB_FALLING_EDGE_CLOCK_BYTE_IN;
    OutputBuffer[dwNumBytesToSend++] = '\x01';
    OutputBuffer[dwNumBytesToSend++] = '\x00'; // Data length of 0x0001 means 2 byte data to clock in

    SPI_CSDisable();

    ftStatus = FT_Write(ftHandle, OutputBuffer, dwNumBytesToSend, &dwNumBytesSent); // send out MPSSE command to MPSSE engine
    dwNumBytesToSend = 0;                                                           // Clear output buffer
    ftStatus = FT_Read(ftHandle, InputBuffer, 2, &dwNumBytesRead);                  // Read 2 bytes from device receive buffer
    *bdata = (InputBuffer[0] << 8) + InputBuffer[1];

    return ftStatus;
}

int _tmain(int argc, _TCHAR *argv[])
{
    FT_HANDLE ftdiHandle;
    DWORD numDevs;
    FT_DEVICE_LIST_INFO_NODE *devInfo;
    ftStatus = FT_CreateDeviceInfoList(&numDevs);
    if (ftStatus == FT_OK)
        printf("Number of devices is %d\n", numDevs);
    else
        return 1;
    if (numDevs > 0)
    {
        // allocate storage for list based on numDevs
        devInfo = (FT_DEVICE_LIST_INFO_NODE *)malloc(sizeof(FT_DEVICE_LIST_INFO_NODE) * numDevs);

        // get the device information list
        ftStatus = FT_GetDeviceInfoList(devInfo, &numDevs);
        if (ftStatus == FT_OK)
        {
            for (i = 0; i < numDevs; i++)
            {
                printf("Dev %d:\n", i);
                printf(" Flags=0x%x\n", devInfo[i].Flags);
                printf(" Type=0x%x\n", devInfo[i].Type);
                printf(" ID=0x%x\n", devInfo[i].ID);
                printf(" LocId=0x%x\n", devInfo[i].LocId);
                printf(" SerialNumber=%s\n", devInfo[i].SerialNumber);
                printf(" Description=%s\n", devInfo[i].Description);
                printf(" ftHandle=0x%x\n", devInfo[i].ftHandle);
            }
        }
    }
    else
        return 1;
    ftStatus = FT_Open(0, &ftdiHandle);
    if (ftStatus != FT_OK)
    {
        printf("Can't open FT2232H device! \n");
        return 1;
    }
    else // Port opened successfully
        printf("Successfully open FT2232H device! \n");

    if (SPI_Initial(ftdiHandle) == TRUE)
    {
        byte ReadByte = 0;

        // initial output buffer
        for (i = 0; i < MemSize; i++)
            DataOutBuffer[i] = i;

        // Purge USB received buffer first before read operation
        ftStatus = FT_GetQueueStatus(ftdiHandle, &dwNumInputBuffer); // Get the number of bytes in the device receive buffer
        if ((ftStatus == FT_OK) && (dwNumInputBuffer > 0))
            FT_Read(ftdiHandle, InputBuffer, dwNumInputBuffer, &dwNumBytesRead); // Read out all the data from receive buffer

        WriteEECmd(ftdiHandle, WREN);
        WriteEECmd(ftdiHandle, ERAL);

        Sleep(20);

        for (i = 0; i < MemSize; i++)
        {
            SPI_WriteByte2RandomAddr(ftdiHandle, i, DataOutBuffer[i]);
            Sleep(2);
            printf("Write data %d to address %d\n", DataOutBuffer[i], i);
        }

        Sleep(20);

        for (i = 0; i < MemSize; i++)
        {
            SPI_ReadByteRandomAddr(ftdiHandle, i, &DataInBuffer[i]);
            printf("Read data from address %d = %d\n", i, DataInBuffer[i]);
        }

        getchar(); // wait here until we get a key press.
    }

    FT_Close(ftdiHandle);

    return 0;
}