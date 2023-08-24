namespace Trakk.Utils.Extensions.EnumerableExtensions
{
    public static class ArrayExtensions
    {

        public static bool StartsWith(this byte[] src, byte[] bytes)
        {
            if (bytes.Count() > src.Count())
                return false;
            return !bytes.Where((sb, index) => sb != src[index]).Any();
        }
        public static T[] Segment<T>(this T[] array, int start, int length = 0)
        {
            return length != 0
                ? new ArraySegment<T>(array, start, length).ToArray()
                : new ArraySegment<T>(array, start, array.Length - start).ToArray();
        }
        
        public static byte[] TrimTailingZeros(this byte[] arr)
        {
            if (arr == null || arr.Length == 0)
                return arr;
            return arr.Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
        }
    }
}