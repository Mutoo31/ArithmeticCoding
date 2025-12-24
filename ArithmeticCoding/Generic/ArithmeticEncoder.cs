using ArithmeticCoding.Shared;

namespace ArithmeticCoding.Generic
{
    public class ArithmeticEncoder(IBitstreamWriter bitstream)
    {
        private const uint FULL = 0xFFFFFFFF;
        private const uint HALF = 0x80000000;
        private const uint QUARTER = 0x40000000;

        private readonly IBitstreamWriter _bitstream = bitstream;
        private uint _low = 0;
        private uint _high = FULL;
        private int _underflow = 0;

        public void EncodeBinary(bool symbol, ushort probability)
        {
            uint range = _high - _low + 1;
            uint split = _low + (range * probability) / 65536;

            if (!symbol)
            {
                _high = split;
            }
            else
            {
                _low = split + 1;
            }

            // Normalize
            while (true)
            {
                if (_high < HALF)
                {
                    OutputBit(0);
                }
                else if (_low >= HALF)
                {
                    OutputBit(1);
                    _low -= HALF;
                    _high -= HALF;
                }
                else if (_low >= QUARTER && _high < 3 * QUARTER)
                {
                    _underflow++;
                    _low -= QUARTER;
                    _high -= QUARTER;
                }
                else
                {
                    break;
                }

                _low <<= 1;
                _high = (_high << 1) | 1;
            }
        }

        private void OutputBit(int bit)
        {
            _bitstream.WriteBit(bit.AsBoolean());
            while (_underflow > 0)
            {
                _bitstream.WriteBit(bit == 0);
                _underflow--;
            }
        }

        public void Finish()
        {
            if (_low < QUARTER)
            {
                OutputBit(0);
            }
            else
            {
                OutputBit(1);
            }
        }
    }
}
