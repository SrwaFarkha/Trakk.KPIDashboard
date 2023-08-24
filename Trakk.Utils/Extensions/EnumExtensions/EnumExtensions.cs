namespace Trakk.Utils.Extensions.EnumExtensions;

public class EnumExtensions
{
    
}
/// <summary> Enum Extension Methods </summary>
/// <typeparam name="TEnum"> type of Enum </typeparam>
public static class EnumObject<TEnum> where TEnum : struct, Enum
{
    public static int Count
    {
        get
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.GetNames(typeof(TEnum)).Length;
        }
    }

    public static List<TClass> ToList<TClass>(Func<TEnum, TClass> createMethod)
        => Enum.GetValues<TEnum>().Select(createMethod).ToList();
}
