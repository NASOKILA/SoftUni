using System;
using System.Collections.Generic;
using System.Linq;

namespace _07CountNumbers
{
    class CountNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            numbers.Sort();
            Dictionary<int, int> counts = new Dictionary<int, int>();


            foreach (var num in numbers)
            {

                int occurrency = numbers.Where(n => n == num).Count();
                counts[num] = occurrency;

            }

            foreach (var keyValuePair in counts)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
