using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern  = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            foreach (var match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}
