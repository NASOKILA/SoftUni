using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SupermarketDatabase
{
    class SupermarketDatabase
    {
        static void Main(string[] args)
        {

            Dictionary<string, double> namePrice = new Dictionary<string, double>();
            Dictionary<string, int> nameQuantity = new Dictionary<string, int>();

            SetStocks(namePrice, nameQuantity);

            PrintResult(namePrice, nameQuantity);

        }


        private static void PrintResult(Dictionary<string, double> namePrice, Dictionary<string, int> nameQuantity)
        {
            List<int> quantities = nameQuantity.Values.ToList();

            decimal grandTotal = 0;
            int counter = 0;
            foreach (var kvp in namePrice)
            {
                var name = kvp.Key;
                var price = kvp.Value;
                var quantity = quantities[counter];
                var result = price * quantity;
                Console.WriteLine($"{name}: ${price:F2} * {quantity} = ${result:F2}");
                counter++;
                grandTotal += (decimal)result;
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }

        private static void SetStocks(Dictionary<string, double> namePrice, Dictionary<string, int> nameQuantity)
        {
            string[] command = Console.ReadLine()
                .Split(' ')
                .ToArray();

            while (command[0] != "stocked")
            {
                string name = command[0];
                double price = double.Parse(command[1]);
                int quantity = int.Parse(command[2]);


                // we replace the price if it is the different
                namePrice[name] = price;

                // if the quantity is different on the same product we add it to the first one
                if (nameQuantity.ContainsKey(name))
                    nameQuantity[name] += quantity;
                else
                    nameQuantity[name] = quantity;



                command = Console.ReadLine()
                .Split(' ')
                .ToArray();
            }
        }



    }
}
