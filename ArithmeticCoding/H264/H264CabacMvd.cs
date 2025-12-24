namespace ArithmeticCoding.H264
{
    /// <summary>
    ///   MVD
    /// </summary>
    public unsafe struct H264CabacMvd
    {
        /// <summary>
        ///   The MVD value.
        /// </summary>
        public fixed short Value[4 * 4 * 2];

        /// <summary>
        ///   3D indexer: [x, y, z]
        /// </summary>
        public short this[int x, int y, int z]
        {
            get
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException(nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException(nameof(y));
                if (z < 0 || z >= 2) throw new ArgumentOutOfRangeException(nameof(z));

                return Value[(y * 4 + x) * 2 + z];
            }
            set
            {
                if (x < 0 || x >= 4) throw new ArgumentOutOfRangeException(nameof(x));
                if (y < 0 || y >= 4) throw new ArgumentOutOfRangeException(nameof(y));
                if (z < 0 || z >= 2) throw new ArgumentOutOfRangeException(nameof(z));

                Value[(y * 4 + x) * 2 + z] = value;
            }
        }
    }
}
