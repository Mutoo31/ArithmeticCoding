namespace ArithmeticCoding.H264
{
    /// <summary>
    ///   The type of the residual block being parsed. The values
    ///   map directly to the variable ctxBlockCat.
    /// </summary>
    public enum H264ResidualBlockKind
    {
        Intra16x16DCLevel,
        Intra16x16ACLevel,
        LumaLevel4x4,
        ChromaDCLevel,
        ChromaACLevel,
        LumaLevel8x8,
        CbIntra16x16DCLevel,
        CbIntra16x16ACLevel,
        CbLevel4x4,
        CbLevel8x8,
        CrIntra16x16DCLevel,
        CrIntra16x16ACLevel,
        CrLevel4x4,
        CrLevel8x8
    }
}
