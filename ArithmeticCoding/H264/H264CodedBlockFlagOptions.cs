namespace ArithmeticCoding.H264
{
    /// <summary>
    ///   Options for parsing coded_block_flag.
    /// </summary>
    public struct H264CodedBlockFlagOptions
    {
        public int Luma4x4BlkIdx;
        public int Chroma4x4BlkIdx;
        public int Luma8x8BlkIdx;
        public int Cb8x8BlkIdx;
        public int Cr4x4BlkIdx;

        public int ICbCr;
    }
}
