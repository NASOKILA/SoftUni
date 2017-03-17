using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Axe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n * 5;           
                
                for (int i = 0; i < n; i++)
                {
                    Console.Write(new string('-', (n * 4) - n));
                    Console.Write("*");
                    Console.Write(new string('-', i));
                    Console.Write("*");
                    Console.WriteLine(new string('-', n * 2 - 2 - i));
                }

            if (n % 2 == 0)  // if num is even
            {
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write(new string('*', ((n * 4) - n) + 1));
                    Console.Write(new string('-', n - 1));
                    Console.Write("*");
                    Console.WriteLine(new string('-', n - 1));
                }

                int counter = 0;
                for (int i = 0; i < n / 2 - 1; i++)
                {
                    Console.Write(new string('-', (n * 4) - n - i));
                    Console.Write("*");
                    Console.Write(new string('-', (n - 1) + counter));
                    counter += 2;
                    Console.Write("*");
                    Console.WriteLine(new string('-', n - 1 - i));
                }

                Console.Write(new string('-', length / 2 + 1));
                Console.Write(new string('*', n * 2 - 1));
                Console.WriteLine(new string('-', n / 2));

            }
            else // if num is odd
            {
                for (int i = 0; i < (n-1) / 2; i++)  
                {
                    Console.Write(new string('*', ((n * 4) - n) + 1));
                    Console.Write(new string('-', n - 1));
                    Console.Write("*");
                    Console.WriteLine(new string('-', n - 1));
                }

                int counter2 = 0;
                for (int i = 0; i < (n-1) / 2 - 1; i++)
                {
                    Console.Write(new string('-', (n * 4) - n - i));
                    Console.Write("*");
                    Console.Write(new string('-', (n - 1) + counter2));
                    counter2 += 2;
                    Console.Write("*");
                    Console.WriteLine(new string('-', n - 1 - i));
                }

                Console.Write(new string('-', (length+1) / 2 + 1));
                Console.Write(new string('*', (n-1) * 2));
                Console.WriteLine(new string('-', (n + 1) / 2));
            }
        }
    }
}
