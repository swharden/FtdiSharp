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
    public void Test_Scan_I2C_Addresses()
    {
        if (!FtdiDevices.Scan().Any())
            return;

        FtdiDevice device = FtdiDevices.Scan().First();

        FtdiSharp.Protocols.I2C i2c = new(device);

        foreach (byte address in i2c.Scan())
            Console.WriteLine(address);
    }
}