﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP25_DECH : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_DECr(processor, ref processor.registers.H);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
