using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor
{
    public interface IInstruction
    {
        void Execute(Processor processor);
        int Duration();
    }
}
