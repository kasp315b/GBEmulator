using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPC1_POPBC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_POPrr(processor, ref processor.registers.BC);
        }

        public int Duration()
        {
            return 12;
        }
    }
}
