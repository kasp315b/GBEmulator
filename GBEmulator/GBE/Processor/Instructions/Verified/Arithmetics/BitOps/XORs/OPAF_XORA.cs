using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPAF_XORA : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_XORr_r(processor, ref processor.registers.A, ref processor.registers.A);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
