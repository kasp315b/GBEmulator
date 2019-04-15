using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OPE2_LD(FF00+C)A
    public class OPE2_LD_FF00_C_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.memory.Write(0xFF00 + processor.registers.C, processor.registers.A);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
