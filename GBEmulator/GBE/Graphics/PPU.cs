using GBEmulator.GBE.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE.Graphics
{
    public class PPU
    {
        private MemoryManager memory;

        public IMemoryRange bgDisplayData1;
        public IMemoryRange bgDisplayData2;
        public IMemoryRange lcdDisplayRAM;
        public MemoryRegister VBK;

        #region All PPU Registers
        public MemoryRegister LCDC; // 0xFF40
        public MemoryRegister STAT; // 0xFF41
        public MemoryRegister SCY;  // 0xFF42
        public MemoryRegister SCX;  // 0xFF43
        public MemoryRegister LY;   // 0xFF44
        public MemoryRegister LYC;  // 0xFF45
        public MemoryRegister DMA;  // 0xFF46
        public MemoryRegister BGP;  // 0xFF47
        public MemoryRegister OBP0; // 0xFF48
        public MemoryRegister OBP1; // 0xFF49
        public MemoryRegister WY;   // 0xFF4A
        public MemoryRegister WX;   // 0xFF4B
        #endregion

        #region LCDC Flags
        public bool FLAG_LCD_DISPLAY_ENABLE
        {
            get { return LCDC.field.bit7; }
            set { LCDC.field.bit7 = value; }
        }

        public bool FLAG_WINDOW_TILE_MAP_DISPLAY_SELECT
        {
            get { return LCDC.field.bit6; }
            set { LCDC.field.bit6 = value; }
        }

        public bool FLAG_WINDOW_DISPLAY_ENABLE
        {
            get { return LCDC.field.bit5; }
            set { LCDC.field.bit5 = value; }
        }

        public bool FLAG_TILE_DATA_SELECT
        {
            get { return LCDC.field.bit4; }
            set { LCDC.field.bit5 = value; }
        }

        public bool FLAG_BG_TILE_MAP_DISPLAY_SELECT
        {
            get { return LCDC.field.bit3; }
            set { LCDC.field.bit3 = value; }
        }

        public bool FLAG_OBJ_SIZE
        {
            get { return LCDC.field.bit2; }
            set { LCDC.field.bit2 = value; }
        }

        public bool FLAG_OBJ_DISPLAY_ENABLE
        {
            get { return LCDC.field.bit1; }
            set { LCDC.field.bit1 = value; }
        }

        public bool FLAG_BG_DISPLAY
        {
            get { return LCDC.field.bit0; }
            set { LCDC.field.bit0 = value; }
        }
        #endregion

        #region STAT Flags
        public bool FLAG_LYCLY_COINCIDENCE_INTERRUPT
        {
            get { return STAT.field.bit6; }
            set { STAT.field.bit6 = value; }
        }

        public bool FLAG_OAM_INTERRUPT
        {
            get { return STAT.field.bit5; }
            set { STAT.field.bit5 = value; }
        }

        public bool FLAG_VBLANK_INTERRUPT
        {
            get { return STAT.field.bit4; }
            set { STAT.field.bit4 = value; }
        }

        public bool FLAG_HBLANK_INTERRUPT
        {
            get { return STAT.field.bit3; }
            set { STAT.field.bit3 = value; }
        }

        public bool FLAG_LYCLY_COINCIDENCE
        {
            get { return STAT.field.bit2; }
            set { STAT.field.bit2 = value; }
        }

        public byte FLAG_LCD_MODE
        {
            get { return (byte)(STAT.value & 0b11); }
            set
            {
                STAT.value &= 0b11111100;
                STAT.value |= (byte)(value & 0b11);
            }
        }
        #endregion

        public PPU(MemoryManager memManager)
        {
            memory = memManager;

            VBK = new MemoryRegister(0xFF4F);
            Block charData0 = new Block(0x9800 - 0x8000);
            Block charData1 = new Block(0x9800 - 0x8000);
            BankedBlock charDataBank = new BankedBlock(new IMemoryRange[] {charData0, charData1}, VBK);
            lcdDisplayRAM = new RangeOffset(charDataBank, 0x8000);

            Block bgDisplayData1Block = new Block(0x9C00 - 0x9800);
            Block bgDisplayData2Block = new Block(0x9FFF - 0x9C00);
            bgDisplayData1 = new RangeOffset(bgDisplayData1Block, 0x9800);
            bgDisplayData2 = new RangeOffset(bgDisplayData2Block, 0x9C00);

            LCDC = new MemoryRegister(0xFF40);
            STAT = new MemoryRegister(0xFF41);
            SCY  = new MemoryRegister(0xFF42);
            SCX  = new MemoryRegister(0xFF43);
            LY   = new MemoryRegister(0xFF44);
            LYC  = new MemoryRegister(0xFF45);
            DMA  = new MemoryRegister(0xFF46);
            BGP  = new MemoryRegister(0xFF47);
            OBP0 = new MemoryRegister(0xFF48);
            OBP1 = new MemoryRegister(0xFF49);
            WY   = new MemoryRegister(0xFF4A);
            WX   = new MemoryRegister(0xFF4B);

            memory.Add(lcdDisplayRAM);
            memory.Add(bgDisplayData1);
            memory.Add(bgDisplayData2);
            memory.Add(VBK);
            memory.Add(LCDC);
            memory.Add(STAT);
            memory.Add(SCY);
            memory.Add(SCX);
            memory.Add(LY);
            memory.Add(LYC);
            memory.Add(DMA);
            memory.Add(BGP);
            memory.Add(OBP0);
            memory.Add(OBP1);
            memory.Add(WY);
            memory.Add(WX);
        }
    }
}
