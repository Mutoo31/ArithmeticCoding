namespace ArithmeticCoding.H264;

public enum H264CabacSliceType
{
    I,
    SI,
    P,
    SP,
    B
}

public enum H264MacroblockMbaffCoding
{
    Frame = 0,
    Field = 1,
    Neither = 2
}

public enum H264MacroblockPredictionCoding
{
    /// <summary>
    ///   I/SI frame
    /// </summary>
    Intra,

    /// <summary>
    ///   P/SP/B frame
    /// </summary>
    Inter,

    /// <summary>
    ///   I frame with PCM macroblocks
    /// </summary>
    Pcm,

    /// <summary>
    ///   Something else
    /// </summary>
    Other
}

/// <summary>
///   MBPPM for H.264 macroblocks
/// </summary>
public enum H264MacroblockPredictionMode
{
    Intra4x4,
    Intra8x8,
    Intra16x16,
    BiPred,
    Direct,
    L0,
    L1,
    InvalidOrNotAn
}

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

public enum H264MacroblockType
{
    B_Direct_16x16,
    B_Skip,
    P_8x8,
    B_8x8,
    P_Skip,
    I_PCM,
    SI,
    I_NxN,
    Other
}
