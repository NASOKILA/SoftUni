using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] words = input.Split(' ').ToArray();

            Random rnd = new Random();
           
           
            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var randomIndex = rnd.Next(0, words.Length);

                // we have to switch the variables
                var tempWord = words[randomIndex];
                // shte izpolzvame treta promenliva za im smenim mestata
                words[i] = tempWord;
                words[randomIndex] = currentWord;

            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
            // AKO IMAME POVECHE CHISLA NQMA DA STANE TAKA
            // MOJEM DA POLZVAME Shuffle algoritum C#

        }
    }
}


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] words = input.Split(' ').ToArray();

            Random rnd = new Random();
           // string[] result = new string[words.Length];
            List<int> checker = new List<int>();
            for (int i = 0; i < words.Length; i++)
            {

                var num = rnd.Next(0, words.Length);
                if (!checker.Contains(num)) // ako ne sudurja nomera go dobavi
                {
                    checker.Add(num);
                    Console.WriteLine(words[num]);
                }
                else
                {
                    i--;
                    num = -1;
                }
                // AKO IMAME POVECHE CHISLA NQMA DA STANE TAKA
                // MOJEM DA POLZVAME Shuffle algoritum C#
             }
            

        }
    }
}
*/
