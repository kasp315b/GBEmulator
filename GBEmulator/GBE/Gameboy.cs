using GBEmulator.GBE.Graphics;
using GBEmulator.GBE.Memory;
using GBEmulator.GBE.Processor;

namespace GBEmulator.GBE
{
    public class Gameboy
    {
        public MemoryManager memory;
        public Processor.Processor processor;
        public PPU ppu;

        public Gameboy()
        {
            memory = new MemoryManager(this);
            processor = new Processor.Processor(this);
            ppu = new PPU(this);
        }
    }
}
