namespace ArithmeticCoding.Shared
{
    /// <summary>
    ///   16 bits stacked on each other
    /// </summary>
    public struct SixteenStackedBits
    {
        /// <summary>
        ///   Actual value.
        /// </summary>
        private ushort m_Value;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SixteenStackedBits"/> structure.
        /// </summary>
        public SixteenStackedBits()
        {
        }

        public bool this[int i]
        {
            readonly get => (m_Value & (1 << i)) != 0;
            set => m_Value = (ushort)(value ? (m_Value | (1 << i)) : (m_Value & ~(1 << i)));
        }
    }
}
