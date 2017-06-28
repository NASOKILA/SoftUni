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

            int minLen = Math.Min(firstWord.Length, secondWord.Length);
            int maxLen = Math.Max(firstWord.Length, secondWord.Length);

            for (int i = 0; i < minLen; i++)
            {
                if (!map.ContainsKey(firstWord[i]))
                {          // ako ne sudurja klucha
                    if (map.ContainsValue(secondWord[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                    map.Add(firstWord[i], secondWord[i]); // go dobavi
                }
                else
                {         // ako se sudurja klucha
                    if (map[firstWord[i]] != secondWord[i])
                    { // ako sa razlichni 
                        Console.WriteLine("false");
                        return;
                    }
                }

            }




            if (firstWord.Length == secondWord.Length)
            {
                Console.WriteLine("true");
                return;
            }



            string substring = string.Empty;

            if (firstWord.Length > secondWord.Length)
            {
                substring = firstWord.Substring(minLen);  // vadim po malkata duma ot po golqmata i slagame ostatuka v substring
            }
            else
            {
                substring = secondWord.Substring(minLen);  // vadim po malkata duma ot po golqmata i slagame ostatuka v substring
            }

            //if (substring.All(ch => !map.Values.Contains(ch) && !map.Keys.Contains(ch)))
            //{   // dava true ako ostatuka se sudurja nqkade v mapa, v kluchovete ili v stoinostite

            //    Console.WriteLine("true");
            //    return;                    // SLAGAME RETURN ZA DA NE SLAGAME ELSE NAKRAQ
            //}
            //// NE SLAGAME ELSE ZASHTOTO IMA return;


            foreach (char c in substring) // obhojdame vsichki elementi
            {
                if (!map.Keys.Contains(c) && !map.Values.Contains(c))
                {       // ako kluchovete i stoinostite na mapa ne sudurjat elementa na substringa
                    Console.WriteLine("false");
                    return;
                }
            }

            Console.WriteLine("true");

        }
    }
}
