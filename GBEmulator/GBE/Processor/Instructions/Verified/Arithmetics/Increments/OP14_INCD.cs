using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP14_INCD : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_INCr(processor, ref processor.registers.D);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
