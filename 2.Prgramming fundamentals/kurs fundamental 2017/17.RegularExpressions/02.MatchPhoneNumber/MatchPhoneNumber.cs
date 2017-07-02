using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();
            string pattern = @"[+359]+\b([ -]{1})(2)\1([\d]{3})\1([\d]{4})\b";
            Regex regex = new Regex(pattern);
            List<string> res = new List<string>();
            MatchCollection matches = regex.Matches(phones);
            foreach (var item in matches)
            {
                if (item.ToString().First() == '+')
                    res.Add(item.ToString());
            }

            Console.WriteLine(string.Join(", ", res));

        }
    }
}
