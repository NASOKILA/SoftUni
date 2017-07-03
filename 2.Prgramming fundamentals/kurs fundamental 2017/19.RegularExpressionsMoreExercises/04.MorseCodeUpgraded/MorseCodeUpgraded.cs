using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MorseCodeUpgraded
{
    class MorseCodeUpgraded
    {
        static void Main(string[] args)
        {
            string[] codes = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int total = 0;
            for (int i = 0; i < codes.Length; i++)
            {
                string code = codes[i];

                bool containsConsecutive = ContainsConsecutive(code);

                int ones = code.Where(n => n == '1').Count();
                int zeroes = code.Where(n => n == '0').Count();

                if (!containsConsecutive)    
                    total = (zeroes * 3) + (ones * 5);
                else
                {
                    total = (zeroes * 3) + (ones * 5);
                    total = CountSequences(code, total);
                }

                Console.Write((char)total);

            }


        }

        private static int CountSequences(string code, int total)
        {
            int seq = 1;
            for (int i = 0; i < code.Length-1; i++)
            {
                if (code[i] == code[i + 1])
                {
                    seq++;
                }
                else if(seq > 1)
                {
                    total = total + seq;
                    seq = 1;
                }
            }

            if (seq > 1)
            {
                total = total + seq;
            }
            return total;
        }

        private static bool ContainsConsecutive(string code)
        {
            
            for (int j = 0; j < code.Length - 1; j++)
            {
                if (code[j] == code[j + 1])
                    return true;   
            }
            return false;
        }
    }
}
