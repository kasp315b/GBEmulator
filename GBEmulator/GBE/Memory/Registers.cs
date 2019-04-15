using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GBEmulator.GBE.Memory
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Registers
    {
        [FieldOffset(0)] public ushort AF;
        [FieldOffset(1)] public byte A;
        [FieldOffset(0)] public byte F;

        [FieldOffset(2)] public ushort BC;
        [FieldOffset(3)] public byte B;
        [FieldOffset(2)] public byte C;

        [FieldOffset(4)] public ushort DE;
        [FieldOffset(5)] public byte D;
        [FieldOffset(4)] public byte E;

        [FieldOffset(6)] public ushort HL;
        [FieldOffset(7)] public byte H;
        [FieldOffset(6)] public byte L;

        [FieldOffset(8)] public ushort PC;
        [FieldOffset(8)] public byte PC_LOW;
        [FieldOffset(9)] public byte PC_HIGH;

        [FieldOffset(10)] public ushort SP;
        [FieldOffset(10)] public byte SP_LOW;
        [FieldOffset(11)] public byte SP_HIGH;
    }
}
