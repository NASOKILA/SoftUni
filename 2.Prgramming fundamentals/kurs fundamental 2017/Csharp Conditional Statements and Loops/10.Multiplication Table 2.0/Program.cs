using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            if (n <= 10)
            {
                for (int i = n; i < 11; i++)
                {
                    Console.WriteLine($"{num} X {i} = {num * i}");
                }
            }
            else
                Console.WriteLine($"{num} X {n} = {num * n}");

            
        }
    }
}
