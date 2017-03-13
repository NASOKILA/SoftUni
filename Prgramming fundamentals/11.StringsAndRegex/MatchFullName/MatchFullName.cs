using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            //TAZI ZADACHA SE RESHAVA S REGEX MOJEM DA POLZVAME  https://regex101.com/
            //ILI http://www.regexr.com/

            /*
             RESHENIETO E:  /\b[A-Z][a-z]+ [A-Z][a-z]+\b/g

            purvo hvashame glavnata bukva s [A-Z]
            posle hvashtame malkite bukvi pone edna no ne znaem kolko zatova slagame + nakraq  [a-z]+
            davame space za prazno mqsto 
            i pak tursim sushtoto Golqmi bukvi i malki bez da znaem kolko [A-Z][a-z]+
             
            VSICHKOTO GO OGRAJDAME V \b...\b KOETO SE KAZVA WORD BOUNDRY KOETO KAZVA CHE TOVA E CQLA DUMA
            \b matchva .,nomera !? i drugi sinvoli koito ako se sudurjat v dumata znachi nqma kak da e ime !!! VAJNO 


             */

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";  // SLAGAME KLIOMBA OT PRED ZA DA STANE 
            Regex regex = new Regex(pattern); // suzdavame regex sus stringa pattern

            string text = "ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan Ivanov";

            bool isTextMatch = regex.IsMatch(text);   // taka razbirame dali se sudurja

            Console.WriteLine(isTextMatch); // dava true

        }
    }
}
