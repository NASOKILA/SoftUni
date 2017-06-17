using System;
using System.Collections.Generic;
using System.Linq;


namespace _05.Pizza_Ingredients
{
    class Pizza_Ingredients
    {
        static void Main(string[] args)
        {

            string[] ingredients = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int lengthOfStrings = int.Parse(Console.ReadLine());

            string[] validIngredients = new string[10];

            int counter = 0;
            foreach (var item in ingredients)
            {
                if (item.Length == lengthOfStrings)
                {
                    Console.WriteLine($"Adding {item}.");
                    validIngredients[counter] = item;
                    counter++;
                }

                if (counter == 11)
                {
                    counter--;
                    break;
                }

            }

            Console.WriteLine($"Made pizza with total of {counter} ingredients.");
            Console.WriteLine("The ingredients are: " + string.Join(", ", validIngredients.Where(e => e != null)) + ".");
        }
    }
}
