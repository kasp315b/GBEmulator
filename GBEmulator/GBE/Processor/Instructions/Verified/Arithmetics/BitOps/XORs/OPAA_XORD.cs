using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPAA_XORD : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_XORr_r(processor, ref processor.registers.A, ref processor.registers.D);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
