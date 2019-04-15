using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP6B_LDLE : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_r(processor, ref processor.registers.L, ref processor.registers.E);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
