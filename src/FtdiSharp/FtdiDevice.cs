using FtdiSharp.FTD2XX;

namespace FtdiSharp;

public struct FtdiDevice
{
    public int Index;
    public bool IsOpen;
    public bool IsHighSpeed;
    public string Type;
    public UInt32 ID;
    public UInt32 LocationID;
    public string SerialNumber;
    public string Description;

    public override string ToString()
    {
        return $"{Type} ({ID})";
    }
}

public static class DeviceInfoExtensions
{
    public static FtdiDevice ToDevice(this FT_DEVICE_INFO_NODE device, int index)
    {
        return new FtdiDevice()
        {
            Index = index,
            IsOpen = (device.Flags & 0b01) > 0,
            IsHighSpeed = (device.Flags & 0b10) > 0,
            Type = device.Type.ToReadableName(),
            ID = device.ID,
            LocationID = device.LocId,
            SerialNumber = device.SerialNumber,
            Description = device.Description,
        };
    }

    public static string ToReadableName(this FT_DEVICE device)
    {
        return device.ToString()!.Split('_')[2];
    }
}
