namespace FtdiSharp.FTD2XX;

// TODO: break apart across smaller files

// Internal structure for reading and writing EEPROM contents
// NOTE:  NEED Pack=1 for byte alignment!  Without this, data is garbage
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public class FT_PROGRAM_DATA
{
    public UInt32 Signature1;
    public UInt32 Signature2;
    public UInt32 Version;
    public UInt16 VendorID;
    public UInt16 ProductID;

    public IntPtr Manufacturer;
    public IntPtr ManufacturerID;
    public IntPtr Description;
    public IntPtr SerialNumber;

    public UInt16 MaxPower;
    public UInt16 PnP;
    public UInt16 SelfPowered;
    public UInt16 RemoteWakeup;
    // FT232B extensions
    public byte Rev4;
    public byte IsoIn;
    public byte IsoOut;
    public byte PullDownEnable;
    public byte SerNumEnable;
    public byte USBVersionEnable;
    public UInt16 USBVersion;
    // FT2232D extensions
    public byte Rev5;
    public byte IsoInA;
    public byte IsoInB;
    public byte IsoOutA;
    public byte IsoOutB;
    public byte PullDownEnable5;
    public byte SerNumEnable5;
    public byte USBVersionEnable5;
    public UInt16 USBVersion5;
    public byte AIsHighCurrent;
    public byte BIsHighCurrent;
    public byte IFAIsFifo;
    public byte IFAIsFifoTar;
    public byte IFAIsFastSer;
    public byte AIsVCP;
    public byte IFBIsFifo;
    public byte IFBIsFifoTar;
    public byte IFBIsFastSer;
    public byte BIsVCP;
    // FT232R extensions
    public byte UseExtOsc;
    public byte HighDriveIOs;
    public byte EndpointSize;
    public byte PullDownEnableR;
    public byte SerNumEnableR;
    public byte InvertTXD;          // non-zero if invert TXD
    public byte InvertRXD;          // non-zero if invert RXD
    public byte InvertRTS;          // non-zero if invert RTS
    public byte InvertCTS;          // non-zero if invert CTS
    public byte InvertDTR;          // non-zero if invert DTR
    public byte InvertDSR;          // non-zero if invert DSR
    public byte InvertDCD;          // non-zero if invert DCD
    public byte InvertRI;           // non-zero if invert RI
    public byte Cbus0;              // Cbus Mux control - Ignored for FT245R
    public byte Cbus1;              // Cbus Mux control - Ignored for FT245R
    public byte Cbus2;              // Cbus Mux control - Ignored for FT245R
    public byte Cbus3;              // Cbus Mux control - Ignored for FT245R
    public byte Cbus4;              // Cbus Mux control - Ignored for FT245R
    public byte RIsD2XX;            // Default to loading VCP
                                    // FT2232H extensions
    public byte PullDownEnable7;
    public byte SerNumEnable7;
    public byte ALSlowSlew;         // non-zero if AL pins have slow slew
    public byte ALSchmittInput;     // non-zero if AL pins are Schmitt input
    public byte ALDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
    public byte AHSlowSlew;         // non-zero if AH pins have slow slew
    public byte AHSchmittInput;     // non-zero if AH pins are Schmitt input
    public byte AHDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
    public byte BLSlowSlew;         // non-zero if BL pins have slow slew
    public byte BLSchmittInput;     // non-zero if BL pins are Schmitt input
    public byte BLDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
    public byte BHSlowSlew;         // non-zero if BH pins have slow slew
    public byte BHSchmittInput;     // non-zero if BH pins are Schmitt input
    public byte BHDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
    public byte IFAIsFifo7;         // non-zero if interface is 245 FIFO
    public byte IFAIsFifoTar7;      // non-zero if interface is 245 FIFO CPU target
    public byte IFAIsFastSer7;      // non-zero if interface is Fast serial
    public byte AIsVCP7;            // non-zero if interface is to use VCP drivers
    public byte IFBIsFifo7;         // non-zero if interface is 245 FIFO
    public byte IFBIsFifoTar7;      // non-zero if interface is 245 FIFO CPU target
    public byte IFBIsFastSer7;      // non-zero if interface is Fast serial
    public byte BIsVCP7;            // non-zero if interface is to use VCP drivers
    public byte PowerSaveEnable;    // non-zero if using BCBUS7 to save power for self-powered designs
                                    // FT4232H extensions
    public byte PullDownEnable8;
    public byte SerNumEnable8;
    public byte ASlowSlew;          // non-zero if AL pins have slow slew
    public byte ASchmittInput;      // non-zero if AL pins are Schmitt input
    public byte ADriveCurrent;      // valid values are 4mA, 8mA, 12mA, 16mA
    public byte BSlowSlew;          // non-zero if AH pins have slow slew
    public byte BSchmittInput;      // non-zero if AH pins are Schmitt input
    public byte BDriveCurrent;      // valid values are 4mA, 8mA, 12mA, 16mA
    public byte CSlowSlew;          // non-zero if BL pins have slow slew
    public byte CSchmittInput;      // non-zero if BL pins are Schmitt input
    public byte CDriveCurrent;      // valid values are 4mA, 8mA, 12mA, 16mA
    public byte DSlowSlew;          // non-zero if BH pins have slow slew
    public byte DSchmittInput;      // non-zero if BH pins are Schmitt input
    public byte DDriveCurrent;      // valid values are 4mA, 8mA, 12mA, 16mA
    public byte ARIIsTXDEN;
    public byte BRIIsTXDEN;
    public byte CRIIsTXDEN;
    public byte DRIIsTXDEN;
    public byte AIsVCP8;            // non-zero if interface is to use VCP drivers
    public byte BIsVCP8;            // non-zero if interface is to use VCP drivers
    public byte CIsVCP8;            // non-zero if interface is to use VCP drivers
    public byte DIsVCP8;            // non-zero if interface is to use VCP drivers
                                    // FT232H extensions
    public byte PullDownEnableH;    // non-zero if pull down enabled
    public byte SerNumEnableH;      // non-zero if serial number to be used
    public byte ACSlowSlewH;        // non-zero if AC pins have slow slew
    public byte ACSchmittInputH;    // non-zero if AC pins are Schmitt input
    public byte ACDriveCurrentH;    // valid values are 4mA, 8mA, 12mA, 16mA
    public byte ADSlowSlewH;        // non-zero if AD pins have slow slew
    public byte ADSchmittInputH;    // non-zero if AD pins are Schmitt input
    public byte ADDriveCurrentH;    // valid values are 4mA, 8mA, 12mA, 16mA
    public byte Cbus0H;             // Cbus Mux control
    public byte Cbus1H;             // Cbus Mux control
    public byte Cbus2H;             // Cbus Mux control
    public byte Cbus3H;             // Cbus Mux control
    public byte Cbus4H;             // Cbus Mux control
    public byte Cbus5H;             // Cbus Mux control
    public byte Cbus6H;             // Cbus Mux control
    public byte Cbus7H;             // Cbus Mux control
    public byte Cbus8H;             // Cbus Mux control
    public byte Cbus9H;             // Cbus Mux control
    public byte IsFifoH;            // non-zero if interface is 245 FIFO
    public byte IsFifoTarH;         // non-zero if interface is 245 FIFO CPU target
    public byte IsFastSerH;         // non-zero if interface is Fast serial
    public byte IsFT1248H;          // non-zero if interface is FT1248
    public byte FT1248CpolH;        // FT1248 clock polarity
    public byte FT1248LsbH;         // FT1248 data is LSB (1) or MSB (0)
    public byte FT1248FlowControlH; // FT1248 flow control enable
    public byte IsVCPH;             // non-zero if interface is to use VCP drivers
    public byte PowerSaveEnableH;   // non-zero if using ACBUS7 to save power for self-powered designs
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
struct FT_EEPROM_HEADER
{
    public UInt32 deviceType;       // FTxxxx device type to be programmed
                                    // Device descriptor options
    public UInt16 VendorId;             // 0x0403
    public UInt16 ProductId;                // 0x6001
    public byte SerNumEnable;           // non-zero if serial number to be used
                                        // Config descriptor options
    public UInt16 MaxPower;             // 0 < MaxPower <= 500
    public byte SelfPowered;            // 0 = bus powered, 1 = self powered
    public byte RemoteWakeup;           // 0 = not capable, 1 = capable
                                        // Hardware options
    public byte PullDownEnable;     // non-zero if pull down in suspend enabled
}

[StructLayout(LayoutKind.Sequential, Pack = 4)]
struct FT_XSERIES_DATA
{
    public FT_EEPROM_HEADER common;

    public byte ACSlowSlew;         // non-zero if AC bus pins have slow slew
    public byte ACSchmittInput;     // non-zero if AC bus pins are Schmitt input
    public byte ACDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
    public byte ADSlowSlew;         // non-zero if AD bus pins have slow slew
    public byte ADSchmittInput;     // non-zero if AD bus pins are Schmitt input
    public byte ADDriveCurrent;     // valid values are 4mA, 8mA, 12mA, 16mA
                                    // CBUS options
    public byte Cbus0;              // Cbus Mux control
    public byte Cbus1;              // Cbus Mux control
    public byte Cbus2;              // Cbus Mux control
    public byte Cbus3;              // Cbus Mux control
    public byte Cbus4;              // Cbus Mux control
    public byte Cbus5;              // Cbus Mux control
    public byte Cbus6;              // Cbus Mux control
                                    // UART signal options
    public byte InvertTXD;          // non-zero if invert TXD
    public byte InvertRXD;          // non-zero if invert RXD
    public byte InvertRTS;          // non-zero if invert RTS
    public byte InvertCTS;          // non-zero if invert CTS
    public byte InvertDTR;          // non-zero if invert DTR
    public byte InvertDSR;          // non-zero if invert DSR
    public byte InvertDCD;          // non-zero if invert DCD
    public byte InvertRI;               // non-zero if invert RI
                                        // Battery Charge Detect options
    public byte BCDEnable;          // Enable Battery Charger Detection
    public byte BCDForceCbusPWREN;  // asserts the power enable signal on CBUS when charging port detected
    public byte BCDDisableSleep;        // forces the device never to go into sleep mode
                                        // I2C options
    public UInt16 I2CSlaveAddress;      // I2C slave device address
    public UInt32 I2CDeviceId;          // I2C device ID
    public byte I2CDisableSchmitt;  // Disable I2C Schmitt trigger
                                    // FT1248 options
    public byte FT1248Cpol;         // FT1248 clock polarity - clock idle high (1) or clock idle low (0)
    public byte FT1248Lsb;          // FT1248 data is LSB (1) or MSB (0)
    public byte FT1248FlowControl;  // FT1248 flow control enable
                                    // Hardware options
    public byte RS485EchoSuppress;  // 
    public byte PowerSaveEnable;        // 
                                        // Driver option
    public byte DriverType;         // 
}

// Base class for EEPROM structures - these elements are common to all devices
/// <summary>
/// Common EEPROM elements for all devices.  Inherited to specific device type EEPROMs.
/// </summary>
public class FT_EEPROM_DATA
{
    //private const UInt32 Signature1     = 0x00000000;
    //private const UInt32 Signature2     = 0xFFFFFFFF;
    //private const UInt32 Version        = 0x00000002;
    /// <summary>
    /// Vendor ID as supplied by the USB Implementers Forum
    /// </summary>
    public UInt16 VendorID = 0x0403;
    /// <summary>
    /// Product ID
    /// </summary>
    public UInt16 ProductID = 0x6001;
    /// <summary>
    /// Manufacturer name string
    /// </summary>
    public string Manufacturer = "FTDI";
    /// <summary>
    /// Manufacturer name abbreviation to be used as a prefix for automatically generated serial numbers
    /// </summary>
    public string ManufacturerID = "FT";
    /// <summary>
    /// Device description string
    /// </summary>
    public string Description = "USB-Serial Converter";
    /// <summary>
    /// Device serial number string
    /// </summary>
    public string SerialNumber = "";
    /// <summary>
    /// Maximum power the device needs
    /// </summary>
    public UInt16 MaxPower = 0x0090;
    //private bool PnP                    = true;
    /// <summary>
    /// Indicates if the device has its own power supply (self-powered) or gets power from the USB port (bus-powered)
    /// </summary>
    public bool SelfPowered = false;
    /// <summary>
    /// Determines if the device can wake the host PC from suspend by toggling the RI line
    /// </summary>
    public bool RemoteWakeup = false;
}

// EEPROM class for FT232B and FT245B
/// <summary>
/// EEPROM structure specific to FT232B and FT245B devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT232B_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    //private bool Rev4                   = true;
    //private bool IsoIn                  = false;
    //private bool IsoOut                 = false;
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if the USB version number is enabled
    /// </summary>
    public bool USBVersionEnable = true;
    /// <summary>
    /// The USB version number.  Should be either 0x0110 (USB 1.1) or 0x0200 (USB 2.0)
    /// </summary>
    public UInt16 USBVersion = 0x0200;
}

