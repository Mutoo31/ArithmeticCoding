namespace ArithmeticCoding.H264;

public record struct H264CabacAddressAndBlockIndices(
    H264CabacMacroblockWithAvailability Address,
    int BlockIndex,
    bool BlockIndexAvailability);

public struct H264CabacMacroblockWithAvailability
{
    public H264CabacMacroblockDescriptor Descriptor;
    public bool Availability;
}

public struct H264CabacMacroblockWithAvailabilityAndPartitionIndices
{
    public H264CabacMacroblockWithAvailability Availability;
    public int MbPartIdx;
    public int SubMbPartIdx;
}
