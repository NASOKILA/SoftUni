using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = -1;

            if (day.Equals("Weekday"))
            {
                if (age <= 18 && age >= 0)
                    price = 12;
                else if (age <= 64 && age > 18)
                    price = 18;
                else if (age <= 122 && age > 64)
                    price = 12;
                 }
            else if (day.Equals("Weekend"))
            {
                if (age <= 18 && age >= 0)
                    price = 15;
                else if (age <= 64 && age > 18)
                    price = 20;
                else if (age <= 122 && age > 64)
                    price = 15;
                }
            else if (day.Equals("Holiday"))
            {
                if (age <= 18 && age >= 0)
                    price = 5;
                else if (age <= 64 && age > 18)
                    price = 12;
                else if (age <= 122 && age > 64)
                    price = 10;
                }

            if (price.Equals(-1))
                Console.WriteLine("Error!");
            else
                Console.WriteLine($"{price}$"); 

        }
    }
}
