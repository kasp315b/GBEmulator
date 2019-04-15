using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP87_ADDAA : IInstruction
    {
        public void Execute(Processor processor)
        {
            byte a = processor.registers.A;
            processor.registers.A += processor.registers.A;
            processor.SetFlag(Processor.FLAG_ZERO, processor.registers.A == 0);
            processor.SetFlag(Processor.FLAG_SUB, false);
            processor.SetFlag(Processor.FLAG_CARRY, Processor.CheckAddCarry(a, a));
            processor.SetFlag(Processor.FLAG_HALF_CARRY, Processor.CheckAddHalfCarry(a, a));
        }

        public int Duration()
        {
            return 4;
        }
    }
}
