namespace FtdiSharp.FTD2XX;

/// <summary>
/// Error states not supported by FTD2XX DLL.
/// </summary>
public enum FT_ERROR
{
    FT_NO_ERROR = 0,
    FT_INCORRECT_DEVICE,
    FT_INVALID_BITMODE,
    FT_BUFFER_SIZE
};