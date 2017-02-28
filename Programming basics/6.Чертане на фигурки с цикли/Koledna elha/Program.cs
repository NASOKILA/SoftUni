using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koledna_elha
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string(' ', n + 1) + "|");

            for (int i = 1; i <= n; i++)  // n puti
            {

                for (int j = 1; j < 2; j++)
                {          
                    Console.Write(new string(' ', n - i));
                    Console.Write(new string('*', i));    // i zapochva ot 0 znachi edna zvezdichka
                    Console.Write(' ');
                    Console.Write('|');
                    Console.Write(' ');
                    Console.Write(new string('*', i));

                }
                Console.WriteLine();               

            }
        }
    }
}
