using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPCD_CALLa16 : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.WordPushStack((ushort)(processor.registers.PC + 2));
            ushort pc = processor.registers.PC;
            processor.registers.PC_LOW = processor.memory.Read(pc);
            processor.registers.PC_HIGH = processor.memory.Read(pc + 1);
        }

        public int Duration()
        {
            return 24;
        }
    }
}
