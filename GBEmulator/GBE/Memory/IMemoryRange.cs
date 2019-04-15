using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public interface IMemoryRange
    {
        void Write(int address, byte value);
        byte Read(int address);
        bool Accepts(int address);
    }
}
