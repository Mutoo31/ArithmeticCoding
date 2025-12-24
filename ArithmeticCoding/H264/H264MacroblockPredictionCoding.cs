namespace ArithmeticCoding.H264
{
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
}
