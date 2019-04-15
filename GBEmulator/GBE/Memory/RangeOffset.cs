using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class RangeOffset : IMemoryRange
    {
        private int offset;
        private IMemoryRange region;

        public RangeOffset(IMemoryRange region, int offset)
        {
            this.region = region;
            this.offset = offset;
        }

        public void Write(int address, byte value)
        {
            region.Write(address - offset, value);
        }

        public byte Read(int address)
        {
            return region.Read(address - offset);
        }

        public bool Accepts(int address)
        {
            return region.Accepts(address - offset);
        }
    }
}
