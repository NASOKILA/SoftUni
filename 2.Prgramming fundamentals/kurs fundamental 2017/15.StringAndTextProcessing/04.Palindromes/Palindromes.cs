using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {

            List<string> text = Console.ReadLine()
                .Split(new string[] {",","."," ","!","?",";",":","-","\\","/","(",")","\"","'","&","%"}
                ,StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> result = new List<string>();

            foreach (var word in text)
            {
                bool ispalindrome = IsPalindrome(word);
                if (ispalindrome)
                    result.Add(word);
            }


            result = result.OrderBy(a => a).ToList();
            Console.WriteLine(string.Join(", ", result));
        }

        public static bool IsPalindrome(string word)
        {
            int min = 0;
            int max = word.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = word[min];
                char b = word[max];
                if (a != b)
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
