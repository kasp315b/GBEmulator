﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP84_ADDAH : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_ADDr_r(processor, ref processor.registers.A, ref processor.registers.H);
        }

        public int Duration()
        {
            return 4;
        }
    }
}
