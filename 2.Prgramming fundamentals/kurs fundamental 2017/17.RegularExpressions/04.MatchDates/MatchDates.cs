using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.MatchDates
{
    class MatchDates
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patt = @"\b(\d{2})([-.\/])([A-Z]?[a-z]{2})\2(\d{4})\b";
            Regex regex = new Regex(patt);

            MatchCollection dates = regex.Matches(input);
            

            foreach (Match date in dates)
            {
                Console.Write($"Day: {date.Groups[1]}, ");
                Console.Write($"Month: {date.Groups[3]}, ");
                Console.WriteLine($"Year: {date.Groups[4]}");
            }

        }
    }
}
