using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit2
{
    class RageQuit2
    {
        static void Main(string[] args)
        {
            // SUS REGEX

            string input = Console.ReadLine().ToUpper();

            string pattern = "(\\D+)(\\d+)";  // purvata grupa e za vsichko koeto ne e chislo a vtorata samo za chislata
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int sinbolsCount = 0;
            
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                
                for (int i = 0; i < int.Parse(match.Groups[2].ToString()); i++)
                {
                    output.Append(match.Groups[1]);  
                    // zakachame purvite grupi po koklkoto puti e kazano t.e. groups[2]
                    // nakraq samo trqbva da printirame outputa
                }
            }


            sinbolsCount = output.ToString().Distinct().Count();  
            // taka broim razlichnite sinvoli v  output

            Console.WriteLine($"Unique symbols used: {sinbolsCount}");

            Console.WriteLine(output);


        }
    }
}
