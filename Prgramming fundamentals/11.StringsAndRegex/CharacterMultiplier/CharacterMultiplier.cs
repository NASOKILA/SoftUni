using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] inputArr = input.Split().ToArray();
            string str1 = inputArr[0];
            string str2 = inputArr[1];


            int sum = 0;
           

            int maxLen = Math.Max(str1.Length, str2.Length);  // namirame minimalniq string
            int minLen = Math.Min(str1.Length, str2.Length);  // namirame maximalniq string
            for (int i = 0; i < minLen; i++)
            {
                sum += str1[i] * str2[i];
            }

            

            if (str1.Length != str2.Length)
            {
                string longerInput = str1.Length > str2.Length  // ako str1 e po golqmo ot str2, longerInput = str1, ako ne da e = na str2
                    ? longerInput = str1 
                    : longerInput = str2;
                
                // ot duljinata na minimalniq string do duljinata na maksimalniq
                for (int i = minLen; i < maxLen; i++)
                {
                    sum += longerInput[i]; // dobavqme samo ot po dulgiq string
                }
            }

            Console.WriteLine(sum);
           
        }
    }
}
