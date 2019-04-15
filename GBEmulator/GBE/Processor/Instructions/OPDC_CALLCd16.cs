using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPDC_CALLCd16 : IInstruction
    {
        public void Execute(Processor processor)
        {
            if(processor.GetFlag(Processor.FLAG_CARRY))
            {
                ushort destination = Processor.AssembleWordReverse(
                    processor.memory.Read(processor.registers.PC++),
                    processor.memory.Read(processor.registers.PC++)
                );
                processor.WordPushStack(processor.registers.PC);
                processor.registers.PC = destination;
                processor.cycles += 12;
            }
            else
            {
                processor.registers.PC += 2;
            }
        }

        public int Duration()
        {
            return 12;
        }
    }
}
