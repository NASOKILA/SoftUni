using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounsSubstringOccurencies
{
    class CounsSubstringOccurencies
    {
        static void Main(string[] args)
        {
            // kolko puti edin string se sudurja vuv drug 
            // OVERLAPPING IS ALLOWED sledovatelno pri aaaaaa  aa se  sudurja 5 puti

            string text = Console.ReadLine().ToLower();
            string searchString = Console.ReadLine().ToLower();

            int counter = 0;

            int index = text.IndexOf(searchString); // namirame purvoto mqsto kudeto turseniq string e v texta

            while (index != -1) // ako ne e -1 znachi e namerilo string apone vednij
            {
                counter++; 
                index = text.IndexOf(searchString, index + 1); // TUK TURSIM SUSHTOTO NESHTO SAMOCHE OT SLEDVASHTATA POZICIQTA
                //index = text.IndexOf(tova koetp tursim, ot koq poziciq go tursi);
            }

            Console.WriteLine(counter);
        }
    }
}