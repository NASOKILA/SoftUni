using System;
using System.Linq;

namespace _02.RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();

            Random rnd = new Random();

            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(words.Length);

                // sega samo thrqbva da slapnem elementite
                if (pos1 != pos2)
                {
                    var old = words[pos1];
                    words[pos1] = words[pos2];
                    words[pos2] = old;
                }

            }

            Console.WriteLine(string.Join("\r\n", words));

        }
    }
}
