using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int calories = 0;
            string ingredient = string.Empty;

            for (int i = 0; i < count ; i++)
            {
                ingredient = Console.ReadLine().ToLower();
                if (ingredient.Equals("cheese"))
                    calories = calories + 500;
                else if (ingredient.Equals("tomato sauce"))
                    calories = calories + 150;
                else if (ingredient.Equals("salami"))
                    calories = calories + 600;
                else if (ingredient.Equals("pepper"))
                    calories = calories + 50;
            }

            Console.WriteLine($"Total calories: {calories}");
             
        }
    }
}
