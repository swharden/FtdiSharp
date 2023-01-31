using FtdiSharp.FTD2XX;

namespace FtdiSharp.Protocols;

public abstract class ProtocolBase : IDisposable
{
    public bool IsOpen => FtdiDevice.IsOpen;

    public readonly FTDI FtdiDevice = new();

    public ProtocolBase(FtdiDevice device)
    {
        if (FtdiDevice.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FT_STATUS status = FtdiDevice.OpenByIndex((uint)device.Index);
        if (status != FT_STATUS.FT_OK)
            throw new InvalidOperationException($"Unable to open device: {device}");

        FtdiDevice.ResetDevice();
    }

    public void Close()
    {
        if (FtdiDevice.IsOpen)
            FtdiDevice.Close();
    }

    public void Dispose()
    {
        Close();
    }
}
