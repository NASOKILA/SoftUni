using System;
using System.Numerics;

namespace _03.BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (long i = n; i > 1; i--)
                result *= i;
            Console.WriteLine(result);
        }
    }
}