// EEPROM class for FT2232C, FT2232L and FT2232D
/// <summary>
/// EEPROM structure specific to FT2232 devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT2232_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    //private bool Rev5                   = true;
    //private bool IsoInA                 = false;
    //private bool IsoInB                 = false;
    //private bool IsoOutA                = false;
    //private bool IsoOutB                = false;
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if the USB version number is enabled
    /// </summary>
    public bool USBVersionEnable = true;
    /// <summary>
    /// The USB version number.  Should be either 0x0110 (USB 1.1) or 0x0200 (USB 2.0)
    /// </summary>
    public UInt16 USBVersion = 0x0200;
    /// <summary>
    /// Enables high current IOs on channel A
    /// </summary>
    public bool AIsHighCurrent = false;
    /// <summary>
    /// Enables high current IOs on channel B
    /// </summary>
    public bool BIsHighCurrent = false;
    /// <summary>
    /// Determines if channel A is in FIFO mode
    /// </summary>
    public bool IFAIsFifo = false;
    /// <summary>
    /// Determines if channel A is in FIFO target mode
    /// </summary>
    public bool IFAIsFifoTar = false;
    /// <summary>
    /// Determines if channel A is in fast serial mode
    /// </summary>
    public bool IFAIsFastSer = false;
    /// <summary>
    /// Determines if channel A loads the VCP driver
    /// </summary>
    public bool AIsVCP = true;
    /// <summary>
    /// Determines if channel B is in FIFO mode
    /// </summary>
    public bool IFBIsFifo = false;
    /// <summary>
    /// Determines if channel B is in FIFO target mode
    /// </summary>
    public bool IFBIsFifoTar = false;
    /// <summary>
    /// Determines if channel B is in fast serial mode
    /// </summary>
    public bool IFBIsFastSer = false;
    /// <summary>
    /// Determines if channel B loads the VCP driver
    /// </summary>
    public bool BIsVCP = true;
}

