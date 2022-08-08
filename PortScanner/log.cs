using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    internal class log
    {
        public static void sucess(string msg)
        {
            ConsoleColor cb = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("SUCCESS");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            ColorConsole.WriteEmbeddedColorLine(msg);
            Console.ForegroundColor = cb;
        }

        public static void error(string msg)
        {
            ConsoleColor cb = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("FAILED");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            ColorConsole.WriteEmbeddedColorLine(msg);
            Console.ForegroundColor = cb;
        }
    }
}
