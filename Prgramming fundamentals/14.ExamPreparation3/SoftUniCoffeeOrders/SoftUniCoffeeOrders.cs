using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCoffeeOrders
{
    class SoftUniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < ordersCount; i++)
            {
   
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy",CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                decimal priceForCoofee =  ((DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsulesCount) * pricePerCapsule );
                totalPrice += priceForCoofee;
                Console.WriteLine($"The price for the coffee is: ${priceForCoofee:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
             
        }
    }
}
