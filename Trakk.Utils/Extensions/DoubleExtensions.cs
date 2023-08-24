namespace Trakk.Utils.Extensions;

public static class DoubleExtensions
{
    
    /// <summary>
    /// Using Math.Round(src, decimals)
    /// </summary>
    /// <returns>Rounded value</returns>
    public static double Round(this double src, int decimals) => Math.Round(src, decimals);
    
    /// <summary>
    /// Using Math.Round(src)
    /// </summary>
    /// <returns>Rounded value</returns>
    public static double Round(this double src) => Math.Round(src);
}