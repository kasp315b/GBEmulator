using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions.Extended
{
    public class OPCB11_RLC : IInstruction
    {
        public void Execute(Processor processor)
        {
            byte carryIn = processor._GetFlag(Processor.FLAG_CARRY);
            byte carryOut = (byte)(processor.registers.C & Processor.BIT_7);
            processor.registers.C = (byte)((processor.registers.C << 1) + carryIn);
            processor.SetFlag(Processor.FLAG_SUB | Processor.FLAG_HALF_CARRY, false);
            processor.SetFlag(Processor.FLAG_ZERO, processor.registers.C == 0);
            processor.SetFlag(Processor.FLAG_CARRY, carryOut != 0);
        }

        public int Duration()
        {
            return 8;
        }
}
}
