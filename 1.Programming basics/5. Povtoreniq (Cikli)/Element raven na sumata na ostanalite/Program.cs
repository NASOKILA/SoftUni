using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element_raven_na_sumata_na_ostanalite
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiChisla = int.Parse(Console.ReadLine());

            int max = int.Parse(Console.ReadLine());
            int sum = max;
            for (var i = 0; i < broiChisla-1; i++) {

                int num = int.Parse(Console.ReadLine());
                if (max < num) { max = num; }
                sum = sum + num;

            }
            var sumaBezMax = sum - max;
            var deference = max - sumaBezMax;
            deference = Math.Abs(deference);
            if (max == sumaBezMax) { Console.WriteLine("Yes"); Console.WriteLine("Sum = {0}", max); }
            else { Console.WriteLine("No"); Console.WriteLine("Diff = {0}", deference); }

        }
    }
}
