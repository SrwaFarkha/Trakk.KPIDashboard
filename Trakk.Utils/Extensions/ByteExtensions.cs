namespace Trakk.Utils.Extensions
{
    public static class ByteExtensions
    {
        public static T Get<T>(this byte b)
        {
            try
            {
                var underlyingType = Nullable.GetUnderlyingType(typeof(T));

                return (T) Convert.ChangeType(b, underlyingType ?? typeof(T));
            }
            catch (InvalidCastException)
            {
            }
            catch (FormatException)
            {
            }

            return default;
        }
        public static bool GetBit(this byte pByte, int bitNo)
        {
            return (pByte & (1 << bitNo)) != 0;
        }

        public static string ToBinaryString(this byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }
        public static string ToBinaryString(this byte[] b)
        {
            return string.Concat(b.Select(x => x.ToBinaryString()));
        }
        public static string ToHex(this byte pByte)
        {
            return pByte.ToString("X2");
        }

        public static void SetBit(this ref byte array, int bitNo, bool value)
        {
            var mask = 1 << (7 - bitNo % 8);
            array = value ? Convert.ToByte(array | mask) : Convert.ToByte(array & ~mask);
        }

        public static byte ExtractValueFromBits(this byte pByte, int bitStart, int bitEnd)
        {
            var value = Convert.ToByte(pByte >> bitStart);
            var count = bitEnd - bitStart + 1;
            var mask = Convert.ToByte((1 << count) - 1);

            value &= mask;

            return value;
        }

        public static byte Low(this byte b)
        {
            return (byte) (b & 0x0F);
        }

        public static int High(this byte b)
        {
            return b << 4;
        }
    }
}