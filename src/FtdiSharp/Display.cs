using System.Linq;

namespace FtdiSharp;

public static class Display
{
    public static string Binary(this byte[] bytes)
    {
        return string.Join(", ", bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
    }
}
