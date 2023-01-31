using FtdiSharp.FTD2XX;

namespace FtdiSharp;

[Obsolete("Use a communicator.")]
public class FtdiManager
{
    public readonly FTDI FTD2XX = new();

    public FtdiManager()
    {
    }

    public FtdiManager(FtdiDevice device)
    {
        Open(device);
    }

    public void Open(FtdiDevice device)
    {
        if (FTD2XX.IsOpen)
            throw new InvalidOperationException("a device is already open");

        FTD2XX.OpenByIndex((uint)device.Index).ThrowIfNotOK();

        FTD2XX.ResetDevice().ThrowIfNotOK();
    }

    public void Close()
    {
        if (!FTD2XX.IsOpen)
            throw new InvalidOperationException("no device is open");

        FTD2XX.Close().ThrowIfNotOK();
    }
}
