# FtdiSharp

[![CI](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml/badge.svg)](https://github.com/swharden/FtdiSharp/actions/workflows/ci.yaml)

**FtdiSharp is a .NET interface for FTDI USB controllers** that provides high-level tools for advanced communication protocols (I²C, SPI, and GPIO) and also supplies a copy of FTDI's official DLL wrapper to provide low-level control for advanced users.

### Communicate _Directly_ With Sensors

FtdiSharp aims to simplify the process of interfacing directly with sensors which communicate using I2C or SPI for FTDI chips which support these advanced protocols. **No microcontroller is required!** Connect your sensor directly to a compatible FTDI device and you can use FtdiSharp to easily control it and make readings. Pair FtdiSharp with with [ScottPlot](https://scottplot.net) to create real-time data visualization applications with only a few lines of code.

![](https://raw.githubusercontent.com/swharden/FtdiSharp/main/dev/screenshots/i2c-connections.png)

![](https://raw.githubusercontent.com/swharden/FtdiSharp/main/dev/screenshots/lm75a.png)

### Intended Audience

**Do not use FtdiSharp if your project only requires a USB serial port.** FtdiSharp is intended for applications which seek to use advanced communication protocols beyond serial UART and provide FTDI-specific actions like reading/writing chip serial numbers. If your project only requires a USB serial port, use [`System.IO.Ports`](https://learn.microsoft.com/en-us/dotnet/api/system.io.ports) which is simpler and officially supported on all operating systems.

### Low-Level Driver Access

**FtdiSharp provides access FTDI's FTD2XX_NET official DLL wrapper for advanced users.** FTDI's official source code has been refactored to break it into smaller files, improve XML documentation, and utilize modern language features. FtdiSharp targets .NET Framework 4.6.2 and .NET 6 so it can be used in .NET Framework and .NET Core environments.

### Demo Application

**This project comes with a demo app that shows how to directly interface several common sensors.** The FT232H can communicate directly with sensors using SPI and I2C, so no microcontroller is required. Unlike FTDI's official code samples (thousands of lines of spaghetti code, often in Visual Basic) the demo application in this project aims to demonstrate common I2C, SPI, and GPIO functionality with minimal complexity.

![](https://raw.githubusercontent.com/swharden/FtdiSharp/main/dev/screenshots/demo.png)

The demo shows how to use FtdiSharp to interact with common sensors:
* [LM75A](https://www.ti.com/lit/ds/symlink/lm75a.pdf) I2C temperature sensor and thermal watchdog
* [BMP280](https://cdn-shop.adafruit.com/datasheets/BST-BMP280-DS001-11.pdf) I2C pressure sensor (0.02 PSI sensitivity)
* [LIS3DH](https://www.st.com/resource/en/datasheet/cd00274221.pdf) I2C 3-axis accelerometer
* [ADS1115](https://www.ti.com/lit/ds/symlink/ads1115.pdf) I2C 4-channel 16-bit ADC (860 samples per second)
* [BH1750](https://www.mouser.com/datasheet/2/348/bh1750fvi-e-186247.pdf) I2C 16-bit ambient light sensor
* [MCP3201](http://ww1.microchip.com/downloads/en/devicedoc/21290f.pdf) SPI 12-bit ADC (100k samples per second)
* [HX710](https://image.micros.com.pl/_dane_techniczne_auto/uphx710b%20smd.pdf) SPI 21-bit ADC (40 samples per second)
* [MCP3008](https://cdn-shop.adafruit.com/datasheets/MCP3008.pdf) SPI 4-channel 10-bit ADC (200k samples per second)
* [ADS1220](https://www.ti.com/lit/ds/symlink/ads1220.pdf) SPI 4-channel 24-bit ADC (2k samples per second)

### USB Interactions Limit Update Rate

While sensors may support thousands of reads per second, limitations of the USB protocol restrict how frequently FtdiSharp can request data updates from connected devices. The strategy demonstrated on this page is best for applications which only require updates a few times per second. Applications which require high-speed repeated measurements or precise timing should not interface a FTDI controller directly to their sensor, but instead use a high-speed microcontroller to manage the interaction.

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

## GPIO Protocol

Pins of a FT232H may be used as general purpose I/O (GPIO) controlled by software.

```cs
// Use the first USB FTDI device found
FtdiDevice device = FtdiDevices.Scan().First();
FtdiSharp.Protocols.GPIO gpio = new(device);

// Set pin states
byte direction = 0b11110000; // make D4-D7 outputs
byte value = 0b10100000; // make D7 and D5 high
gpio.Set(direction, value);

// Read pin states
byte reading = gpio.Read();
```

## Additional Resources

* [Adafruit FT232H Breakout Board](https://www.adafruit.com/product/2264)

* Microsoft's [System.IO.Ports](https://learn.microsoft.com/en-us/dotnet/api/system.io.ports) should be used for applications which only seek to interface with a USB serial adapter.

* Microsoft has a [dotnet/iot repository](https://github.com/dotnet/iot) with lots of useful code and information about protocols and common devices, including [FT232H](https://github.com/dotnet/iot/tree/main/src/devices/Ft232H). I considered using this project but I found support for FT232H to be incomplete, incorrectly documented, and buggy. They have an [impressive number of devices](https://github.com/dotnet/iot/tree/main/src/devices) though, and it seems this library is being actively developed so I hope it will be more useful in the future.