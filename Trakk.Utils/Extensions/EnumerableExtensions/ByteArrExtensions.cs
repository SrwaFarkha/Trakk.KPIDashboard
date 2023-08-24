using Trakk.Utils.Extensions.StringExtensions;

namespace Trakk.Utils.Extensions.EnumerableExtensions
{
    public static class ByteArrExtensions
    {
        public static string ToHexString(this byte[] byteArray)
        {
            return string.Join(string.Empty, byteArray.Select(x => x.ToString("X2")));
        }
                /// <summary>
        /// Try to convert byte array to generic
        /// </summary>
        public static T Get<T>(this byte[] array)
        {
            try
            {
                var underlyingType = Nullable.GetUnderlyingType(typeof(T));

                return (T) Convert.ChangeType(array, underlyingType ?? typeof(T));
            }
            catch (InvalidCastException)
            {
            }
            catch (FormatException)
            {
            }

            return default;
        }

        public static int ExtractInt(this byte[] arr)
        {
            return arr.ToHexString().ToInt();
        }

        public static int ExtractInt(this byte[] arr, int start, int end)
        {
            return arr.BitSection(start, end).ToHexString().ToInt();
        }
        public static decimal ExtractDecimal(this byte[] arr)
        {
            return arr.ToHexString().ToDecimal();
        }
        public static decimal ReadConcoxCoordinate(this byte[] data)
        {
            return (decimal) ((data[0] << 24) + (data[1] << 16) + (data[2] << 8) + data[3]) / 1800000;
        }
        public static decimal ExtractDecimal(this byte[] arr, int start, int end)
        {
            return arr.BitSection(start, end).ToHexString().ToDecimal();
        }

        public static byte[] BitSection(this byte[] array, int bitStart, int bitEnd)
        {
            var interval = bitEnd - bitStart + 1;
            var result = new byte[(interval - 1) / 8 + 1];

            var sourceBitIndex = bitStart;
            var disp = interval % 8 == 0 ? 0 : 8 - interval % 8;
            for (var i = disp; i < interval + disp; i++)
            {
                var value = array.GetBit(sourceBitIndex);
                result.SetBit(i, value);
                sourceBitIndex++;
            }

            return result;
        }
        
        public static bool GetBit(this byte[] array, int bitNo)
        {
            var mask = 1 << (7 - bitNo % 8);
            return (array[bitNo / 8] & mask) != 0;
        }

        public static void SetBit(this byte[] array, int bitIndex, bool value)
        {
            var mask = 1 << (7 - bitIndex % 8);
            if (value)
                array[bitIndex / 8] = Convert.ToByte(array[bitIndex / 8] | mask);
            else
                array[bitIndex / 8] = Convert.ToByte(array[bitIndex / 8] & ~mask);
        }
    }
}