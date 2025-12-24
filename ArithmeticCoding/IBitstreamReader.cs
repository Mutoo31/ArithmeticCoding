namespace ArithmeticCoding;

/// <summary>
///   Bitstream data reader for use in arithmetic coding.
/// </summary>
public interface IBitstreamReader
{
    /// <summary>
    ///   Reads a single bit from the bitstream.
    /// </summary>
    /// <returns>Bit that was read.</returns>
    bool ReadBit();

    /// <summary>
    ///   Reads a single bit from the bitstream.
    /// </summary>
    /// <returns>Bit that was read.</returns>
    Task<bool> ReadBitAsync();
}
