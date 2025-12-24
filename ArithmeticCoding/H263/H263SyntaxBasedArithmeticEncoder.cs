namespace ArithmeticCoding.H263
{
    /// <summary>
    ///   H.263 SAC encoder
    /// </summary>
    public class H263SyntaxBasedArithmeticEncoder
    {
        /// <summary>
        ///   The Quarter multiplied once.
        /// </summary>
        private const ushort Q1 = 16384;

        /// <summary>
        ///   The Quarter multiplied twice.
        /// </summary>
        private const ushort Q2 = 32768;

        /// <summary>
        ///   The Quarter multiplied thrice.
        /// </summary>
        private const ushort Q3 = 49152;

        /// <summary>
        ///   Largest representable value.
        /// </summary>
        private const ushort Top = 65535;

        /// <summary>
        ///   Low value.
        /// </summary>
        private int low;

        /// <summary>
        ///   High value.
        /// </summary>
        private int high;

        /// <summary>
        ///   The opposite bits.
        /// </summary>
        private int oppositeBits;

        /// <summary>
        ///   The length.
        /// </summary>
        private int length;

        /// <summary>
        ///   The low value.
        /// </summary>
        public int Low
        {
            get => low;
            set => low = value;
        }

        /// <summary>
        ///   The low value.
        /// </summary>
        public int High
        {
            get => high;
            set => high = value;
        }

        /// <summary>
        ///   The opposite bits.
        /// </summary>
        public int OppositeBits
        {
            get => oppositeBits;
            set => oppositeBits = value;
        }

        /// <summary>
        ///   The length.
        /// </summary>
        public int Length
        {
            get => length;
            set => length = value;
        }

        /// <summary>
        ///   Encodes a single H.263 syntax-based arithmetic encoder symbol.
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="cumulativeFrequencies">The cumulative frequencies</param>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public void EncodeSymbol(int index, ReadOnlySpan<int> cumulativeFrequencies, IH263PscFifo pscFifo)
        {
            length = high - low + 1;
            high = low - 1 + (length * cumulativeFrequencies[index]) / cumulativeFrequencies[0];
            low += (length * cumulativeFrequencies[index + 1]) / cumulativeFrequencies[0];

            for (; ; )
            {
                if (high < Q2)
                {
                    pscFifo.WriteBitToFifo(false);
                    while (oppositeBits > 0)
                    {
                        pscFifo.WriteBitToFifo(true);
                        oppositeBits--;
                    }
                }
                else if (low >= Q2)
                {
                    pscFifo.WriteBitToFifo(true);
                    while (oppositeBits > 0)
                    {
                        pscFifo.WriteBitToFifo(false);
                        oppositeBits--;
                    }
                    low -= Q2;
                    high -= Q2;
                }
                else if (low >= Q1 && high < Q3)
                {
                    oppositeBits++;
                    low -= Q1;
                    high -= Q1;
                }
                else break;

                low *= 2;
                high = 2 * high + 1;
            }
        }

        /// <summary>
        ///   Encodes a single H.263 syntax-based arithmetic encoder symbol.
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="cumulativeFrequencies">The cumulative frequencies</param>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public async Task EncodeSymbolAsync(int index, Memory<int> cumulativeFrequencies, IH263PscFifo pscFifo)
        {
            length = high - low + 1;
            high = low - 1 + (length * cumulativeFrequencies.Span[index]) / cumulativeFrequencies.Span[0];
            low += (length * cumulativeFrequencies.Span[index + 1]) / cumulativeFrequencies.Span[0];

            for (; ; )
            {
                if (high < Q2)
                {
                    await sendBitToFifo(false);
                    while (oppositeBits > 0)
                    {
                        await sendBitToFifo(true);
                        oppositeBits--;
                    }
                }
                else if (low >= Q2)
                {
                    await sendBitToFifo(true);
                    while (oppositeBits > 0)
                    {
                        await sendBitToFifo(false);
                        oppositeBits--;
                    }
                    low -= Q2;
                    high -= Q2;
                }
                else if (low >= Q1 && high < Q3)
                {
                    oppositeBits++;
                    low -= Q1;
                    high -= Q1;
                }
                else break;

                low *= 2;
                high = 2 * high + 1;
            }

            async Task sendBitToFifo(bool b)
            {
                if (pscFifo.SupportsAsyncWrite) await pscFifo.WriteBitToFifoAsync(b);
                else pscFifo.WriteBitToFifo(b);
            }
        }

        /// <summary>
        ///   Encodes a single H.263 syntax-based arithmetic encoder symbol.
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="cumulativeFrequencies">The cumulative frequencies</param>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public async Task EncodeSymbolAsync(int index, int[] cumulativeFrequencies, IH263PscFifo pscFifo)
            => await EncodeSymbolAsync(index, cumulativeFrequencies.AsMemory(), pscFifo);

        /// <summary>
        ///   Flushes the encoder.
        /// </summary>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public void Flush(IH263PscFifo pscFifo)
        {
            oppositeBits++;
            if (low < Q1)
            {
                pscFifo.WriteBitToFifo(false);
                while (oppositeBits > 0)
                {
                    pscFifo.WriteBitToFifo(true);
                    oppositeBits--;
                }
            }
            else
            {
                pscFifo.WriteBitToFifo(true);
                while (oppositeBits > 0)
                {
                    pscFifo.WriteBitToFifo(false);
                    oppositeBits--;
                }
            }
            low = 0;
            high = Top;
        }

        /// <summary>
        ///   Flushes the encoder.
        /// </summary>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public async Task FlushAsync(IH263PscFifo pscFifo)
        {
            oppositeBits++;
            if (low < Q1)
            {
                await sendBitToFifo(false);
                while (oppositeBits > 0)
                {
                    await sendBitToFifo(true);
                    oppositeBits--;
                }
            }
            else
            {
                await sendBitToFifo(true);
                while (oppositeBits > 0)
                {
                    await sendBitToFifo(false);
                    oppositeBits--;
                }
            }
            low = 0;
            high = Top;

            async Task sendBitToFifo(bool b)
            {
                if (pscFifo.SupportsAsyncWrite) await pscFifo.WriteBitToFifoAsync(b);
                else pscFifo.WriteBitToFifo(b);
            }
        }
    }
}
