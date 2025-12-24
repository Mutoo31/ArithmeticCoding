namespace ArithmeticCoding.H263
{
    /// <summary>
    ///   H.263 Picture Start Code FIFO
    /// </summary>
    public interface IH263PscFifo
    {
        /// <summary>
        ///   Get bit from PSC FIFO
        /// </summary>
        /// <returns>The bit</returns>
        bool GetBitFromFifo();

        /// <summary>
        ///   Get bit from PSC FIFO
        /// </summary>
        /// <returns>The bit</returns>
        Task<bool> GetBitFromFifoAsync();

        /// <summary>
        ///   Write bit to PSC FIFO.
        /// </summary>
        /// <param name="bit">The bit to write.</param>
        void WriteBitToFifo(bool bit);

        /// <summary>
        ///   Write bit to PSC FIFO.
        /// </summary>
        /// <param name="bit">The bit to write.</param>
        Task WriteBitToFifoAsync(bool bit);

        /// <summary>
        ///   Is asynchronous reading supported?
        /// </summary>
        bool SupportsAsyncRead { get; }

        /// <summary>
        ///   Is asynchronous writing supported?
        /// </summary>
        bool SupportsAsyncWrite { get; }
    }
}
