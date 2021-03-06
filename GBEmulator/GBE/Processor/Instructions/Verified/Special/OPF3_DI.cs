﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPF3_DI : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.EnableInterrupts();
        }

        public int Duration()
        {
            return 4;
        }
    }
}
