using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPFF_RST38H : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.WordPushStack(processor.registers.PC);
            processor.registers.PC = 0x38;
        }

        public int Duration()
        {
            return 16;
        }
    }
}
