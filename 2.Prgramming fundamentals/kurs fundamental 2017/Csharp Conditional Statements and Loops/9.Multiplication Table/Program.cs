using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"{num} X {i} = {num*i}");
            }

        }
    }
}
