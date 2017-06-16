using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {

            List<double> nums = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var item in nums)
            {
                if (!counts.ContainsKey(item))
                    counts[item] = 1;
                else
                    counts[item]++;
            }

            foreach (var key in counts.Keys)
            {
                Console.WriteLine($"{key} -> {counts[key]}");
            }
        }
    }
}
