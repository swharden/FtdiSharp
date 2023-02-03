Module D2XX_Unit_NET
    '===========================================================================================================================
    ' This module was written to be compatible with version 2.1.3.1 of FTDI FTD2XX.DLL
    ' Created January 2005
    ' FTDI
    ' www.ftdichip.com
    '===========================================================================================================================


    '===========================================================================================================================
    ' FTD2XX Return codes
    '===========================================================================================================================
    Public Const FT_OK = 0
    Public Const FT_INVALID_HANDLE = 1
    Public Const FT_DEVICE_NOT_FOUND = 2
    Public Const FT_DEVICE_NOT_OPENED = 3
    Public Const FT_IO_ERROR = 4
    Public Const FT_INSUFFICIENT_RESOURCES = 5
    Public Const FT_INVALID_PARAMETER = 6
    Public Const FT_INVALID_BAUD_RATE = 7
    Public Const FT_DEVICE_NOT_OPENED_FOR_ERASE = 8
    Public Const FT_DEVICE_NOT_OPENED_FOR_WRITE = 9
    Public Const FT_FAILED_TO_WRITE_DEVICE = 10
    Public Const FT_EEPROM_READ_FAILED = 11
    Public Const FT_EEPROM_WRITE_FAILED = 12
    Public Const FT_EEPROM_ERASE_FAILED = 13
    Public Const FT_EEPROM_NOT_PRESENT = 14
    Public Const FT_EEPROM_NOT_PROGRAMMED = 15
    Public Const FT_INVALID_ARGS = 16
    Public Const FT_OTHER_ERROR = 17


    '===========================================================================================================================
    ' FTD2XX Flags - These are only used in this module
    '===========================================================================================================================
    ' FT_OpenEx Flags (See FT_OpenEx)
    Public Const FT_OPEN_BY_SERIAL_NUMBER = 1
    Public Const FT_OPEN_BY_DESCRIPTION = 2

    ' FT_ListDevices Flags (See FT_ListDevices)
    Public Const FT_LIST_NUMBER_ONLY = &H80000000
    Public Const FT_LIST_BY_INDEX = &H40000000
    Public Const FT_LIST_ALL = &H20000000


    '===========================================================================================================================
    ' FTD2XX Buffer Constants - These are only used in this module
    '===========================================================================================================================
    Const FT_In_Buffer_Size = &H100000                  ' 1024K
    Const FT_In_Buffer_Index = FT_In_Buffer_Size - 1
    Const FT_Out_Buffer_Size = &H10000                  ' 64K
    Const FT_Out_Buffer_Index = FT_Out_Buffer_Size - 1


    '===========================================================================================================================
    ' FTD2XX Constants
    '===========================================================================================================================
    ' FT Standard Baud Rates (See FT_SetBaudrate)
    Public Const FT_BAUD_300 = 300
    Public Const FT_BAUD_600 = 600
    Public Const FT_BAUD_1200 = 1200
    Public Const FT_BAUD_2400 = 2400
    Public Const FT_BAUD_4800 = 4800
    Public Const FT_BAUD_9600 = 9600
    Public Const FT_BAUD_14400 = 14400
    Public Const FT_BAUD_19200 = 19200
    Public Const FT_BAUD_38400 = 38400
    Public Const FT_BAUD_57600 = 57600
    Public Const FT_BAUD_115200 = 115200
    Public Const FT_BAUD_230400 = 230400
    Public Const FT_BAUD_460800 = 460800
    Public Const FT_BAUD_921600 = 921600

    ' FT Data Bits (See FT_SetDataCharacteristics)
    Public Const FT_DATA_BITS_7 = 7
    Public Const FT_DATA_BITS_8 = 8

    ' FT Stop Bits (See FT_SetDataCharacteristics)
    Public Const FT_STOP_BITS_1 = 0
    Public Const FT_STOP_BITS_2 = 2

    ' FT Parity (See FT_SetDataCharacteristics)
    Public Const FT_PARITY_NONE = 0
    Public Const FT_PARITY_ODD = 1
    Public Const FT_PARITY_EVEN = 2
    Public Const FT_PARITY_MARK = 3
    Public Const FT_PARITY_SPACE = 4

    ' FT Flow Control (See FT_SetFlowControl)
    Public Const FT_FLOW_NONE = &H0
    Public Const FT_FLOW_RTS_CTS = &H100
    Public Const FT_FLOW_DTR_DSR = &H200
    Public Const FT_FLOW_XON_XOFF = &H400

    ' Modem Status
    Public Const FT_MODEM_STATUS_CTS = &H10
    Public Const FT_MODEM_STATUS_DSR = &H20
    Public Const FT_MODEM_STATUS_RI = &H40
    Public Const FT_MODEM_STATUS_DCD = &H80

    ' FT Purge Commands (See FT_Purge)
    Public Const FT_PURGE_RX = 1
    Public Const FT_PURGE_TX = 2

    ' FT Bit Mode (See FT_SetBitMode)
    Public Const FT_RESET_BITMODE = &H0
    Public Const FT_ASYNCHRONOUS_BIT_BANG = &H1
    Public Const FT_MPSSE = &H2
    Public Const FT_SYNCHRONOUS_BIT_BANG = &H4
    Public Const FT_MCU_HOST = &H8
    Public Const FT_OPTO_ISOLATE = &H10

    ' FT Notification Event Masks (See FT_SetEventNotification)
    Public Const FT_EVENT_RXCHAR = 1
    Public Const FT_EVENT_MODEM_STATUS = 2
    Public Const WAIT_ABANDONED As Integer = &H80
    'Public Const WAIT_FAILED As Integer = &HFFFFFFFF
    Public Const WAIT_OBJECT_0 As Integer = &H0
    Public Const WAIT_TIMEOUT As Integer = &H102

    Public Const INFINITE As Integer = &HFFFFFFFF


    '===========================================================================================================================
    'Type definition for EEPROM as equivalent for C-structure "FT_PROGRAM_DATA"
    '===========================================================================================================================

    'Define string as Integer and use FT_EE_ReadEx and FT_EE_ProgramEx functions


    Public Structure FT_PROGRAM_DATA
        Dim Signature1 As Integer                  ' // Header - must be 0x00000000
        Dim Signature2 As Integer                  ' // Header - must be 0xFFFFFFFF
        Dim Version As Integer                     ' // 0 = original, 1 = FT2232C extensions
        Dim VendorID As Short                 ' // 0x0403
        Dim ProductID As Short                ' // 0x6001
        Dim Manufacturer As Integer                ' // "FTDI" (32 bytes allocated)
        Dim ManufacturerID As Integer              ' // "FT" (16 bytes allocated)
        Dim Description As Integer                 ' // "USB HS Serial Converter" (64 bytes allocated)
        Dim SerialNumber As Integer                ' // "FT000001" if fixed, or NULL (16 bytes allocated)
        Dim MaxPower As Short                 ' // 0 < MaxPower <= 500
        Dim PnP As Short                      ' // 0 = disabled, 1 = enabled
        Dim SelfPowered As Short              ' // 0 = bus powered, 1 = self powered
        Dim RemoteWakeup As Short             ' // 0 = not capable, 1 = capable
        ' Rev4 extensions:
        Dim Rev4 As Byte                        ' // true if Rev4 chip, false otherwise
        Dim IsoIn As Byte                       ' // true if in endpoint is isochronous
        Dim IsoOut As Byte                      ' // true if out endpoint is isochronous
        Dim PullDownEnable As Byte              ' // true if pull down enabled
        Dim SerNumEnable As Byte                ' // true if serial number to be used
        Dim USBVersionEnable As Byte            ' // true if chip uses USBVersion
        Dim USBVersion As Short               ' // BCD (0x0200 => USB2)
        ' FT2232C extensions:
        Dim Rev5 As Byte                        ' // non-zero if Rev5 chip, zero otherwise
        Dim IsoInA As Byte                      ' // non-zero if in endpoint is isochronous
        Dim IsoInB As Byte                      ' // non-zero if in endpoint is isochronous
        Dim IsoOutA As Byte                     ' // non-zero if out endpoint is isochronous
        Dim IsoOutB As Byte                     ' // non-zero if out endpoint is isochronous
        Dim PullDownEnable5 As Byte             ' // non-zero if pull down enabled
        Dim SerNumEnable5 As Byte               ' // non-zero if serial number to be used
        Dim USBVersionEnable5 As Byte           ' // non-zero if chip uses USBVersion
        Dim USBVersion5 As Short              ' // BCD (0x0200 => USB2)
        Dim AIsHighCurrent As Byte              ' // non-zero if interface is high current
        Dim BIsHighCurrent As Byte              ' // non-zero if interface is high current
        Dim IFAIsFifo As Byte                   ' // non-zero if interface is 245 FIFO
        Dim IFAIsFifoTar As Byte                ' // non-zero if interface is 245 FIFO CPU target
        Dim IFAIsFastSer As Byte                ' // non-zero if interface is Fast serial
        Dim AIsVCP As Byte                      ' // non-zero if interface is to use VCP drivers
        Dim IFBIsFifo As Byte                   ' // non-zero if interface is 245 FIFO
        Dim IFBIsFifoTar As Byte                ' // non-zero if interface is 245 FIFO CPU target
        Dim IFBIsFastSer As Byte                ' // non-zero if interface is Fast serial
        Dim BIsVCP As Byte                      ' // non-zero if interface is to use VCP drivers
    End Structure




    '===========================================================================================================================
    ' Public declarations of variables for external modules to access from FTD2XX.dll
    '===========================================================================================================================
    Public FT_Status As Integer
    Public FT_Device_Count As Integer
    Public FT_Serial_Number As String
    Public FT_Description As String
    Public FT_Handle As Integer
    Public FT_Type As String
    Public FT_VID_PID As String
    Public FT_Current_Baud As Integer
    Public FT_Current_DataBits As Byte
    Public FT_Current_StopBits As Byte
    Public FT_Current_Parity As Byte
    Public FT_Current_FlowControl As Integer
    Public FT_Current_XOn_Char As Byte
    Public FT_Current_XOff_Char As Byte
    Public FT_ModemStatus As Integer
    Public FT_RxQ_Bytes As Integer
    Public FT_TxQ_Bytes As Integer
    Public FT_EventStatus As Integer
    Public FT_Event_On As Boolean
    Public FT_Error_On As Boolean
    Public FT_Event_Value As Byte
    Public FT_Error_Value As Byte
    Public FT_In_Buffer(FT_In_Buffer_Index) As Byte
    Public FT_Out_Buffer(FT_Out_Buffer_Index) As Byte
    Public FT_Latency As Byte
    Public FT_EEPROM_DataBuffer As FT_PROGRAM_DATA
    Public FT_EEPROM_Manufacturer As String
    Public FT_EEPROM_ManufacturerID As String
    Public FT_EEPROM_Description As String
    Public FT_EEPROM_SerialNumber As String
    Public FT_UA_Size As Integer
    Public FT_UA_Data() As Byte     'NOTE: when using Read_EEPROM_UA and Write_EEPROM_UA get size of user area first,
    '      then use the command ReDim FT_UA_Data(0 to FT_UA_Size-1) As Byte


    '===========================================================================================================================
    ' Declarations for device information functions in FTD2XX.dll:
    '===========================================================================================================================
    Public Declare Function FT_GetNumberOfDevices Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_ListDevices" (ByRef lngNumberOfDevices As Integer, ByVal pvArg2 As String, ByVal lngFlags As Integer) As Integer
    Public Declare Function FT_GetDeviceString Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_ListDevices" (ByVal lngDeviceIndex As Integer, ByVal lpszDeviceString As String, ByVal lngFlags As Integer) As Integer
    Public Declare Function FT_GetDeviceInfo Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngFT_Type As Integer, ByRef lngID As Integer, ByVal pucSerialNumber As String, ByVal pucDescription As String, ByRef pvDummy As Byte) As Integer



    '===========================================================================================================================
    ' Declarations for functions in FTD2XX.dll:
    '===========================================================================================================================
    Public Declare Function FT_OpenByIndex Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_Open" (ByVal intDeviceNumber As Integer, ByRef lngHandle As Integer) As Integer
    Public Declare Function FT_OpenBySerialNumber Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_OpenEx" (ByVal SerialNumber As String, ByVal lngFlags As Integer, ByRef lngHandle As Integer) As Integer
    Public Declare Function FT_OpenByDescription Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_OpenEx" (ByVal Description As String, ByVal lngFlags As Integer, ByRef lngHandle As Integer) As Integer
    Public Declare Function FT_Close Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_Read_String Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_Read" (ByVal lngHandle As Integer, ByVal lpvBuffer As String, ByVal lngBufferSize As Integer, ByRef lngBytesReturned As Integer) As Integer
    Public Declare Function FT_Write_String Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_Write" (ByVal lngHandle As Integer, ByVal lpvBuffer As String, ByVal lngBufferSize As Integer, ByRef lngBytesWritten As Integer) As Integer
    Public Declare Function FT_Read_Bytes Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_Read" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesReturned As Integer) As Integer
    Public Declare Function FT_Write_Bytes Lib "C:\WINDOWS\System32\FTD2XX.DLL" Alias "FT_Write" (ByVal lngHandle As Integer, ByRef lpvBuffer As Byte, ByVal lngBufferSize As Integer, ByRef lngBytesWritten As Integer) As Integer
    Public Declare Function FT_SetBaudRate Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngBaudRate As Integer) As Integer
    Public Declare Function FT_SetDivisor Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal intDivisor As Integer) As Integer
    Public Declare Function FT_SetDataCharacteristics Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal byWordLength As Byte, ByVal byStopBits As Byte, ByVal byParity As Byte) As Integer
    Public Declare Function FT_SetFlowControl Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal intFlowControl As Integer, ByVal byXonChar As Byte, ByVal byXoffChar As Byte) As Integer
    Public Declare Function FT_ResetDevice Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_SetDtr Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_ClrDtr Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_SetRts Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_ClrRts Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_GetModemStatus Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngModemStatus As Integer) As Integer
    Public Declare Function FT_SetChars Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal byEventChar As Byte, ByVal byEventCharEnabled As Byte, ByVal byErrorChar As Byte, ByVal byErrorCharEnabled As Byte) As Integer
    Public Declare Function FT_Purge Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngMask As Integer) As Integer
    Public Declare Function FT_SetTimeouts Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngReadTimeout As Integer, ByVal lngWriteTimeout As Integer) As Integer
    Public Declare Function FT_GetQueueStatus Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngRxBytes As Integer) As Integer
    Public Declare Function FT_GetLatencyTimer Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef ucTimer As Byte) As Integer
    Public Declare Function FT_SetLatencyTimer Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal ucTimer As Byte) As Integer
    Public Declare Function FT_GetBitMode Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef ucMode As Byte) As Integer
    Public Declare Function FT_SetBitMode Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal ucMask As Byte, ByVal ucEnable As Byte) As Integer
    Public Declare Function FT_SetUSBParameters Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngInTransferSize As Integer, ByVal lngOutTransferSize As Integer) As Integer
    Public Declare Function FT_SetBreakOn Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_SetBreakOff Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_GetStatus Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lngamountInRxQueue As Integer, ByRef lngAmountInTxQueue As Integer, ByRef lngEventStatus As Integer) As Integer

    Public Declare Function FT_SetEventNotification Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByVal lngEventMask As Integer, ByVal lngEvent As Integer) As Integer
    ' event notification needs kernel32.dll functions to create events and threads
    ' Find kernel32 functions at http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dllproc/base/dynamic_link_library_functions.asp
    Public Declare Function Sleep Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lngMilliseconds As Integer) As Integer
    '   Public Declare Function CreateEvent Lib "C:\WINDOWS\System32\kernel32.dll" Alias "CreateEventA" (ByVal lngEventAttributes As Integer, ByVal ucManualReset As Byte, ByVal ucInitialState As Byte, ByVal lpName As String) As Integer
    '   Public Declare Function WaitForSingleObject Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lngEventHandle As Integer, ByVal lngMilliseconds As Integer) As Integer
    '   Public Declare Function SetEvent Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lngEventHandle As Integer) As Integer
    '   Public Declare Function CreateThread Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lpThreadAttributes As Any, ByVal lngStackSize As Integer, ByVal lngStartAddress As Integer, ByVal lpParameter As Any, ByVal lngCreationFlags As Integer, ByVal lngThreadID As Integer) As Integer
    '   Public Declare Function TerminateThread Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lngThreadHandle As Integer, ByVal lngExitCode As Integer) As Integer
    '   Public Declare Function CloseHandle Lib "C:\WINDOWS\System32\kernel32.dll" (ByVal lngHandle As Integer) As Integer


    ' For returning strings from DLL calls using VB, see
    ' http://msdn.microsoft.com/library/default.asp?url=/library/en-us/modcore/html/deovrreturningstringsfromdllfunctions.asp

    '===========================================================================================================================
    'Declarations for the EEPROM-accessing functions in FTD2XX.dll:
    '===========================================================================================================================
    Public Declare Function FT_EraseEE Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer) As Integer
    Public Declare Function FT_EE_ReadEx Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lpData As FT_PROGRAM_DATA, ByVal pucManufacturer As String, ByVal pucManufacturerID As String, ByVal pucDescription As String, ByVal pucSerialNumber As String) As Integer
    Public Declare Function FT_EE_ProgramEx Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lpData As FT_PROGRAM_DATA, ByVal pucManufacturer As String, ByVal pucManufacturerID As String, ByVal pucDescription As String, ByVal pucSerialNumber As String) As Integer
    Public Declare Function FT_EE_UASize Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef lpdwSize As Integer) As Integer
    Public Declare Function FT_EE_UARead Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef pucData As Byte, ByVal dwDataLen As Integer, ByRef lpdwBytesRead As Integer) As Integer
    Public Declare Function FT_EE_UAWrite Lib "C:\WINDOWS\System32\FTD2XX.DLL" (ByVal lngHandle As Integer, ByRef pucData As Byte, ByVal dwDataLen As Integer) As Integer





    '===========================================================================================================================
    '
    ' Example functions using FTD2XX.DLL function calls
    '
    '===========================================================================================================================

    Function GetFTDeviceCount() As Integer

        FT_Status = FT_GetNumberOfDevices(FT_Device_Count, vbNullChar, FT_LIST_NUMBER_ONLY)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function GetFTDeviceSerialNumber(ByVal DeviceIndex As Integer) As Integer
        Dim Flag As Integer
        Dim TempDevString As String

        TempDevString = Space(16)

        FT_Status = FT_GetDeviceString(DeviceIndex, TempDevString, FT_LIST_BY_INDEX Or FT_OPEN_BY_SERIAL_NUMBER)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

        FT_Serial_Number = Left(TempDevString, InStr(1, TempDevString, vbNullChar) - 1)

    End Function


    Function GetFTDeviceDescription(ByVal DeviceIndex As Integer) As Integer
        Dim TempDevString As String

        TempDevString = Space(64)

        FT_Status = FT_GetDeviceString(DeviceIndex, TempDevString, FT_LIST_BY_INDEX Or FT_OPEN_BY_DESCRIPTION)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

        FT_Description = Left(TempDevString, InStr(1, TempDevString, vbNullChar) - 1)

    End Function


    Function Open_USB_Device_By_Index(ByVal DeviceIndex As Integer) As Integer

        FT_Status = FT_OpenByIndex(DeviceIndex, FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If


    End Function


    Function Open_USB_Device_By_Serial_Number(ByVal SerialNumber As String) As Integer

        FT_Status = FT_OpenByDescription(SerialNumber, 1, FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Open_USB_Device_By_Description(ByVal Description As String) As Integer

        FT_Status = FT_OpenByDescription(Description, 2, FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Close_USB_Device() As Integer

        FT_Status = FT_Close(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Info() As Integer
        Dim ID As Integer
        Dim pvDummy As Byte
        Dim VidPid As String
        Dim TempSerialNumber As String
        Dim TempDescription As String
        Dim lngFT_Type As Integer

        TempSerialNumber = Space(16)
        TempDescription = Space(64)

        FT_Status = FT_GetDeviceInfo(FT_Handle, lngFT_Type, ID, TempSerialNumber, TempDescription, 0)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

        FT_Serial_Number = Left(TempSerialNumber, InStr(1, TempSerialNumber, vbNullChar) - 1)
        FT_Description = Left(TempDescription, InStr(1, TempDescription, vbNullChar) - 1)

        If lngFT_Type = "0" Then
            FT_Type = "FT232/245BM"
        ElseIf lngFT_Type = "1" Then
            FT_Type = "FT232/245AM"
        ElseIf lngFT_Type = "2" Then
            FT_Type = "FT8U100AX"
        ElseIf lngFT_Type = "3" Then
            FT_Type = "Unknown"
        ElseIf lngFT_Type = "4" Then
            FT_Type = "FT2232C"
        End If

        VidPid = Hex(ID)
        While Len(VidPid) < 8
            VidPid = "0" + VidPid
        End While
        FT_VID_PID = VidPid

    End Function


    Function Reset_USB_Device() As Integer

        FT_Status = FT_ResetDevice(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function



    Function Purge_USB_Device_Out() As Integer

        FT_Status = FT_Purge(FT_Handle, FT_PURGE_RX)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Purge_USB_Device_In() As Integer

        FT_Status = FT_Purge(FT_Handle, FT_PURGE_TX)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Data_Characteristics() As Integer

        FT_Status = FT_SetDataCharacteristics(FT_Handle, FT_Current_DataBits, FT_Current_StopBits, FT_Current_Parity)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Baud_Rate() As Integer

        FT_Status = FT_SetBaudRate(FT_Handle, FT_Current_Baud)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Baud_Rate_Divisor(ByVal intDivisor As Integer) As Integer

        FT_Status = FT_SetDivisor(FT_Handle, intDivisor)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function



    Function Set_USB_Device_Flow_Control() As Integer

        FT_Status = FT_SetFlowControl(FT_Handle, FT_Current_FlowControl, FT_Current_XOn_Char, FT_Current_XOff_Char)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Modem_Status() As Integer

        FT_Status = FT_GetModemStatus(FT_Handle, FT_ModemStatus)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Queue_Status() As Integer

        FT_Status = FT_GetQueueStatus(FT_Handle, FT_RxQ_Bytes)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Characters() As Integer
        Dim Events_On As Byte
        Dim Errors_On As Byte

        If FT_Event_On Then Events_On = 1 Else Events_On = 0
        If FT_Error_On Then Errors_On = 1 Else Errors_On = 0
        FT_Status = FT_SetChars(FT_Handle, FT_Event_Value, Events_On, FT_Error_Value, Errors_On)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Timeouts(ByVal ReadTimeOut As Integer, ByVal WriteTimeout As Integer) As Integer

        FT_Status = FT_SetTimeouts(FT_Handle, ReadTimeOut, WriteTimeout)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_RTS() As Integer

        FT_Status = FT_SetRts(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Clear_USB_Device_RTS() As Integer

        FT_Status = FT_ClrRts(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_DTR() As Integer

        FT_Status = FT_SetDtr(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Clear_USB_Device_DTR() As Integer

        FT_Status = FT_ClrDtr(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Write_Data_String(ByVal StringData As String) As Integer
        Dim Write_Result As Integer
        Dim StringDataLength As Integer

        StringDataLength = Len(StringData)
        FT_Status = FT_Write_String(FT_Handle, StringData, StringDataLength, Write_Result)
        If FT_Status <> FT_OK Then
            Exit Function
        End If
    End Function


    Function Write_Data_Bytes(ByVal Write_Count As Integer) As Integer
        ' Writes Write_Count Bytes from FT_Out_Buffer to the USB device
        ' Function returns the number of bytes actually sent
        Dim Write_Result As Integer

        FT_Status = FT_Write_Bytes(FT_Handle, FT_Out_Buffer(0), Write_Count, Write_Result)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Read_Data_String(ByVal StringData As String) As Integer
        Dim Read_Result As Integer
        Dim TempStringData As String

        TempStringData = Space(FT_RxQ_Bytes + 1)

        FT_Status = FT_Read_String(FT_Handle, TempStringData, FT_RxQ_Bytes, Read_Result)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

        StringData = Trim(TempStringData)

    End Function

    Function Read_Data_Bytes(ByVal Read_Count As Integer) As Integer
        ' Reads Read_Count Bytes (or less) from the USB device to the FT_In_Buffer
        ' Function returns the number of bytes actually received  which may range from zero
        ' to the actual number of bytes requested, depending on how many have been received
        ' at the time of the request + the read timeout value.Dim Read_Result As Integer
        Dim Read_Result As Integer

        FT_Status = FT_Read_Bytes(FT_Handle, FT_In_Buffer(0), Read_Count, Read_Result)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Latency_Timer() As Integer

        FT_Status = FT_GetLatencyTimer(FT_Handle, FT_Latency)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Latency_Timer() As Integer

        FT_Status = FT_SetLatencyTimer(FT_Handle, FT_Latency)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Bit_Mode(ByVal Mask As Byte) As Integer

        FT_Status = FT_GetBitMode(FT_Handle, Mask)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Bit_Mode(ByVal Mask As Byte, ByVal Enable As Byte) As Integer

        FT_Status = FT_SetBitMode(FT_Handle, Mask, Enable)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Parameters(ByVal InTransferSize As Integer, ByVal OutTransferSize As Integer) As Integer

        FT_Status = FT_SetUSBParameters(FT_Handle, InTransferSize, OutTransferSize)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Break_On() As Integer

        FT_Status = FT_SetBreakOn(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Break_Off() As Integer

        FT_Status = FT_SetBreakOff(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_USB_Device_Status() As Integer

        FT_Status = FT_GetStatus(FT_Handle, FT_RxQ_Bytes, FT_TxQ_Bytes, FT_EventStatus)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Set_USB_Device_Event_Notification(ByVal EventMask As Integer, ByVal EventHandle As Integer) As Integer

        FT_Status = FT_SetEventNotification(FT_Handle, EventMask, EventHandle)

        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function



    Function Read_FT232_FT245_EEPROM() As Integer
        Dim TempManufacturer As String
        Dim TempManufacturerID As String
        Dim TempDescription As String
        Dim TempSerialNumber As String

        ' Create empty strings
        TempManufacturer = Space(32)
        TempManufacturerID = Space(16)
        TempDescription = Space(64)
        TempSerialNumber = Space(16)

        ' Initialise structure
        FT_EEPROM_DataBuffer.Signature1 = &H0
        FT_EEPROM_DataBuffer.Signature2 = &HFFFFFFFF
        FT_EEPROM_DataBuffer.Version = 0
        FT_EEPROM_DataBuffer.VendorID = 0
        FT_EEPROM_DataBuffer.ProductID = 0
        FT_EEPROM_DataBuffer.Manufacturer = 0
        FT_EEPROM_DataBuffer.ManufacturerID = 0
        FT_EEPROM_DataBuffer.Description = 0
        FT_EEPROM_DataBuffer.SerialNumber = 0
        FT_EEPROM_DataBuffer.MaxPower = 0
        FT_EEPROM_DataBuffer.PnP = 0
        FT_EEPROM_DataBuffer.SelfPowered = 0
        FT_EEPROM_DataBuffer.RemoteWakeup = 0
        ' Rev4 extensions:
        FT_EEPROM_DataBuffer.Rev4 = 0
        FT_EEPROM_DataBuffer.IsoIn = 0
        FT_EEPROM_DataBuffer.IsoOut = 0
        FT_EEPROM_DataBuffer.PullDownEnable = 0
        FT_EEPROM_DataBuffer.SerNumEnable = 0
        FT_EEPROM_DataBuffer.USBVersionEnable = 0
        FT_EEPROM_DataBuffer.USBVersion = 0
        ' FT2232C extensions:
        FT_EEPROM_DataBuffer.Rev5 = 0
        FT_EEPROM_DataBuffer.IsoInA = 0
        FT_EEPROM_DataBuffer.IsoInB = 0
        FT_EEPROM_DataBuffer.IsoOutA = 0
        FT_EEPROM_DataBuffer.IsoOutB = 0
        FT_EEPROM_DataBuffer.PullDownEnable5 = 0
        FT_EEPROM_DataBuffer.SerNumEnable5 = 0
        FT_EEPROM_DataBuffer.USBVersionEnable5 = 0
        FT_EEPROM_DataBuffer.USBVersion5 = 0
        FT_EEPROM_DataBuffer.AIsHighCurrent = 0
        FT_EEPROM_DataBuffer.BIsHighCurrent = 0
        FT_EEPROM_DataBuffer.IFAIsFifo = 0
        FT_EEPROM_DataBuffer.IFAIsFifoTar = 0
        FT_EEPROM_DataBuffer.IFAIsFastSer = 0
        FT_EEPROM_DataBuffer.AIsVCP = 0
        FT_EEPROM_DataBuffer.IFBIsFifo = 0
        FT_EEPROM_DataBuffer.IFBIsFifoTar = 0
        FT_EEPROM_DataBuffer.IFBIsFastSer = 0
        FT_EEPROM_DataBuffer.BIsVCP = 0

        FT_Status = FT_EE_ReadEx(FT_Handle, FT_EEPROM_DataBuffer, TempManufacturer, TempManufacturerID, TempDescription, TempSerialNumber)
        If FT_Status <> FT_OK Then
            Exit Function
        End If


        FT_EEPROM_Manufacturer = Left(TempManufacturer, InStr(1, TempManufacturer, vbNullChar) - 1)
        FT_EEPROM_ManufacturerID = Left(TempManufacturerID, InStr(1, TempManufacturerID, vbNullChar) - 1)
        FT_EEPROM_Description = Left(TempDescription, InStr(1, TempDescription, vbNullChar) - 1)
        FT_EEPROM_SerialNumber = Left(TempSerialNumber, InStr(1, TempSerialNumber, vbNullChar) - 1)

    End Function


    Function Read_FT2232C_EEPROM() As Integer
        Dim TempManufacturer As String
        Dim TempManufacturerID As String
        Dim TempDescription As String
        Dim TempSerialNumber As String

        ' Create empty strings
        TempManufacturer = Space(32)
        TempManufacturerID = Space(16)
        TempDescription = Space(64)
        TempSerialNumber = Space(16)

        ' Initialise structure
        FT_EEPROM_DataBuffer.Signature1 = &H0
        FT_EEPROM_DataBuffer.Signature2 = &HFFFFFFFF
        FT_EEPROM_DataBuffer.Version = 1
        FT_EEPROM_DataBuffer.VendorID = 0
        FT_EEPROM_DataBuffer.ProductID = 0
        FT_EEPROM_DataBuffer.Manufacturer = 0
        FT_EEPROM_DataBuffer.ManufacturerID = 0
        FT_EEPROM_DataBuffer.Description = 0
        FT_EEPROM_DataBuffer.SerialNumber = 0
        FT_EEPROM_DataBuffer.MaxPower = 0
        FT_EEPROM_DataBuffer.PnP = 0
        FT_EEPROM_DataBuffer.SelfPowered = 0
        FT_EEPROM_DataBuffer.RemoteWakeup = 0
        ' Rev4 extensions:
        FT_EEPROM_DataBuffer.Rev4 = 0
        FT_EEPROM_DataBuffer.IsoIn = 0
        FT_EEPROM_DataBuffer.IsoOut = 0
        FT_EEPROM_DataBuffer.PullDownEnable = 0
        FT_EEPROM_DataBuffer.SerNumEnable = 0
        FT_EEPROM_DataBuffer.USBVersionEnable = 0
        FT_EEPROM_DataBuffer.USBVersion = 0
        ' FT2232C extensions:
        FT_EEPROM_DataBuffer.Rev5 = 0
        FT_EEPROM_DataBuffer.IsoInA = 0
        FT_EEPROM_DataBuffer.IsoInB = 0
        FT_EEPROM_DataBuffer.IsoOutA = 0
        FT_EEPROM_DataBuffer.IsoOutB = 0
        FT_EEPROM_DataBuffer.PullDownEnable5 = 0
        FT_EEPROM_DataBuffer.SerNumEnable5 = 0
        FT_EEPROM_DataBuffer.USBVersionEnable5 = 0
        FT_EEPROM_DataBuffer.USBVersion5 = 0
        FT_EEPROM_DataBuffer.AIsHighCurrent = 0
        FT_EEPROM_DataBuffer.BIsHighCurrent = 0
        FT_EEPROM_DataBuffer.IFAIsFifo = 0
        FT_EEPROM_DataBuffer.IFAIsFifoTar = 0
        FT_EEPROM_DataBuffer.IFAIsFastSer = 0
        FT_EEPROM_DataBuffer.AIsVCP = 0
        FT_EEPROM_DataBuffer.IFBIsFifo = 0
        FT_EEPROM_DataBuffer.IFBIsFifoTar = 0
        FT_EEPROM_DataBuffer.IFBIsFastSer = 0
        FT_EEPROM_DataBuffer.BIsVCP = 0

        FT_Status = FT_EE_ReadEx(FT_Handle, FT_EEPROM_DataBuffer, TempManufacturer, TempManufacturerID, TempDescription, TempSerialNumber)
        If FT_Status <> FT_OK Then
            Exit Function
        End If


        FT_EEPROM_Manufacturer = Left(TempManufacturer, InStr(1, TempManufacturer, vbNullChar) - 1)
        FT_EEPROM_ManufacturerID = Left(TempManufacturerID, InStr(1, TempManufacturerID, vbNullChar) - 1)
        FT_EEPROM_Description = Left(TempDescription, InStr(1, TempDescription, vbNullChar) - 1)
        FT_EEPROM_SerialNumber = Left(TempSerialNumber, InStr(1, TempSerialNumber, vbNullChar) - 1)

    End Function


    Function Program_FT232_FT245_EEPROM(ByVal FT_EEPROM_DataBuffer As FT_PROGRAM_DATA, ByVal FT_EEPROM_Manufacturer As String, ByVal FT_EEPROM_ManufacturerID As String, ByVal FT_EEPROM_Description As String, ByVal FT_EEPROM_SerialNumber As String) As Integer

        FT_EEPROM_DataBuffer.Signature1 = &H0
        FT_EEPROM_DataBuffer.Signature2 = &HFFFFFFFF
        FT_EEPROM_DataBuffer.Version = 0

        FT_Status = FT_EE_ProgramEx(FT_Handle, FT_EEPROM_DataBuffer, FT_EEPROM_Manufacturer, FT_EEPROM_ManufacturerID, FT_EEPROM_Description, FT_EEPROM_SerialNumber)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Program_FT2232C_EEPROM(ByVal FT_EEPROM_DataBuffer As FT_PROGRAM_DATA, ByVal FT_EEPROM_Manufacturer As String, ByVal FT_EEPROM_ManufacturerID As String, ByVal FT_EEPROM_Description As String, ByVal FT_EEPROM_SerialNumber As String) As Integer

        FT_EEPROM_DataBuffer.Signature1 = &H0
        FT_EEPROM_DataBuffer.Signature2 = &HFFFFFFFF
        FT_EEPROM_DataBuffer.Version = 1

        FT_Status = FT_EE_ProgramEx(FT_Handle, FT_EEPROM_DataBuffer, FT_EEPROM_Manufacturer, FT_EEPROM_ManufacturerID, FT_EEPROM_Description, FT_EEPROM_SerialNumber)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Erase_EEPROM() As Integer

        FT_Status = FT_EraseEE(FT_Handle)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Get_EEPROM_UA_Size() As Integer

        FT_Status = FT_EE_UASize(FT_Handle, FT_UA_Size)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Read_EEPROM_UA(ByVal UA_Read_Count As Integer) As Integer
        Dim UA_Read_Result As Integer

        FT_Status = FT_EE_UARead(FT_Handle, FT_UA_Data(0), UA_Read_Count, UA_Read_Result)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


    Function Write_EEPROM_UA(ByVal UA_Write_Count As Integer) As Integer
        Dim UA_Write_Result As Integer

        FT_Status = FT_EE_UAWrite(FT_Handle, FT_UA_Data(0), UA_Write_Count)
        If FT_Status <> FT_OK Then
            Exit Function
        End If

    End Function


End Module
