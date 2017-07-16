using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {


            var n = ulong.Parse(Console.ReadLine()); // m
            var m = ulong.Parse(Console.ReadLine()); // n
            var y = ulong.Parse(Console.ReadLine());

            var powerCopy = n;

            var targetCounter = 0;
            decimal halfPower = (n / (decimal)2.00);

            while (powerCopy >= m)
            {
                if (powerCopy == halfPower)
                {

                    if (y != 0 && powerCopy != 0)
                    {
                        powerCopy /= y;

                        if (powerCopy < m)
                        {
                            break;
                        }
                    }
                }

                powerCopy -= m;
                targetCounter++;
            }

            Console.WriteLine($"{powerCopy}");
            Console.WriteLine($"{targetCounter}");
        }
    }
}
