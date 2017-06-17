using System;
using System.Linq;


namespace _08.Upgraded_Matcher
{
    class Upgraded_Matcher
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

            string[] command = Console.ReadLine().Split(' ').ToArray();
            while (command[0] != "done")
            {

                int index = Array.IndexOf(namesOfProducts, command[0]);

                string name = namesOfProducts[index];

                decimal price = pricesOfProducts[index];

                int orderedQuantity = int.Parse(command[1]);

                long quantity = 0;

                try
                {
                     quantity = quantitiesOfProducts[index];
                }
                catch
                {
                     quantity = 0;
                }

                decimal result = orderedQuantity * price;
                if (quantity >= orderedQuantity)
                {
                    quantitiesOfProducts[index] -= orderedQuantity; 
                    Console.WriteLine($"{name} x {orderedQuantity} costs {result:F2}");
                }
                else
                    Console.WriteLine($"We do not have enough {name}");

                command = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
