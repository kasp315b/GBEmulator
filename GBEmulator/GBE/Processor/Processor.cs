using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GBEmulator.GBE.Memory;
using GBEmulator.GBE.Processor.Instructions;
using GBEmulator.GBE.Processor.Instructions.Extended;

namespace GBEmulator.GBE.Processor
{
    public class Processor
    {

        public const byte BIT_0 = 0b00000001;
        public const byte BIT_1 = 0b00000010;
        public const byte BIT_2 = 0b00000100;
        public const byte BIT_3 = 0b00001000;
        public const byte BIT_4 = 0b00010000;
        public const byte BIT_5 = 0b00100000;
        public const byte BIT_6 = 0b01000000;
        public const byte BIT_7 = 0b10000000;

        public const byte FLAG_ZERO       = BIT_7;
        public const byte FLAG_SUB        = BIT_6;
        public const byte FLAG_HALF_CARRY = BIT_5;
        public const byte FLAG_CARRY      = BIT_4;

        public const byte INTERRUPT_VBLANK   = BIT_0;
        public const byte INTERRUPT_LCD_STAT = BIT_1;
        public const byte INTERRUPT_TIMER    = BIT_2;
        public const byte INTERRUPT_SERIAL   = BIT_3;
        public const byte INTERRUPT_JOYPAD   = BIT_4;

        public static IInstruction[] InstructionMap = CreateInstructionMap();
        public static IInstruction[] CBInstructionMap = CreateCBInstructionMap();

        public Registers registers;
        public MemoryManager memory;
        public int cycles;
        public MemoryRegister interruptEnableRegister;
        public MemoryRegister interruptFlagRegister;
        public bool interruptsMasterEnable;

        public bool crashed = false;

        public int totalInstructionsRan = 0;

        public string[] lastInstructions = new string[100];
        public int lastInstructionLog = 0;

        public Processor(MemoryManager memManager)
        {
            registers = new Registers();

            interruptsMasterEnable = false;
            interruptEnableRegister = new MemoryRegister(0xFFFF);
            interruptFlagRegister = new MemoryRegister(0xFF0F);

            memory = memManager;
            memory.Add(interruptEnableRegister);
            memory.Add(interruptFlagRegister);

            cycles = 0;
        }

        public void Execute()
        {
            if (crashed) return;
            if(interruptsMasterEnable)
            {
                if(HandleInterrupt(INTERRUPT_VBLANK,   0x40)) goto SkipInterrupts;
                if(HandleInterrupt(INTERRUPT_LCD_STAT, 0x48)) goto SkipInterrupts;
                if(HandleInterrupt(INTERRUPT_TIMER,    0x50)) goto SkipInterrupts;
                if(HandleInterrupt(INTERRUPT_SERIAL,   0x58)) goto SkipInterrupts;
                if(HandleInterrupt(INTERRUPT_JOYPAD,   0x60)) goto SkipInterrupts;
                SkipInterrupts:;
            }
            byte opcode = memory.Read(registers.PC++);
            try
            {
                IInstruction instruction = InstructionMap[opcode];
                instruction.Execute(this);
                if(opcode != 0xCB) LogInstruction("0x" + (registers.PC-1).ToString("X") + ": " + instruction.GetType().Name);
                cycles += instruction.Duration();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Unknown instruction: 0x" + opcode.ToString("X"));
                Console.WriteLine("I have executed " + totalInstructionsRan + " instructions so far.");
                crashed = true;
            }
            totalInstructionsRan++;
        }

        public void PrefixExecute()
        {
            byte opcode = memory.Read(registers.PC++);
            try
            {
                IInstruction instruction = CBInstructionMap[opcode];
                instruction.Execute(this);
                LogInstruction("0x" + (registers.PC - 2).ToString("X") + ": " + instruction.GetType().Name);
                cycles += instruction.Duration();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown instruction: 0xCB" + opcode.ToString("X"));
                crashed = true;
            }
        }

        public void LogInstruction(string str)
        {
            lastInstructions[(lastInstructionLog++)%lastInstructions.Length] = str;
        }

        public bool HandleInterrupt(byte interrupt, byte vector)
        {
            if (GetEnableInterrupt(interrupt) && GetInterruptWaiting(interrupt))
            {
                cycles += 5;
                WordPushStack(registers.PC);
                registers.PC_HIGH = 0;
                registers.PC_LOW = vector;
                interruptsMasterEnable = false;
                ClearInterrupt(interrupt);
                return true;
            }
            return false;
        }

        public void EnableInterrupts()
        {
            interruptsMasterEnable = true;
        }

