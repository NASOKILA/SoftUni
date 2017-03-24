using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim()).ToArray();


            string pattern = "([$]+)|([#]+)|([@]+)|([\\^]+)";
            Regex regex = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                if (ticket.Length.Equals(20))
                {
                    MatchCollection matches = regex.Matches(ticket);

                    if (matches.Count.Equals(1) && matches[0].Length /2 == 10) // ako ima edin match na koito duljinata mu /2 e = na 10
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {matches[0].Length / 2}{matches[0].ToString().First()} Jackpot!");  // pechatame jackpot
                    }
                    else if (matches.Count.Equals(2))
                    {
                        if (matches[0].Length >= matches[1].Length && matches[0].Length >= 6 && matches[0].Length <= 9) // ako ima dva matcha s ednakvi duljini ot 6 do 9
                        {
                            if(matches[0].ToString().First() == matches[1].ToString().First())  // ako sinvolite sa ednakvi
                                Console.WriteLine($"ticket \"{ticket}\" - {matches[0].Length}{matches[0].ToString().First()}");
                        }
                    
                    }

                    if (matches.Count.Equals(0))
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
                else
                    Console.WriteLine("invalid ticket");
            }         
        }
    }
}
