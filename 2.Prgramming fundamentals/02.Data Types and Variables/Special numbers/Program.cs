using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specialno chislo e kogato sbora na chislata mnu e 5, 7 ili 11

            int n = int.Parse(Console.ReadLine());
           

            // n%10  taka vzimame vtoroto chislo 
            // n/10 taka vzimame purvoto 

            for (int i = 1; i <= n; i++)
            {
                int sumOfDigits = 0;
                int digits = i;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10; // taka subirame vsichki cifri nezavisimo kolko e golqmo chisloto
                    digits = digits / 10;
                }

                //  SUZDAVAME BOOL S PROVERKI AKO NAPISANOTO V SKOBITE E VQRNO VRUSHTA TRUE AKO E GRESHNO VRISHTA FALSE
                bool isItSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);  
                Console.WriteLine("{0} -> {1}", i, isItSpecial);
            }
        }
    }
}
