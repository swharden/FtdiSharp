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
}