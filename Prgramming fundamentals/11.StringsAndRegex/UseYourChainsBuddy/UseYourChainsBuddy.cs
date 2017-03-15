using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        static void Main(string[] args)
        {

            /*
 LOOK AROUNDS:
 positive look ahead, negative look ahead
 positive look behind, negative look behind

MEJDU TQH SE SLAGAT REGEXI
MESTAT KURSERA KUDETO NA NAS NI TRQBVA, POMAGAT MNOGO

(?=...) - positive look ahead
(?<=...) - positive look behind

primer:

tursim text mejdu taga <p>...</p>
 (?=<p>)...PISHEM SI REGEKSA...(?<=</p>)


            negative look ahead i negative look behind gledat da go nqma edin element za da matchne 
            za razlika ot positive koito gleda da go ima 
 */


            string input = Console.ReadLine();
            string pattern = @"<p>(.+?)</p>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string str = match.Groups[1].ToString().Trim(); // vzimame grupa 0
                str = Regex.Replace(str, "\\s+", " "); // replaisvame mnogoto whitespasove i novi redove sus edin whitespace 
                str = Regex.Replace(str, "\\W+", " "); // replasvame vsichko koeto ne e duma sus prazno mqsto
                str = str.Trim();

                //SEGA TRQBVA DA PROMENIM ZNACHITE

              string result = string.Empty;
                foreach (Char element in str)
                {
                    if (element >= 'a' && element <= 'm')
                    {
                        int index = Convert.ToInt32(element) + 13;
                        char newElement = (char)index;
                        result += newElement;
                    }
                    else if (element >= 'n' && element <= 'z')
                    {
                        int index = Convert.ToInt32(element) - 13;
                        char newElement = (char)index;
                        result += newElement;
                    }
                    else
                        result += element;
                }

                Console.Write(result + " ");

            }


        }
    }
}
