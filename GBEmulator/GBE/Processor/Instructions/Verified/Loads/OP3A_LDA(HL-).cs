using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP3A_LDA(HL-)
    public class OP3A_LDA_HL__ : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_mrr(processor, ref processor.registers.A, ref processor.registers.HL);
            processor.registers.HL--;
        }
        
        public int Duration()
        {
            return 8;
        }
    }
}
