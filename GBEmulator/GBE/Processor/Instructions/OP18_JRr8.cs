using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP18_JRr8 : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.registers.PC = (ushort)(processor.registers.PC + (sbyte)processor.memory.Read(processor.registers.PC++));
        }

        public int Duration()
        {
            return 12;
        }
    }
}
