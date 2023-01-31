using System.Runtime.Intrinsics.X86;

namespace FtdiSharpTests;

public class HardwareTests
{
    [Test]
    public void Test_Scan_Devices()
    {
        foreach (FtdiDevice device in FtdiDevices.Scan())
            Console.WriteLine(device);
    }

    [Test]
    public void Test_Quickstart()
    {
        // Display all connected FTDI devices
        foreach (FtdiDevice device in FtdiDevices.Scan())
            Console.WriteLine(device);

        // Open the first FTDI device
        FtdiManager ftman = new(FtdiDevices.First());
    }

    [Test]
    public void Test_Scan_I2C()
    {
        FtdiDevice device = FtdiDevices.First();

        FtdiManager ftman = new(device);

        FtdiSharp.Protocols.I2C i2c = new(ftman);

        foreach (byte address in i2c.Scan())
            Console.WriteLine(address);
    }
}