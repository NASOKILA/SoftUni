using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            // trqbva da hvanem telefonen nomer
            string pattern = @"([+][359]+)( |-)\d\2(\d{3})\2(\d{4})";
            string text = "+359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 + 359 2-222-2222, +359-2-222-222, +359-2-222-22222";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match  in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
