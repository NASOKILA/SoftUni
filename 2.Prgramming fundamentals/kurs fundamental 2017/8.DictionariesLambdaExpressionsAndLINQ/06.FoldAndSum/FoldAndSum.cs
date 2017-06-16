using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> newList = new List<int>();

            newList.AddRange(nums.Take(nums.Count / 4).Reverse());
            nums.Reverse();
            newList.AddRange(nums.Take(nums.Count / 4));
            nums = nums.Skip(nums.Count / 4).Take(nums.Count / 2).Reverse().ToList();
            //.Skip(nums.Count / 4).Reverse().ToList();

            List<int> sum = newList.Select((x, index) => x + nums[index]).ToList();

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
