using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmulator.GBE
{
    public class Decompiler
    {

        string[] assembly;
        byte[] data;

        public Decompiler(byte[] data)
        {
            this.data = data;
        }

        public void Decompile()
        {
            List<string> assembly = new List<string>();
            int i = 0;
            while(i < data.Length)
            {
                switch(data[i++])
                {
                    default:
                        assembly.Add("Unrecognized instruction: " + data[i].ToString("X"));
                        break;
                    case 0x00:
                        assembly.Add("NOP");
                        break;
                    case 0x01:
                        assembly.Add("LD BC, $"+AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0x02:
                        assembly.Add("LD (BC), A");
                        break;
                    case 0x03:
                        assembly.Add("INC BC");
                        break;
                    case 0x04:
                        assembly.Add("INC B");
                        break;
                    case 0x05:
                        assembly.Add("DEC B");
                        break;
                    case 0x06:
                        assembly.Add("LD B, $" + data[i++].ToString("X"));
                        break;
                    case 0x07:
                        assembly.Add("RLCA");
                        break;
                    case 0x08:
                        assembly.Add("LD ($"+AssembleWord(data[i++], data[i++]).ToString("X") + "), SP");
                        break;
                    case 0x09:
                        assembly.Add("ADD HL, BC");
                        break;
                    case 0x0A:
                        assembly.Add("LD A, (BC)");
                        break;
                    case 0x0B:
                        assembly.Add("DEC BC");
                        break;
                    case 0x0C:
                        assembly.Add("INC C");
                        break;
                    case 0x0D:
                        assembly.Add("DEC C");
                        break;
                    case 0x0E:
                        assembly.Add("LD C, $" + data[i++].ToString("X"));
                        break;
                    case 0x0F:
                        assembly.Add("RRCA");
                        break;
                    case 0x10:
                        assembly.Add("STOP");
                        i++;
                        break;
                    case 0x11:
                        assembly.Add("LD DE, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0x12:
                        assembly.Add("LD (DE), A");
                        break;
                    case 0x13:
                        assembly.Add("INC DE");
                        break;
                    case 0x14:
                        assembly.Add("INC D");
                        break;
                    case 0x15:
                        assembly.Add("DEC D");
                        break;
                    case 0x016:
                        assembly.Add("LD D, $" + data[i++].ToString("X"));
                        break;
                    case 0x17:
                        assembly.Add("RLA");
                        break;
                    case 0x18:
                        assembly.Add("JR $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0x19:
                        assembly.Add("ADD HL, DE");
                        break;
                    case 0x1A:
                        assembly.Add("LD A, (DE)");
                        break;
                    case 0x1B:
                        assembly.Add("DEC DE");
                        break;
                    case 0x1C:
                        assembly.Add("INC E");
                        break;
                    case 0x1D:
                        assembly.Add("DEC E");
                        break;
                    case 0x1E:
                        assembly.Add("LD E, $"+data[i++].ToString("X"));
                        break;
                    case 0x1F:
                        assembly.Add("RRA");
                        break;
                    case 0x20:
                        assembly.Add("JR NZ, $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0x21:
                        assembly.Add("LD HL, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0x22:
                        assembly.Add("LD (HL+), A");
                        break;
                    case 0x23:
                        assembly.Add("INC HL");
                        break;
                    case 0x24:
                        assembly.Add("INC H");
                        break;
                    case 0x25:
                        assembly.Add("DEC H");
                        break;
                    case 0x26:
                        assembly.Add("LD H, " + data[i++].ToString("X"));
                        break;
                    case 0x27:
                        assembly.Add("DAA");
                        break;
                    case 0x28:
                        assembly.Add("JR Z, $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0x29:
                        assembly.Add("ADD HL, HL");
                        break;
                    case 0x2A:
                        assembly.Add("LD A, (HL+)");
                        break;
                    case 0x2B:
                        assembly.Add("DEC HL");
                        break;
                    case 0x2C:
                        assembly.Add("INC L");
                        break;
                    case 0x2D:
                        assembly.Add("DEC L");
                        break;
                    case 0x2E:
                        assembly.Add("LD L, $" + data[i++].ToString("X"));
                        break;
                    case 0x2F:
                        assembly.Add("CPL");
                        break;
                    case 0x30:
                        assembly.Add("JR NC, $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0x31:
                        assembly.Add("LD SP, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0x32:
                        assembly.Add("LD (HL-), A");
                        break;
                    case 0x33:
                        assembly.Add("INC SP");
                        break;
                    case 0x34:
                        assembly.Add("INC (HL)");
                        break;
                    case 0x35:
                        assembly.Add("DEC (HL)");
                        break;
                    case 0x36:
                        assembly.Add("LD (HL), $" + data[i++].ToString("X"));
                        break;
                    case 0x37:
                        assembly.Add("SCF");
                        break;
                    case 0x38:
                        assembly.Add("JR C, $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0x39:
                        assembly.Add("ADD HL, SP");
                        break;
                    case 0x3A:
                        assembly.Add("LD A, (HL-)");
                        break;
                    case 0x3B:
                        assembly.Add("DEC SP");
                        break;
                    case 0x3C:
                        assembly.Add("INC A");
                        break;
                    case 0x3D:
                        assembly.Add("DEC A");
                        break;
                    case 0x3E:
                        assembly.Add("LD A, $" + data[i++].ToString("X"));
                        break;
                    case 0x3F:
                        assembly.Add("CCF");
                        break;
                    case 0x40:
                        assembly.Add("LD B, B");
                        break;
                    case 0x41:
                        assembly.Add("LD B, C");
                        break;
                    case 0x42:
                        assembly.Add("LD B, D");
                        break;
                    case 0x43:
                        assembly.Add("LD B, E");
                        break;
                    case 0x44:
                        assembly.Add("LD B, H");
                        break;
                    case 0x45:
                        assembly.Add("LD B, L");
                        break;
                    case 0x46:
                        assembly.Add("LD B, (HL)");
                        break;
                    case 0x47:
                        assembly.Add("LD B, A");
                        break;
                    case 0x48:
                        assembly.Add("LD C, B");
                        break;
                    case 0x49:
                        assembly.Add("LD C, C");
                        break;
                    case 0x4A:
                        assembly.Add("LD C, D");
                        break;
                    case 0x4B:
                        assembly.Add("LD C, E");
                        break;
                    case 0x4C:
                        assembly.Add("LD C. H");
                        break;
                    case 0x4D:
                        assembly.Add("LD C, L");
                        break;
                    case 0x4E:
                        assembly.Add("LD C, (HL)");
                        break;
                    case 0x4F:
                        assembly.Add("LD C, A");
                        break;
                    case 0x50:
                        assembly.Add("LD D, B");
                        break;
                    case 0x51:
                        assembly.Add("LD D, C");
                        break;
                    case 0x52:
                        assembly.Add("LD D, D");
                        break;
                    case 0x53:
                        assembly.Add("LD D, E");
                        break;
                    case 0x54:
                        assembly.Add("LD D, H");
                        break;
                    case 0x55:
                        assembly.Add("LD D, L");
                        break;
                    case 0x56:
                        assembly.Add("LD D, (HL)");
                        break;
                    case 0x57:
                        assembly.Add("LD D, A");
                        break;
                    case 0x58:
                        assembly.Add("LD E, B");
                        break;
                    case 0x59:
                        assembly.Add("LD E, C");
                        break;
                    case 0x5A:
                        assembly.Add("LD E, D");
                        break;
                    case 0x5B:
                        assembly.Add("LD E, E");
                        break;
                    case 0x5C:
                        assembly.Add("LD E, H");
                        break;
                    case 0x5D:
                        assembly.Add("LD E, L");
                        break;
                    case 0x5E:
                        assembly.Add("LD E, (HL)");
                        break;
                    case 0x5F:
                        assembly.Add("LD E, A");
                        break;
                    case 0x60:
                        assembly.Add("LD H, B");
                        break;
                    case 0x61:
                        assembly.Add("LD H, C");
                        break;
                    case 0x62:
                        assembly.Add("LD H, D");
                        break;
                    case 0x63:
                        assembly.Add("LD H, E");
                        break;
                    case 0x64:
                        assembly.Add("LD H, H");
                        break;
                    case 0x65:
                        assembly.Add("LD H, L");
                        break;
                    case 0x66:
                        assembly.Add("LD H, (HL)");
                        break;
                    case 0x67:
                        assembly.Add("LD H, A");
                        break;
                    case 0x68:
                        assembly.Add("LD L, B");
                        break;
                    case 0x69:
                        assembly.Add("LD L, C");
                        break;
                    case 0x6A:
                        assembly.Add("LD L, D");
                        break;
                    case 0x6B:
                        assembly.Add("LD L, E");
                        break;
                    case 0x6C:
                        assembly.Add("LD L, H");
                        break;
                    case 0x6D:
                        assembly.Add("LD L, L");
                        break;
                    case 0x6E:
                        assembly.Add("LD L, (HL)");
                        break;
                    case 0x6F:
                        assembly.Add("LD L, A");
                        break;
                    case 0x70:
                        assembly.Add("LD (HL), B");
                        break;
                    case 0x71:
                        assembly.Add("LD (HL), C");
                        break;
                    case 0x72:
                        assembly.Add("LD (HL), D");
                        break;
                    case 0x73:
                        assembly.Add("LD (HL), E");
                        break;
                    case 0x74:
                        assembly.Add("LD (HL), H");
                        break;
                    case 0x75:
                        assembly.Add("LD (HL), L");
                        break;
                    case 0x76:
                        assembly.Add("HALT");
                        break;
                    case 0x77:
                        assembly.Add("LD (HL), A");
                        break;
                    case 0x78:
                        assembly.Add("LD A, B");
                        break;
                    case 0x79:
                        assembly.Add("LD A, C");
                        break;
                    case 0x7A:
                        assembly.Add("LD A, D");
                        break;
                    case 0x7B:
                        assembly.Add("LD A, E");
                        break;
                    case 0x7C:
                        assembly.Add("LD A, H");
                        break;
                    case 0x7D:
                        assembly.Add("LD A, L");
                        break;
                    case 0x7E:
                        assembly.Add("LD A, (HL)");
                        break;
                    case 0x7F:
                        assembly.Add("LD A, A");
                        break;
                    case 0x80:
                        assembly.Add("ADD A, B");
                        break;
                    case 0x81:
                        assembly.Add("ADD A, C");
                        break;
                    case 0x82:
                        assembly.Add("ADD A, D");
                        break;
                    case 0x83:
                        assembly.Add("ADD A, E");
                        break;
                    case 0x84:
                        assembly.Add("ADD A, H");
                        break;
                    case 0x85:
                        assembly.Add("ADD A, L");
                        break;
                    case 0x86:
                        assembly.Add("ADD A, (HL)");
                        break;
                    case 0x87:
                        assembly.Add("ADD A, A");
                        break;
                    case 0x88:
                        assembly.Add("ADC A, B");
                        break;
                    case 0x89:
                        assembly.Add("ADC A, C");
                        break;
                    case 0x8A:
                        assembly.Add("ADC A, D");
                        break;
                    case 0x8B:
                        assembly.Add("ADC A, E");
                        break;
                    case 0x8C:
                        assembly.Add("ADC A, H");
                        break;
                    case 0x8D:
                        assembly.Add("ADC A, L");
                        break;
                    case 0x8E:
                        assembly.Add("ADC A, (HL)");
                        break;
                    case 0x8F:
                        assembly.Add("ADC A, A");
                        break;
                    case 0x90:
                        assembly.Add("SUB A, B");
                        break;
                    case 0x91:
                        assembly.Add("SUB A, C");
                        break;
                    case 0x92:
                        assembly.Add("SUB A, D");
                        break;
                    case 0x93:
                        assembly.Add("SUB A, E");
                        break;
                    case 0x94:
                        assembly.Add("SUB A, H");
                        break;
                    case 0x95:
                        assembly.Add("SUB A, L");
                        break;
                    case 0x96:
                        assembly.Add("SUB A, (HL)");
                        break;
                    case 0x97:
                        assembly.Add("SUB A, A");
                        break;
                    case 0x98:
                        assembly.Add("SBC A, B");
                        break;
                    case 0x99:
                        assembly.Add("SBC A, C");
                        break;
                    case 0x9A:
                        assembly.Add("SBC A, D");
                        break;
                    case 0x9B:
                        assembly.Add("SBC A, E");
                        break;
                    case 0x9C:
                        assembly.Add("SBC A, H");
                        break;
                    case 0x9D:
                        assembly.Add("SBC A, L");
                        break;
                    case 0x9E:
                        assembly.Add("SBC A, (HL)");
                        break;
                    case 0x9F:
                        assembly.Add("SBC A, A");
                        break;
                    case 0xA0:
                        assembly.Add("AND A, B");
                        break;
                    case 0xA1:
                        assembly.Add("AND A, C");
                        break;
                    case 0xA2:
                        assembly.Add("AND A, D");
                        break;
                    case 0xA3:
                        assembly.Add("AND A, E");
                        break;
                    case 0xA4:
                        assembly.Add("AND A, H");
                        break;
                    case 0xA5:
                        assembly.Add("AND A, L");
                        break;
                    case 0xA6:
                        assembly.Add("AND A, (HL)");
                        break;
                    case 0xA7:
                        assembly.Add("AND A, A");
                        break;
                    case 0xA8:
                        assembly.Add("XOR A, B");
                        break;
                    case 0xA9:
                        assembly.Add("XOR A, C");
                        break;
                    case 0xAA:
                        assembly.Add("XOR A, D");
                        break;
                    case 0xAB:
                        assembly.Add("XOR A, E");
                        break;
                    case 0xAC:
                        assembly.Add("XOR A, H");
                        break;
                    case 0xAD:
                        assembly.Add("XOR A, L");
                        break;
                    case 0xAE:
                        assembly.Add("XOR A, (HL)");
                        break;
                    case 0xAF:
                        assembly.Add("XOR A, A");
                        break;
                    case 0xB0:
                        assembly.Add("OR A, B");
                        break;
                    case 0xB1:
                        assembly.Add("OR A, C");
                        break;
                    case 0xB2:
                        assembly.Add("OR A, D");
                        break;
                    case 0xB3:
                        assembly.Add("OR A, E");
                        break;
                    case 0xB4:
                        assembly.Add("OR A, H");
                        break;
                    case 0xB5:
                        assembly.Add("OR A, L");
                        break;
                    case 0xB6:
                        assembly.Add("OR A, (HL)");
                        break;
                    case 0xB7:
                        assembly.Add("OR A, A");
                        break;
                    case 0xB8:
                        assembly.Add("CP A, B");
                        break;
                    case 0xB9:
                        assembly.Add("CP A, C");
                        break;
                    case 0xBA:
                        assembly.Add("CP A, D");
                        break;
                    case 0xBB:
                        assembly.Add("CP A, E");
                        break;
                    case 0xBC:
                        assembly.Add("CP A, H");
                        break;
                    case 0xBD:
                        assembly.Add("CP A, L");
                        break;
                    case 0xBE:
                        assembly.Add("CP A, (HL)");
                        break;
                    case 0xBF:
                        assembly.Add("CP A, A");
                        break;
                    case 0xC0:
                        assembly.Add("RET NZ");
                        break;
                    case 0xC1:
                        assembly.Add("POP BC");
                        break;
                    case 0xC2:
                        assembly.Add("JP NZ, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xC3:
                        assembly.Add("JP $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xC4:
                        assembly.Add("CALL NZ, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xC5:
                        assembly.Add("PUSH BC");
                        break;
                    case 0xC6:
                        assembly.Add("ADD A, $" + data[i++].ToString("X"));
                        break;
                    case 0xC7:
                        assembly.Add("RST 00");
                        break;
                    case 0xC8:
                        assembly.Add("RET Z");
                        break;
                    case 0xC9:
                        assembly.Add("RET");
                        break;
                    case 0xCA:
                        assembly.Add("JP Z, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xCB:
                        switch(data[i++])
                        {
                            default:
                                assembly.Add("Unimplemented CB instruction: " + data[i].ToString("X"));
                                break;

                            case 0x7C:
                                assembly.Add("BIT 7, H");
                                break;
                        }
                        break;
                    case 0xCC:
                        assembly.Add("CALL Z, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xCD:
                        assembly.Add("CALL $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xCE:
                        assembly.Add("ADC A, $" + data[i++].ToString("X"));
                        break;
                    case 0xCF:
                        assembly.Add("RST 08");
                        break;
                    case 0xD0:
                        assembly.Add("RET NC");
                        break;
                    case 0xD1:
                        assembly.Add("POP DE");
                        break;
                    case 0xD2:
                        assembly.Add("JP NC, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xD3:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xD4:
                        assembly.Add("CALL NC, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xD5:
                        assembly.Add("PUSH DE");
                        break;
                    case 0xD6:
                        assembly.Add("SUB A, $" + data[i++].ToString("X"));
                        break;
                    case 0xD7:
                        assembly.Add("RST 10");
                        break;
                    case 0xD8:
                        assembly.Add("RET C");
                        break;
                    case 0xD9:
                        assembly.Add("RETI");
                        break;
                    case 0xDA:
                        assembly.Add("JP C, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xDB:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xDC:
                        assembly.Add("CALL C, $" + AssembleWord(data[i++], data[i++]).ToString("X"));
                        break;
                    case 0xDD:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xDE:
                        assembly.Add("SBC A, $" + data[i++].ToString("X"));
                        break;
                    case 0xDF:
                        assembly.Add("RST 18");
                        break;
                    case 0xE0:
                        assembly.Add("LD (FF00+$" + data[i++].ToString("X") + "), A");
                        break;
                    case 0xE1:
                        assembly.Add("POP HL");
                        break;
                    case 0xE2:
                        assembly.Add("LD (FF00+C), A");
                        break;
                    case 0xE3:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xE4:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xE5:
                        assembly.Add("PUSH HL");
                        break;
                    case 0xE6:
                        assembly.Add("AND A, $" + data[i++].ToString("X"));
                        break;
                    case 0xE7:
                        assembly.Add("RST 20");
                        break;
                    case 0xE8:
                        assembly.Add("ADD SP, $" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0xE9:
                        assembly.Add("JP HL");
                        break;
                    case 0xEA:
                        assembly.Add("LD ($" + AssembleWord(data[i++], data[i++]) + "), A");
                        break;
                    case 0xEB:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xEC:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xED:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xEE:
                        assembly.Add("XOR A, $" + data[i++].ToString("X"));
                        break;
                    case 0xEF:
                        assembly.Add("RST 28");
                        break;
                    case 0xF0:
                        assembly.Add("LD A, (FF00+$" + data[i++].ToString("X") + ")");
                        break;
                    case 0xF1:
                        assembly.Add("POP AF");
                        break;
                    case 0xF2:
                        assembly.Add("LD A, (FF00+C)");
                        break;
                    case 0xF3:
                        assembly.Add("DI");
                        break;
                    case 0xF4:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xF5:
                        assembly.Add("PUSH AF");
                        break;
                    case 0xF6:
                        assembly.Add("OR A, $" + data[i++].ToString("X"));
                        break;
                    case 0xF7:
                        assembly.Add("RST 30");
                        break;
                    case 0xF8:
                        assembly.Add("LD HL, SP+$" + data[i++].ToString("X") + " (SIGNED)");
                        break;
                    case 0xF9:
                        assembly.Add("LD SP, HL");
                        break;
                    case 0xFA:
                        assembly.Add("LD A, ($" + AssembleWord(data[i++], data[i++]).ToString("X") + ")");
                        break;
                    case 0xFB:
                        assembly.Add("EI");
                        break;
                    case 0xFC:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xFD:
                        assembly.Add("Unused instruction code");
                        break;
                    case 0xFE:
                        assembly.Add("CP A, $" + data[i++].ToString("X"));
                        break;
                    case 0xFF:
                        assembly.Add("RST 38");
                        break;
                }
            }
            this.assembly = assembly.ToArray<string>();
        }

        public ushort AssembleWord(byte low, byte high)
        {
            return (ushort)((high<<8) | low);
        }

        public string[] GetAssembly()
        {
            return assembly;
        }
    }
}
