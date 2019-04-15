using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    //           OPE0_LD(FF00+a8)A
    public class OPE0_LD_FF00_u8_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.memory.Write(0xFF00 + processor.memory.Read(processor.registers.PC), processor.registers.A);
        }

        public int Duration()
        {
            return 12;
        }
    }
}
