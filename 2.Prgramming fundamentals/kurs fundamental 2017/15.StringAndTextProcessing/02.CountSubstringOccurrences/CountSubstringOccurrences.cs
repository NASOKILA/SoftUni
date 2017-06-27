using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string wordToSearch = Console.ReadLine().ToLower();
            int occurencies = 0;

            var index = text.IndexOf(wordToSearch);

            while (index != -1)
            {
                occurencies++;
                index = text.IndexOf(wordToSearch, index + 1);
            }
            Console.WriteLine(occurencies);
        }
    }
}


