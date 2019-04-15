using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class ReadOnly : IMemoryRange
    {
        private IMemoryRange range;

        public ReadOnly(IMemoryRange range)
        {
            this.range = range;
        }

        public void Write(int address, byte value)
        {
            // Do nothing
        }

        public byte Read(int address)
        {
            return range.Read(address);
        }

        public bool Accepts(int address)
        {
            return range.Accepts(address);
        }
    }
}
