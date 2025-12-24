namespace ArithmeticCoding.H264
{
    public record struct H264CabacAddressAndBlockIndices(
        H264CabacMacroblockWithAvailability Address,
        int BlockIndex,
        bool BlockIndexAvailability);
}
