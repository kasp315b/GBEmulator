﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP17_RLA : IInstruction
    {
        public void Execute(Processor processor)
        {
            Processor.OP_RLA(processor);
        }

    public int Duration()
        {
            return 4;
        }
    }
}
