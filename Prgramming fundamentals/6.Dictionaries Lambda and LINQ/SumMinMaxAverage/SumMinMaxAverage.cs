using System;
using System.Collections.Generic;
using System.Linq;


namespace SumMinMaxAverage
{
    class SumMinMaxAverage
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                nums[i] = num;
            }

            Console.WriteLine("Sum = {0}",nums.Sum());
            Console.WriteLine("Min = {0}", nums.Min());
            Console.WriteLine("Max = {0}", nums.Max());
            Console.WriteLine("Average = {0}", nums.Average());
        }
    }
}
