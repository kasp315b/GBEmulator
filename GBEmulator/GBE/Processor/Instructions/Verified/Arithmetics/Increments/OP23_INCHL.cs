﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP23_INCHL : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_INCrr(processor, ref processor.registers.HL);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
