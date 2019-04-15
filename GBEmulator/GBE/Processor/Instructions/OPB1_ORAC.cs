using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPB1_ORAC : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.SetFlag(Processor.FLAG_ZERO, (processor.registers.A | processor.registers.C) == 0);
            processor.SetFlag(Processor.FLAG_SUB, false);
            processor.SetFlag(Processor.FLAG_HALF_CARRY, false);
            processor.SetFlag(Processor.FLAG_CARRY, false);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