        public void DisableInterrupts()
        {
            interruptsMasterEnable = false;
        }

        public bool GetInterruptWaiting(byte flag)
        {
            return (interruptFlagRegister.value & flag) != 0;
        }

        public void SetEnableInterrupt(byte flag, bool state) {
            if (state) {
                interruptEnableRegister.value |= flag; ;
            }
            else
            {
                interruptEnableRegister.value &= (byte)~flag;
            }
        }

        public bool GetEnableInterrupt(byte flag)
        {
            return (interruptEnableRegister.value & flag) != 0;
        }

        public void SetInterrupt(byte flag)
        {
            interruptFlagRegister.value |= flag;
        }

        public void ClearInterrupt(byte flag)
        {
            interruptFlagRegister.value &= (byte)~flag;
        }

        public void SetFlag(byte flag, bool state)
        {
            if(state)
            {
                registers.F |= flag;
            }
            else
            {
                registers.F &= (byte)~flag;
            }
        }

        public bool GetFlag(byte flag)
        {
            return (registers.F & flag) != 0;
        }

        public byte _GetFlag(byte flag)
        {
            return (byte)(registers.F & flag);
        }

        public void BytePushStack(byte value)
        {
            memory.Write(registers.SP--, value);
        }

        public byte BytePopStack()
        {
            return memory.Read(++registers.SP);
        }

        public void WordPushStack(ushort value)
        {
            BytePushStack((byte)((value >> 8) & 0xFF));
            BytePushStack((byte)(value & 0xFF));
        }

        public ushort WordPopStack()
        {
            return AssembleWord(BytePopStack(), BytePopStack());
        }

        public static bool CheckAddCarry(byte a, byte b)
        {
            return ((a & 0xFF) + (b & 0xF)) > 0xFF;
        }

        public static bool CheckSubCarry(byte a, byte b)
        {
            return ((a & 0xFF) - (b & 0xFF)) < 0;
        }

        public static bool CheckAddHalfCarry(byte a, byte b)
        {
            return ((a & 0xF) + (b & 0xF)) > 0xF;
        }

        public static bool CheckSubHalfCarry(byte a, byte b)
        {
            return ((a & 0xF) - (b & 0xF)) < 0;
        }

        public static bool Check16AddCarry(ushort a, ushort b)
        {
            return ((a & 0xFFFF) + (b & 0xFFFF)) > 0xFFFF;
        }

        public static bool Check16SubCarry(ushort a, ushort b)
        {
            return ((a & 0xFFFF) - (b & 0xFFFF)) < 0;
        }

        public static bool Check16AddHalfCarry(ushort a, ushort b)
        {
            return ((a & 0xFFF) + (b & 0xFFF)) > 0xFFF;
        }

        public static bool Check16SubHalfCarry(ushort a, ushort b)
        {
            return ((a & 0xFFF) - (b & 0xFFF)) < 0;
        }

        public static ushort AssembleWord(byte high, byte low)
        {
            return (ushort)(low | (high << 8));
        }

        public static ushort AssembleWordReverse(byte low, byte high)
        {
            return AssembleWord(high, low);
        }

        public static void OP_ADDrr_rr(Processor processor, ref ushort rra, ref ushort rrb)
        {
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_HALF_CARRY, Check16AddHalfCarry(rra, rrb));
            processor.SetFlag(FLAG_CARRY, Check16AddCarry(rra, rrb));
            rra += rrb;
        }