// EEPROM class for FT232R and FT245R
/// <summary>
/// EEPROM structure specific to FT232R and FT245R devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT232R_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    /// <summary>
    /// Disables the FT232R internal clock source.  
    /// If the device has external oscillator enabled it must have an external oscillator fitted to function
    /// </summary>
    public bool UseExtOsc = false;
    /// <summary>
    /// Enables high current IOs
    /// </summary>
    public bool HighDriveIOs = false;
    /// <summary>
    /// Sets the endpoint size.  This should always be set to 64
    /// </summary>
    public byte EndpointSize = 64;
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Inverts the sense of the TXD line
    /// </summary>
    public bool InvertTXD = false;
    /// <summary>
    /// Inverts the sense of the RXD line
    /// </summary>
    public bool InvertRXD = false;
    /// <summary>
    /// Inverts the sense of the RTS line
    /// </summary>
    public bool InvertRTS = false;
    /// <summary>
    /// Inverts the sense of the CTS line
    /// </summary>
    public bool InvertCTS = false;
    /// <summary>
    /// Inverts the sense of the DTR line
    /// </summary>
    public bool InvertDTR = false;
    /// <summary>
    /// Inverts the sense of the DSR line
    /// </summary>
    public bool InvertDSR = false;
    /// <summary>
    /// Inverts the sense of the DCD line
    /// </summary>
    public bool InvertDCD = false;
    /// <summary>
    /// Inverts the sense of the RI line
    /// </summary>
    public bool InvertRI = false;
    /// <summary>
    /// Sets the function of the CBUS0 pin for FT232R devices.
    /// Valid values are FT_CBUS_TXDEN, FT_CBUS_PWRON , FT_CBUS_RXLED, FT_CBUS_TXLED, 
    /// FT_CBUS_TXRXLED, FT_CBUS_SLEEP, FT_CBUS_CLK48, FT_CBUS_CLK24, FT_CBUS_CLK12, 
    /// FT_CBUS_CLK6, FT_CBUS_IOMODE, FT_CBUS_BITBANG_WR, FT_CBUS_BITBANG_RD
    /// </summary>
    public byte Cbus0 = FT_CBUS_OPTIONS.FT_CBUS_SLEEP;
    /// <summary>
    /// Sets the function of the CBUS1 pin for FT232R devices.
    /// Valid values are FT_CBUS_TXDEN, FT_CBUS_PWRON , FT_CBUS_RXLED, FT_CBUS_TXLED, 
    /// FT_CBUS_TXRXLED, FT_CBUS_SLEEP, FT_CBUS_CLK48, FT_CBUS_CLK24, FT_CBUS_CLK12, 
    /// FT_CBUS_CLK6, FT_CBUS_IOMODE, FT_CBUS_BITBANG_WR, FT_CBUS_BITBANG_RD
    /// </summary>
    public byte Cbus1 = FT_CBUS_OPTIONS.FT_CBUS_SLEEP;
    /// <summary>
    /// Sets the function of the CBUS2 pin for FT232R devices.
    /// Valid values are FT_CBUS_TXDEN, FT_CBUS_PWRON , FT_CBUS_RXLED, FT_CBUS_TXLED, 
    /// FT_CBUS_TXRXLED, FT_CBUS_SLEEP, FT_CBUS_CLK48, FT_CBUS_CLK24, FT_CBUS_CLK12, 
    /// FT_CBUS_CLK6, FT_CBUS_IOMODE, FT_CBUS_BITBANG_WR, FT_CBUS_BITBANG_RD
    /// </summary>
    public byte Cbus2 = FT_CBUS_OPTIONS.FT_CBUS_SLEEP;
    /// <summary>
    /// Sets the function of the CBUS3 pin for FT232R devices.
    /// Valid values are FT_CBUS_TXDEN, FT_CBUS_PWRON , FT_CBUS_RXLED, FT_CBUS_TXLED, 
    /// FT_CBUS_TXRXLED, FT_CBUS_SLEEP, FT_CBUS_CLK48, FT_CBUS_CLK24, FT_CBUS_CLK12, 
    /// FT_CBUS_CLK6, FT_CBUS_IOMODE, FT_CBUS_BITBANG_WR, FT_CBUS_BITBANG_RD
    /// </summary>
    public byte Cbus3 = FT_CBUS_OPTIONS.FT_CBUS_SLEEP;
    /// <summary>
    /// Sets the function of the CBUS4 pin for FT232R devices.
    /// Valid values are FT_CBUS_TXDEN, FT_CBUS_PWRON , FT_CBUS_RXLED, FT_CBUS_TXLED, 
    /// FT_CBUS_TXRXLED, FT_CBUS_SLEEP, FT_CBUS_CLK48, FT_CBUS_CLK24, FT_CBUS_CLK12, 
    /// FT_CBUS_CLK6
    /// </summary>
    public byte Cbus4 = FT_CBUS_OPTIONS.FT_CBUS_SLEEP;
    /// <summary>
    /// Determines if the VCP driver is loaded
    /// </summary>
    public bool RIsD2XX = false;
}

