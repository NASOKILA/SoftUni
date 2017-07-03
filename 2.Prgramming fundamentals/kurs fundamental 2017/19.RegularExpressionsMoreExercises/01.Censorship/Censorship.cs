using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.Censorship
{
    class Censorship
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string sentence = Console.ReadLine();
            string replacement = new string('*', word.Length);
            var result = Regex.Replace(sentence,word, replacement);
            Console.WriteLine(result);

        }
    }
}
