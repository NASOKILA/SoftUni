using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    class AndreyAndBilliard
    {
        static void Main(string[] args)
        {
            

            Dictionary<string, decimal> productAndPrice = new Dictionary<string, decimal>();

            Dictionary<string, Dictionary<string, int>> nameProductAndQuantity = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> productAndQuantity = new Dictionary<string, int>();

            SetShop(productAndPrice);

            SetOrders(productAndPrice, productAndQuantity, nameProductAndQuantity);
            
            PrintResult(productAndPrice,nameProductAndQuantity);

        }

        private static void SetOrders(Dictionary<string, decimal> productAndPrice, Dictionary<string, int> productAndQuantity, Dictionary<string, Dictionary<string, int>> nameProductAndQuantity)
        {
            string command = Console.ReadLine();

            while (command != "end of clients")
            {
                string[] input2 = command
                    .Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input2[0];
                string productToBuy = input2[1];
                int quantity = int.Parse(input2[2]);


                if (productAndPrice.ContainsKey(productToBuy))
                {
                    if (!nameProductAndQuantity.ContainsKey(name)) // ako ne sudurja tova ime
                    {
                        productAndQuantity = new Dictionary<string, int>();
                        productAndQuantity[productToBuy] = quantity;
                    }
                    else
                    {
                        productAndQuantity = nameProductAndQuantity[name];

                        if (productAndQuantity.ContainsKey(productToBuy))
                            productAndQuantity[productToBuy] += quantity;
                        else
                            productAndQuantity[productToBuy] = quantity;
                    }

                    nameProductAndQuantity[name] = productAndQuantity;
                }

                command = Console.ReadLine();
            }
        }

        private static void SetShop(Dictionary<string, decimal> productAndPrice)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();

                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                productAndPrice[product] = price;
            }
        }

        private static void PrintResult(Dictionary<string, decimal> productAndPrice, Dictionary<string, Dictionary<string, int>> nameProductAndQuantity)
        {
            decimal totalBill = 0;
            foreach (var nameItem in nameProductAndQuantity.OrderBy(a => a.Key))
            {
                var name = nameItem.Key;
                Console.WriteLine(name);
                foreach (var productQuantity in nameItem.Value)
                {
                    string product = productQuantity.Key;
                    decimal quantity = productQuantity.Value;
                    decimal bill = quantity * productAndPrice[product];

                    Console.WriteLine($"-- {product} - {quantity}");
                    Console.WriteLine($"Bill: {bill:F2}");
                    totalBill += bill;
                }
            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}
