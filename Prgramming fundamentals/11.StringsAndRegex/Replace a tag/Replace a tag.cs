using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Replace_a_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Purvo trqbva da hvanem linka, 
             da go zamenim s dadenoto v zadachata*/


            string pattern = @"<a.*?href.*?=.*?(""\S*"")>(.*?)<\/a>";
            // ESKEIPVAME SREDNITE KAVICHKI SUS SHIFT + KAVICHKA
       
            //trqbva da napravim replaca
            string replaced = @"[URL href=$1]$2[/URL]";    // $1 i $2 sa grupite 1 i 2 v regexa          

            string text = "<ul> <li> <a href=\"http://softuni.bg\">SoftUni</a></ li ></ ul > ";
            // ekeipvame kavichkite sus  \ predi tqh

            text = Regex.Replace(text, pattern, replaced);
            // vuv texta zamestvame patterna sus replaced IZPOLZVAME GRUPITE !!!

            Console.WriteLine(text);
        }
    }
}
