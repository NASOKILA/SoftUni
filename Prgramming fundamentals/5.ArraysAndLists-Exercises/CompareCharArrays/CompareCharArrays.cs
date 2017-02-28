using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            char[] firstWord = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            char[] secondWord = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            char[] shorterArray = firstWord;
            char[] longerArray = secondWord;
            if (firstWord.Length > secondWord.Length)
            {
                shorterArray = secondWord;
                longerArray = firstWord;
            }

            for (int i = 0; i < shorterArray.Length; i++)
            {
                if (firstWord[i] < secondWord[i])
                {
                    Console.WriteLine(string.Join("", firstWord));
                    Console.WriteLine(string.Join("", secondWord));
                    break;
                }
                else if (firstWord[i] > secondWord[i])
                {
                    Console.WriteLine(string.Join("", secondWord));
                    Console.WriteLine(string.Join("", firstWord));
                    break;
                }
                else {
                    Console.WriteLine(string.Join("", shorterArray));
                    Console.WriteLine(string.Join("", longerArray));
                    break;
                }
            }

        }
    }
}
