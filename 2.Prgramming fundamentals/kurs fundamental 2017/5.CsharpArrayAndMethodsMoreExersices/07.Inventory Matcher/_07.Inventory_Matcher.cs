using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Inventory_Matcher
{
    class Inventory_Matcher
    {
        static void Main(string[] args)
        {
            string[] namesOfProducts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            long[] quantitiesOfProducts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            decimal[] pricesOfProducts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            string command = Console.ReadLine();
            while (command != "done")
            {
                int index = Array.IndexOf(namesOfProducts, command);
                string name = namesOfProducts[index];
                decimal price = pricesOfProducts[index];
                long quantity = quantitiesOfProducts[index];

                Console.WriteLine($"{name} costs: {price}; Available quantity: {quantity}");

                command = Console.ReadLine();
            }

        }
    }
}
