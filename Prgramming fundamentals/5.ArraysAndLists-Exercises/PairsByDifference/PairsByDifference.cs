using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsByDifference
{
    class PairsByDifference
    {
        static void Main(string[] args)
        {

            int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine()); 
       
            int pairs = 0;

            for (int i = 0; i < n.Length; i++)
            {

                for (int j = i; j < n.Length; j++)
                {
                    if (Math.Abs(n[i] - n[j]) == diff)
                    {
                        pairs++;
                    }
                }

            }
           
                Console.WriteLine(pairs);

        }
    }
}
