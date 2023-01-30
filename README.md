# FtdiSharp

[![CI](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml/badge.svg)](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml)

FtdiSharp is a simple .NET interface for FTDI USB controllers

> Warning: This library is in preview and its public API may change as it continues to evolve

## Quickstart

```cs
// Create a FTDI communication manager
FtdiManager ftman = new();

// Display all connected FTDI devices
DeviceInfo[] devices = ftman.GetDevices();
foreach (DeviceInfo device in devices)
    Console.WriteLine(device);

// Open the first FTDI device
FTMan.Open(devices[0]);
```

## I2C Protocol

High level functions simplify communication with I2C devices for FTDI chips which support it (e.g., FT232H).

### Scan for I2C Devices
```cs
FtdiSharp.Protocols.I2C i2c = new(ftman);

foreach (byte address in i2c.Scan())
    Console.WriteLine(address);
```

### Interact with an I2C Device

This code reads luminosity from a [BH1750 light sensor](https://www.mouser.com/datasheet/2/348/Rohm_11162017_ROHMS34826-1-1279292.pdf)

```cs
// enable continuous sensor reading mode
byte deviceAddress = 0x23;
byte continuousMode = 0b00010000;
I2C.Write(deviceAddress, continuousMode);

// read light intensity from two bytes at a given address
byte deviceAddress = i2cAddressSelector1.Address;
byte sensorRegister = 0x02;
byte[] bytes = I2C.Read(deviceAddress, sensorRegister);

// convert the two bytes to lumens according to the datasheet
double value = (bytes[0] * 256 + bytes[1]) / 1.2;
```