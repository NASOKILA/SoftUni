using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova
{
    class Program
    {
        static void Main(string[] args)
        {

            //checked if a number holds atleast one digit number
            int n = int.Parse(Console.ReadLine());

            for (int j = 1; j < n; j++)
            {

                 
                int result = j;
                int chislo = j;
                while (true)
                {
                    chislo = result % 10;  // namirame poslednata cifra  ot num      
                    if (chislo % 2 == 0) { Console.WriteLine(result);  }
                    result = result / 10; // mahame poslednata cifra              
                    if (result == 0) { break; }
                }
            }
        }
    }
}
