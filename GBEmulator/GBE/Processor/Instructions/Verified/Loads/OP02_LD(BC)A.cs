using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP02_LD(BC)A
    public class OP02_LD_BC_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDmrr_r(processor, ref processor.registers.BC, ref processor.registers.A);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
