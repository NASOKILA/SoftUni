using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine().ToLower();
            string denOtSedmicata = Console.ReadLine().ToLower();
            double amount = double.Parse(Console.ReadLine());
            double price = 0.00;

            var weekend = (denOtSedmicata == "saturday" || denOtSedmicata == "sunday"); // tova e bool

            var workingDay = (denOtSedmicata == "monday" || denOtSedmicata == "tuesday"
                    || denOtSedmicata == "wednesday" || denOtSedmicata == "thursday"
                    || denOtSedmicata == "friday"); // tova e bool


            if (fruit == "banana" && workingDay) { price = 2.50; }
                else if (fruit == "apple" && workingDay) { price = 1.20; }
                else if (fruit == "orange" && workingDay) { price = 0.85; }
                else if (fruit == "grapefruit" && workingDay) { price = 1.45; }
                else if (fruit == "kiwi" && workingDay) { price = 2.70; }
                else if (fruit == "pineapple" && workingDay) { price = 5.50; }
                else if (fruit == "grapes" && workingDay) { price = 3.85; }

                else if (fruit == "banana" && weekend) { price = 2.70; }
                else if (fruit == "apple" && weekend) { price = 1.25; }
                else if (fruit == "orange" && weekend) { price = 0.90; }
                else if (fruit == "grapefruit" && weekend) { price = 1.60; }
                else if (fruit == "kiwi" && weekend) { price = 3.00; }
                else if (fruit == "pineapple" && weekend) { price = 5.60; }
                else if (fruit == "grapes" && weekend) { price = 4.20; }

            if (price > 0)
            {
                double result = price * amount;
                Console.WriteLine("{0:f2}", result);
            }
            else { Console.WriteLine("error"); }
        }
    }
}
