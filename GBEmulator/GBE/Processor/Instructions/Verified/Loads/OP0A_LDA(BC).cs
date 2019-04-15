using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP0A_LDA(BC)
    public class OP0A_LDA_BC_ : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_mrr(processor, ref processor.registers.A, ref processor.registers.BC);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
