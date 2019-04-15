using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP08_LD(a16)SP
    public class OP08_LD_a16_SP : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDmu16_rr(processor, ref processor.registers.SP);
        }

        public int Duration()
        {
            return 20;
        }
    }
}
