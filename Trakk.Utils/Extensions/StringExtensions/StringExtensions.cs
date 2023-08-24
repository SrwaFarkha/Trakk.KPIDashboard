using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using NLog;

namespace Trakk.Utils.Extensions.StringExtensions
{
    public static class StringExtensions
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Replace " with \"
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string MakeCodeCopySafe(this string src) => src.Replace("\"", "\\\"");
        
        public static Dictionary<Type, Func<string, object>> Converters { get; } =
            new()
            {
                {typeof(byte), s => byte.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},         
                {typeof(byte?), s => byte.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(sbyte), s => sbyte.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(short), s => short.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(ushort), s => ushort.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(int), s => int.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(int?), s => int.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(uint), s => uint.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(long), s => long.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(ulong), s => ulong.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(decimal), s => decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(decimal?), s => decimal.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(double), s => double.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(double?), s => double.Parse(s, NumberStyles.Any, CultureInfo.InvariantCulture)},
                {typeof(DateTime), s => DateTime.Parse(s, CultureInfo.InvariantCulture)},
                {typeof(bool), s => bool.Parse(s)}
            };

        public static T? Get<T>(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return default;
            try
            {
                return (T) Converters[typeof(T)](text);
            }
            catch (Exception e)
            {
                Logger.Warn($"{e.Message} '{text}' > '{typeof(T).FullName}'");
            }

            return default;
        }
        public static T? TryGet<T>(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return default;
            try
            {
                return (T) Converters[typeof(T)](text) ?? (T)Convert.ChangeType(text, typeof(T));
            }
            catch (Exception e)
            {
                Logger.Warn($"{e.Message} '{text}' > '{typeof(T).FullName}'");
            }

            return default;
        }
        public static T? Cast<T>(this string value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception e)
            {
                Logger.Warn($"{e.Message} '{value}' > '{typeof(T).Name}'");
            }

            return default;
        }
        /// <summary>
        ///     Shortcut for String.Concat
        ///     turns array to a string without separators.
        /// </summary>
        /// <returns>string</returns>
        public static string String(this string[] src)
        {
            return string.Concat(src);
        }

        public static byte[] ConvertStringToByteArray(this string input)
        {
            return input.Select(Convert.ToByte).ToArray();
        }
        
        public static byte[] ConvertHexStringToByteArray(this string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException( $"The binary key cannot have an odd number of digits: {hexString}");
            }

            var data = new byte[hexString.Length / 2];
            for (var index = 0; index < data.Length; index++)
            {
                var byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data; 
        }
        public static string ToBase64String(this string src)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(src));
        }

        public static string DecodeBase64String(this string src)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(src));
        }

        public static string ToJson(this object obj, bool indented = false) => JsonConvert.SerializeObject(obj, indented? Formatting.Indented : Formatting.None);
        public static string ToJson(this object obj, Formatting formatting, JsonSerializerSettings settings) => JsonConvert.SerializeObject(obj, formatting, settings);

        public static int ToInt(this string src, NumberStyles numberStyle = NumberStyles.HexNumber)
        {
            return int.Parse(src, numberStyle);
        }
        public static decimal ToDecimal(this string src, NumberStyles numberStyle = NumberStyles.HexNumber)
        {
            return Convert.ToInt64(src, 16); //decimal.Parse(src, numberStyle);
        }
        public static bool IsHex(this string src) => src.ToCharArray().Any(c => !"0123456789abcdefABCDEF".Contains(c));
        public static bool NullSafeContains(this string? src, string match) =>
            !string.IsNullOrEmpty(src) && src.Contains(match);
    }
}