// EEPROM class for FT2232H
/// <summary>
/// EEPROM structure specific to FT2232H devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT2232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if AL pins have a slow slew rate
    /// </summary>
    public bool ALSlowSlew = false;
    /// <summary>
    /// Determines if the AL pins have a Schmitt input
    /// </summary>
    public bool ALSchmittInput = false;
    /// <summary>
    /// Determines the AL pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ALDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if AH pins have a slow slew rate
    /// </summary>
    public bool AHSlowSlew = false;
    /// <summary>
    /// Determines if the AH pins have a Schmitt input
    /// </summary>
    public bool AHSchmittInput = false;
    /// <summary>
    /// Determines the AH pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte AHDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if BL pins have a slow slew rate
    /// </summary>
    public bool BLSlowSlew = false;
    /// <summary>
    /// Determines if the BL pins have a Schmitt input
    /// </summary>
    public bool BLSchmittInput = false;
    /// <summary>
    /// Determines the BL pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte BLDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if BH pins have a slow slew rate
    /// </summary>
    public bool BHSlowSlew = false;
    /// <summary>
    /// Determines if the BH pins have a Schmitt input
    /// </summary>
    public bool BHSchmittInput = false;
    /// <summary>
    /// Determines the BH pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte BHDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if channel A is in FIFO mode
    /// </summary>
    public bool IFAIsFifo = false;
    /// <summary>
    /// Determines if channel A is in FIFO target mode
    /// </summary>
    public bool IFAIsFifoTar = false;
    /// <summary>
    /// Determines if channel A is in fast serial mode
    /// </summary>
    public bool IFAIsFastSer = false;
    /// <summary>
    /// Determines if channel A loads the VCP driver
    /// </summary>
    public bool AIsVCP = true;
    /// <summary>
    /// Determines if channel B is in FIFO mode
    /// </summary>
    public bool IFBIsFifo = false;
    /// <summary>
    /// Determines if channel B is in FIFO target mode
    /// </summary>
    public bool IFBIsFifoTar = false;
    /// <summary>
    /// Determines if channel B is in fast serial mode
    /// </summary>
    public bool IFBIsFastSer = false;
    /// <summary>
    /// Determines if channel B loads the VCP driver
    /// </summary>
    public bool BIsVCP = true;
    /// <summary>
    /// For self-powered designs, keeps the FT2232H in low power state until BCBUS7 is high
    /// </summary>
    public bool PowerSaveEnable = false;
}

