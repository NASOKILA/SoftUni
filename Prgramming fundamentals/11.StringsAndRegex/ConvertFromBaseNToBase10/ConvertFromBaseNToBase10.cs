using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBaseNToBase10
{
    class ConvertFromBaseNToBase10
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            BigInteger baseN = BigInteger.Parse(input[0]);                                // 7           
            BigInteger result = input[1].Select(digit => digit - (BigInteger)48).Aggregate(0, (BigInteger x, BigInteger y) => x * baseN + y);

            Console.WriteLine(result);




        }
    }
}
