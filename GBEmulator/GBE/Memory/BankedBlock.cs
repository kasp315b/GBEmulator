using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class BankedBlock : IMemoryRange
    {
        private IMemoryRange[] banks;
        private MemoryRegister selector;

        public BankedBlock(IMemoryRange[] banks, MemoryRegister selector)
        {
            this.banks = banks;
            this.selector = selector;
        }

        public void Write(int address, byte value)
        {
            GetCurrentBank().Write(address, value);
        }

        public byte Read(int address)
        {
            return GetCurrentBank().Read(address);
        }

        public bool Accepts(int address)
        {
            return GetCurrentBank().Accepts(address);
        }

        public MemoryRegister GetSelectorRegister()
        {
            return selector;
        }

        public IMemoryRange GetCurrentBank()
        {
            return banks[selector.value & banks.Length];
        }
    }
}
