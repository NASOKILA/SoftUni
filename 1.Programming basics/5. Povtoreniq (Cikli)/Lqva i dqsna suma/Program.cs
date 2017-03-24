using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lqva_i_dqsna_suma
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiChisla = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;

            for (var i = 1; i <= broiChisla;i++) {
                int num = int.Parse(Console.ReadLine());
                sum1 += num;
            }

            for (var ii = 1; ii <= broiChisla;ii++)
            {
                int num = int.Parse(Console.ReadLine());
                sum2 += num;
            }

            var deference = sum1 - sum2;
            deference = Math.Abs(deference);

            if (sum1 == sum2) { Console.WriteLine("Yes, sum = {0}", sum1); }
            else { Console.WriteLine("No, diff = {0}", deference); }
        }
    }
}
