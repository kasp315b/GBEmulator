using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP03_INCBC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_INCrr(processor, ref processor.registers.BC);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
