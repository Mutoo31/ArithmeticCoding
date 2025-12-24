using ArithmeticCoding.Shared;

namespace ArithmeticCoding.H263
{
    /// <summary>
    ///   H.263 SAC decoder
    /// </summary>
    public class H263SyntaxBasedArithmeticDecoder
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
        public int Low { get; set; }

        /// <summary>
        ///   High value.
        /// </summary>
        public int High { get; set; }

        /// <summary>
        ///   Code value.
        /// </summary>
        public int CodeValue { get; set; }

        /// <summary>
        ///   Length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///   Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///   Cumulative.
        /// </summary>
        public int Cumulative { get; set; }

        /// <summary>
        ///   Decodes a single H.263 symbol.
        /// </summary>
        /// <param name="cumulativeFrequencies">The cumulative frequencies; see <see cref="H263SyntaxBasedArithmeticModels"/></param>
        /// <param name="pscFifo">The PSC First-In First-Out</param>
        /// <returns>The symbol.</returns>
        public int DecodeSymbol(ReadOnlySpan<int> cumulativeFrequencies, IH263PscFifo pscFifo)
        {
            this.Length = this.High - this.Low + 1;
            this.Cumulative = (-1 + (this.CodeValue - this.Low + 1) *cumulativeFrequencies[0]) / this.Length;

            for (int index = 1; cumulativeFrequencies[index] > this.Cumulative; index++)
            {
            }

            this.High = this.Low - 1 + (this.Length * cumulativeFrequencies[this.Index - 1]) / cumulativeFrequencies[0];
            this.Low += (this.Length * cumulativeFrequencies[this.Index]) / cumulativeFrequencies[0];

            for (; ; )
            {
                if (this.High < Q2)
                {
                }
                else if (this.Low >= Q2)
                {
                    this.CodeValue -= Q2;
                    this.Low -= Q2;
                    this.High -= Q2;
                }
                else if (this.Low >= Q1 && this.High < Q3)
                {
                    this.CodeValue -= Q1;
                    this.Low -= Q1;
                    this.High -= Q1;
                }
                else break;

                this.Low *= 2;
                this.High = 2 * this.High + 1;

                int bit = pscFifo.GetBitFromFifo().AsInt32();

                this.CodeValue = 2 * this.CodeValue + bit;
            }
            return this.Index - 1;
        }

        /// <summary>
        ///   Decodes a single H.263 symbol.
        /// </summary>
        /// <param name="cumulativeFrequencies">The cumulative frequencies; see <see cref="H263SyntaxBasedArithmeticModels"/></param>
        /// <param name="pscFifo">The PSC First-In First-Out</param>
        /// <returns>The symbol.</returns>
        public async Task<int> DecodeSymbol(int[] cumulativeFrequencies, IH263PscFifo pscFifo)
        {
            this.Length = this.High - this.Low + 1;
            this.Cumulative = (-1 + (this.CodeValue - this.Low + 1) * cumulativeFrequencies[0]) / this.Length;

            for (int index = 1; cumulativeFrequencies[index] > this.Cumulative; index++)
            {
            }

            this.High = this.Low - 1 + (this.Length * cumulativeFrequencies[this.Index - 1]) / cumulativeFrequencies[0];
            this.Low += (this.Length * cumulativeFrequencies[this.Index]) / cumulativeFrequencies[0];

            for (; ; )
            {
                if (this.High < Q2)
                {
                }
                else if (this.Low >= Q2)
                {
                    this.CodeValue -= Q2;
                    this.Low -= Q2;
                    this.High -= Q2;
                }
                else if (this.Low >= Q1 && this.High < Q3)
                {
                    this.CodeValue -= Q1;
                    this.Low -= Q1;
                    this.High -= Q1;
                }
                else break;

                this.Low *= 2;
                this.High = 2 * this.High + 1;

                int bit = (await pscFifo.GetBitFromFifoAsync()).AsInt32();

                this.CodeValue = 2 * this.CodeValue + bit;
            }
            return this.Index - 1;
        }
        
        /// <summary>
        ///   Resets the H.263 SAC decoder.
        /// </summary>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public void Reset(IH263PscFifo pscFifo)
        {
            this.CodeValue = 0;
            this.Low = 0;
            this.High = Top;

            for (int i = 1; i <= 16; i++)
            {
                int bit = pscFifo.GetBitFromFifo().AsInt32();
                this.CodeValue = 2 * this.CodeValue + bit;
            }
        }

        /// <summary>
        ///   Resets the H.263 SAC decoder.
        /// </summary>
        /// <param name="pscFifo">The PSC First-in First-out</param>
        public async Task ResetAsync(IH263PscFifo pscFifo)
        {
            this.CodeValue = 0;
            this.Low = 0;
            this.High = Top;

            for (int i = 1; i <= 16; i++)
            {
                int bit = (await pscFifo.GetBitFromFifoAsync()).AsInt32();
                this.CodeValue = 2 * this.CodeValue + bit;
            }
        }
    }
}
