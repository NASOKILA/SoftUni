using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfIntegerNumber
{
    class Program
    {

        static void PrintSign(int i)
        {
            if (i < 0)
            {
                Console.WriteLine("The number {0} is negative.", i);
            }
            else if (i > 0)
            {
                Console.WriteLine("The number {0} is positive.", i);
            }
            else if (i == 0)
            {
                Console.WriteLine("The number {0} is zero.",i);
            }

        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintSign(n);
        }
    }
}
