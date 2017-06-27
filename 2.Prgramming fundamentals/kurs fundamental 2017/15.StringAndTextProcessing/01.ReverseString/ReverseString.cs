using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string reversedWord = string.Empty;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += word[i];
            }
            Console.WriteLine(reversedWord);
        }
    }
}
