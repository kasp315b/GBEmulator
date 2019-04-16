using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class BitFieldByte
    {
        public const byte BIT_0_MASK = 0b00000001;
        public const byte BIT_1_MASK = 0b00000010;
        public const byte BIT_2_MASK = 0b00000100;
        public const byte BIT_3_MASK = 0b00001000;
        public const byte BIT_4_MASK = 0b00010000;
        public const byte BIT_5_MASK = 0b00100000;
        public const byte BIT_6_MASK = 0b01000000;
        public const byte BIT_7_MASK = 0b10000000;

        public const byte NOT_BIT_0_MASK = 0b11111110;
        public const byte NOT_BIT_1_MASK = 0b11111101;
        public const byte NOT_BIT_2_MASK = 0b11111011;
        public const byte NOT_BIT_3_MASK = 0b11110111;
        public const byte NOT_BIT_4_MASK = 0b11101111;
        public const byte NOT_BIT_5_MASK = 0b11011111;
        public const byte NOT_BIT_6_MASK = 0b10111111;
        public const byte NOT_BIT_7_MASK = 0b01111111;

        private byte _value;

        public byte value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public bool bit0
        {
            get
            {
                return (_value & BIT_0_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_0_MASK;
                else _value &= NOT_BIT_0_MASK;
            }
        }

        public bool bit1
        {
            get
            {
                return (_value & BIT_1_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_1_MASK;
                else _value &= NOT_BIT_1_MASK;
            }
        }

        public bool bit2
        {
            get
            {
                return (_value & BIT_2_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_2_MASK;
                else _value &= NOT_BIT_2_MASK;
            }
        }

        public bool bit3
        {
            get
            {
                return (_value & BIT_3_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_3_MASK;
                else _value &= NOT_BIT_3_MASK;
            }
        }

        public bool bit4
        {
            get
            {
                return (_value & BIT_4_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_4_MASK;
                else _value &= NOT_BIT_4_MASK;
            }
        }

        public bool bit5
        {
            get
            {
                return (_value & BIT_5_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_5_MASK;
                else _value &= NOT_BIT_5_MASK;
            }
        }

        public bool bit6
        {
            get
            {
                return (_value & BIT_6_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_6_MASK;
                else _value &= NOT_BIT_6_MASK;
            }
        }

        public bool bit7
        {
            get
            {
                return (_value & BIT_7_MASK) != 0;
            }
            set
            {
                if (value) _value |= BIT_7_MASK;
                else _value &= NOT_BIT_7_MASK;
            }
        }

        public BitFieldByte()
        {
            _value = 0;
        }

        public BitFieldByte(byte value)
        {
            _value = value;
        }

        public BitFieldByte(BitFieldByte field)
        {
            _value = field._value;
        }
    }
}
