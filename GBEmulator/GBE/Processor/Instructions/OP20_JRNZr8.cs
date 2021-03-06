﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OP20_JRNZr8 : IInstruction
    {
        public void Execute(Processor processor)
        {
            sbyte i = (sbyte)processor.memory.Read(processor.registers.PC++);
            if (!processor.GetFlag(Processor.FLAG_ZERO)) {
                processor.registers.PC = (ushort)(processor.registers.PC + i);
                processor.cycles += 4;
            }
        }

    public int Duration()
        {
            return 8;
        }
    }
}
