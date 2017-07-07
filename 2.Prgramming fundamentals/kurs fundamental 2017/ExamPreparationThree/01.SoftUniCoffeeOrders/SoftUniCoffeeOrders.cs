using System;
using System.Globalization;


namespace _01.SoftUniCoffeeOrders
{
    class SoftUniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                ulong capsulesCount = ulong.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                decimal price = (((decimal)daysInMonth * capsulesCount )* pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
                totalPrice += price;

            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
