using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LargestThreeNumbers
{
    class LargestThreeNumbers
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ",nums.OrderByDescending(n => n).Take(3).ToList()));

        }
    }
}
