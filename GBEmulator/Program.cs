using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GBEmulator.GBE.Memory;
using GBEmulator.GBE.Processor;
using GBEmulator.GBE.Graphics;

namespace GBEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            //GraphicsForm form = new GraphicsForm();
            //form.Show();

            MemoryManager mem = new MemoryManager();
            Processor proc = new Processor(mem);
            PPU ppu = new PPU(mem);

            int count = 1;
            bool wait = true;
            bool print = true;
            int checkpoint = 24645;

            while(true /*form.Visible*/)
            {
                if (!wait || count > 0)
                {
                    proc.Execute();

                    if (print)
                    {
                        Console.SetCursorPosition(0, 0);
                        StringBuilder screen = new StringBuilder();
                        screen.AppendLine("Instruction Log:   " + proc.totalInstructionsRan + "           ");
                        for (int i = 0; i < 25; i++)
                        {
                            int logindex = (proc.lastInstructionLog - i);
                            if (logindex < 0) logindex = logindex + proc.lastInstructions.Length;
                            string inst = proc.lastInstructions[logindex % proc.lastInstructions.Length];
                            if (inst == null) inst = "";
                            string regs;
                            switch (i)
                            {
                                case 0:
                                    regs = "Registers:";
                                    break;
                                case 1:
                                    regs = "0x" + proc.registers.A.ToString("X");
                                    regs = "A  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 2:
                                    regs = "0x" + proc.registers.B.ToString("X");
                                    regs = "B  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 3:
                                    regs = "0x" + proc.registers.C.ToString("X");
                                    regs = "C  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 4:
                                    regs = "0x" + proc.registers.D.ToString("X");
                                    regs = "D  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 5:
                                    regs = "0x" + proc.registers.E.ToString("X");
                                    regs = "E  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 6:
                                    regs = "0x" + proc.registers.F.ToString("X");
                                    regs = "F  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 7:
                                    regs = "0x" + proc.registers.AF.ToString("X");
                                    regs = "AF = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 8:
                                    regs = "0x" + proc.registers.BC.ToString("X");
                                    regs = "BC = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 9:
                                    regs = "0x" + proc.registers.DE.ToString("X");
                                    regs = "DE = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 10:
                                    regs = "0x" + proc.registers.PC.ToString("X");
                                    regs = "PC = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 11:
                                    regs = "0x" + proc.registers.SP.ToString("X");
                                    regs = "SP = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 12:
                                    regs = "0x" + proc.registers.H.ToString("X");
                                    regs = "H  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 13:
                                    regs = "0x" + proc.registers.L.ToString("X");
                                    regs = "L  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 14:
                                    regs = "0x" + proc.registers.HL.ToString("X");
                                    regs = "HL = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 20:
                                    regs = "Flags:";
                                    break;
                                case 21:
                                    regs = proc.GetFlag(Processor.FLAG_ZERO).ToString();
                                    regs = "ZERO  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 22:
                                    regs = proc.GetFlag(Processor.FLAG_SUB).ToString();
                                    regs = "SUB   = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 23:
                                    regs = proc.GetFlag(Processor.FLAG_HALF_CARRY).ToString();
                                    regs = "HALF  = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                case 24:
                                    regs = proc.GetFlag(Processor.FLAG_CARRY).ToString();
                                    regs = "CARRY = " + new string(' ', 9 - regs.Length) + regs;
                                    break;
                                default:
                                    regs = new string(' ', 40);
                                    break;
                            }
                            if (regs.Length < 40) regs = regs + new string(' ', 40 - regs.Length);
                            if (inst.Length < 30) inst = inst + new string(' ', 30 - inst.Length);
                            screen.AppendLine(inst + regs);
                        }
                        Console.Write(screen);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(proc.totalInstructionsRan.ToString() + "     ");
                    }

                    count--;
                }
                else
                {
                    Thread.Sleep(10);
                }

                if(Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch(key)
                    {
                        case ConsoleKey.Spacebar:
                            count = 1;
                            wait = true;
                            break;
                        case ConsoleKey.D1:
                            count += 10;
                            break;
                        case ConsoleKey.D2:
                            count += 100;
                            break;
                        case ConsoleKey.D3:
                            count += 1000;
                            break;
                        case ConsoleKey.D0:
                            count += checkpoint;
                            break;
                        case ConsoleKey.D4:
                            count += 10000;
                            break;
                        case ConsoleKey.P:
                            wait = !wait;
                            break;
                        case ConsoleKey.R:
                            Console.Clear();
                            print = !print;
                            break;
                    }
                }
                
                //Application.DoEvents();
            }
        }
    }
}
