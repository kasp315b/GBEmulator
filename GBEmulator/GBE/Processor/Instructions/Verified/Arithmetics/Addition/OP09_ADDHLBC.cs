﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP09_ADDHLBC : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_ADDrr_rr(processor, ref processor.registers.HL, ref processor.registers.BC);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
