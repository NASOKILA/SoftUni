using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_5_Raketa
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = n * 3;
            int heighGornaChast = n;
            int heighSrednaChast = n*2;
            int heighDolnaChast = n/2;

            char character = (char)92; //  \
            int spaces = 0;

            for (int i = 1; i <= n; i++)    // gorna chast !
            {
                Console.Write(new string('.',(width/2) -i));
                Console.Write("/");
                Console.Write(new string(' ', spaces));
                Console.Write(character);
                Console.WriteLine(new string('.', (width / 2) - i));

                spaces += 2;
            }

            Console.Write(new string('.', n / 2));
            Console.Write(new string('*', n * 2));
            Console.WriteLine(new string('.', n / 2));

            for (int j = 0; j < n * 2; j++) // sredna chast
            {
                Console.Write(new string('.', n / 2));
                Console.Write("|");
                Console.Write(new string(character, (n * 2) - 2));
                Console.Write("|");
                Console.WriteLine(new string('.', n / 2));
            }

            int counter = 0;
            for (int v = 0; v < n / 2; v++)  // treta chast
            {
                Console.Write(new string('.', (n / 2) - v));
                Console.Write("/");
                Console.Write(new string('*', ((n * 2) - 2) + counter));
                Console.Write(character);
                Console.WriteLine(new string('.', (n / 2) - v));

                counter += 2;
            }

        }
    }
}
