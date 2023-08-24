namespace Trakk.Utils.Extensions;

public static class DecimalExtensions
{
    public static decimal Trim(this decimal src, int decimals) => Math.Round(src, decimals);

    public static bool Tolerate(this decimal src, decimal other, decimal tolerance) =>
        Math.Abs(src - other) <= tolerance;

}