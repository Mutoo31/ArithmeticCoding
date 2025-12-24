using System;

namespace ArithmeticCoding.Shared;

internal struct BitString8
{
    private byte _value;
    private byte _length;

    public BitString8()
    {
        _value = 0;
        _length = 0;
    }

    public BitString8(byte value, byte length)
    {
        _value = value;
        _length = length;
    }

    public readonly byte Value => _value;
    public readonly byte Length => _length;

    public void AppendBit(bool bit)
    {
        _value = (byte)((_value << 1) | (bit ? 1 : 0));
        _length++;
        if (_length > 8)
            _length = 8;
    }

    // basically indexer get property but this one never throws
    public readonly bool GetSafeBit(int n) => (_value & (1 << n)) != 0;

    public bool this[int index]
    {
        readonly get
        {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException();
            return (_value & (1 << (_length - index - 1))) != 0;
        }

        set
        {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException();
            if (value)
                _value |= (byte)(1 << (_length - index - 1));
            else
                _value &= (byte)~(1 << (_length - index - 1));
        }
    }
}
