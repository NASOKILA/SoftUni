using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*@[a-zA-Z\-]+(\.[a-z]+)+\b)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
