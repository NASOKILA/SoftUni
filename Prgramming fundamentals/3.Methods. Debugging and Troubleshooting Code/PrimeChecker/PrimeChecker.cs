using System;


namespace PrimeChecker
{
   public class PrimeChecker
    {


        static bool IsPrime(long n)
        {
            bool isPrime = true;
            if (n < 2) { isPrime = false; } // ako chisloto e po malko ot 2, znachi e false!
            for (int divider = 2; divider < n; divider++)
            {
               
                if (n % divider == 0) { isPrime = false; break; } // ako se deli na 2 znachi ne e prosto chislo                              
            }
            return isPrime;
        }

        public static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            bool result = IsPrime(num);
            Console.WriteLine(result);
        }

    }
}
