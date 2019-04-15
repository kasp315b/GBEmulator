using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP77_LD(HL)A
    public class OP77_LD_HL_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDmrr_r(processor, ref processor.registers.HL, ref processor.registers.A);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
