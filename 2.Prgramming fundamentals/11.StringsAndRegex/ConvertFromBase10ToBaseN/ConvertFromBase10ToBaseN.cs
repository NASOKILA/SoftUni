using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBase10ToBaseN
{
    class ConvertFromBase10ToBaseN
    {
        

        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BigInteger baseN = input[0];  // 7
            BigInteger base10Num = input[1];  // 10
            StringBuilder result = new StringBuilder();

            BigInteger remainder = 0;
            List<BigInteger> digits = new List<BigInteger>();

            while (base10Num != 0)
            {
                remainder = base10Num % baseN;  // 10 % 7 
                base10Num = base10Num / baseN;   // 10 / 10
                digits.Add(remainder);               
            }

            

            for (int i = digits.Count-1; i >= 0; i--)
            {
                result.Append(digits[i]);
            }

            
            Console.WriteLine(result);

        }
    }
}
