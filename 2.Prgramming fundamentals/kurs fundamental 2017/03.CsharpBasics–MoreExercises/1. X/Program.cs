using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = n - 2; // 3

            // top part
            for (int i = 0; i < (n-1)/2; i++)
            {
                Console.Write(new string(' ', i));
                Console.Write("x");
                Console.Write(new string(' ', counter));
                Console.WriteLine("x");
                counter -= 2;
            }

            Console.Write(new string(' ', (n - 1) / 2));
            Console.WriteLine("x");


            int counter2 = ((n - 1) / 2) - 1;
            int counter3 = 1;
            // bottom part
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                Console.Write(new string(' ', counter2));
                Console.Write("x");
                Console.Write(new string(' ', counter3));
                Console.WriteLine("x");
                counter2--;
                counter3 += 2;
            }

        }
    }
}
