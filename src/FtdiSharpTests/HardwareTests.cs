using System.Runtime.Intrinsics.X86;

namespace FtdiSharpTests;

public class HardwareTests
{
    [Test]
    public void Test_Scan_Devices()
    {
        FtdiManager ftman = new();
        DeviceInfo[] devices = ftman.GetDevices();
        Console.WriteLine($"Connected devices: {devices.Length}");

        foreach (DeviceInfo device in devices)
        {
            Console.WriteLine(device);
        }
    }

    [Test]
    public void Test_Quickstart()
    {
        // Create a FTDI communication manager
        FtdiManager ftman = new();

        // Display all connected FTDI devices
        DeviceInfo[] devices = ftman.GetDevices();
        foreach (DeviceInfo device in devices)
            Console.WriteLine(device);

        // Open the first FTDI device
        ftman.Open(devices.First());
    }

    //[Test]
    public void Test_Scan_I2C()
    {
        FtdiManager ftman = new();
        ftman.Open(index: 0);

        FtdiSharp.Protocols.I2C i2c = new(ftman);

        foreach (byte address in i2c.Scan())
            Console.WriteLine(address);
    }
}