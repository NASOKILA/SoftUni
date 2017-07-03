using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.Mines
{
    class Mines
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"<(?<chars>.+?)>";
            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                char[] chars = match.Groups[1].ToString().ToCharArray();
                int power = Math.Abs(chars[0] - chars[1]);

                // replace the bomb with _
                int length = match.ToString().Length;
                int startIndex = input.IndexOf(match.ToString());
                int endIndex = startIndex + length;

                for (int i = startIndex; i < endIndex; i++)
                    input = input.Remove(i, 1).Insert(i, "_");


                // replace the bomb blast with _ Use startIndex and EndIndex

                // blast left

                for (int i = startIndex - 1; i > startIndex - power - 1; i--)
                {
                    if (i < 0)
                        break;

                    input = input.Remove(i, 1).Insert(i, "_");
                }
                // blast right

                for (int i = endIndex; i < endIndex + power; i++)
                {
                    if (i >= input.Length)
                        break;

                    input = input.Remove(i, 1).Insert(i, "_");
                }

            }

            Console.WriteLine(input);
        }
    }
}
