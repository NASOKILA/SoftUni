using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_5_Christmas_hat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char character = (char)92;
                      
            // shapka:
                            
                Console.Write(new string('.', (n * 2) - 1));
                Console.Write("/"); 
                Console.Write("|");
                Console.Write(character);
                Console.WriteLine(new string('.', (n * 2) - 1));
            
                Console.Write(new string('.', (n * 2) - 1));
                Console.Write(character);
                Console.Write("|");
                Console.Write("/");
                Console.WriteLine(new string('.', (n * 2) - 1));

            // sredna chast: 
            int counter = 0;
            for (int i = 1; i <= n*2; i++)
            {
                Console.Write(new string('.', (n * 2) - i));
                Console.Write("*");
                Console.Write(new string('-', counter));
                Console.Write("*");
                Console.Write(new string('-', counter));
                Console.Write("*");
                Console.WriteLine(new string('.', (n * 2) - i));
                counter++;
            }

            // treta chast 
            Console.WriteLine(new string('*', (n * 4) + 1));
            Console.Write("*");
            for (int i = 0; i < 2* n; i++)
            {
                Console.Write(".*");
            }
            Console.WriteLine();
            Console.WriteLine(new string('*', (n * 4) + 1));

        }
    }
}
