using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class RerouteRanges : IMemoryRange
    {
        private IMemoryRange writeRange;
        private IMemoryRange readRange;

        public RerouteRanges(IMemoryRange writeRange, IMemoryRange readRange)
        {
            this.writeRange = writeRange;
            this.readRange = readRange;
        }

        public void Write(int address, byte value)
        {
            writeRange.Write(address, value);
        }

        public byte Read(int address)
        {
            return readRange.Read(address);
        }

        public bool Accepts(int address)
        {
            return writeRange.Accepts(address) && readRange.Accepts(address);
        }
    }
}
