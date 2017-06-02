using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceDouble = 0;
            double priceSuite = 0;

            if (month.Equals("May") || month.Equals("October"))
            {
                priceStudio = 50;
                priceDouble = 65;
                priceSuite = 75;

                if (nights > 7)
                {
                    priceStudio *= 0.95; // 5% 
                }

            }
            else if (month.Equals("June") || month.Equals("September"))
            {

                priceStudio = 60;
                priceDouble = 72;
                priceSuite = 82;

                if (nights > 14)
                {
                    priceDouble *= 0.90; // 10% 
                }

            }
            else if (month.Equals("July") || month.Equals("August") || month.Equals("December"))
            {

                priceStudio = 68;
                priceDouble = 77;


                if (nights > 14)
                    priceSuite *= 0.85; // 15% 

            }


            var totalStudioPrice = priceStudio * nights;
            var totalSDoublePrice = priceDouble * nights;
            var totalSuitePrice = priceSuite * nights;

            if (month.Equals("October") || month.Equals("September"))
            {
                if (nights > 7)
                {
                    totalStudioPrice -= priceStudio;
                }
            }


            Console.WriteLine($"Studio: {totalStudioPrice:f2} lv.");
            Console.WriteLine($"Double: {totalSDoublePrice:f2} lv.");
            Console.WriteLine($"Suite: {totalSuitePrice:f2} lv.");




        }
    }
}
