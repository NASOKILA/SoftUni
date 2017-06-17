using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .ToList();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!counts.ContainsKey(word))
                    counts[word] = 1;
                else
                    counts[word]++;
            }


            Console.WriteLine(string.Join(", ", counts.Keys.Where(k => counts[k] % 2 == 1)));
        }
    }
}
