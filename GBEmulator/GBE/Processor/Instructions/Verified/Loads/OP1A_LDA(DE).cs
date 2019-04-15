using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP1A_LDA(DE)
    public class OP1A_LDA_DE_ : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_mrr(processor, ref processor.registers.A, ref processor.registers.DE);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
