using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SalesReport
{
    class Sale
    {
        public string town { get; set; }
        public string product { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        //Pishem prop i TAP i avtomatichno ni se pishe samo
    }
    class SalesReport
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, decimal> townAndTotalSales = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                List<string> sale = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                Sale currentSale = SetSale(sale);

                decimal totalSales = currentSale.price * currentSale.quantity;

                if(!townAndTotalSales.ContainsKey(currentSale.town))
                    townAndTotalSales[currentSale.town] = totalSales;
                else
                    townAndTotalSales[currentSale.town] += totalSales;
            }

            PrintResult(townAndTotalSales);
        }

        private static void PrintResult(SortedDictionary<string, decimal> townAndTotalSales)
        {
            foreach (var kvp in townAndTotalSales)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }

        private static Sale SetSale(List<string> sale)
        {

            Sale currentSale = new Sale()
            {
                town = sale[0],
                product = sale[1],
                price = decimal.Parse(sale[2]),
                quantity = decimal.Parse(sale[3])

            };
            return currentSale;
        }
    }
}
