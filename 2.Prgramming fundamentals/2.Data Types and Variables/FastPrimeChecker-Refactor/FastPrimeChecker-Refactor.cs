using System;


namespace FastPrimeChecker_Refactor
{
    public class Program
    {
        public static void Main(string[] args)
        {

            /*You are given a program that checks if numbers in a given range [2...N] are prime. 
              For each number is printed "{number} is prime -> {True or False}". 
              The code however, is not very well written. Your job is to modify it in a way
              that is easy to read and understand.
              
             A prime number (or a prime) is a natural number greater than 1 that has no positive divisors other than 1 and itself.
              For example, 5 is prime because 1 and 5 are its only positive integer factors, whereas 6 is composite because it has 
              the divisors 2 and 3 in addition to 1 and 6.*/



            int n = int.Parse(Console.ReadLine());  // ako n = 5
            for (int number = 2; number <= n; number++) // vurti 3 puti
            {

                bool isItPrime = true;

                for (int divider = 2; divider <= Math.Sqrt(number); divider++)   // koren kvadraten ot 9 = 3 ,  ot 4 = 2
                {
                    if (number % divider == 0) 
                    {
                        isItPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{number} -> {isItPrime}");
            }

        }
    }
}
