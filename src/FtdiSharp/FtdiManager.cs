using FtdiSharp.FTD2XX;
using System.Linq;

namespace FtdiSharp;

/// <summary>
/// A high-level FTDI device manager that interacts with the native library so you don't have to.
/// </summary>
public class FtdiManager
{
    /// <summary>
    /// This class is a modified version of the official library FTDI provides to communicate with their DLL.
    /// FtdiSharp users should not have to interact with this class directly, but it's made available just in case.
    /// </summary>
    public readonly FTDI FTD2XX = new();

    public FtdiManager()
    {
    }

    /// <summary>
    /// Returns all devices currently connected to the computer
    /// </summary>
    public DeviceInfo[] GetDevices()
    {
        UInt32 numDevices = 0;
        FTD2XX.GetNumberOfDevices(ref numDevices);

        FT_DEVICE_INFO_NODE[] nodes = new FT_DEVICE_INFO_NODE[numDevices];
        FTD2XX.GetDeviceList(nodes);

        DeviceInfo[] devices = nodes.Select(x => x.ToDevice()).ToArray();

        return devices;
    }

    public void Open(DeviceInfo device)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenBySerialNumber(device.SerialNumber).ThrowIfNotOK();
    }

    public void Close()
    {
        if (!FTD2XX.IsOpen)
            throw new InvalidOperationException("no device is open");

        FTD2XX.Close().ThrowIfNotOK();
    }
}
