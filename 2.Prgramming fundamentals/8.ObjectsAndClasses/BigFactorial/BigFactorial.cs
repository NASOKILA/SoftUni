using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BigFactorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
           

            int number = int.Parse(Console.ReadLine()); ;
            BigInteger fact = number;
                       
            for (int i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }
            Console.WriteLine(fact);
            
        }
    }
}
