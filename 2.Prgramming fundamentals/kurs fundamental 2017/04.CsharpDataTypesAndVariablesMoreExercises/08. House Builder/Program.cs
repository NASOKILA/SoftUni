using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstPrice = long.Parse(Console.ReadLine());
            long secondPrice = long.Parse(Console.ReadLine());

            long sbytePrice = 4;
            long intPrice = 10;
            if (firstPrice < 128 && firstPrice > 0)
            {
                sbytePrice *= firstPrice;
                intPrice *= secondPrice;
            }
            else
            {
                sbytePrice *= secondPrice;
                intPrice *= firstPrice;
            }

            Console.WriteLine(sbytePrice + intPrice);

        }
    }
}
