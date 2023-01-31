using System.Linq;

namespace FtdiSharp;

public static class FtdiDevices
{
    /// <summary>
    /// Returns all FTDI devices connected to the computer
    /// </summary>
    public static FtdiDevice[] Scan()
    {
        FTD2XX.FTDI ftdi = new();

        UInt32 numDevices = 0;
        ftdi.GetNumberOfDevices(ref numDevices);

        FTD2XX.FT_DEVICE_INFO_NODE[] nodes = new FTD2XX.FT_DEVICE_INFO_NODE[numDevices];
        ftdi.GetDeviceList(nodes);

        FtdiDevice[] devices = new FtdiDevice[numDevices];
        for (int i = 0; i < numDevices; i++)
        {
            devices[i] = nodes[i].ToDevice(i);
        }

        return devices;
    }

    /// <summary>
    /// Returns the first FTDI device found connected to the computer
    /// </summary>
    public static FtdiDevice First()
    {
        FtdiDevice[] devices = Scan();

        if (!devices.Any())
            throw new InvalidOperationException("No connected FTDI devices found");

        return devices.First();
    }
}
