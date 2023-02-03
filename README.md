# FtdiSharp

[![CI](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml/badge.svg)](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml)

**FtdiSharp is a simple .NET interface for FTDI USB controllers.** FtdiSharp has high-level communication managers that make it easy to exchange data using UART, I²C, SPI, and FIFO, but it also provides low-level access to functions in FTDI's DLL for advanced users.

FTDI's FTD2XX source code has been refactored to break it into smaller files, improve XML documentation, and utilize modern language features. FtdiSharp targets .NET Framework 4.6.2 and .NET 6 so it can be used in .NET Framework and .NET Core environments.

> Warning: This library is in preview and its public API may change as it continues to evolve

## Quickstart

```cs
// Show all USB FTDI devices attached to the system
foreach (FtdiDevice device in FtdiDevices.Scan())
    Console.WriteLine(device);
```

## SPI Protocol

High level functions simplify communication with SPI devices for FTDI chips which support it (e.g., FT232H).

### FT232H SPI Pinout

* SCK: D0
* MOSI: D1
* MISO: D2
* CS: D3

### Interact with SPI Devices

This code reads voltage from a [MCP3201 ADC](https://www.mouser.com/pdfDocs/21290c-28774.pdf)

```cs
// Use the first USB FTDI device found
FtdiDevice device = FtdiDevices.Scan().First();
FtdiSharp.Protocols.SPI spi = new(device);

// Pull the cable select line low and read two bytes
spi.CsLow();
byte[] bytes = spi.ReadBytes(2);
spi.CsHigh();

// Calculate the 14-bit reading according to the datasheet
byte b1 = (byte)(bytes[0] & 0b00011111);
byte b2 = (byte)(bytes[1] & 0b11111110);
int value = ((b1 << 8) + b2) >> 1;
```

## I²C Protocol

High level functions simplify communication with I2C devices for FTDI chips which support it (e.g., FT232H).

### FT232H I²C Pinout

* SCL: D0
* SDA: D1 and D2 tied together

### Scan for I²C Devices
```cs
// Use the first USB FTDI device found
FtdiDevice device = FtdiDevices.Scan().First();

// Create an I2C protocol communicator
FtdiSharp.Protocols.I2C i2c = new(device);

// Show all the I2C addresses in use
foreach (byte address in i2c.Scan())
    Console.WriteLine(address);
```

### Interact with an I²C Device

This code reads luminosity from a [BH1750 light sensor](https://www.mouser.com/datasheet/2/348/Rohm_11162017_ROHMS34826-1-1279292.pdf)

```cs
// Use the first USB FTDI device found
FtdiDevice device = FtdiDevices.Scan().First();
FtdiSharp.Protocols.I2C i2c = new(device);

// Enter continuous sensor mode
byte address = 0x23;
byte config = 0b00010000;
i2c.Write(address, config);

// Read light intensity as two bytes
byte[] bytes = i2c.Read(address, 2);

// Convert the two bytes to lumens according to the datasheet
double value = (bytes[0] * 256 + bytes[1]) / 1.2;
```

## Additional Resources

Microsoft has a [dotnet/iot repository](https://github.com/dotnet/iot) with lots of useful code and information about protocols and common devices, including [FT232H](https://github.com/dotnet/iot/tree/main/src/devices/Ft232H). I considered using this project but I found support for FT232H to be incomplete, incorrectly documented, and buggy. They have an [impressive number of devices](https://github.com/dotnet/iot/tree/main/src/devices) though, and it seems this library is being actively developed so I hope it will be more useful in the future.