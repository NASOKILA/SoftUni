using System;


namespace MultiplyEvensByOdds
{
    class Program
    {
        static int GetMultiplesByEvenAndOdds(int num) {

            int sumEvens = GetSumOfEvenDigits(num);
            int sumOdd = GetSumOfOddDigits(num);
            return sumEvens * sumOdd;
        }

        static int GetSumOfEvenDigits(int num) {
            num = Math.Abs(num);
            int sum = 0;

            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 0)
                {
                    sum = sum + lastDigit;
                }
                num /= 10;
            }
            return sum;

        }

        static int GetSumOfOddDigits(int num) {
            num = Math.Abs(num);
            int sum = 0;

            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 != 0) {
                    sum += lastDigit;
                }
                num /= 10;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = GetMultiplesByEvenAndOdds(n);
            Console.WriteLine(result);
        }
    }
}
