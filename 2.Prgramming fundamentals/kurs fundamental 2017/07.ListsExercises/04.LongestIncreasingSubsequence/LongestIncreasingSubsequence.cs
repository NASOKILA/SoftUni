using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {

            List<int> n = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            int start = 0;
            int len = 1;

            int bestStart = 0;
            int bestLen = 0;
            
            for (int i = 1; i < n.Count; i++)
            {
                if (n[i] - n[i - 1] == 1)
                {
                    len++;
                }
                else
                {
                    start = i;
                    len = 1;

                }
                if (len > bestLen)
                {
                    bestLen = len;
                    bestStart = start;
                }

            }

            for (int i = bestStart; i < bestStart + bestLen; i++)
            {
                Console.Write(n[i] + " ");
            }
            Console.WriteLine();

        }
    }
}
