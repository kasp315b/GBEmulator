using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP04_INCB : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_INCr(processor, ref processor.registers.B);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
