using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .Where(a => a.Length > 0)
                .ToArray();

            foreach (var ticket in tickets)
            {


                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string leftSide = ticket.Substring(0,10);
                    string rightSide = ticket.Substring(10);
                
                    string leftLongestSequence = FindMaxEqualSeq(leftSide);
                    string rightLongestSequence = FindMaxEqualSeq(rightSide);

                   



                    char matchSymbol = leftLongestSequence.First();
                    if (!rightLongestSequence.Contains(matchSymbol))
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                        continue;
                    }


                    if ((leftLongestSequence.Length >= 6 && leftLongestSequence.Length <= 9)
                        && (rightLongestSequence.Length >= 6 && rightLongestSequence.Length <= 9)
                        && (leftLongestSequence[0] == rightLongestSequence[0]))
                    {
                        // trqbva vinagi da printirame minimuma, ako v ednata strana ima 8 matcha a v drugata ima 6, printirame 6
                        int lengthToPrint = Math.Min(leftLongestSequence.Length, rightLongestSequence.Length);    
                        Console.WriteLine($"ticket \"{ticket}\" - {lengthToPrint}{leftLongestSequence[0]}");
                    }

                    else if (leftLongestSequence.Length == 10 && rightLongestSequence.Length == 10)
                        Console.WriteLine($"ticket \"{ticket}\" - 10{matchSymbol} Jackpot!");
                }
                   
            }


        }

        private static string FindMaxEqualSeq(string s)
        {

            string bestStr = "" + s[0]; 
            var max = 1;
            for (int i = 0; i < s.Length-1; i++)
            {
                var ch = s[i];
                int count = 1;
                while (i + count < s.Length && s[i + count] == s[i])
                {
                    count++;
                    if (count > max)
                    {
                        max = count;
                        bestStr = s.Substring(i, count);
                    }
                }
            }
            return bestStr;
        }
    }
}