// EEPROM class for FT4232H
/// <summary>
/// EEPROM structure specific to FT4232H devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT4232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if A pins have a slow slew rate
    /// </summary>
    public bool ASlowSlew = false;
    /// <summary>
    /// Determines if the A pins have a Schmitt input
    /// </summary>
    public bool ASchmittInput = false;
    /// <summary>
    /// Determines the A pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ADriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if B pins have a slow slew rate
    /// </summary>
    public bool BSlowSlew = false;
    /// <summary>
    /// Determines if the B pins have a Schmitt input
    /// </summary>
    public bool BSchmittInput = false;
    /// <summary>
    /// Determines the B pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte BDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if C pins have a slow slew rate
    /// </summary>
    public bool CSlowSlew = false;
    /// <summary>
    /// Determines if the C pins have a Schmitt input
    /// </summary>
    public bool CSchmittInput = false;
    /// <summary>
    /// Determines the C pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte CDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if D pins have a slow slew rate
    /// </summary>
    public bool DSlowSlew = false;
    /// <summary>
    /// Determines if the D pins have a Schmitt input
    /// </summary>
    public bool DSchmittInput = false;
    /// <summary>
    /// Determines the D pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte DDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// RI of port A acts as RS485 transmit enable (TXDEN)
    /// </summary>
    public bool ARIIsTXDEN = false;
    /// <summary>
    /// RI of port B acts as RS485 transmit enable (TXDEN)
    /// </summary>
    public bool BRIIsTXDEN = false;
    /// <summary>
    /// RI of port C acts as RS485 transmit enable (TXDEN)
    /// </summary>
    public bool CRIIsTXDEN = false;
    /// <summary>
    /// RI of port D acts as RS485 transmit enable (TXDEN)
    /// </summary>
    public bool DRIIsTXDEN = false;
    /// <summary>
    /// Determines if channel A loads the VCP driver
    /// </summary>
    public bool AIsVCP = true;
    /// <summary>
    /// Determines if channel B loads the VCP driver
    /// </summary>
    public bool BIsVCP = true;
    /// <summary>
    /// Determines if channel C loads the VCP driver
    /// </summary>
    public bool CIsVCP = true;
    /// <summary>
    /// Determines if channel D loads the VCP driver
    /// </summary>
    public bool DIsVCP = true;
}
// EEPROM class for FT232H
/// <summary>
/// EEPROM structure specific to FT232H devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT232H_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if AC pins have a slow slew rate
    /// </summary>
    public bool ACSlowSlew = false;
    /// <summary>
    /// Determines if the AC pins have a Schmitt input
    /// </summary>
    public bool ACSchmittInput = false;
    /// <summary>
    /// Determines the AC pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ACDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Determines if AD pins have a slow slew rate
    /// </summary>
    public bool ADSlowSlew = false;
    /// <summary>
    /// Determines if the AD pins have a Schmitt input
    /// </summary>
    public bool ADSchmittInput = false;
    /// <summary>
    /// Determines the AD pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ADDriveCurrent = FT_DRIVE_CURRENT.FT_DRIVE_CURRENT_4MA;
    /// <summary>
    /// Sets the function of the CBUS0 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN, FT_CBUS_CLK30,
    /// FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus0 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS1 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN, FT_CBUS_CLK30,
    /// FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus1 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS2 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN
    /// </summary>
    public byte Cbus2 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS3 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN
    /// </summary>
    public byte Cbus3 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS4 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN
    /// </summary>
    public byte Cbus4 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS5 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_IOMODE,
    /// FT_CBUS_TXDEN, FT_CBUS_CLK30, FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus5 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS6 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_IOMODE,
    /// FT_CBUS_TXDEN, FT_CBUS_CLK30, FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus6 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS7 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE
    /// </summary>
    public byte Cbus7 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS8 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_IOMODE,
    /// FT_CBUS_TXDEN, FT_CBUS_CLK30, FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus8 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Sets the function of the CBUS9 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_IOMODE,
    /// FT_CBUS_TXDEN, FT_CBUS_CLK30, FT_CBUS_CLK15, FT_CBUS_CLK7_5
    /// </summary>
    public byte Cbus9 = FT_232H_CBUS_OPTIONS.FT_CBUS_TRISTATE;
    /// <summary>
    /// Determines if the device is in FIFO mode
    /// </summary>
    public bool IsFifo = false;
    /// <summary>
    /// Determines if the device is in FIFO target mode
    /// </summary>
    public bool IsFifoTar = false;
    /// <summary>
    /// Determines if the device is in fast serial mode
    /// </summary>
    public bool IsFastSer = false;
    /// <summary>
    /// Determines if the device is in FT1248 mode
    /// </summary>
    public bool IsFT1248 = false;
    /// <summary>
    /// Determines FT1248 mode clock polarity
    /// </summary>
    public bool FT1248Cpol = false;
    /// <summary>
    /// Determines if data is ent MSB (0) or LSB (1) in FT1248 mode
    /// </summary>
    public bool FT1248Lsb = false;
    /// <summary>
    /// Determines if FT1248 mode uses flow control
    /// </summary>
    public bool FT1248FlowControl = false;
    /// <summary>
    /// Determines if the VCP driver is loaded
    /// </summary>
    public bool IsVCP = true;
    /// <summary>
    /// For self-powered designs, keeps the FT232H in low power state until ACBUS7 is high
    /// </summary>
    public bool PowerSaveEnable = false;
}

