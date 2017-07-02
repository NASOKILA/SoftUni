using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class MagicExchangeableWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<char, char> map = new Dictionary<char, char>();

            string firstWord = words[0];
            string secondWord = words[1];

            bool sameLength = true;

            if (firstWord.Length != secondWord.Length)
                sameLength = false;

            var shorter = firstWord.Length <= secondWord.Length 
                ? firstWord 
                : secondWord;


            for (int i = 0; i < shorter.Length; i++)
            {
                if (!map.ContainsKey(firstWord[i]))
                {//ako ne sudurja takuv kluch
                    if (!map.ContainsValue(secondWord[i]))
                    {// ako ne sudurja takova value
                        map[firstWord[i]] = secondWord[i]; // gi dobavi
                    }
                    else
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }       
                else
                {
                    if (!map.ContainsValue(secondWord[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
            }


            if (!sameLength)
            {
                string longer = words.Where(w => w != shorter).FirstOrDefault().ToString();

                if (longer == secondWord)
                {
                    foreach (var @char in longer)
                    {
                        if (!map.ContainsValue(@char))
                        {
                            Console.WriteLine("false");
                            return;
                        }
                    }
                }
                else
                {
                    foreach (var @char in longer)
                    {
                        if (!map.ContainsKey(@char))
                        {
                            Console.WriteLine("false");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("true");
        }
    }
}
