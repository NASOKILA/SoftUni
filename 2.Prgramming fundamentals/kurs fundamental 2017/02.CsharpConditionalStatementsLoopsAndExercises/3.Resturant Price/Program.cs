using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Resturant_Price
{
    class Program
    {
        static void Main(string[] args)
        {

            int groupSize = int.Parse(Console.ReadLine());
            string packageType = Console.ReadLine();

            string hall = string.Empty;
            int hallPrice = 0;
            int packagePrice = 0;
            double totalPrice = 0;

            if (groupSize > 0 && groupSize <= 50) {
                hall = "Small Hall";
                hallPrice = 2500;
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                hall = "Terrace";
                hallPrice = 5000;
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                hall = "Bih Hall";
                hallPrice = 7500;
            }

            if (packageType.Equals("Normal"))
            {
                packagePrice = 500;
                totalPrice = hallPrice + packagePrice;
                totalPrice = totalPrice - (totalPrice / 20); // 20%
            }
            else if (packageType.Equals("Gold"))
            {
                packagePrice = 750;
                totalPrice = hallPrice + packagePrice;
                totalPrice = totalPrice - (totalPrice / 10); // 10%
            }
            else if (packageType.Equals("Platinum"))
            {
                packagePrice = 1000;
                totalPrice = hallPrice + packagePrice;
                totalPrice = totalPrice - (totalPrice / 20) - (totalPrice / 10); // 15%
            }


            totalPrice = totalPrice / groupSize;


            if (hall.Equals(""))
                Console.WriteLine("We do not have an appropriate hall.");
            else
            {
                Console.WriteLine($"We can offer you the {hall}");
                Console.WriteLine($"The price per person is {totalPrice:F2}$");
            }

        }
    }
}
