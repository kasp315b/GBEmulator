using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPEA_LD_a16_A : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.memory.Write(
                Processor.AssembleWordReverse(
                    processor.memory.Read(processor.registers.PC++),
                    processor.memory.Read(processor.registers.PC++)
                ),
                processor.registers.A
            );
        }

        public int Duration()
        {
            return 16;
        }
    }
}
