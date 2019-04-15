using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP00_NOP : IInstruction
    {
        public void Execute(Processor processor)
        {
            // Do nothing
        }

        public int Duration()
        {
            return 4;
        }
    }
}
