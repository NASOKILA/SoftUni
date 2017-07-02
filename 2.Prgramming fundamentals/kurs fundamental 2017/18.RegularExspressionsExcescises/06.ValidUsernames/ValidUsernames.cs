using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern = @"\b[a-zA-z]{1}([\w\d_]{2,24})\b";
            Regex regex = new Regex(pattern);

            List<string> validNames = new List<string>();
            List<int> sums = new List<int>();

            GetValidNames(validNames, names, regex);

            int maxSum = CalculateMaxSum(validNames, sums);
       
            PritResult(validNames,maxSum);
        }

        private static void GetValidNames(List<string> validNames, string[] names, Regex regex)
        {
            foreach (var name in names)
            {
                Match match = regex.Match(name);
                if (match.Length > 1)
                    validNames.Add(name);
            }
        }

        private static int CalculateMaxSum(List<string> validNames, List<int> sums)
        {
            for (int i = 0; i < validNames.Count-1; i++)
            {
                int sum = validNames[i].Length + validNames[i + 1].Length;
                sums.Add(sum);
            }
            return sums.Max();
        }

        private static void PritResult(List<string> validNames, int maxSum)
        {
            for (int i = 0; i < validNames.Count-1; i++)
            {
                if (validNames[i].Length + validNames[i + 1].Length == maxSum)
                {
                    Console.WriteLine(validNames[i]);
                    Console.WriteLine(validNames[i+1]);
                    break;
                }
                
            }

        }
    }
}
