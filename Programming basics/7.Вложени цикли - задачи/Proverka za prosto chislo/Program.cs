using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proverka_za_prosto_chislo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string prime = "Prime";
            string notPrime = "Not prime";
            string result = "";

            if (n < 2) { Console.WriteLine(notPrime); }
            if (n == 2 || n == 3) { Console.WriteLine(prime); }
            else
            {
                // prosto chislo e chislo > 2 koeto se deli samo na sebesi i edno primerno 7    7 = 1*7 ili 7*1
                // 4 ne e prosto zashtoto se deli na 4, 1 i na 2!!!
                int counter = 2;
             
                while (counter < n-1)      // 5     
                {
                    if (n % counter == 0) { result = notPrime; break; }
                    else { result = prime; }
                    counter++;
                }
                Console.WriteLine(result);
                

            }
        }
    }
}
