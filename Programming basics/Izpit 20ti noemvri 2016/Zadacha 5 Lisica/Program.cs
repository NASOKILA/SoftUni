using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_5_Lisica
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0)
            {
                while (true)
                {
                    n = int.Parse(Console.ReadLine());
                    if (n % 2 == 1) { break; }
                }
            }

            double width = (n * 2) + 3;
            double height = width;
            char character = (char)92; //   \ - sinvol
            int counter = 1;

            for (int i = 1; i <= n; i++) // gorna chast !
            {
                Console.Write(new string('*',i));
                Console.Write(character);
                Console.Write(new string('-', (n*2) - counter));
                Console.Write("/");
                Console.WriteLine(new string('*', i));

                counter += 2;
            }
            //double num = ((width - n) / 5.00);
            //num = Math.Ceiling(num);
            int counter2 = 0;
            for (int i = 0; i < n/3; i++)  // sredna chast
            {
                Console.Write("|");
                Console.Write(new string('*', ((n - 1) / 2) + i));
                Console.Write(character);
                Console.Write(new string('*', (n - counter2)));
                Console.Write("/");
                Console.Write(new string('*', ((n - 1) / 2) + i));
                Console.WriteLine("|");
                counter2 += 2;
            }

            int counter3 = 1;
            for (int i = 1; i <= n; i++) // dolna chast !
            {
                Console.Write(new string('-', i));
                Console.Write(character);
                Console.Write(new string('*', (n * 2) - counter3));
                Console.Write("/");
                Console.WriteLine(new string('-', i));

                counter3 += 2;
            }



        }
    }
}
