using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Peperuda
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char character = (char)92;

            for (int i = 0; i < n - 2; i++)
            {

                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write(character);
                    Console.Write(" ");
                    Console.Write("/");
                    Console.Write(new string('*', n - 2));
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write(character);
                    Console.Write(" ");
                    Console.Write("/");
                    Console.Write(new string('-', n - 2));
                }
                Console.WriteLine();
            }

            Console.Write(new string(' ', n - 1));
            Console.WriteLine("@");

            for (int i = 0; i < n - 2; i++)
            {

                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("/");
                    Console.Write(" ");
                    Console.Write(character);
                    Console.Write(new string('*', n - 2));
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("/");
                    Console.Write(" ");
                    Console.Write(character);
                    Console.Write(new string('-', n - 2));
                }
                Console.WriteLine();
            }

        }
    }
}
