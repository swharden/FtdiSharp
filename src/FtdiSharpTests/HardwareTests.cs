namespace FtdiSharpTests;

public class HardwareTests
{
    readonly bool FtdiDeviceFound = FtdiDevices.Scan().Any();

    [Test]
    public void Test_Scan_Devices()
    {
        foreach (FtdiDevice device in FtdiDevices.Scan())
            Console.WriteLine(device);
    }

    [Test]
    public void Test_Scan_I2C_Addresses()
    {
        if (!FtdiDeviceFound)
            return;

        FtdiDevice device = FtdiDevices.Scan().First();

        FtdiSharp.Protocols.I2C i2c = new(device);

        foreach (byte address in i2c.Scan())
            Console.WriteLine(address);
    }

    [Test]
    public void Test_Read_Light_Sensor()
    {
        if (!FtdiDeviceFound)
            return;

        // Connect to the first USB FTDI device
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
        Console.WriteLine(value);
    }
}