using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class Sinkhole : IMemoryRange
    {
        public Sinkhole()
        {
        }

        public void Write(int address, byte value)
        {
            Console.WriteLine("Wrote \"" + value + "\" to memory sinkhole @ " + address.ToString("X"));
        }

        public byte Read(int address)
        {
            Console.WriteLine("Read from memory sinkhole @ " + address.ToString("X"));
            return 0;
        }

        public bool Accepts(int address)
        {
            return true;
        }
    }
}
