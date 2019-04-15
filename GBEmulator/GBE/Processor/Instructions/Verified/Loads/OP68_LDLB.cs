using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP68_LDLB : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_r(processor, ref processor.registers.L, ref processor.registers.B);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
