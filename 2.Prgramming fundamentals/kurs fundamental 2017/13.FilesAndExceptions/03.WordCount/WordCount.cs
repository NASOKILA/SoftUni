using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").Split(' ').ToArray();
            string[] textInInputFile = File.ReadAllText("input.txt").Split(new char[] {' ',',','.','?','!','-'},StringSplitOptions.RemoveEmptyEntries).ToArray();

            int wordOneCount = 0;
            int wordTwoCount = 0;
            int wordThreeCount = 0;

            foreach (var word in words)
            {
                foreach (var w in textInInputFile)
                {
                    if (word == words[0])
                    {
                        if (w.ToLower() == word)
                            wordOneCount++;
                    }
                    else if (word == words[1])
                    {
                        if (w.ToLower() == word)
                            wordTwoCount++;
                    }
                    else if (word == words[2])
                    {
                        if (w.ToLower() == word)
                            wordThreeCount++;
                    }


                }
            }

            List<string> result = new List<string>();
            result.Add($"{words[0]} - {wordOneCount}");
            result.Add($"{words[1]} - {wordTwoCount}");
            result.Add($"{words[2]} - {wordThreeCount}");

            File.WriteAllLines("output.txt", result);

        }
    }
}
