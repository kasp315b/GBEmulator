﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP3E_LDAu8 : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_LDr_u8(processor, ref processor.registers.A);
        }

        public int Duration()
        {
            return 8;
        }
    }
}
