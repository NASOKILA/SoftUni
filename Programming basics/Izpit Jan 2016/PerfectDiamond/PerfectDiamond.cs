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

            Console.Write(new string(' ', n - 1));
            Console.Write("*");

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                    Console.Write("_");

                }
                Console.Write("*");
            }

        }
    }
}
