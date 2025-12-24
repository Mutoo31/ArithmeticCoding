using System.Runtime.CompilerServices;

namespace ArithmeticCoding.Shared
{
    internal static class Maths
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clip3(int x, int y, int z)
        {
            if (z < x)
                return x;
            else if (x > y)
                return y;
            else
                return z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        // .NET Standard 2.0 doesn't support Math.Log2 so this is a polyfill
        public static int Log2(int x)
        {
            return (int)Math.Log(x) / (int)Math.Log(2);
        }
    }
}
