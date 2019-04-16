using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPC5_PUSHBC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_PUSHrr(processor, ref processor.registers.BC);
        }

        public int Duration()
        {
            return 16;
        }
    }
}
