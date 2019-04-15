using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP86_ADDA(HL)
    public class OP86_ADDA_HL_ : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_ADDr_mrr(processor, ref processor.registers.A, ref processor.registers.HL);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
