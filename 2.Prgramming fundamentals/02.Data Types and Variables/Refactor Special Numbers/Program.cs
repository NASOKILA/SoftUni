using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            /*You are given a working code that is a solution to Problem 5. Special Numbers. However, the variables are
            improperly named, declared before they are needed and some of them are used for multiple things.
            Without using your previous solution, modify the code so that it is easy to read and understand.*/

            int n = int.Parse(Console.ReadLine());



            int sumOfDigits = 0;
            for (int i = 1; i <= n; i++)
            {
               int digits = i;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }

                bool isItSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);

                Console.WriteLine($"{i} -> {isItSpecial}");
                sumOfDigits = 0;
               
            }


        }
    }
}
