using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicheski_Chisla
{
    class Program
    {
        static void Main(string[] args)
        {

            int magicNumber = int.Parse(Console.ReadLine());

            var result = 0;


            // NE GO RAZBRAH !!!
            for (int i = 100000; i <= 999999; i++)
            {
                result = 1;
                int num = i;
                do
                {
                    result = result * (num % 10);
                    num = num / 10;
                } while (num > 0);

                 if (result == magicNumber)
                {
                    Console.Write("{0} ", i);
                }

            }

        }
    }
}
