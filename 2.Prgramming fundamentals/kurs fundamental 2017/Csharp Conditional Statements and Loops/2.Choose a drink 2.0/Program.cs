using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Choose_a_drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            string profession = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = 0;
            switch (profession)
            {
                case "Athlete":
                    price = 0.70;
                    break;
                case "Businessman":
                    price = 1.00;
                    break;
                case "Businesswoman":
                    price = 1.00;
                    break;
                case "SoftUni Student":
                    price = 1.70;
                    break;
                default:
                    {
                        price = 1.20; 
                        break;
                    }
            }

            Console.WriteLine($"The {profession} has to pay {quantity*price:F2}.");

        }
    }
}
