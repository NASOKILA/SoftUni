using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string matchesStr = GetMatches(text);
            string replaced = ReplaceWithASpace(matchesStr);
            string converted = ConvertCharackters(replaced);

            Console.WriteLine(converted);

        }

        private static string ConvertCharackters(string replaced)
        {
            string result = string.Empty;
            List<string> words = replaced
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            foreach (var word in words)
            {
                foreach (var letter in word)
                {
                    if (letter >= 97 && letter <= 122)
                    {
                        //it is a small letter
                        if (letter >= 97 && letter <= 109)
                        {
                            // from 'a' to 'm'
                            result += (char)(letter + 13);
                        }
                        else if (letter >= 110 && letter <= 122)
                        {
                            // from 'n' to 'z'
                            result += (char)(letter - 13);

                        }

                    }
                    else
                    {
                        result += letter;
                    }

                }
                result += " ";
            }
            

            return result.Remove(result.Length-1, 1);
        }

        private static string ReplaceWithASpace(string matchesStr)
        {
            string patt = @"[^a-z0-9]";
            string result = Regex.Replace(matchesStr, patt, " ");
            return result;
        }

        private static string GetMatches(string text)
        {
            string result = string.Empty;
            string pattern = @"<p>(.+?)<\/p>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                string matchStr = match.Groups[1].ToString();
                result += matchStr;
            }
            return result;
        }
    }
}
