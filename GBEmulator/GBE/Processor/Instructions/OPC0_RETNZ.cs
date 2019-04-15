using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPC0_RETNZ : IInstruction
    {
        public void Execute(Processor processor)
        {
            if(!processor.GetFlag(Processor.FLAG_ZERO))
            {
                processor.registers.PC = processor.WordPopStack();
                processor.cycles += 12;
            }
        }

        public int Duration()
        {
            return 8;
        }
    }
}
