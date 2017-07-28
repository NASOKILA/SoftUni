using System;


namespace MasterNumbers
{
    class MasterNumbers
    {

        static bool IsPalindrome(int n)
        {
            bool isPalindrome = false;
            int num = 0;
            int rev = 0;
            int dig = 0;
            num = n;
            while (num > 0)
            {
                dig = num % 10;
                rev = rev * 10 + dig;
                num = num / 10;
            }
            if (n == rev)
            {
                isPalindrome = true;
            }
            return isPalindrome;
       }

        static bool SumOfDigitsDividedBySeven(int n) {
            bool isDevidedBySeven = false;

            int num2 = n;
            int oldNum = num2;
            int result = 0;
            int chislo = 0;

            while (true)
            {
                chislo = num2 % 10;  // namirame poslednata cifra  ot num      
                result += chislo; // vkarvame q v result  
                num2 = num2 / 10; // mahame poslednata cifra              
                if (num2 == 0) { break; }
            }


            if (result % 7 == 0)
            {
                isDevidedBySeven = true;
            }

                return isDevidedBySeven;
        }

        static bool HasEvenDigit(int n) {

            bool hasEvenDigit = false;
            int realResult = n;
            int chislo2 = realResult;
            while (true)
            {
                chislo2 = realResult % 10;
                realResult = realResult / 10;
                if (chislo2 % 2 == 0) { hasEvenDigit = true; break; }   //ALL THE PELINDROME NUMBERS WITH SUM OF DIGITS DEVIDED BY 7 WITH AN EVEN DIGIT!
                else if (realResult == 0) { break; }
            }
            return hasEvenDigit;
        }

        static void PrintMasterNumber(int n) {

            for (int i = 1; i < n; i++)
            {
                bool isPelindrome = IsPalindrome(i);
                bool sumOfDigitsDevBySeven = SumOfDigitsDividedBySeven(i);
                bool hasEvenDigit = HasEvenDigit(i);

                if (isPelindrome && sumOfDigitsDevBySeven && hasEvenDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintMasterNumber(n);
        }
    }
}
