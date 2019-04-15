using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP99_SBCAC : IInstruction
    {
        public void Execute(Processor processor)
        {
            byte s = (byte)(processor.registers.C + processor._GetFlag(Processor.FLAG_CARRY));
            processor.SetFlag(Processor.FLAG_SUB, true);
            processor.SetFlag(Processor.FLAG_HALF_CARRY, Processor.CheckSubHalfCarry(processor.registers.A, s));
            processor.SetFlag(Processor.FLAG_CARRY, Processor.CheckSubCarry(processor.registers.A, s));
            processor.registers.A -= s;
            processor.SetFlag(Processor.FLAG_ZERO, processor.registers.A == 0);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
