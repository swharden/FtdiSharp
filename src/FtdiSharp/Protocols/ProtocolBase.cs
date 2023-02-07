using FtdiSharp.FTD2XX;

namespace FtdiSharp.Protocols;

public abstract class ProtocolBase : IDisposable
{
    public bool IsOpen => FtdiDevice.IsOpen;

    public readonly FTDI FtdiDevice = new();

    public ProtocolBase(FtdiDevice device)
    {
        if (!FtdiDevice.IsOpen)
            FtdiDevice.OpenByIndex((uint)device.Index).ThrowIfNotOK();

        FtdiDevice.ResetDevice();
    }

    public void Flush()
    {
        FtdiDevice.FlushBuffer();
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
