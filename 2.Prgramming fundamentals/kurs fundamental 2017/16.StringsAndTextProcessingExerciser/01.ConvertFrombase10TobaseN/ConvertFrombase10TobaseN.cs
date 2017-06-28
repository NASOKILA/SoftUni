using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ConvertFrombase10TobaseN
{
    class ConvertFrombase10TobaseN
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            long baseNToConvert = long.Parse(input[0]); // from 2 to 10   
            long base10NumToBeConverted = long.Parse(input[1]);

            List<long> res = new List<long>();
            long result = -1;
            while (result != 0)
            {

                result = base10NumToBeConverted / baseNToConvert;
                long reminder = base10NumToBeConverted % baseNToConvert;
                res.Add(reminder);
                base10NumToBeConverted = result;

            }
            res.Reverse();
            Console.WriteLine(string.Join("", res));
        }
    }
}
