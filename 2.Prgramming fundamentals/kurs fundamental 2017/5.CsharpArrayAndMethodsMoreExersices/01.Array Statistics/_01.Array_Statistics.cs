using System;
using System.Linq;

namespace _01.Array_Statistics
{
    class Array_Statistics
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int maxNum = input.Max();
            int minNum = input.Min();
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }

            double average = (double)sum / input.Length;

            Console.WriteLine($"Min = {minNum}");
            Console.WriteLine($"Max = {maxNum}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
