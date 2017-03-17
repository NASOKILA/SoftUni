using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToThePast
{
    class BackToThePast
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int yearUntilDeath = int.Parse(Console.ReadLine());

            int years = 18;
            int count = yearUntilDeath - 1800;
            for (int i = 0; i <= count; i++)
            {
                if (i % 2 == 0)
                {
                    money -= 12000.00;
                }
                else
                {
                    money = money - (12000.00 + (years * 50.00));
                }
                years += 1;
            }

            if (money < 0)
            {
                money = Math.Abs(money);
                Console.WriteLine($"He will need {money:F2} dollars to survive.");

            }
            else     
            Console.WriteLine($"Yes! He will live a carefree life and will have {money:F2} dollars left.");

        }
    }
}
