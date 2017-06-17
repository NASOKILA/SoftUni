using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            int numberOfItemsToBuy = int.Parse(Console.ReadLine());

            double subtotal = 0.0;

            for (int i = 0; i < numberOfItemsToBuy; i++)
            {
                string itemName = Console.ReadLine();
                double itemPrice = double.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());

                if (itemCount > 1)
                    Console.WriteLine($"Adding {itemCount} {itemName}s to cart.");
                else
                    Console.WriteLine($"Adding {itemCount} {itemName} to cart.");

                subtotal = subtotal + (itemPrice * itemCount);

            }

            Console.WriteLine($"Subtotal: ${subtotal:F2}");

            if(subtotal <= budjet)
                Console.WriteLine($"Money left: ${budjet-subtotal:F2}");
            else
                Console.WriteLine($"Not enough. We need ${subtotal - budjet:F2} more.");

        }
    }
}
