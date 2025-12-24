namespace ArithmeticCoding.Shared;

internal static class Int32Boolean
{
    public static int AsInt32(this bool value) => value ? 1 : 0;
    public static bool AsBoolean(this int value) => value != 0;
}
