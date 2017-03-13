using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            byte secondNumber = byte.Parse(Console.ReadLine());

            //result = 934573817465075391826664309019448  

            if (firstNumber == "0" || secondNumber == 0 || firstNumber == "")
            {
                Console.WriteLine(0);  // slagame tova zashtoto inache shte ni dade 0000000000... koeto e greshen otgovor
                return;
            }


            byte product = 0;
            byte numberInMind = 0;
            byte remainder = 0;
            StringBuilder result = new StringBuilder();

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                product = (byte)(byte.Parse(firstNumber[i].ToString()) * secondNumber + numberInMind);
                numberInMind = (byte)(product / 10);
                remainder = (byte)(product % 10);
                result.Append(remainder);
                if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }

            }

            char[] reverse = result.ToString().ToCharArray();
            Array.Reverse(reverse);
            Console.WriteLine(reverse);


        }
    }
    
}
