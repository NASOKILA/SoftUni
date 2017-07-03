using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.OnlyLetters
{
    class OnlyLetters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\d+";
            
            var matches = Regex.Matches(input,pattern)
                .Cast<Match>()
                .Select(a => a)
                .ToArray();

            foreach (var match in matches)
            {
                int indexToStartRemoving = input.IndexOf(match.ToString().First());
                int countOfCharsToRemove = match.Length;

                if (indexToStartRemoving + countOfCharsToRemove == input.Length)
                    break;

               input = input.Remove(indexToStartRemoving, countOfCharsToRemove);
               input = input.Insert(indexToStartRemoving, input[indexToStartRemoving].ToString());
            }

            Console.WriteLine(input);
        }
    }
}
