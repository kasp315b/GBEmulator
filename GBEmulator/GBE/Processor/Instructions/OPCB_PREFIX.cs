using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Processor.Instructions
{
    public class OPCB_PREFIX : IInstruction
    {
        public void Execute(Processor processor)
        {
            processor.PrefixExecute();
        }

        public int Duration()
        {
            return 4;
        }
    }
}
