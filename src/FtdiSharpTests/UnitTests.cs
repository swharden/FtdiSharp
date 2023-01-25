namespace FtdiSharpTests;

public class UnitTests
{
    [Test]
    public void Test_DeviceNames_CanBeParsed()
    {
        foreach (FtdiSharp.FTD2XX.FT_DEVICE dev in Enum.GetValues(typeof(FtdiSharp.FTD2XX.FT_DEVICE)))
        {
            Console.WriteLine(dev.ToReadableName());
        }
    }
}
