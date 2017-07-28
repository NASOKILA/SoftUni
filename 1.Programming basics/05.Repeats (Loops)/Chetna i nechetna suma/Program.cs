using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chetna_i_nechetna_suma
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;
            double broiChislaDelenoNaDve = (double)broiChisla / 2;

            for (var i = 0; i < broiChislaDelenoNaDve; i++) {

                int num = int.Parse(Console.ReadLine());
                sumOdd += num;
                if (!(broiChisla % 2 == 0) && i == broiChislaDelenoNaDve - 0.5 ) { break; }
                int num2 = int.Parse(Console.ReadLine());
                sumEven += num2;

            }
         

            var deference = sumOdd - sumEven;
            deference = Math.Abs(deference);
            if (sumOdd == sumEven) { Console.WriteLine("Yes"); Console.WriteLine("Sum = {0}", sumOdd); }
            else { Console.WriteLine("No"); Console.WriteLine("Diff = {0}",deference); }
        }
    }
}
