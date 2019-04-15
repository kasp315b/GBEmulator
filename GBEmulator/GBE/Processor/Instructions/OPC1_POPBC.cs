using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPC1_POPBC : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.registers.BC = processor.WordPopStack();
        }

        public int Duration()
        {
            return 12;
        }
    }
}
