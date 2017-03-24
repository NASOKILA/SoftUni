using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket2
{
    class WinningTicket2
    {
        static void Main(string[] args)
        {

            string[] tickets = Console.ReadLine()
               .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(c => c.Trim()).ToArray();


            foreach (var ticket in tickets)
            {
                if (!ticket.Length.Equals(20))
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
               

                    var left = new string(ticket.Take(10).ToArray());
                    var right = new string(ticket.Skip(10).ToArray());

                    string[] winningSymbols = new string[] {"@", "#", "\\$", "\\^"};
                    bool winningTicket = false;

                    foreach (var  winningSymbol in winningSymbols)
                    {
                        Regex regex = new Regex($"{winningSymbol}{{6,}}"); // suzdavame regeksite
                        Match leftMatch = regex.Match(left);
                        if (leftMatch.Success) // ako ima match
                        {
                            Match rightMatch = regex.Match(right);
                            if (rightMatch.Success)
                            {
                                winningTicket = true;

                                var leftSymbolsLength = leftMatch.Value.Length;
                                var rightSymbolsLength = rightMatch.Value.Length;
                                var jackpot = leftSymbolsLength == 10 && rightSymbolsLength == 10
                                    ? " Jackpot"
                                    : string.Empty;
                                // ako symbolsLength == 10 dai jackpot ako ne dai praen string

                                Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftSymbolsLength, rightSymbolsLength)}{winningSymbol.Trim('\\')}{jackpot}");
                                break;
                            }
                        }
                    }

                    if (!winningTicket)
                        Console.WriteLine($"ticket \"{ticket}\" - no match");

                
            }
        }
    }
}
