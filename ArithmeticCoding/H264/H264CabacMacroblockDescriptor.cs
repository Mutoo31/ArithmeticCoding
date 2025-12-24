namespace ArithmeticCoding.H264
{
    public unsafe struct H264CabacMacroblockDescriptor
    {
        private const int MaximumReferenceIndices = 16;

        /// <summary>
        ///   The value CurrMbAddr equivalent for this macroblock in a slice.
        /// </summary>
        public int Address;

        /// <summary>
        ///   Was mb_skip_flag equal to 1 at the time of parsing this macroblock?
        /// </summary>
        public bool SkipFlag;

        /// <summary>
        ///   This slice type is treated as both part of the slice and the macroblock.
        ///   For example, in a B slice, some macroblocks can be Intra-coded, in which case,
        ///   SliceType here should be equal to I.
        /// </summary>
        public H264CabacSliceType SliceType;

        /// <summary>
        ///   The macro-block type.
        /// </summary>
        public int MacroblockType;

        /// <summary>
        ///   The value of the transform_size_8x8_flag syntax element. If unspecified/not parsed, its value
        ///   defaults to <see langword="false"/>.
        /// </summary>
        public bool TransformSize8x8Flag;

        /// <summary>
        ///   The mvd_l0 and mvd_l1 syntax elements.
        /// </summary>
        public H264CabacMvd MvdL0;

        /// <summary>
        ///   The mvd_l0 and mvd_l1 syntax elements.
        /// </summary>
        public H264CabacMvd MvdL1;

        public fixed int SubMbType[4];

        public fixed int L0ReferenceIndices[MaximumReferenceIndices];

        public fixed int L1ReferenceIndices[MaximumReferenceIndices];

        public H264MacroblockType ExactType;

        public H264MacroblockPredictionCoding PredictionCoding;

        public bool MbaffFrameFlag;

        public H264MacroblockMbaffCoding MbaffCoding;

        public H264CabacMacroblockResidualCodedBlockFlags Residual;

        public int CodedBlockPattern;
    }
}
