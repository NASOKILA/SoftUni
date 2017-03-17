using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop
{
    class Stop
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 3 && n > 1000)
                return;

            int length = (n + 1)* 2 + n*2 +1;


            Console.Write(new string('.', n+1));
            Console.Write(new string('_', (n * 2) + 1));
            Console.WriteLine(new string('.', n + 1));

            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', n - i));
                Console.Write("//");
                Console.Write(new string('_', (n*2)-1 + counter));
                counter += 2;
                Console.Write("\\\\");
                Console.WriteLine(new string('.', n - i));
            }

            Console.Write("//");
            Console.Write(new string('_', (length - 9) / 2));
            Console.Write("STOP!");
            Console.Write(new string('_', (length - 9) / 2));
            Console.WriteLine("\\\\");


            int counter2 = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', i));
                Console.Write("\\\\");
                Console.Write(new string('_', (length - 4 - counter2) ));
                counter2 += 2;

                Console.Write("//");
                Console.WriteLine(new string('.', i));

            }

        }
    }
}
