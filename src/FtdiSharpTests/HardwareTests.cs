namespace FtdiSharpTests;

public class HardwareTests
{
    [Test]
    public void Test_Scan_Devices()
    {
        FtdiManager ftman = new();
        ConnectedDevice[] devices = ftman.GetConnectedDevices();
        Console.WriteLine($"Connected devices: {devices.Length}");

        foreach (ConnectedDevice device in devices)
        {
            Console.WriteLine(device);
        }
    }
}