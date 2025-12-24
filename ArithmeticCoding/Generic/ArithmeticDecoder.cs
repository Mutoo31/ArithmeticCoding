using ArithmeticCoding.Shared;

namespace ArithmeticCoding.Generic
{
    public class ArithmeticDecoder
    {
        private const int STATE_BITS = 32;         // Number of bits for the arithmetic coder state
        private const uint FULL = 0xFFFFFFFF;      // 2^32 - 1
        private const uint HALF = 0x80000000;      // 2^31
        private const uint QUARTER = 0x40000000;   // 2^30

        private readonly IBitstreamReader _bitstream;
        private uint _low;
        private uint _high;
        private uint _code;

        public ArithmeticDecoder(IBitstreamReader bitstream)
        {
            _bitstream = bitstream;
            _low = 0;
            _high = FULL;
            _code = 0;

            // Initialize the code with first 32 bits
            for (int i = 0; i < STATE_BITS; i++)
            {
                _code = (_code << 1) | ReadBit();
            }
        }

        // Read next bit from bitstream safely
        private uint ReadBit()
        {
            return (uint)_bitstream.ReadBit().AsInt32();
        }

        // Decode a binary symbol with probability p (scaled 0..65535)
        public int DecodeBinary(ushort probability)
        {
            uint range = _high - _low + 1;
            uint split = _low + (range * probability) / 65536;

            int symbol;
            if (_code <= split)
            {
                symbol = 0;
                _high = split;
            }
            else
            {
                symbol = 1;
                _low = split + 1;
            }

            // Normalize
            while (true)
            {
                if (_high < HALF)
                {
                    // do nothing, just shift
                }
                else if (_low >= HALF)
                {
                    _code -= HALF;
                    _low -= HALF;
                    _high -= HALF;
                }
                else if (_low >= QUARTER && _high < 3 * QUARTER)
                {
                    _code -= QUARTER;
                    _low -= QUARTER;
                    _high -= QUARTER;
                }
                else
                {
                    break;
                }

                _low <<= 1;
                _high = (_high << 1) | 1;
                _code = (_code << 1) | ReadBit();
            }

            return symbol;
        }
    }
}
