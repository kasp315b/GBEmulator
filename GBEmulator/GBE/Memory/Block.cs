using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class Block : IMemoryRange
    {
        private byte[] data;

        public Block(int size)
        {
            data = new byte[size+1];
        }

        public void Write(int address, byte value)
        {
            data[address] = value;
        }

        public byte Read(int address)
        {
            return data[address];
        }

        public bool Accepts(int address)
        {
            return address >= 0 && address < data.Length;
        }
    }
}