        public static void OP_INCr(Processor processor, ref byte r)
        {
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_HALF_CARRY, CheckAddHalfCarry(r++, 1));
            processor.SetFlag(FLAG_ZERO, r == 0);
        }

        public static void OP_DECr(Processor processor, ref byte r)
        {
            processor.SetFlag(FLAG_HALF_CARRY, CheckSubHalfCarry(r--, 1));
            processor.SetFlag(FLAG_ZERO, r == 0);
            processor.SetFlag(FLAG_SUB, true);
        }

        public static void OP_DECrr(Processor processor, ref ushort rr)
        {
            rr--;
        }

        public static void OP_INCrr(Processor processor, ref ushort rr)
        {
            rr++;
        }

        public static void OP_LDrr_u16(Processor processor, ref ushort rr)
        {
            rr = AssembleWordReverse(processor.memory.Read(processor.registers.PC++), processor.memory.Read(processor.registers.PC++));
        }

        public static void OP_LDmrr_r(Processor processor, ref ushort rr, ref byte r)
        {
            processor.memory.Write(rr, r);
        }

        public static void OP_LDr_u8(Processor processor, ref byte r)
        {
            r = processor.memory.Read(processor.registers.PC++);
        }

        public static void OP_LDr_mrr(Processor processor, ref byte r, ref ushort rr)
        {
            r = processor.memory.Read(rr);
        }

        public static void OP_LDmu16_rr(Processor processor, ref ushort rr)
        {
            ushort address = AssembleWordReverse(processor.memory.Read(processor.registers.PC++), processor.memory.Read(processor.registers.PC++));
            processor.memory.Write(address, (byte)(rr & 0xFF));
            processor.memory.Write(address+1, (byte)((rr >> 8) & 0xFF));
        }

        public static void OP_LDr_r(Processor processor, ref byte ra, ref byte rb)
        {
            ra = rb;
        }

        public static void OP_ADDr_r(Processor processor, ref byte ra, ref byte rb)
        {
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_CARRY, CheckAddCarry(ra, rb));
            processor.SetFlag(FLAG_HALF_CARRY, CheckAddHalfCarry(ra, rb));
            ra += rb;
            processor.SetFlag(FLAG_ZERO, ra == 0);
        }

        public static void OP_ADDr_mrr(Processor processor, ref byte r, ref ushort rr)
        {
            byte mem = processor.memory.Read(rr);
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_CARRY, CheckAddCarry(r, mem));
            processor.SetFlag(FLAG_HALF_CARRY, CheckAddHalfCarry(r, mem));
            r += mem;
            processor.SetFlag(FLAG_ZERO, r == 0);

        }

        public static void OP_ORr_r(Processor processor, ref byte ra, ref byte rb)
        {
            processor.SetFlag(FLAG_ZERO, (ra | rb) == 0);
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_HALF_CARRY, false);
            processor.SetFlag(FLAG_CARRY, false);
        }

        public static void OP_XORr_r(Processor processor, ref byte ra, ref byte rb)
        {
            ra ^= rb;
            processor.SetFlag(FLAG_ZERO, ra == 0);
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_HALF_CARRY, false);
            processor.SetFlag(FLAG_CARRY, false);
        }

        public static void OP_POPrr(Processor processor, ref ushort rr)
        {
            rr = processor.WordPopStack();
        }

        public static void OP_PUSHrr(Processor processor, ref ushort rr)
        {
            processor.WordPushStack(rr);
        }

        public static void OP_LDma16_r(Processor processor, ref byte r)
        {
            processor.memory.Write(AssembleWordReverse(processor.memory.Read(processor.registers.PC++), processor.memory.Read(processor.registers.PC++)), r);
        }

        public static void OP_RLA(Processor processor)
        {
            byte carryIn = processor._GetFlag(FLAG_CARRY);
            byte carryOut = (byte)(processor.registers.A & BIT_7);
            processor.registers.A = (byte)((processor.registers.A << 1) + carryIn);
            processor.SetFlag(FLAG_ZERO, false);
            processor.SetFlag(FLAG_SUB, false);
            processor.SetFlag(FLAG_HALF_CARRY, false);
            processor.SetFlag(FLAG_CARRY, carryOut != 0);
        }

        public static IInstruction[] CreateInstructionMap()
        {
            IInstruction[] insts = new IInstruction[0xFF+1];
            insts[0x00] = new OP00_NOP();
            insts[0x01] = new OP01_LDBCu16();
            insts[0x02] = new OP02_LD_BC_A();
            insts[0x03] = new OP03_INCBC();
            insts[0x04] = new OP04_INCB();
            insts[0x05] = new OP05_DECB();
            insts[0x06] = new OP06_LDBu8();

            insts[0x08] = new OP08_LD_a16_SP();
            insts[0x09] = new OP09_ADDHLBC();
            insts[0x0A] = new OP0A_LDA_BC_();
            insts[0x0B] = new OP0B_DECBC();
            insts[0x0C] = new OP0C_INCC();
            insts[0x0D] = new OP0D_DECC();
            insts[0x0E] = new OP0E_LDCu8();

            
            insts[0x11] = new OP11_LDDEu16();
            insts[0x12] = new OP12_LD_DE_A();
            insts[0x13] = new OP13_INCDE();
            insts[0x14] = new OP14_INCD();
            insts[0x15] = new OP15_DECD();
            insts[0x16] = new OP16_LDDu8();
            insts[0x17] = new OP17_RLA();
            insts[0x18] = new OP18_JRr8();

            insts[0x1A] = new OP1A_LDA_DE_();
            insts[0x1B] = new OP1B_DECDE();

            insts[0x1D] = new OP1D_DECE();

            insts[0x20] = new OP20_JRNZr8();
            insts[0x21] = new OP21_LDHLu16();
            insts[0x22] = new OP22_LD_HL__A();
            insts[0x23] = new OP23_INCHL();

            insts[0x25] = new OP25_DECH();

            insts[0x28] = new OP28_JRZr8();
            insts[0x29] = new OP29_ADDHLHL();

            insts[0x2B] = new OP2B_DECHL();

            insts[0x2E] = new OP2E_LDLu8();

            insts[0x31] = new OP31_LDSPu16();
            insts[0x32] = new OP32_LD_HL__A();
            insts[0x33] = new OP33_INCSP();

            insts[0x3A] = new OP3A_LDA_HL__();
            insts[0x3B] = new OP3B_DECSP();

            insts[0x3D] = new OP3D_DECA();
            insts[0x3E] = new OP3E_LDAu8();

            insts[0x40] = new OP40_LDBB();
            insts[0x41] = new OP41_LDBC();
            insts[0x42] = new OP42_LDBD();
            insts[0x43] = new OP43_LDBE();
            insts[0x44] = new OP44_LDBH();
            insts[0x45] = new OP45_LDBL();

            insts[0x47] = new OP47_LDBA();
            insts[0x48] = new OP48_LDCB();
            insts[0x49] = new OP49_LDCC();
            insts[0x4A] = new OP4A_LDCD();
            insts[0x4B] = new OP4B_LDCE();
            insts[0x4C] = new OP4C_LDCH();
            insts[0x4D] = new OP4D_LDCL();

            insts[0x4F] = new OP4F_LDCA();

            insts[0x50] = new OP50_LDDB();
            insts[0x51] = new OP51_LDDC();
            insts[0x52] = new OP52_LDDD();
            insts[0x53] = new OP53_LDDE();
            insts[0x54] = new OP54_LDDH();
            insts[0x55] = new OP55_LDDL();

            insts[0x57] = new OP57_LDDA();
            insts[0x58] = new OP58_LDEB();
            insts[0x59] = new OP59_LDEC();
            insts[0x5A] = new OP5A_LDED();
            insts[0x5B] = new OP5B_LDEE();
            insts[0x5C] = new OP5C_LDEH();
            insts[0x5D] = new OP5D_LDEL();

            insts[0x67] = new OP67_LDHA();
            insts[0x68] = new OP68_LDLB();
            insts[0x69] = new OP69_LDLC();
            insts[0x6A] = new OP6A_LDLD();
            insts[0x6B] = new OP6B_LDLE();
            insts[0x6C] = new OP6C_LDLH();
            insts[0x6D] = new OP6D_LDLL();

            insts[0x77] = new OP77_LD_HL_A();
            insts[0x78] = new OP78_LDAB();

            insts[0x80] = new OP80_ADDAB();
            insts[0x81] = new OP81_ADDAC();
            insts[0x82] = new OP82_ADDAD();
            insts[0x83] = new OP83_ADDAE();
            insts[0x84] = new OP84_ADDAH();
            insts[0x85] = new OP85_ADDAL();
            insts[0x86] = new OP86_ADDA_HL_();
            insts[0x87] = new OP87_ADDAA();

            insts[0x99] = new OP99_SBCAC();

            insts[0xA8] = new OPA8_XORB();
            insts[0xA9] = new OPA9_XORC();
            insts[0xAA] = new OPAA_XORD();
            insts[0xAB] = new OPAB_XORE();
            insts[0xAC] = new OPAC_XORH();

            insts[0xAF] = new OPAF_XORA();

            insts[0xB1] = new OPB1_ORAC();

            insts[0xC0] = new OPC0_RETNZ();
            insts[0xC1] = new OPC1_POPBC();

            insts[0xC5] = new OPC5_PUSHBC();

            insts[0xC9] = new OPC9_RET();

            insts[0xCB] = new OPCB_PREFIX();

            insts[0xCD] = new OPCD_CALLa16();

            insts[0xDC] = new OPDC_CALLCd16();

            insts[0xE0] = new OPE0_LD_FF00_u8_A();

            insts[0xE2] = new OPE2_LD_FF00_C_A();

            insts[0xE6] = new OPE6_ANDAu8();

            insts[0xEA] = new OPEA_LD_a16_A();

            insts[0xF3] = new OPF3_DI();

            insts[0xFF] = new OPFF_RST38H();
            
            return insts;
        }

        public static IInstruction[] CreateCBInstructionMap()
        {
            IInstruction[] insts = new IInstruction[0xFF];

            insts[0x11] = new OPCB11_RLC();

            insts[0x7C] = new OPCB7C_BIT7H();

            return insts;
        }
    }
}
