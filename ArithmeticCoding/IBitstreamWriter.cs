namespace ArithmeticCoding;

/// <summary>
///   Bitstream writer for use in arithmetic coding.
/// </summary>
public interface IBitstreamWriter
{
    /// <summary>
    ///   Writes a bit in the arithmetic writer.
    /// </summary>
    /// <param name="bit">The bit.</param>
    void WriteBit(bool bit);

    /// <summary>
    ///   Writes a bit in the arithmetic writer.
    /// </summary>
    /// <param name="bit">The bit.</param>
    Task WriteBitAsync(bool bit);
}
