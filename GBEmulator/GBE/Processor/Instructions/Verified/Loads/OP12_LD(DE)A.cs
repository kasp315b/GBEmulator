using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP12_LD(DE)A
    public class OP12_LD_DE_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDmrr_r(processor, ref processor.registers.DE, ref processor.registers.A);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
