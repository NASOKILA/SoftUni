using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SplitbyWordCasing
{
    class SplitbyWordCasing
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine()
    .Split(new char[] { ' ', ':', ',', '.', ';', '!', '(', ')', '"', '/', '\\', '[', ']', '\'' }, StringSplitOptions.RemoveEmptyEntries)
    .ToList();

            List<string> LowerCaseWords = new List<string>();
            List<string> UpperCaseWords = new List<string>();
            List<string> MixedCaseWords = new List<string>();

            foreach (var word in text)
            {
                if (word.All(c => char.IsUpper(c)))
                    UpperCaseWords.Add(word);
                else if (word.All(c => char.IsLower(c)))
                    LowerCaseWords.Add(word);
                else
                    MixedCaseWords.Add(word);
            }

            Console.WriteLine($"Lower-case: " + string.Join(", ", LowerCaseWords));
            Console.WriteLine($"Mixed-case: " + string.Join(", ", MixedCaseWords));
            Console.WriteLine($"Upper-case: " + string.Join(", ", UpperCaseWords));

        }
    }
}
