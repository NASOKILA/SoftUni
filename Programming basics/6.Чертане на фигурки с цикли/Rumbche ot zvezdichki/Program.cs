using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumbche_ot_zvezdichki
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            

            for (int i = 1; i <= n; i++)
            {
                var line = new string(' ',  n - i); // purvi red
                Console.Write(line);

                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                    Console.Write(" ");
                }
                Console.WriteLine();
                
            }
            for (int i = 0; i < n - 1; i++)
            {

                Console.Write(new string(' ', i + 1) + "*");
                for (int j = n-1; j > i+1 ; j--)
                {
                    Console.Write(" ");
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
