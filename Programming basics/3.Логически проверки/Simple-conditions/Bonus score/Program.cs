using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_score
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());  // trqbva da e int
            double bonus = 0.00;
            double total = 0.00;

            if (num <= 100) {
                bonus = 5;
                var num2 = (double)num;
                if (num2 % 2 == 0) { bonus = bonus + 1; }
                if (num2 % 5 == 0 && num2 % 2 == 1) { bonus = bonus + 2; }
                total = num2 + bonus;
                Console.WriteLine(bonus);
                Console.WriteLine(total);

            } else if (num > 100 && num <= 1000) {
                var num2 = (double)num;
                bonus = num2 / 5;
                if (num2 % 2 == 0) { bonus = bonus + 1; }
                if (num2 % 5 == 0 && num2 % 2 == 1) { bonus = bonus + 2; }
                total = num2 + bonus;
                Console.WriteLine(bonus);
                Console.WriteLine(total);

            } else if (num>1000) {
                var num2 = (double)num;
                bonus = num2 / 10;
                if (num2 % 2 == 0) { bonus = bonus + 1; }
                if (num2 % 5 == 0 && num2 % 2 == 1) { bonus = bonus + 2; }
                    total = num2 + bonus;
                Console.WriteLine(bonus);
                Console.WriteLine(total);

            }


        }
    }
}
