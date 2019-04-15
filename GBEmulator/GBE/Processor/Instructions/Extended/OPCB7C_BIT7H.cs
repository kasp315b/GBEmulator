using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions.Extended
{
    public class OPCB7C_BIT7H : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.SetFlag(Processor.FLAG_SUB, false);
            processor.SetFlag(Processor.FLAG_HALF_CARRY, true);
            processor.SetFlag(Processor.FLAG_ZERO, (processor.registers.H & Processor.BIT_7) == 0);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
