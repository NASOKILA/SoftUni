using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (var letter in input)
            {
                var utf = "u" + ((int)letter).ToString("X4").ToLower();
                Console.Write("\\" + utf);

            }

        }
    }
}
