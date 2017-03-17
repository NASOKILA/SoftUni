using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Diamond
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 5 * n;
            int height = (3 * n) + 2;

            Console.Write(new string('.', n));
            Console.Write(new string('*', n * 3));
            Console.WriteLine(new string('.', n));

            int counter = 0;
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(new string('.', n-1-i));
                Console.Write("*");
                Console.Write(new string('.', (n * 3) + counter));
                counter += 2;
                Console.Write("*");
                Console.WriteLine(new string('.', n - 1 - i));
            }

            Console.WriteLine(new string('*',width));

            int counter2 = 0;
            for (int i = 0; i < n*2; i++)
            {
                Console.Write(new string('.', i + 1));
                Console.Write("*");
                Console.Write(new string('.', width - 4 - counter2));
                counter2 += 2;
                Console.Write("*");
                Console.WriteLine(new string('.', i + 1));
            }

            Console.Write(new string('.', n * 2 + 1));
            Console.Write(new string('*', n-2));
            Console.WriteLine(new string('.', n * 2 + 1));

        }
    }
}
