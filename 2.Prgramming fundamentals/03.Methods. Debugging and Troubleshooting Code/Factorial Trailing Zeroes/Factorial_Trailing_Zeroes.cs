using System;
using System.Numerics;

namespace Factorial_Trailing_Zeroes
{
    public class Factorial_Trailing_Zeroes
    {



        public static BigInteger PrintFactoriel(short n)
        {

            BigInteger fact = 1;
            BigInteger counter = 1;
            do
            {
                fact = fact * counter;
                counter++;

            } while (counter <= n);

            return fact;
        }

        public static short NumberOfZeros(BigInteger n)
        {

            short numberOfZeros = 0;

            BigInteger digit = n;
            BigInteger result = digit;

            while (true)
            {
                digit = result % 10;
                result = result / 10;
                if (digit == 0) { numberOfZeros++; }
                else { break; }
            }


            return numberOfZeros;

        }

        public static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            // factoriel ot 5 e   1*2*3*4*5 = 120

            BigInteger factoriel = PrintFactoriel(n);
            short numOfZeros = NumberOfZeros(factoriel);
            Console.WriteLine(numOfZeros);

        }
    }
}
