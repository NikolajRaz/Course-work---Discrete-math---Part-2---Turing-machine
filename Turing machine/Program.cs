using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_machine
{
    class Machine
    {
        private string[] states = new string[30];
        private int statescount;
        private string[] instructions = new string[100];
        private int instructcount;
        private char[] bandf = new char[999];
        private string band;
        private int cursor;
        private string currstate;
        private int gflag;
        public Machine()
        {
            int i = 0;
            Console.Write("Enter start state(Format example - q01): ");
            currstate = Console.ReadLine();
            Console.WriteLine("Enter states:(Enter -, to stop entering, format example - q01) ");
            string b = "n";
            while (b != "-")
            {
                Console.Write("Enter {0} state: ", i + 1);
                b = Console.ReadLine();
                Console.WriteLine();
                if (b != "-")
                {
                    i++;
                    states[i] = b;
                }
            }
            statescount = i;
            i = 0;
            Console.WriteLine("Enter instructions:(Enter -, to stop entering, format example q01/q02*>, <-LEFT, >-RIGHT, any other symbol - DO NOTHING) ");
            b = "n";
            while (b != "-")
            {
                Console.Write("Enter {0} instruction: ", i + 1);
                b = Console.ReadLine();
                Console.WriteLine();
                if (b != "-")
                {
                    i++;
                    instructions[i] = b;
                }
            }
            instructcount = i;

        }

        private void bandenter()
        {
            Console.WriteLine("Enter band, using alphabet: ");
            band = Console.ReadLine();
            int i = 0;
            for(i = 0; i<band.Length;i++)
            {
                bandf[i] = band[i];
            }
        }

        private void shift(string a)
        {
            char b = a[8];
            if (b == '<')
                cursor--;
            else
            {
                if (b == '>')
                    cursor++;
                else
                    gflag++;
            }
        }
        private char replace(char a)
        {
            string c = Char.ToString(a);
            char b = 'n';
            int i = 0;
            int flag = 0;
            while(flag != 1)
            {
                i++;
                if (instructions[i].IndexOf(currstate) == 0 && instructions[i].IndexOf(c) == 3)
                {
                    b = instructions[i][7];
                    shift(instructions[i]);
                    currstate = instructions[i].Substring(4);
                    currstate = currstate.Substring(0, 3);
                    flag++;
                }
            }
            return b;
        }

        private void cursprint()
        {
            for(int i = 0; i<band.Length; i++)
            {
                if(i == cursor)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(bandf[i]);
                    Console.ResetColor();
                }
                else
                    Console.Write(bandf[i]);
            }
        }
        public void doit()
        {
            bandenter();
            cursor = 0;
            gflag = 0;
            int i = 0;
            cursprint();
            Console.WriteLine();
            while (gflag != 1)
            {
                bandf[cursor] = replace(bandf[cursor]);
                cursprint();
                Console.WriteLine();
            }
            Console.WriteLine(bandf);//9
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Machine mach = new Machine();
            mach.doit();
            Console.Read();
        }
    }
}
