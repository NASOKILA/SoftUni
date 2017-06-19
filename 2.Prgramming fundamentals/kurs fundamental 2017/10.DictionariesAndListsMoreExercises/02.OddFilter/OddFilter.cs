using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddFilter
{
    class OddFilter
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var remainingNums = nums.Where(n => n%2 == 0).ToList();
            double average = remainingNums.Sum() / remainingNums.Count;

            for (int i = 0; i < remainingNums.Count; i++)
            {
                if (remainingNums[i] > average)
                    remainingNums[i]++;
                else
                    remainingNums[i]--;
            }

            Console.WriteLine(string.Join(" ", remainingNums));

        }
    }
}
