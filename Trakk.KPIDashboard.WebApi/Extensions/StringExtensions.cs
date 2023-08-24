namespace Trakk.Minimal.Api.Extensions;

public static class StringExtensions
{
    public static (string first, string second) SplitAt(this string str, int index)
    {
        return (str[..index], str[index..]);
    }
}