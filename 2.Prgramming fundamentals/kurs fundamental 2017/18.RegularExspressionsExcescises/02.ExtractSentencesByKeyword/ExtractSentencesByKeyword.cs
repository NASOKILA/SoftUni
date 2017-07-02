using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ExtractSentencesByKeyword
{
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(new char[] {'.','!','?'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

           

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i].Contains($" {word}"))
                    Console.WriteLine(input[i]);     
                
            }

        }
    }
}
