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

## I²C Protocol

High level functions simplify communication with I2C devices for FTDI chips which support it (e.g., FT232H).

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
