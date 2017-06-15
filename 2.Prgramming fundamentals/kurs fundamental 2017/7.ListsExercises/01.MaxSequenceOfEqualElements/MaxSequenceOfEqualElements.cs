using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int length = 1;
            int start = 0;
            int maxSequence = 0;

            for (int i = start; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                    length++;
                else
                    length = 1;
                   
                if (length > maxSequence)
                {
                    maxSequence = length;
                    start = i+1 - maxSequence;
                }

            }

            Console.WriteLine(string.Join(" ", numbers.Skip(start+1).Take(maxSequence)));
        }
    }
}
