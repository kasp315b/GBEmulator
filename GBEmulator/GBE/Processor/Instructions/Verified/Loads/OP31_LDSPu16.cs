using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP31_LDSPu16 : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDrr_u16(processor, ref processor.registers.SP);
        }

        public int Duration()
        {
            return 12;
        }
    }
}
