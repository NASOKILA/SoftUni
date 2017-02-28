using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplityWordCasing
{
    class SplityWordCasing
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            List<string> words = text.Split(new char[] { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '\\', '[', ']' }, 
                StringSplitOptions.RemoveEmptyEntries).ToList();
            // taka kazvame che moje da s splitva sus vsichki tezi separatori, a ne samo sus  ' '
            

            List<string> lowerCase  = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> upperCase = new List<string>();
           


            for (int i = 0; i < words.Count; i++) 
            {

               
                char[] letter = words[i].ToCharArray(); // suzdavam char masiv koito obhojda vsichki bukvi !

                if (letter.All(char.IsUpper))
                {                  
                    upperCase.Add(words[i]);
                }
                else if (letter.All(char.IsLower))
                {                   
                    lowerCase.Add(words[i]);
                }
                else
                {
                    mixedCase.Add(words[i]);
                }
           
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", upperCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", mixedCase));


        }
    }
}
