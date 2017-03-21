using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDesert
{
    class SweetDesert
    {
        static void Main(string[] args)
        {
            // AKO SE RABOTI SUS PARI ILI CENI VINAGI SE POLZVA DECIMAL

            decimal cash = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPricePerKilo = decimal.Parse(Console.ReadLine());

    
            double setsOfPortions = Math.Ceiling(numberOfGuests / 6.00);
            decimal priceForBananas = (int)setsOfPortions * (bananaPrice * 2);
            decimal priceForEggs = (int)setsOfPortions * (eggPrice * 4);
            decimal priceForBerries = (int)setsOfPortions * ( berriesPricePerKilo * (decimal)0.2);
            decimal totalPrice = priceForBananas + priceForEggs + priceForBerries;

            
            if (totalPrice <= cash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                totalPrice = (totalPrice - cash);
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalPrice:f2}lv more.");
            }

        }
    }
}
