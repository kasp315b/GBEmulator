using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class MemoryRegister : IMemoryRange
    {
        public byte value;
        private int offset;

        public MemoryRegister(int offset)
        {
            this.offset = offset;
        }

        public void Write(int address, byte value)
        {
            this.value = value;
        }

        public byte Read(int address)
        {
            return value;
        }

        public bool Accepts(int address)
        {
            return address == offset;
        }
    }
}
