using FtdiSharp.FTD2XX;
using System.Linq;

namespace FtdiSharp;

/// <summary>
/// A high-level FTDI device manager that interacts with the native library so you don't have to.
/// FTDI232H pins: D0=SCL, D1+D2=SDA
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

    public void Open(int? index = null, uint? location = null, string? description = null, string? serialNumber = null)
    {
        if (index is not null)
        {
            OpenByIndex(index.Value);
            return;
        }

        if (location is not null)
        {
            OpenByLocation(location.Value);
            return;
        }

        if (description is not null)
        {
            OpenByDescription(description);
            return;
        }

        if (serialNumber is not null)
        {
            OpenBySerialNumber(serialNumber);
            return;
        }

        throw new ArgumentException("At least one argument must be defined");
    }

    public void Open(DeviceInfo device)
    {
        OpenByLocation(device.LocationID);
    }

    public void OpenByIndex(int deviceIndex)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenByIndex((uint)deviceIndex).ThrowIfNotOK();

        FTD2XX.ResetDevice().ThrowIfNotOK();
    }

    public void OpenByLocation(uint location)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenByLocation((uint)location);

        FTD2XX.ResetDevice();
    }

    public void OpenByDescription(string description)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenByDescription(description);

        FTD2XX.ResetDevice();
    }

    public void OpenBySerialNumber(string serial)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenBySerialNumber(serial);

        FTD2XX.ResetDevice();
    }

    public void Close()
    {
        if (!FTD2XX.IsOpen)
            throw new InvalidOperationException("no device is open");

        FTD2XX.Close().ThrowIfNotOK();
    }
}
