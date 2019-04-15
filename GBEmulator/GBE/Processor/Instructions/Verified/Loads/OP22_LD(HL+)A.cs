using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OP22_LD(HL+)A
    public class OP22_LD_HL__A : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDmrr_r(processor, ref processor.registers.HL, ref processor.registers.A);
            processor.registers.HL++;
        }

        public int Duration()
        {
            return 8;
        }
    }
}
