﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP40_LDBB : IInstruction
    {
        public void Execute(Processor processor)
        {
            // Effectively does nothing.
        }

        public int Duration()
        {
            return 4;
        }
    }
}
