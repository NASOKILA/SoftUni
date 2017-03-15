using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {

            /*
             (?:^|\s) - TOVA E NON-CAPTURING GRUPA KOQTO : ili hvashta nachaloto na string ili prazno mqsto
             ([a-zA-Z0-9] - hvashta mnojestvo sinvoli ot a do z malko, ot A do Z golqmo ili ot 0 do 9 
            otvarqme grupa sus ( 

            OT USLOVIETO ZNAEM CHE MOJE MDA IMAME '.'  '-'  '_'  PO SREDATA NA IMEILA
            
            [\.\-\_a-zA-Z0-9]*
            S TOVA [\.\-\_ NIE ESKEIPVAME TEZI TRI SINVOLA SLEDOVATELNO MOJE DA SE SUDURJAT V DUMATA 
            S * KAZVAME nula ili poveche puti 
            @ - da ima kliomba 
            [a-zA-Z\-]+ - eskeipvame tireto ot a do z malko i ot A do Z golqmo samo vednuj da go ima edin ili poveche puti
            (\.[a-z]+)+ - Nove grupa koqto zapochva s tochkata, bukvi ot a do z malko, da se povatea edin ili poveche puti
            i da se povtarq ftupata edin ili poveche puti
            
            \b) - zatvarqme purvata grupa

             */





            string text = Console.ReadLine();
            string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*@[a-zA-Z\-]+(\.[a-z]+)+\b)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }


        }
    }
}