/// <summary>
/// EEPROM structure specific to X-Series devices.
/// Inherits from FT_EEPROM_DATA.
/// </summary>
public class FT_XSERIES_EEPROM_STRUCTURE : FT_EEPROM_DATA
{
    /// <summary>
    /// Determines if IOs are pulled down when the device is in suspend
    /// </summary>
    public bool PullDownEnable = false;
    /// <summary>
    /// Determines if the serial number is enabled
    /// </summary>
    public bool SerNumEnable = true;
    /// <summary>
    /// Determines if the USB version number is enabled
    /// </summary>
    public bool USBVersionEnable = true;
    /// <summary>
    /// The USB version number: 0x0200 (USB 2.0)
    /// </summary>
    public UInt16 USBVersion = 0x0200;
    /// <summary>
    /// Determines if AC pins have a slow slew rate
    /// </summary>
    public byte ACSlowSlew;
    /// <summary>
    /// Determines if the AC pins have a Schmitt input
    /// </summary>
    public byte ACSchmittInput;
    /// <summary>
    /// Determines the AC pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ACDriveCurrent;
    /// <summary>
    /// Determines if AD pins have a slow slew rate
    /// </summary>
    public byte ADSlowSlew;
    /// <summary>
    /// Determines if AD pins have a schmitt input
    /// </summary>
    public byte ADSchmittInput;
    /// <summary>
    /// Determines the AD pins drive current in mA.  Valid values are FT_DRIVE_CURRENT_4MA, FT_DRIVE_CURRENT_8MA, FT_DRIVE_CURRENT_12MA or FT_DRIVE_CURRENT_16MA
    /// </summary>
    public byte ADDriveCurrent;
    /// <summary>
    /// Sets the function of the CBUS0 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_GPIO, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus0;
    /// <summary>
    /// Sets the function of the CBUS1 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_GPIO, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus1;
    /// <summary>
    /// Sets the function of the CBUS2 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_GPIO, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus2;
    /// <summary>
    /// Sets the function of the CBUS3 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_GPIO, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus3;
    /// <summary>
    /// Sets the function of the CBUS4 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus4;
    /// <summary>
    /// Sets the function of the CBUS5 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus5;
    /// <summary>
    /// Sets the function of the CBUS6 pin for FT232H devices.
    /// Valid values are FT_CBUS_TRISTATE, FT_CBUS_RXLED, FT_CBUS_TXLED, FT_CBUS_TXRXLED,
    /// FT_CBUS_PWREN, FT_CBUS_SLEEP, FT_CBUS_DRIVE_0, FT_CBUS_DRIVE_1, FT_CBUS_TXDEN, FT_CBUS_CLK24,
    /// FT_CBUS_CLK12, FT_CBUS_CLK6, FT_CBUS_BCD_CHARGER, FT_CBUS_BCD_CHARGER_N, FT_CBUS_VBUS_SENSE, FT_CBUS_BITBANG_WR,
    /// FT_CBUS_BITBANG_RD, FT_CBUS_TIME_STAMP, FT_CBUS_KEEP_AWAKE
    /// </summary>
    public byte Cbus6;
    /// <summary>
    /// Inverts the sense of the TXD line
    /// </summary>
    public byte InvertTXD;
    /// <summary>
    /// Inverts the sense of the RXD line
    /// </summary>
    public byte InvertRXD;
    /// <summary>
    /// Inverts the sense of the RTS line
    /// </summary>
    public byte InvertRTS;
    /// <summary>
    /// Inverts the sense of the CTS line
    /// </summary>
    public byte InvertCTS;
    /// <summary>
    /// Inverts the sense of the DTR line
    /// </summary>
    public byte InvertDTR;
    /// <summary>
    /// Inverts the sense of the DSR line
    /// </summary>
    public byte InvertDSR;
    /// <summary>
    /// Inverts the sense of the DCD line
    /// </summary>
    public byte InvertDCD;
    /// <summary>
    /// Inverts the sense of the RI line
    /// </summary>
    public byte InvertRI;
    /// <summary>
    /// Determines whether the Battery Charge Detection option is enabled.
    /// </summary>
    public byte BCDEnable;
    /// <summary>
    /// Asserts the power enable signal on CBUS when charging port detected.
    /// </summary>
    public byte BCDForceCbusPWREN;
    /// <summary>
    /// Forces the device never to go into sleep mode.
    /// </summary>
    public byte BCDDisableSleep;
    /// <summary>
    /// I2C slave device address.
    /// </summary>
    public ushort I2CSlaveAddress;
    /// <summary>
    /// I2C device ID
    /// </summary>
    public UInt32 I2CDeviceId;
    /// <summary>
    /// Disable I2C Schmitt trigger.
    /// </summary>
    public byte I2CDisableSchmitt;
    /// <summary>
    /// FT1248 clock polarity - clock idle high (1) or clock idle low (0)
    /// </summary>
    public byte FT1248Cpol;
    /// <summary>
    /// FT1248 data is LSB (1) or MSB (0)
    /// </summary>
    public byte FT1248Lsb;
    /// <summary>
    /// FT1248 flow control enable.
    /// </summary>
    public byte FT1248FlowControl;
    /// <summary>
    /// Enable RS485 Echo Suppression
    /// </summary>
    public byte RS485EchoSuppress;
    /// <summary>
    /// Enable Power Save mode.
    /// </summary>
    public byte PowerSaveEnable;
    /// <summary>
    /// Determines whether the VCP driver is loaded.
    /// </summary>
    public byte IsVCP;
}