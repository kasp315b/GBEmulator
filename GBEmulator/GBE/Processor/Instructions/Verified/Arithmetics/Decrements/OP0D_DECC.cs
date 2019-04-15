using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP0D_DECC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_DECr(processor, ref processor.registers.C);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
