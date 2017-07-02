using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.ConvertFromBaseNToBase10
{
    class ConvertFromBaseNToBase10
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            long baseNToConvert = long.Parse(input[0]); // from 2 to 10   
            string base10NumToBeConverted = input[1];

            List<int> firstResult = new List<int>();

            // 23 reverse the string
             base10NumToBeConverted = new string(base10NumToBeConverted
                 .ToCharArray()
                 .Reverse()
                 .ToArray());

            var sum = new BigInteger();
            
            for (int i = 0; i < base10NumToBeConverted.Length; i++)
            {
                int currentNum = int.Parse(base10NumToBeConverted[i].ToString());
                sum += (currentNum * BigInteger.Pow(baseNToConvert, i));
                
            }
            

            Console.WriteLine($"{sum}");
        }

    }
}
