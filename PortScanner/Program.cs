using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortScanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Atomo -> PortScanner";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
██████╗  ██████╗ ██████╗ ████████╗    ███████╗ ██████╗ █████╗ ███╗   ██╗███╗   ██╗███████╗██████╗ 
██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝    ██╔════╝██╔════╝██╔══██╗████╗  ██║████╗  ██║██╔════╝██╔══██╗
██████╔╝██║   ██║██████╔╝   ██║       ███████╗██║     ███████║██╔██╗ ██║██╔██╗ ██║█████╗  ██████╔╝
██╔═══╝ ██║   ██║██╔══██╗   ██║       ╚════██║██║     ██╔══██║██║╚██╗██║██║╚██╗██║██╔══╝  ██╔══██╗
██║     ╚██████╔╝██║  ██║   ██║       ███████║╚██████╗██║  ██║██║ ╚████║██║ ╚████║███████╗██║  ██║
╚═╝      ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝
                                                                                                                                                 
Telegram: @Mahitozin
Github: https://github.com/Mahitozin

IMPORTANT!
use ',' to separe port, to add one range of port use '-'
Exemple!
    [ Ports -> 12,13-20 ] 
Will be equal to
    [ Ports -> 12,13,14,15,16,17,18,19,20 ]
");
            Console.ResetColor();
            string ip = input("Ip -> ");
            string porta = input("Ports -> ");
            string portas = convert(porta);

            foreach (string x in portas.Split(','))
            {
                try
                {
                    Socket s = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                    s.ReceiveTimeout = 1000;
                    s.Connect(ip, Convert.ToInt32(x));
                    foreach (string y in port.list.Split('|'))
                    {
                        if (y.Split(':')[0] == x.ToString())
                        {
                            log.sucess($"Port oppened -> [darkgreen]{x}[/darkgreen] Service -> [darkgreen]{y.Split(':')[1]}[/darkgreen]");
                        }
                    }
                }
                catch (SocketException ex)
                {
                    foreach (string y in port.list.Split('|'))
                    {
                        if (y.Split(':')[0] == x.ToString())
                        {
                            log.error($"Port closed -> [darkred]{x}[/darkred] Service -> [darkred]{y.Split(':')[1]}[/darkred]");
                        }
                    }
                }
            }
            Console.WriteLine("COMPLETED");
            Console.ReadLine();
        }

        static string input(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        static string convert(string input)
        {
            string portas = "";

            foreach (string x in input.Split(','))
            {
                if (x.Contains("-"))
                {
                    int min = int.Parse(x.Split('-')[0]);
                    int max = int.Parse(x.Split('-')[1]);

                    for (int i = min; i < max + 1; i++)
                    {
                        portas += i + ",";
                    }
                }
                else
                {
                    portas += x + ",";
                }
            }

            return portas.Remove(portas.Length - 1);
        }
    }
}