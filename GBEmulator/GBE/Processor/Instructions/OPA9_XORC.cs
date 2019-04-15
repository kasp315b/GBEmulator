using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPA9_XORC : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.registers.A ^= processor.registers.C;
            processor.SetFlag(Processor.FLAG_ZERO, processor.registers.A == 0);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
