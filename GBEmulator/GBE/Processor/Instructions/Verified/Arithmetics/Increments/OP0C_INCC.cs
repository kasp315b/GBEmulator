using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP0C_INCC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_INCr(processor, ref processor.registers.C);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
