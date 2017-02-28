using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class IndexOfLetters
    {
        static void Main(string[] args)
        {
            string w = Console.ReadLine().ToLower();
            char[] word = w.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine("{0} -> {1}",word[i],(int)word[i] - 97);
            }


        }
    }
}
