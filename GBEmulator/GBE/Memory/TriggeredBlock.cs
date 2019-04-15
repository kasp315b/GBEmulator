using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Memory
{
    public class TriggeredBlock : IMemoryRange
    {
        private Block data;
        private RangeOffset offset;
        private int trigger;
        private byte flag;
        private bool enabled;

        public TriggeredBlock(int size, int offset, int trigger, byte flag)
        {
            data = new Block(size);
            this.offset = new RangeOffset(data, offset);
            this.trigger = trigger;
            this.flag = flag;
            enabled = true;
        }

        public void Write(int address, byte value)
        {
            if (enabled)
            {
                if (address == trigger)
                {
                    if(value == flag)
                    {
                        enabled = false;
                    }
                }
                else
                {
                    offset.Write(address, value);
                }
            }
        }

        public byte Read(int address)
        {
            if (address == trigger) return (byte)(enabled ? 0 : flag);
            if (enabled) return offset.Read(address);
            return 0;
        }

        public bool Accepts(int address)
        {
            return enabled && (offset.Accepts(address) || address == trigger);
        }
    }
}
