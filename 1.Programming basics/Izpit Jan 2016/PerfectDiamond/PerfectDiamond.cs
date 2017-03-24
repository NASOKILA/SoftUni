using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDiamond
{
    class PerfectDiamond
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("*");
                return;
            }

            Console.Write(new string(' ', n - 1));
            Console.WriteLine("*");

            for (int i = 1; i < n; i++)
            {
                Console.Write(new string(' ', n - 1 - i));

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*-");                    
                }
                Console.WriteLine("*");
              
            }

            for (int i = 1; i < n-1; i++)
            {
                Console.Write(new string(' ', i));
                for (int j = n-i; j > 1; j--)
                {
                    Console.Write("*-");
                }
                Console.WriteLine("*");
            }
            Console.Write(new string(' ', n - 1));
            Console.WriteLine("*");

        }
    }
}
