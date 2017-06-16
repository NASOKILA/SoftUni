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

            
            var maxSequenceOfEqualElements = FirstMaxSequenceOfEqualElements(numbers);

            Console.WriteLine(string.Join(" ", maxSequenceOfEqualElements));
        }

        private static int[] FirstMaxSequenceOfEqualElements(List<int> numbers)
        {

            List<int> longestSequence = new List<int>();
            List<int> currentSequence = new List<int>();
            currentSequence.Add(numbers[0]); // dobavqme edin element

            for (int i = 1; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                int searchedNum = currentSequence[0];

                if (currentNum == searchedNum)
                {
                    currentSequence.Add(currentNum);
                    // dobavqme current num kum currenteSequence
                }
                else
                {
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = new List<int>(currentSequence);
                        // taka clonirame edin spisuk v drug
                    }
                    currentSequence.Clear(); // sus clear() izchistvame vsichki elementi ot edin masiv
                    currentSequence.Add(currentNum);
                }

                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence = new List<int>(currentSequence);
                    // taka clonirame edin spisuk v drug
                }
            }
           

            return longestSequence.ToArray();

        }
    }
}
