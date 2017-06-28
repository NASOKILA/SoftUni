using System;
using System.Collections.Generic;
using System.Linq;
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
            long base10NumToBeConverted = long.Parse(input[1]);

            var result = FromBase(base10NumToBeConverted, baseNToConvert);
            Console.WriteLine(result);
        }
        public static long FromBase(long value, long @base)
        {
            string number = value.ToString();
            long n = 1;
            long r = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                r += n * (number[i] - '0');
                n *= @base;
            }

            return r;
        }
    }
}
