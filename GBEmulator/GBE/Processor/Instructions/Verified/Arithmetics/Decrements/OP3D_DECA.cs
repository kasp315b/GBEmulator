using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP3D_DECA : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_DECr(processor, ref processor.registers.A);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
