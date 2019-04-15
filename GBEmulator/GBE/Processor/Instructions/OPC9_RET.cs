using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPC9_RET : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.registers.PC_LOW = processor.memory.Read(processor.registers.SP++);
            processor.registers.PC_HIGH = processor.memory.Read(processor.registers.SP++);
        }

        public int Duration()
        {
            return 16;
        }
    }
}
