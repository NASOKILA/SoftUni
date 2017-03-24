
using System;
using System.Collections.Generic;

namespace SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {           

            int n = int.Parse(Console.ReadLine());
            // slow(n);
            fast(n);
        }

        static bool IsPrime(int i) {

            
                for (int j = 2; j < i; j++) // prime numbers start from 2
                {
                    if (i % j == 0)
                    {
                        return false;
                    }
                }
            return true;       
        }

        static void fast(int n)
        {

            bool[] primes = new bool[n + 1];  // pishe ot 0 do nvkluchitelno
            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
            }

            primes[0] = primes[1] = false;

            for (int p = 2; p <= n ; p++)
            {
                if (primes[p] == true)
                {
                    Console.WriteLine(p);

                    for (int j = 2; j <= n; j++)
                    {
                        if (j * p <= n && j * p >= 0)
                        {
                            primes[j * p] = false;
                        }
                    }
                }
            }
        }

        static void slow(int n)
        {

            for (int i = 1; i < n; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

    }
}
