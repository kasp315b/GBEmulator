using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPE6_ANDAu8 : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.SetFlag(Processor.FLAG_ZERO, (processor.registers.A = (byte)(processor.registers.A & processor.memory.Read(processor.registers.PC++))) == 0);
            processor.SetFlag(Processor.FLAG_SUB, false);
            processor.SetFlag(Processor.FLAG_HALF_CARRY, true);
            processor.SetFlag(Processor.FLAG_CARRY, false);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
