using System;


namespace FibonacciNumbers
{
    public class FibonacciNumbers
    {


        static void GetFibonacciNumbers(long num) {

            long fib0 = 1;
            long fib1 = 1;
            long fibCurrent = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 2; i <= num; i++)   // n puti
            {
                
                fib0 = fib1;
                fib1 = fibCurrent ;
                fibCurrent = fib0 + fib1;
            }
            Console.WriteLine(fibCurrent);

        }

        public static void Main(string[] args)
        { // Fibonacci e prosto poredica ot chisla       1, 1, 2, 3, 5, 8, 13.....

            long n = long.Parse(Console.ReadLine());
            GetFibonacciNumbers(n);
            
        }
    }
}
